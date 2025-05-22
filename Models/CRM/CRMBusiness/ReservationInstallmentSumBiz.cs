using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationInstallmentSumBiz
    {
        #region Private Data
        ReservationInstallmentDb _ReservationInstallmentDb;
        CellBiz _TowerBiz;
        #endregion
        #region Constructors
        public ReservationInstallmentSumBiz()
        { }
        public ReservationInstallmentSumBiz(DataRow objDr)
        {
            _ReservationInstallmentDb = new ReservationInstallmentDb(objDr);

        }
        #endregion
        #region Public Properties

        public double TotalDiscountValue
        {
            get
            {
                return _ReservationInstallmentDb.TotalDiscountValue;
            }
        }
        public double TotalValue
        {
            get
            {
                return _ReservationInstallmentDb.TotalValue;
            }
        }
        public double TotalCheckValue
        {
            get
            {
                return _ReservationInstallmentDb.TotalCheckValue;
            }
        }
        public double TotalPaidValue
        {
            get
            {
                return _ReservationInstallmentDb.TotalPaidValue;
            }
        }
        public double TotalRemainingValue
        {
            get
            {
                return _ReservationInstallmentDb.TotalRemainingValue;
            }
        }
        public int InstallmentMainType
        {
            get
            {
                return _ReservationInstallmentDb.InstallmentMainType;
            }
        }

        public double InstallmentValue
        {
            get
            {
                return _ReservationInstallmentDb.InstallmentValue;
            }
        }
        public double InstallmentPaidValue
        {
            get
            {
                return _ReservationInstallmentDb.InstallmentPaidValue;
            }
        }
        public double InstallmentDiscount
        {
            get
            {
                return _ReservationInstallmentDb.InstallmentDiscount;
            }
        }
        public double InstallmentRemainingValue
        {
            get
            {
                return _ReservationInstallmentDb.InstallmentRemainingValue;
            }
        }
        public double InstallmentCheckValue
        {
            get
            {
                return _ReservationInstallmentDb.InstallmentCheckValue;
            }
        }

        public double PeriodicPaymentValue
        {
            get
            {
                return _ReservationInstallmentDb.PeriodicPaymentValue;
            }
        }
        public double PeriodicPaymentPaidValue
        {
            get
            {
                return _ReservationInstallmentDb.PeriodicPaymentPaidValue;
            }
        }
        public double PeriodicPaymentDiscount
        {
            get
            {
                return _ReservationInstallmentDb.PeriodicPaymentDiscount;
            }
        }
        public double PeriodicPaymentRemainingValue
        {
            get
            {
                return _ReservationInstallmentDb.PeriodicPaymentRemainingValue;
            }
        }
        public double PeriodicPaymentCheckValue
        {
            get
            {
                return _ReservationInstallmentDb.PeriodicPaymentCheckValue;
            }
        }
        public double DeliveryPaymentValue
        {
            get
            {
                return _ReservationInstallmentDb.DeliveryPaymentValue;
            }
        }
        public double DeliveryPaymentPaidValue
        {
            get
            {
                return _ReservationInstallmentDb.DeliveryPaymentPaidValue;
            }
        }
        public double DeliveryPaymentDiscount
        {
            get
            {
                return _ReservationInstallmentDb.DeliveryPaymentDiscount;
            }
        }
        public double DeliveryPaymentRemainingValue
        {
            get
            {
                return _ReservationInstallmentDb.DeliveryPaymentRemainingValue;
            }
        }
        public double DeliveryPaymentCheckValue
        {
            get
            {
                return _ReservationInstallmentDb.DeliveryPaymentCheckValue;
            }
        }
        public double OtherPaymentValue
        {
            get
            {
                return _ReservationInstallmentDb.OtherPaymentValue;
            }
        }
        public double OtherPaymentPaidValue
        {
            get
            {
                return _ReservationInstallmentDb.OtherPaymentPaidValue;
            }
        }
        public double OtherPaymentDiscount
        {
            get
            {
                return _ReservationInstallmentDb.OtherPaymentDiscount;
            }
        }
        public double OtherPaymentRemainingValue
        {
            get
            {
                return _ReservationInstallmentDb.OtherPaymentRemainingValue;
            }
        }
        public double OtherPaymentCheckValue
        {
            get
            {
                return _ReservationInstallmentDb.OtherPaymentCheckValue;
            }
        }


        public string InstallmentTypeNameA
        {
            get
            {
                return _ReservationInstallmentDb.InstallmentTypeNameA;
            }
        }

        public string CustomerStr
        {
          
            get
            {
                return _ReservationInstallmentDb.CustomerStr;
            }
        }
        public string UnitStr
        {
            
            get
            {
                return _ReservationInstallmentDb.UnitStr;
            }
        }

        public string TowerName
        {
            
            get
            {
                return _ReservationInstallmentDb.TowerName;
            }
        }
        public CellBiz TowerBiz
        {
            get
            {
                if (_TowerBiz == null)
                {
                    if (_ReservationInstallmentDb.TowerID != 0)
                        _TowerBiz = new CellBiz(_ReservationInstallmentDb.TowerID);
                    else
                        _TowerBiz = new CellBiz();
                }

                return _TowerBiz;
            }
        }
        public string ProjectName
        {
           
            get
            {
                return _ReservationInstallmentDb.ProjectName;
            }
        }
       


      
        public int Y
        {
            get
            {
                return _ReservationInstallmentDb.Y;
            }
        }
        public int M
        {
            get
            {
                return _ReservationInstallmentDb.M;
            }
        }
        public int D
        {
            get
            {
                return _ReservationInstallmentDb.D;
            }
        }
        public string PeriodStr
        {
            get
            {
                string Returned = "";
                int intDay = D == 0 ? 1 : D;
                int intMonth = M;
                int intYear = Y;

                if (intYear != 0)
                {
                    DateTime dtTemp = DateTime.Now;
                    if (intMonth == 0)
                    {
                        intMonth = 1;
                        dtTemp = new DateTime(intYear, intMonth, intDay);
                        Returned = dtTemp.ToString("yyyy");
                    }
                    else
                    {
                        dtTemp = new DateTime(intYear, intMonth, intDay);
                        if (D == 0)
                            Returned = dtTemp.ToString("yyyy-MM");
                        else
                            Returned = dtTemp.ToString("yyyy-MM-dd");
                    }
                }
                return Returned;
            }
        }
       
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
