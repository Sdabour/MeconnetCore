using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationSalesSumDetailedBiz
    {
        #region Private Data
        ReservationSalesSumDetailedDb _ReservationSalesSumDetailedDb;
        #endregion
        #region Constractors
        public ReservationSalesSumDetailedBiz()
        {
            _ReservationSalesSumDetailedDb = new ReservationSalesSumDetailedDb();
        }
        public ReservationSalesSumDetailedBiz(DataRow objDR)
        {
             _ReservationSalesSumDetailedDb = new ReservationSalesSumDetailedDb(objDR);
        }
        
        #endregion
        #region Public Accessorice

        public string BranchName
        {
            set
            {
                _ReservationSalesSumDetailedDb.BranchName = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.BranchName;
            }
        }
        public string WorkerFirstName
        {
            set
            {
                _ReservationSalesSumDetailedDb.WorkerFirstName = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.WorkerFirstName;
            }
        }
        public string UnitFullName
        {
            set
            {
                _ReservationSalesSumDetailedDb.UnitFullName = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.UnitFullName;
            }
        }
        public int ReservationID
        {
            set
            {
                _ReservationSalesSumDetailedDb.ReservationID = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.ReservationID;
            }
        }
        public DateTime ResevationDate
        {
            set
            {
                _ReservationSalesSumDetailedDb.ResevationDate = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.ResevationDate;
            }
        }
        public DateTime ContractingDate
        {
            set
            {
                _ReservationSalesSumDetailedDb.ContractingDate = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.ContractingDate;
            }
        }

        public DateTime DelevaryDate
        {
            set
            {
                _ReservationSalesSumDetailedDb.DelevaryDate = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.DelevaryDate;
            }
        }

        public double CachPrice
        {
            set
            {
                _ReservationSalesSumDetailedDb.CachPrice = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.CachPrice;
            }
        }
        public double ReservationValue
        {
            set
            {
                _ReservationSalesSumDetailedDb.ReservationValue = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.ReservationValue;
            }
        }
        public int Status
        {
            set
            {
                _ReservationSalesSumDetailedDb.Status = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.Status;
            }
        }


        public string CustomerFullName
        {
            set
            {
                _ReservationSalesSumDetailedDb.CustomerFullName = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.CustomerFullName;
            }
        }


         public int CellID
        {
            set
            {
                _ReservationSalesSumDetailedDb.CellID = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.CellID;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _ReservationSalesSumDetailedDb.IsDateRange = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.IsDateRange;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _ReservationSalesSumDetailedDb.DateFrom = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.DateFrom;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _ReservationSalesSumDetailedDb.DateTo = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.DateTo;
            }
        }
        public int WorkerID 
        {
            set
            {
                _ReservationSalesSumDetailedDb.WorkerID = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.WorkerID;
            }
        }
        public int BranchID
        {
            set
            {
                _ReservationSalesSumDetailedDb.BranchID = value;
            }
            get
            {
                return _ReservationSalesSumDetailedDb.BranchID;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        #endregion

    }
}
