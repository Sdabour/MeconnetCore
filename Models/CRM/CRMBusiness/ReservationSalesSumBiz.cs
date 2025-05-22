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
    public class ReservationSalesSumBiz
    {
        #region Private Data
        ReservationSalesSumDb objReservationSalesSumDb;
        SalesManBiz _SalesMan;
        #endregion

        #region Constractors
        public ReservationSalesSumBiz()
        {
            objReservationSalesSumDb = new ReservationSalesSumDb();
        }
        public ReservationSalesSumBiz(DataRow objDR)
        {
            objReservationSalesSumDb = new ReservationSalesSumDb(objDR);
        }
        #endregion
        #region Public Accessorice
        public string WorkerName
        {
            set
            {
                objReservationSalesSumDb.WorkerName = value;
            }
            get
            {
                return objReservationSalesSumDb.WorkerName;
            }
        }
        public double ContractingCount
        {
            set
            {
                objReservationSalesSumDb.ContractingCount = value;
            }
            get
            {
                return objReservationSalesSumDb.ContractingCount;
            }
        }
        public double DeservedCount
        {
            set
            {
                objReservationSalesSumDb.DeservedCount = value;
            }
            get
            {
                return objReservationSalesSumDb.DeservedCount;
            }
        }
        public double  CompletedCount
        {
            set
            {
                objReservationSalesSumDb.CompletedCount = value;
            }
            get
            {
                return objReservationSalesSumDb.CompletedCount;
            }
        }
        public double CancellationCount
        {
            set
            {
                objReservationSalesSumDb.CancellationCount = value;
            }
            get
            {
                return objReservationSalesSumDb.CancellationCount;
            }
        }
        public double CessionCount
        {
            set
            {
                objReservationSalesSumDb.CessionCount = value;
            }
            get
            {
                return objReservationSalesSumDb.CessionCount;
            }
        }
        public double TotalValue
        {
            set
            {
                objReservationSalesSumDb.TotalValue = value;
            }
            get
            {
                return objReservationSalesSumDb.TotalValue;
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
        #endregion
    }
}
