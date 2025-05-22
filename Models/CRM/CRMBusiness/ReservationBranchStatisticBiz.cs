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
    public class ReservationBranchStatisticBiz
    {
        #region Private Data
        ReservationBranchStatisticDb _ReservationStatisticDb;
        CellBiz _CellBiz;
        BranchBiz _BranchBiz;
        #endregion

        #region Constractors
        public ReservationBranchStatisticBiz()
        {
            _ReservationStatisticDb = new ReservationBranchStatisticDb();
        }
       
        public ReservationBranchStatisticBiz(DataRow objDR)
        {
            _ReservationStatisticDb = new ReservationBranchStatisticDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public string BranchName
        {
            set
            {
                _ReservationStatisticDb.BranchName = value;
            }
            get
            {
                return _ReservationStatisticDb.BranchName;
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
        public int TempDeservedCount
        {
            set
            {
                _ReservationStatisticDb.TempDeserved = value;
            }
            get
            {
               return _ReservationStatisticDb.TempDeserved;
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
        public int TotalCount
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
        

        #endregion

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}
