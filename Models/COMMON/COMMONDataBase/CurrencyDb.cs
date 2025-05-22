using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.COMMON.COMMONDataBase
{
    public class CurrencyDb : BaseSingleDb
    {
        #region Private Data
        protected double _Value;
        protected string _Code;
        string _ShortName;

        protected bool _IsStandarad;
        DataTable _CurrencyTable;
        static DataTable _CacheCurrencyTable;
        #region Private Data For Search
        protected string _LikeNameA;
        #endregion
        #endregion
        #region Constructors
        public CurrencyDb()
        {
            
        }

        public CurrencyDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                //_NameA = objDR["CurrencyNameA"].ToString();
                //_NameE = objDR["CurrencyNameE"].ToString();
                //_Code = objDR["CurrencyCode"].ToString();
                //_IsStandarad = bool.Parse(objDR["CurrencyIsStandarad"].ToString());
                //_Value = double.Parse(objDR["CurrencyValue"].ToString());
                SetData(objDR);
            }
            
        }
        public CurrencyDb(DataRow objDR)
        {
            SetData(objDR);
          
        }
        public CurrencyDb(int intID, string strNameA)
        {
            _ID = intID;
            _NameA = strNameA;
            
        }
        public CurrencyDb(string strCode)
        {
            _Code = strCode;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
                SetData(dtTemp.Rows[0]);
        }


        #endregion
        #region Public Properties

        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }

        public string ShortName
        {
            set 
            {
                _ShortName = value;
            }
            get 
            {
                return _ShortName;
            }
            
        }
        public bool IsStandarad
        {
            set
            {
                _IsStandarad = value;
            }
            get
            {
                return _IsStandarad;
            }
        }
        #region Properites For Search
        public  string LikeNameA
        {
            set
            {
                _LikeNameA = value;
            }
        }
        #endregion
      
        public static DataTable CacheCurrencyTable
        {
            set 
            {
                _CacheCurrencyTable = value;
            }

            get
            {
                if (_CacheCurrencyTable == null)
                {
                    _CacheCurrencyTable = SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr);

                }
                return _CacheCurrencyTable;
            }
        }
        public DataTable CurrencyTable
        {
            set
            {
                _CurrencyTable = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT CurrencyID, CurrencyNameA, CurrencyNameE, " +
                                            "  CurrencyCode,CurrencyShortName, CurrencyValue,CurrencyIsStandarad " +
                                            " FROM   dbo.COMMONCurrency  WHERE     (Dis IS NULL) ";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                int intIsStanderd = _IsStandarad == true ? 1 : 0;
                string Returned = " insert into COMMONCurrency (CurrencyNameA, CurrencyNameE,CurrencyValue, CurrencyCode,CurrencyShortName, CurrencyIsStandarad,  UsrIns, TimIns) values(";
                Returned = Returned + "'" + _NameA + "','" + _NameE + "'," + _Value + ",'" + _Code + "','"+ _ShortName + "'," +
                    intIsStanderd + "," + SysData.CurrentUser.ID + ",Getdate())";
                return Returned;
            }
        }
       
        public string EditStr
        {
            get
            {
                int intIsStanderd = _IsStandarad == true ? 1 : 0;
                string Returned = "update  COMMONCurrency ";
                Returned = Returned + " set CurrencyNameA ='" + _NameA + "'";
                Returned = Returned + " ,CurrencyNameE ='" + _NameE + "'";
                Returned = Returned + ",CurrencyValue =" + _Value + "";
                Returned = Returned + ",CurrencyCode ='" + _Code + "'";
                Returned += ",CurrencyShortName='" + _ShortName + "'";
                Returned = Returned + ",CurrencyIsStandarad=" + intIsStanderd;
                Returned = Returned + ",TimUpd = GetDate()";
                Returned = Returned + ",UsrUpd =" + SysData.CurrentUser.ID;
                Returned = Returned + " where CurrencyID = " + _ID;
                return Returned;
            }
        }
        public string EditRateStr
        {
            get
            {
                int intIsStanderd = _IsStandarad == true ? 1 : 0;
                string Returned = "update  COMMONCurrency "+
                 " set  CurrencyIsStandarad=" + intIsStanderd +
                 ",CurrencyValue =" + _Value + ""+
                ",TimUpd = GetDate()"+
                ",UsrUpd =" + SysData.CurrentUser.ID +
                " where CurrencyID = " + _ID;
                if (_IsStandarad)
                    Returned += " update  COMMONCurrency " +
                 " set  CurrencyIsStandarad= 0 where CurrencyID<>"+ _ID ;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update  COMMONCurrency  set Dis= GetDate() where CurrencyID=" + _ID;
                return Returned;
            }
        }
        #endregion
        #region Private Methodsda
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["CurrencyID"]== null || objDR["CurrencyID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["CurrencyID"].ToString());
            _NameA = objDR["CurrencyNameA"].ToString();
            _NameE = objDR["CurrencyNameE"].ToString();
            _Code = objDR["CurrencyCode"].ToString();
            _ShortName = objDR["CurrencyShortName"].ToString();
            _IsStandarad = bool.Parse(objDR["CurrencyIsStandarad"].ToString());
            _Value = double.Parse(objDR["CurrencyValue"].ToString());
        }

        #endregion
        #region Public Methods
        public override void Add()
        {
            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);

        }
        public override void Edit()
        {

            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
            
        }



        public override void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public void EditRates()
        {
            if (_CurrencyTable == null || _CurrencyTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_CurrencyTable.Rows.Count];
            int intIndex = 0;
            CurrencyDb objDb;
            foreach (DataRow objDr in _CurrencyTable.Rows)
            {
                objDb = new CurrencyDb(objDr);
                arrStr[intIndex] = objDb.EditRateStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public override DataTable Search()
        {
            string strSql =  SearchStr;
            if (_ID != 0)
                strSql = strSql + " and CurrencyID = " + _ID.ToString();
           if (_Code != null && _Code != "")
            strSql = strSql + "  and CurrencyCode = '" + _Code + "' " ;
        if (_LikeNameA != null && _LikeNameA != "")
            strSql = strSql + " and CurrencyNameA Like '%" + _LikeNameA + "%'";
        return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Currency");

        }
       
       
       #endregion
    }
}
