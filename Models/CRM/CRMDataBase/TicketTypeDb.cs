using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class TicketTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public TicketTypeDb()
        {

        }
        public TicketTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public TicketTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT      TicketTypeID,TicketTypeCode , TicketTypeNameA, TicketTypeNameE " +
                                  " FROM         CRMTicketType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["TicketTypeID"].ToString() != "")
                _ID = int.Parse(objDR["TicketTypeID"].ToString());
            _Code = objDR["TicketTypeCOde"].ToString();
            _NameA = objDR["TicketTypeNameA"].ToString();
            _NameE = objDR["TicketTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMTicketType" +
                            " (TicketTypeCode, TicketTypeNameA, TicketTypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID +
                            ",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMTicketType" +
                            " SET TicketTypeCode ='" + _Code + "'" +
                            ", TicketTypeNameA ='" + _NameA + "'" +
                            ", TicketTypeNameE = '" + _NameE + "'" +
                             ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " Where TicketTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMTicketType " +
                            " SET   Dis = GetData() " +
                            " Where TicketTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  TicketTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
