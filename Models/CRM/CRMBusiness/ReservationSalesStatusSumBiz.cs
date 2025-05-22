
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace  SharpVision.CRM.CRMBusiness
{
    public class ReservationSalesStatusSumBiz
    {
        #region Private Data
        ReservationSalesStatusSumDb _ReservationSalesStatusSumDb;
        SalesManBiz _SalesMan;
        #endregion

        #region Constractors
        public ReservationSalesStatusSumBiz()
        {
            _ReservationSalesStatusSumDb = new ReservationSalesStatusSumDb();
        }
        public ReservationSalesStatusSumBiz(DataRow objDR)
        {
            _ReservationSalesStatusSumDb = new ReservationSalesStatusSumDb(objDR);
        }
        #endregion
        #region Public Accessorice
        public string WorkerName
        {
            set
            {
                _ReservationSalesStatusSumDb.WorkerName = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.WorkerName;
            }
        }
        public double ContractingCount
        {
            set
            {
                _ReservationSalesStatusSumDb.ContractingCount = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.ContractingCount;
            }
        }
        public double DeservedCount
        {
            set
            {
                _ReservationSalesStatusSumDb.DeservedCount = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.DeservedCount;
            }
        }
        public double  CompletedCount
        {
            set
            {
                _ReservationSalesStatusSumDb.CompletedCount = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.CompletedCount;
            }
        }
        public double CancellationCount
        {
            set
            {
                _ReservationSalesStatusSumDb.CancellationCount = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.CancellationCount;
            }
        }
        public double CessionCount
        {
            set
            {
                _ReservationSalesStatusSumDb.CessionCount = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.CessionCount;
            }
        }
        public double TotalValue
        {
            set
            {
                _ReservationSalesStatusSumDb.TotalValue = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.TotalValue;
            }
        }

        public SalesManBiz SalesMan
        {
            set
            {
                _SalesMan = value;
            }
            get
            {
                return _SalesMan;
            }
        }
        public double CanceledValue
        {
            set
            {
                _ReservationSalesStatusSumDb.CanceledValue = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.CanceledValue;
            }
        }
        public double ContractedValue
        {
            set
            {
                _ReservationSalesStatusSumDb.ContractedValue = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.ContractedValue;
            }
        }
        public double JustReservedValue
        {
            set
            {
                _ReservationSalesStatusSumDb.JustReservedValue = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.JustReservedValue;
            }
        }
        public double CanceledWithoutContractingValue
        {
            set
            {
                _ReservationSalesStatusSumDb.CanceledWithoutContractingValue = value;
            }
            get
            {
                return _ReservationSalesStatusSumDb.CanceledWithoutContractingValue;
            }
        }
        #endregion
    }
}
