using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class DetailStatementDb
    {
        #region Private Data

        protected int _DetailStatementID;
        protected int _DetailStatementBonuisType;
        protected int _DetailStatementEstimationStatement;
        protected DateTime _DetailStatementDate;
        protected string _DetailStatementDesc;
        protected bool _StatusDelete;

        
        
        
        #endregion
        #region Constructors
        public DetailStatementDb()
        {
        }
        public DetailStatementDb(int intDetailStatementID)
        {
            _DetailStatementID = intDetailStatementID;
           
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public DetailStatementDb(DataRow objDR)
        {
            SetData(objDR);           
        }
        public DetailStatementDb(DataRow objDR,bool blBelongStatus)
        {
            _DetailStatementID = int.Parse(objDR["DetailStatementID"].ToString());
            if (objDR["DetailStatementBonuisType"].ToString() != "")
                _DetailStatementBonuisType = int.Parse(objDR["DetailStatementBonuisType"].ToString());
            else
                _DetailStatementBonuisType = 0;
            _DetailStatementEstimationStatement = int.Parse(objDR["DetailStatementEstimationStatement"].ToString());
            _DetailStatementDate = DateTime.Parse(objDR["DetailStatementDate"].ToString());
            _DetailStatementDesc = objDR["DetailStatementDesc"].ToString();
            _StatusDelete = bool.Parse(objDR["StatusDelete"].ToString());
        }
        #endregion
        #region Public Properties
        public int DetailStatementID
        {
            set { _DetailStatementID = value; }
            get { return _DetailStatementID; }          
        }

        public int DetailStatementBonuisType
        {
            set { _DetailStatementBonuisType = value; }
            get { return _DetailStatementBonuisType; }            
        }

        public int DetailStatementEstimationStatement
        {
            set { _DetailStatementEstimationStatement = value; }
            get { return _DetailStatementEstimationStatement; }           
        }

        public DateTime DetailStatementDate
        {
            set { _DetailStatementDate = value; }
            get { return _DetailStatementDate; }            
        }

        public string DetailStatementDesc
        {
            set { _DetailStatementDesc = value; }
            get { return _DetailStatementDesc; }           
        }

        public bool StatusDelete
        {
            set { _StatusDelete = value; }
            get { return _StatusDelete; }
        }
        
        public static string SearchStr
        {
            get
            {
                string ReturnStr = " SELECT     HRDetailStatement.DetailStatementID, HRDetailStatement.DetailStatementBonuisType, HRDetailStatement.DetailStatementDate, HRDetailStatement.DetailStatementDesc, HRDetailStatement.DetailStatementEstimationStatement,DetailTypeTable.* " +
                                   " FROM HRDetailStatement Left Outer join ( " + DetailTypeDb.SearchStr + " ) DetailTypeTable On HRDetailStatement.DetailStatementBonuisType = DetailTypeTable.DetailTypeID";
                return ReturnStr;
            }
        }
        public  string AddStr
        {
            get
            {
                double dblDetailStatementDate = _DetailStatementDate.ToOADate() - 2;
                string ReturnStr = " INSERT INTO HRDetailStatement " +
                                " (DetailStatementBonuisType, DetailStatementDate, DetailStatementDesc, DetailStatementEstimationStatement, UsrIns, TimIns)" +
                                " VALUES  " +
                                " (" + _DetailStatementBonuisType + "," + dblDetailStatementDate + ",'" + _DetailStatementDesc + "'," + _DetailStatementEstimationStatement + "," + SysData.CurrentUser.ID + ",GetDate())";

                return ReturnStr;
            }
        }
        public  string EditStr
        {
            get
            {
                double dblDetailStatementDate = DetailStatementDate.ToOADate() - 2;
                string ReturnStr = " UPDATE    HRDetailStatement " +
                                " SET DetailStatementBonuisType = " + _DetailStatementBonuisType + "" +
                                " , DetailStatementDate = " + dblDetailStatementDate + "" +
                                " , DetailStatementDesc = '" + _DetailStatementDesc + "'" +
                                " , DetailStatementEstimationStatement = " + _DetailStatementEstimationStatement + "" +
                                " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                                " , TimUpd = GetDate()" +
                                " WHERE (DetailStatementID = " + _DetailStatementID + ")";
                return ReturnStr;
            }
        }
        public  string DeleteStr
        {
            get
            {
                string ReturnStr = " DELETE FROM HRDetailStatement";
                ReturnStr = ReturnStr + " Where   (DetailStatementID = " + _DetailStatementID + ")";
                return ReturnStr;
            }
        }        
#endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _DetailStatementID = int.Parse(objDR["DetailStatementID"].ToString());
            if (objDR["DetailStatementBonuisType"].ToString() != "")
                _DetailStatementBonuisType = int.Parse(objDR["DetailStatementBonuisType"].ToString());
            else
                _DetailStatementBonuisType = 0;
            _DetailStatementEstimationStatement = int.Parse(objDR["DetailStatementEstimationStatement"].ToString());
            _DetailStatementDate = DateTime.Parse(objDR["DetailStatementDate"].ToString());
            _DetailStatementDesc = objDR["DetailStatementDesc"].ToString();
            _StatusDelete = false;
            
        }
        #endregion
        #region Public Methods
        public void Add()
        {

            _DetailStatementID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {


            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_DetailStatementID != 0)
                strSql = strSql + " And   (DetailStatementID = " + _DetailStatementID + ")";
            if (_DetailStatementEstimationStatement != 0)
                strSql = strSql + " And   (DetailStatementEstimationStatement = " + _DetailStatementEstimationStatement + ")";  
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
