using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.RP.RPBusiness;
using SharpVision.HR.HRBusiness;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationStatisticBiz
    {
        #region Private Data
        ReservationStatisticDb _ReservationStatisticDb;
        CellBiz _CellBiz;
        WorkerBiz _WorkerBiz;
        BranchBiz _BranchBiz;
        #endregion

        #region Constractors
        public ReservationStatisticBiz()
        {
            _ReservationStatisticDb = new ReservationStatisticDb();
        }
       
        public ReservationStatisticBiz(DataRow objDR)
        {
            _ReservationStatisticDb = new ReservationStatisticDb(objDR);
        }
        #endregion

        #region Public Accessorice
         public string WorkerName
        {
            set 
            {
                _ReservationStatisticDb.WorkerName = value; 
            }
            get
            {
                return _ReservationStatisticDb.WorkerName;
            }
        }
        public int ContractCount
        {
            set
            {
                _ReservationStatisticDb.ContractCount = value; 
            }
            get 
            {
                return _ReservationStatisticDb.ContractCount; 
            }
            
        }
        public int DeservedCount
        {
            set 
            {
                _ReservationStatisticDb.DeservedCount = value; 
            }
            get 
            {
                return _ReservationStatisticDb.DeservedCount; 
            }
            
        }
        public int EndingCount
        {
            set
            {
                _ReservationStatisticDb.EndingCount = value; 
            }
            get
            {
                return _ReservationStatisticDb.EndingCount; 
            }
            
        }
        public int CanselationCount
        {
            set 
            {
                _ReservationStatisticDb.CanselationCount = value; 
            }
            get
            {
                return _ReservationStatisticDb.CanselationCount; 
            }
            
        }
        public int CessionCount
        {
            set 
            {
                _ReservationStatisticDb.CessionCount = value; 
            }
            get 
            {
                return _ReservationStatisticDb.CessionCount; 
            }
            
        }
        protected double TotalValue
        {
            set 
            {
                _ReservationStatisticDb.TotalValue = value; 
            }
            get
            {
                return _ReservationStatisticDb.TotalValue; 
            }

        }

        #region Accessorice For Search
        public CellBiz CellBiz
        {
            set 
            {
                _CellBiz = value; 
            }
           
            
        }
        public WorkerBiz WorkerBiz
        {
            set 
            {
                _WorkerBiz = value; 
            }
            
            
        }
        public int Status
        {
            set
            {
                _ReservationStatisticDb.Status = value; 
            }
            
            
        }

        public BranchBiz BranchBiz
        {
            set
            {
                _BranchBiz = value; 
            }
        }
        public DateTime DtFrom
        {
            set
            {
                _ReservationStatisticDb.DtFrom = value; 
            }
        }
        public DateTime DtTo
        {
            set 
            {
                _ReservationStatisticDb.DtTo = value; 
            }
        }

        #endregion

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}
