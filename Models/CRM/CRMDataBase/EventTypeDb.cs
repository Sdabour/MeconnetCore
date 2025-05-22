using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class EventTypeDB : BaseSingleDb
    {
        #region Private Data
        
        #endregion
        #region Constructors
        public EventTypeDB()
        { 

        }
        public EventTypeDB(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _ID = int.Parse(objDR["EventTypeID"].ToString());
            _NameA = objDR["EventTypeNameA"].ToString();
            _NameE = objDR["EventTypeNameE"].ToString();

        }

        public EventTypeDB(DataRow objDR)
        {
            _ID = int.Parse(objDR["EventTypeID"].ToString());
            _NameA = objDR["EventTypeNameA"].ToString();
            _NameE = objDR["EventTypeNameE"].ToString();
        }

        #endregion
        #region Public Properties
        public static string SearchStr
        {
            get
            {
                return "SELECT EventTypeID,EventTypeNameA, EventTypeNameE FROM   CRMEventType ";
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMEventType" +
                      " (EventTypeNameA, EventTypeNameE, UsrIns, TimIns)" +
                      " VALUES     (" + _NameA + "," + _NameE + "," + SysData.CurrentUser.ID + ",GetDate())";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMEventType"+
                            " SET   EventTypeNameA ="+_NameA+""+
                            ", EventTypeNameE ="+_NameE+""+
                            ", UsrUpd ="+SysData.CurrentUser.ID+""+
                            ", TimUpd = Getdate()"+
                            " where EventTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMEventType SET  Dis = Getdate() where EventTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where  (Dis is null)";
            if (_ID != null)
                strSql = " And  EventTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
