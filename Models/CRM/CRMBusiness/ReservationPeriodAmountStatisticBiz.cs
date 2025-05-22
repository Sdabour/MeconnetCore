using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
 {
    public class ReservationPeriodAmountStatisticBiz
    {
        #region Private Data
        ReservationPeriodAmountStatisticDb _ReservationPeriodAmountStatisticDb;
        #endregion
        #region Constractors
        public ReservationPeriodAmountStatisticBiz()
        {
            _ReservationPeriodAmountStatisticDb = new ReservationPeriodAmountStatisticDb();
        }
        public ReservationPeriodAmountStatisticBiz(DataRow objDR)
        {
            _ReservationPeriodAmountStatisticDb = new ReservationPeriodAmountStatisticDb(objDR);
        }
        #endregion
        #region Public Accessorice
        public int TotalUnitCount
        {
            set
            {
                _ReservationPeriodAmountStatisticDb.TotalUnitCount = value;
            }
            get
            {
                return _ReservationPeriodAmountStatisticDb.TotalUnitCount;
            }
        }
        public int CellID
        {
            set
            {
                _ReservationPeriodAmountStatisticDb.CellID = value;
            }
            get
            {
                return _ReservationPeriodAmountStatisticDb.CellID;
            }
        }
        public string CellNameA
        {
            set
            {
                _ReservationPeriodAmountStatisticDb.CellNameA = value;
            }
            get
            {
                return _ReservationPeriodAmountStatisticDb.CellNameA;

            }
        }
        public double PeriodAmount
        {
            set
            {
                _ReservationPeriodAmountStatisticDb.PeriodAmount = value;
            }
            get
            {
                return _ReservationPeriodAmountStatisticDb.PeriodAmount;
            }
        }
        public double TotalValue
        {
            set
            {
                _ReservationPeriodAmountStatisticDb.TotalValue = value;
            }
            get
            {
                return _ReservationPeriodAmountStatisticDb.TotalValue;
            }
        }
        public double InstallmentDiscount
        {
            set
            {
                _ReservationPeriodAmountStatisticDb.InstallmentDiscount = value;
            }
            get
            {
                return _ReservationPeriodAmountStatisticDb.InstallmentDiscount;
            }
        }
        #endregion
    }
}
