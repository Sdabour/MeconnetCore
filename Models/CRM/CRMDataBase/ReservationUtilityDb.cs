using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationUtilityDb
    {
        #region Private Data
        protected int _ID;
        protected int _ReservationID;
        protected int _UtilityTypeID;
        protected double _Value;
        protected bool _Scheduled;
        protected int _UtilityStatus;
        static string _ReservationIDs;
        protected int _NewReservationID;
        #endregion
        #region Constructors
        public ReservationUtilityDb()
        { 

        }
        public ReservationUtilityDb(int intID)
        {
            _ReservationID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _ID = int.Parse(objDR["UtilityID"].ToString());
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _UtilityTypeID = int.Parse(objDR["UtilityTypeID"].ToString());
            _Value = double.Parse(objDR["UtilityValue"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());
            _NewReservationID = int.Parse(objDR["NewReservationID"].ToString());
        }
        public ReservationUtilityDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["UtilityID"].ToString());
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _UtilityTypeID = int.Parse(objDR["UtilityTypeID"].ToString());
            _Value = double.Parse(objDR["UtilityValue"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());

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
        public int ReservationID
        {
            set 
            {
                _ReservationID = value; 
            }
            get
            {
                return _ReservationID; 
            }
            
        }
        public int UtilityTypeID
        {
            set 
            {
                _UtilityTypeID = value; 
            }
            get
            {
                return _UtilityTypeID; 
            }
            
        }
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
        public bool Scheduled
        {
            set
            {
                _Scheduled = value;
            }
            get
            {
                return _Scheduled;
            }
        }
        public int UtilityStatus
        {
            set
            {
                _UtilityStatus = value;
            }
            get
            {
                return _UtilityStatus;
            }

        }
        public int NewReservationID
        {
            set
            {
                _NewReservationID = value;
            }
            get
            {
                return _NewReservationID;
            }

        }

        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public string AddStr
        {
            get
            {
                int intScheduled = _Scheduled ? 1 : 0;
                string Returned = " INSERT INTO CRMReservationUtility" +
                            " (ReservationID, UtilityTypeID, UtilityValue,Scheduled)" +
                            " VALUES     (" + _ReservationID + "," + _UtilityTypeID + "," +
                            _Value +  "," + intScheduled +") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {

                string Returned = " UPDATE    CRMReservationUtility" +
                           " SET  UtilityTypeID =" + _UtilityTypeID + "" +
                           ", UtilityValue = " + _Value + "" +
                           " where ReservationID = " + _ReservationID + " and UtilityID=" + _ID;
                return Returned;
            }
        }
        public string EditNewReservationStr
        {
            get
            {
                string Returned = " UPDATE    CRMReservationUtility" +
                                         " SET  ReservationID= " + _NewReservationID+
                                         "  where ReservationID = " + _ReservationID + " and UtilityID=" + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "delete from  CRMReservationUtility" +
                            " where ReservationID = " + _ReservationID + " and UtilityID=" + _ID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT UtilityID,ReservationID, UtilityValue,Scheduled,0 as NewReservationID,UtilityTable.* "+
                    " FROM   CRMReservationUtility inner join (" + UtilityTypeDb.SearchStr + ") as UtilityTable on UtilityTable.UtilityTypeID = CRMReservationUtility.UtilityTypeID ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
           
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);

        }
        public void Edit()
        {
            string strSql;
            if (_NewReservationID != 0)
                strSql = EditNewReservationStr;
            else
                strSql = EditStr;
         
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void EditNewReservation()
        {
            SysData.SharpVisionBaseDb.
                ExecuteNonQuery(EditNewReservationStr);
        }

        public void EditStatus()
        {
            string strSql = " UPDATE    CRMReservationUtility" +
                            " SET  UtilityStatus = " + _UtilityStatus + "" +
                            //" ,UsrUpd = " + SysData.CurrentUser.ID + " " +
                            //" ,TimUpd =Getdate() " +
                            " where ReservationID = " + _ReservationID + " and UtilityID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public void Schedul()
        {
            int intSchedul = _Scheduled ? 1 : 0;
            string strSql = " UPDATE    CRMReservationUtility"+
                            " SET   Scheduled ="+_Scheduled+""+
                            " WHERE     (ReservationID = "+_ReservationID+") AND (UtilityID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void Delete()
        { 

        }
        public DataTable Search()
        { 
             string strSql = SearchStr + " WHERE    (1 = 1)";
             if (_ReservationID != 0)
                 strSql = strSql + " And ReservationID = " + _ReservationID + "";
             if (_ReservationIDs != null && _ReservationIDs != "")
                 strSql = strSql + " And ReservationID in (" + _ReservationIDs + ") ";

             if (_ID != 0)
                 strSql = strSql + " And UtilityID = " + _ID + "";
             return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"Utility");

        }
        #endregion
    }
}
