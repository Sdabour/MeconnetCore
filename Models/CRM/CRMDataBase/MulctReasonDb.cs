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
    public class MulctReasonDb
    {
        #region Private Data
        protected int _ID;
        protected string _Desc;
        #endregion

        #region Constructors
        public MulctReasonDb()
        { 

        }
        public MulctReasonDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _Desc = objDR["ReasonDesc"].ToString();
        }
        public MulctReasonDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["ReasonID"].ToString());
            _Desc = objDR["ReasonDesc"].ToString();
        }
        #endregion

        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }

        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }

        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     ReasonID, ReasonDesc FROM   CRMMulctReason";
                return Returned;
            }
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
            string strSql = " INSERT INTO CRMMulctReason (ReasonDesc) VALUES     ('"+_Desc+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = " UPDATE    CRMMulctReason SET  ReasonDesc = " + _Desc + " " +
                            " WHERE     (ReasonID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " UPDATE    CRMMulctReason SET   Dis = GetDate() " +
                           " WHERE     (ReasonID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE     (Dis IS NULL) ";
            if (_ID != 0)
                strSql += " And  MulctReasonID  = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
