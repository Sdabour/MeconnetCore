using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.GL.GLDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class InstallmentCheckDb
    {
        #region Private Data
        protected int _InstallmentID;
        protected int _CheckID;
        protected int _Status;
        #region Private data for search
        string _InstallmentIDs;
        string _ReservationIDs;
        #endregion
        #endregion

        #region Constractors
        public InstallmentCheckDb()
        { 
            
        }
        public InstallmentCheckDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _InstallmentID = int.Parse(objDR["InstallmentID"].ToString());
            _Status = int.Parse(objDR["Status"].ToString());
        }
        public InstallmentCheckDb(DataRow objDR) 
        {
            _InstallmentID = int.Parse(objDR["InstallmentID"].ToString());
            _Status = int.Parse(objDR["Status"].ToString());
        }
        #endregion

        #region Public Accessorice
        public int InstallmentID
        {
            set
            {
                _InstallmentID = value;
            }
            get
            {
                return _InstallmentID;
            }
        }
        public int CheckID
        {
            set
            {
                _CheckID = value;
            }
            get
            {
                return _CheckID;
            }

        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        public string InstallmentIDs
        {
            set
            {
                _InstallmentIDs = value;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CRMReservationInstallmentCheck.InstallmentID, "+
                    "CRMReservationInstallmentCheck.CheckID , CRMReservationInstallmentCheck.Status,CheckTable.*" +
                                  " FROM         CRMReservationInstallmentCheck LEFT OUTER JOIN"+
                                  " (" +new CheckDb().SearchStr + ") as CheckTable ON CRMReservationInstallmentCheck.CheckID= CheckTable.CheckID ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        
        #endregion

        #region Public Methods
        public  void Add()
        {
          
            string strSql = " INSERT INTO CRMReservationInstallmentCheck"+
                            " (InstallmentID, CheckID, Status)"+
                            " VALUES     ("+_InstallmentID+","+_CheckID+","+_Status+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
          
            string strSql = " UPDATE    CRMReservationInstallmentCheck" +
                            " SET  InstallmentID =" + _InstallmentID + "" +
                            " , CheckID =" + _CheckID + "" +
                            " , Status = " + _Status + "" +
            " Where CheckID = " + _CheckID + " and InstallmentID = " + _InstallmentID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where 1 = 1";
            if (_CheckID != 0)
                strSql += " and CheckID = " + _CheckID + " ";
            if (_InstallmentID != 0)
                strSql += " and InstallmentID = " + _InstallmentID + " ";
            if(_InstallmentIDs != null && _InstallmentIDs != "")
                strSql += " and InstallmentID in(" + _InstallmentIDs + ") ";
            if (_ReservationIDs != null && _ReservationIDs != "")
                strSql += " and InstallmentID in(select InstallmentID from "+
                    " CRMReservationInstallment where ReservationID in (" + _ReservationIDs + ")) ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion

    }
}
