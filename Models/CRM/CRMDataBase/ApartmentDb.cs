using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.RP.RPDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ApartmentDb : CellDb
    {
        //CellType = 9
        #region Private Data
        protected int _ModelID;
        protected int _CellID;
        protected double _Survey;
        protected int _Customer;
        protected CustomerDb _CustomerDb;
        protected ApartmentModelDb _ModelDb;
        #region PrivateData For Search
        protected double _FromSurvey;
        protected double _ToSurvey;
        protected string _CellName;
        protected string _CellIDs;
        protected bool _IsReserved;
        
        #endregion
        #endregion
      
        #region Constructors
        public ApartmentDb()
            : base()
        {
            _TypeID = 9;
            _ModelDb = new ApartmentModelDb();
            _CustomerDb = new CustomerDb();
        }
        public ApartmentDb(DataRow objDr)
            : base(objDr)
        {
            // CellSurvey, CellModel, CurrentCustomer,
            _TypeID = 9;
            if (objDr["CellSurvey"] == DBNull.Value)
            {
                _CustomerDb = new CustomerDb();
                _ModelDb = new ApartmentModelDb();
                return;
            }
            _Survey = double.Parse(objDr["CellSurvey"].ToString());
            _ModelID = int.Parse(objDr["CellModel"].ToString());
            _Customer = int.Parse(objDr["CurrentCustomer"].ToString());
            if (_ModelID != 0)
                _ModelDb = new ApartmentModelDb(objDr);
            else
                _ModelDb = new ApartmentModelDb();
             if (_Customer != 0)
                 _CustomerDb = new CustomerDb(objDr);
             else
                 _CustomerDb = new CustomerDb();



        }
        #endregion
        #region Public Properties
        public int ModelID
        {
            set
            {
                _ModelID = value;
            }
            get
            {
                return _ModelID;
            }
        }
        public int Customer
        {
            set
            {
                _Customer = value;
            }
            get
            {
                return _Customer;
            }
        }
        public double Survey
        {
            set
            {
                _Survey = value;
            }
            get
            {
                return _Survey;
            }
        }
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
            }
        }
        public string CellName
        {
            set
            {
                _CellName = value;
            }
        }
        public double FromSurvey
        {
            set
            {
                _FromSurvey = value;
            }
        }
        public double ToSurvey
        {
            set
            {
                _ToSurvey = value;
            }
           
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public bool IsReserved
        {
            set
            {
                _IsReserved = value;
            }
        }
        public CustomerDb CustomerDb
        {
            get
            {
                return _CustomerDb;
            }
        }
        public ApartmentModelDb ModelDb
        {
            get
            {
                return _ModelDb;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT  CellSurvey, CellModel, CurrentCustomer,CellTable.*,ModelTable.*,CustomerTable.* " +
                                  " FROM  CRMApartment Full outer join (" + CellDb.SearchStr + ") as celltable on CRMApartment.CellID = CellTable.CellID " +
                                  " left outer join (" + ApartmentModelDb.SearchStr + ") as ModelTable on CellModel = ModelTable.ModelID " +
                                  " left outer join ("; //+ CustomerDb.SearchStr + ") as CustomerTable on CurrentCustomer=CustomerTable.CustomerID  ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public override void Add()
        {
            base._TypeID = 9;
            base.Add();
            string strSql = " INSERT INTO CRMApartment (CellID, CellSurvey, CellModel, CurrentCustomer)"+
                            " VALUES     ("+_ID+","+_Survey+","+_ModelID+","+_Customer+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            base.Edit();
            string [] arrStr = new string[2] ;
            arrStr[0] = " INSERT INTO CRMApartment (CellID, CellSurvey, CellModel, CurrentCustomer) " +
                            " select " + _ID + " as CellID," + _Survey + " as Survey," + _ModelID + " as ModelID," + _Customer + " as Customer "+
            " where not exists (select CellID from CRMApartment where CellID="+ _ID + ")";
                            
            arrStr[1] = " UPDATE    CRMApartment " +
                            " SET  CellSurvey ="+_Survey+"" +
                            ", CellModel ="+_ModelID+"" +
                            ", CurrentCustomer ="+_Customer+" " +
                            " Where CellID = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void EditCurrentCustomer()
        {
            string strSql = " UPDATE    CRMApartment " +
                           " SET   CurrentCustomer =" + _Customer + " " +
                           " Where CellID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
 
        }
        public override void Delete()
        {
            base.Delete();
            string strSql = " DELETE FROM CRMApartment Where CellID = " + _ID + "";
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (CellTable.CellType = 9) ";
            if (_CellIDs != null && _CellIDs != "")
                strSql = strSql + " And CRMApartment.CellID In (" + _CellIDs + ")";
            if (_ID != 0)
                strSql = strSql + " And CRMApartment.CellID = " + _ID + "";
            if (_FromSurvey != 0)
                strSql = strSql + " And   (CellSurvey BETWEEN " + _FromSurvey + " AND " + _ToSurvey + ")";
            if (_CellName != null && _CellName != "")
                strSql = strSql + " And CellNameA like '%" + _CellName + "%' ";
            if (_ModelID != 0)
                strSql = strSql + " And CRMApartment.CellModel = "+_ModelID+"";
            if (_Customer != 0)
                strSql = strSql + " And CRMApartment.CurrentCustomer = " + _Customer + "";
            else
            {
                if(_IsReserved )
                    strSql = strSql + " And CRMApartment.CurrentCustomer <>0 ";
                else
                    strSql = strSql + " And (CRMApartment.CurrentCustomer = 0 or CRMApartment.CurrentCustomer is null   )";
 
            }
            if (_ParentID != 0)
                strSql = strSql + " and CellParentID=" + _ParentID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}