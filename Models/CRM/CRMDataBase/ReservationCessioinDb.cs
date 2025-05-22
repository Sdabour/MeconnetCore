using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.HR.HRDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationCessioinDb
    {
        #region Private Data
        int _ID;
        int _NewReservationID;
        int _OldReservationID;
        string _UnitFullName;
        string _OldReservationCustomerName;
        //string _NewReservationUnitName;
        string _NewReservationCustomerName;
        double _CessionCost;
        double _OldReservationPreviousPaidValue;
        DateTime _CessionDate;
        int _CellFamilyID;
        string _CellIDs;
        string _UnitCode;
        bool _IsDateRange;
        DateTime _StartDate;
        DateTime _EndDate;
        int _NewReservationStatus;/*
                                   * 0 dont care
                                   * 1 only still Reserved
                                   * 2 only canceled
                                   */
        #endregion
        #region Constructors
        public ReservationCessioinDb()
        {
 
        }
        public ReservationCessioinDb(DataRow objDr)
        {
            SetData(objDr);

        }
        #endregion
        #region Public Properties
        public double OldReservationPreviousPaidValue
        {
            set
            {
                _OldReservationPreviousPaidValue = value;
            }
            get 
            {
                return _OldReservationPreviousPaidValue;
            }
        }
        public double CessionCost
        {
            set
            {
                _CessionCost = value;

            }
            get
            {
                return _CessionCost;
            }
        }
        public DateTime CessionDate
        {
            set
            {
                _CessionDate = value;
            }
            get
            {
                return _CessionDate;
            }
        }
        public int OldReservationID
        {
            set
            {
                _OldReservationID = value;
            }
            get
            {
                return _OldReservationID;
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
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public string UnitCode
        {
            set
            {
                _UnitCode = value;
            }
        }
        public bool IsDateRange
        {
            set 
            {
                _IsDateRange = value;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }
        public string UnitFullName
        {
            get
            {
                return _UnitFullName;
            }
        }
        public string OldReservationCustomerName 
        {
            get
            {
                return _OldReservationCustomerName;
            }
        }

        public string NewReservationCustomerName 
        {
            get
            {
                return _NewReservationCustomerName;
            }
        }

        public  string AddStr
        {
            get
            {
                double dblDate = _CessionDate.ToOADate() - 2;
                string Returned = "insert into CRMreservationCession (NewReservationID,OldReservationID" +
                    ", CessionCost,CessionPreviousPaidValue, CessionDate) values (" + _NewReservationID + "," + _OldReservationID + "," +
                    _CessionCost + "," + _OldReservationPreviousPaidValue +","+ dblDate + ")" ;
                return Returned;

            }
        }
        public static string SearchStr
        {
            get
            {
                #region Manipulate Cession Data
                string strCessionDate = "SELECT OldReservationID CessionedReservationID, NewReservationID NewReservation, CessionCost  OldCessionCost, " +
                    "CessionPreviousPaidValue, CessionDate " +
                      " FROM         CRMReservationCession ";
                ReservationDb objReservationDb = new ReservationDb();
                //objReservationDb.CustomerSearchStr;
                string strNewReservation = "SELECT  NewReservationID AS OldCessionNewReservationID, OldReservationID AS OldCessionMainReservationID" +
                    ", CessionDate AS OldCessionDate,OldCessionCustomerTable.CustomerFullName as NewCustomerFullName" +
                    ",OldCessionUnitTable.UnitFullName as NewUnitFullName " +
                      " FROM    (" + objReservationDb.CustomerSearchStr + ") as NewCustomerTable " +
                      " on  dbo.CRMReservationCession.NewReservationID = NewCustomerTable.ReservationID  " +
                      " inner join (" + objReservationDb.UnitSearchStr + ") as NewUnitTable " +
                      " on dbo.CRMReservationCession.NewReservationID = NewUnitTable.CurrentReservation ";

                string strOldReservation = "SELECT  NewReservationID AS NewCessionMainReservationID, OldReservationID AS NewCessionOldReservationID, CessionCost AS NewCessionCost, " +
                      " CessionPreviousPaidValue AS NewCessionPreviousPaidValue, CessionDate AS NewCessionDate " +
                      ",NewCessionCustomerTable.CustomerFullName as OldCustomerFullName,NewCessionUnitTable.UnitFullName as OldUnitFullName " +
                      " FROM  dbo.CRMReservationCession " +
                      " inner join (" + objReservationDb.CustomerSearchStr + ") as NewCessionCustomerTable " +
                      " on  dbo.CRMReservationCession.NewReservationID = NewCessionCustomerTable.ReservationID  " +
                      " inner join (" + objReservationDb.UnitSearchStr + ") NewCessionUnitTable " +
                      " on dbo.CRMReservationCession.NewReservationID = NewCessionUnitTable.CurrentReservation  ";
                #endregion
                //string Returned = "SELECT  NewReservationID, OldReservationID, CessionCost, CessionPreviousPaidValue, CessionDate "+
                //    ",OldReservationTable."+
                //                   " FROM   dbo.CRMReservationCession "+
                //                   " inner join (" + strOldReservation + ") as OldReservationTable "+
                //                   " on dbo.CRMReservationCession.OldReservationID = OldReservationTable.OldCessionMainReservationID " +
                //                   " inner join (" +strNewReservation + ") as NewReservationTable  "+
                //                   " on  dbo.CRMReservationCession.NewReservationID = NewReservationTable.NewCessionMainReservationID ";

                string Returned = "SELECT  NewReservationID, OldReservationID, CessionCost, CessionPreviousPaidValue, CessionDate " +
                   ",OldReservationCustomerTable.CustomerFullName as OldReservationCustomerFullName "+
                   ",NewReservationCustomerTable.CustomerFullName as NewReservationCustomerFullName " +
                   ",UnitTable.UnitFullName "+
                                  " FROM   dbo.CRMReservationCession " +
                                  " inner join (" + objReservationDb.CustomerSearchStr + ") as OldReservationCustomerTable " +
                                  " on dbo.CRMReservationCession.OldReservationID = OldReservationCustomerTable.ReservationID " +
                                  " inner join (" + objReservationDb.CustomerSearchStr + ") as NewReservationCustomerTable " +
                                  " on  dbo.CRMReservationCession.NewReservationID = NewReservationCustomerTable.ReservationID "+
                                  " inner join (" + objReservationDb.UnitSearchStr + ") as UnitTable "+
                                  " on dbo.CRMReservationCession.OldReservationID = UnitTable.CurrentReservation ";
                return Returned;

            }
        }
        

        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["OldReservationID"].ToString() != "")
                return;
            _OldReservationID = int.Parse(objDr["OldReservationID"].ToString());
            _NewReservationID = int.Parse(objDr["NewReservationID"].ToString());
            _CessionDate = DateTime.Parse(objDr["CessionDate"].ToString());
            _CessionCost = double.Parse(objDr["CessionCost"].ToString());
            _OldReservationPreviousPaidValue = double.Parse( objDr["CessionPreviousPaidValue"].ToString());
            _UnitFullName = objDr["UnitFullName"].ToString();
            _NewReservationCustomerName = objDr["NewReservationCustomerFullName"].ToString();
            _OldReservationCustomerName = objDr["OldReservationCustomerFullName"].ToString();

 
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
            ReservationDb objReservationDb = new ReservationDb();
            objReservationDb.ID = _OldReservationID;
            objReservationDb.DeleteNonCollectedCheckPayment();
           string strSql = "update CRMReservationInstallment set InstallmentStatus=2 " +
              "  where InstallmentStatus<>1 and ReservationID =" + _OldReservationID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public DataTable Search()
        {
            string strSql = SearchStr ;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
