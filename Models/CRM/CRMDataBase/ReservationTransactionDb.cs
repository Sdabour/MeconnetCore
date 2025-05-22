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
    public class ReservationTransactionDb
    {
        #region Private Data
     
        int _ReservationID;
        int _TransactionType;
        int _TransactionID;
        string _UnitStr;
        string _TowerStr;
        string _ProjectStr;
        int _ReservationStatus;
        double _ReservationValue;

       
        DateTime _Date;
        #endregion
        #region Constructors
        public ReservationTransactionDb()
        { 

        }
        public ReservationTransactionDb(int intID)
        {
           
            
        }
        public ReservationTransactionDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
      
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
        public int TransactionType
        {
            set
            {
                _TransactionType = value;
            }
            get
            {
                return _TransactionType;
            }
        }
        public int TransactionID
        {
            set
            {
                _TransactionID = value;
            }
            get
            {
                return _TransactionID;
            }
        }
        public string UnitStr
        {
            set
            {
                _UnitStr = value;
            }
            get
            {
                return _UnitStr;
            }
        }
        public string TowerStr
        {
            set
            {
                _TowerStr = value;
            }
            get
            {

                return _TowerStr;
            }
        }
        public string ProjectStr
        {
            set
            {
                _ProjectStr = value;
            }
            get
            {
                return _ProjectStr;
            }
        }
        public int ReservationStatus
        {
            set
            {
                _ReservationStatus = value;
            }
            get
            {
                return _ReservationStatus;
            }
        }
        public double ReservationValue
        {
            set
            {
                _ReservationValue = value;
            }
            get
            {
                return _ReservationValue;
            }
        }
        public string AddStr
        {
            get
            {
                string strTRansactionID = _TransactionID == 0 ? "@TransactionID" : _TransactionID.ToString();
                string Returned = "insert into CRMReservationTransaction (ReservationID, TransactionID, UnitStr"+
                    ", TowerStr, ProjectStr, ReservationStatus, TotalValue) "+
                    " values ("+ _ReservationID + "," +strTRansactionID + ",'" + _UnitStr + "','" + _TowerStr + 
                    "','" + _ProjectStr + "'," + _ReservationStatus + "," + _ReservationValue +")";
                return Returned;
            }

        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     ReservationID, TransactionID, UnitStr, TowerStr, ProjectStr, ReservationStatus, TotalValue "+
                       " FROM   dbo.CRMReservationTransaction ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            //_TransactionType = int.Parse(objDR[""].ToString());
            _TransactionID = int.Parse(objDR["TransactionID"].ToString());
            _UnitStr = objDR["UnitStr"].ToString();
            _TowerStr = objDR["TowerStr"].ToString();
            _ProjectStr = objDR["ProjectStr"].ToString();
            _ReservationStatus = int.Parse(objDR["ReservationStatus"].ToString());
            _ReservationValue = double.Parse(objDR["TotalValue"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            //double Date = _Date.ToOADate() - 2;
            //string strSql = " INSERT INTO CRMReservationTransaction"+
            //                " (TransactionID, ReservationID, TransactionType, ReservationOldStatus, ReservationNewStatus, TransactionDate)"+
            //                " VALUES     (" + _ID + "," + _ReservationID + "," + _TransactionType + "," + _ReservationOldStatus + "," + _ReservationNewStatus + "," + Date + ") ";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Edit()
        {
            //double Date = _Date.ToOADate() - 2;
            //string strSql = "  UPDATE    CRMReservationTransaction"+
            //                " SET   ReservationID ="+_ReservationID+""+
            //                " , TransactionType ="+_TransactionType+""+
            //                " , ReservationOldStatus ="+_ReservationOldStatus+""+
            //                " , ReservationNewStatus ="+_ReservationNewStatus+""+
            //                " , TransactionDate ="+Date+""+
            //                "   WHERE     (TransactionID = "+_ID+") ";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            //string strSql = " DELETE FROM CRMReservationTransaction WHERE     (TransactionID = "+_ID+") ";
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1 = 1)";
           
            if(_ReservationID != 0)
                strSql = strSql + " And ReservationID = " + _ReservationID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion
    }
}
