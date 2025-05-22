using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class TowerReservationSumBiz
    {
        #region Private Data
        TowerReservationSumDb _TowerReservationSumDb;
        #endregion

        #region Constractors
        public TowerReservationSumBiz()
        {
            _TowerReservationSumDb = new TowerReservationSumDb();
        }
        public TowerReservationSumBiz(DataRow objDR)
        {
            _TowerReservationSumDb = new TowerReservationSumDb(objDR);
        }
        #endregion

        #region Public Accessorice
         public string TowerNo
        {
            set
            {
                _TowerReservationSumDb.TowerNo = value;
            }
            get
            {
                return _TowerReservationSumDb.TowerNo;
            }
        }
        public double TotalValue
        {
            set
            {
                _TowerReservationSumDb.TotalValue = value;
            }
            get
            {
                return _TowerReservationSumDb.TotalValue;
            }
        }
        public double TotalTempPayment
        {
            set
            {
                _TowerReservationSumDb.TotalTempPayment = value;
            }
            get
            {
                return _TowerReservationSumDb.TotalTempPayment;
            }
        }
        public double TotalInstallmentValue
        {
            set
            {
                _TowerReservationSumDb.TotalInstallmentValue = value;
            }
            get
            {
                return _TowerReservationSumDb.TotalInstallmentValue;
            }
        }
        public double TotalInstallmentPaymentSum
        {
            set
            {
                _TowerReservationSumDb.TotalInstallmentPaymentSum = value;
            }
            get
            {
                return _TowerReservationSumDb.TotalInstallmentPaymentSum;
            }
        }
        public int FreeCount
        {
            set
            {
                _TowerReservationSumDb.FreeCount = value;
            }
            get
            {
                return _TowerReservationSumDb.FreeCount;
            }
        }
        public int ClosedCount
        {
            set
            {
                _TowerReservationSumDb.ClosedCount = value;
            }
            get
            {
                return _TowerReservationSumDb.ClosedCount;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods

        #endregion

    }
}
