using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
//using SharpVision.CRM.CRMWeb;
using SharpVision.HR.HRBusiness;
using SharpVision.GL.GLBusiness;
using System.Collections;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationPaymentSumBiz
    {
        #region Private Data
        ReservationPaymentDb _ReservationPaymentDb;

        #endregion
        #region Constructors
        public ReservationPaymentSumBiz()
        {
            _ReservationPaymentDb = new ReservationPaymentDb();
        }
        public ReservationPaymentSumBiz(DataRow objDr)
        {
            _ReservationPaymentDb = new ReservationPaymentDb(objDr);
        }
        #endregion
        #region Public Properties
        public string CustomerStr
        {
            set
            {
                _ReservationPaymentDb.CustomerStr = value;
            }
            get
            {
                return _ReservationPaymentDb.CustomerStr;
            }
        }
        public string UnitStr
        {
            set
            {
                _ReservationPaymentDb.UnitStr = value;
            }
            get
            {
                return _ReservationPaymentDb.UnitStr;
            }
        }

        public string TowerName
        {
            set
            {
                _ReservationPaymentDb.TowerName = value;
            }
            get
            {
                return _ReservationPaymentDb.TowerName;
            }
        }
        public string ProjectName
        {
            set
            {
                _ReservationPaymentDb.ProjectName = value;
            }
            get
            {
                return _ReservationPaymentDb.ProjectName;
            }
        }
        public double PaymentValue
        {
            set
            {
                _ReservationPaymentDb.PaymentValue = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentValue;
            }
        }
        public double InstallmentPaymentValue
        {
            get
            {
                return _ReservationPaymentDb.InstallmentPaymentValue;
            }
        }
        public double TempPaymentValue
        {
            get
            {
                return _ReservationPaymentDb.TempPaymentValue;
            }
        }
        public double MulctPaymentValue
        {
            get
            {
                return _ReservationPaymentDb.MulctPaymentValue;
            }
        }
        public double AdministrativePaymentValue
        {
            get
            {
                return _ReservationPaymentDb.AdministrativePaymentValue;
            }
        }
        public double PayBackPaymentValue
        {
            get
            {
                return _ReservationPaymentDb.PayBackPaymentValue;
            }
        }
        public double DirectPaymentInValue
        {
            get
            {
                return _ReservationPaymentDb.DirectPaymentInValue;
            }
        }
        public double DirectPaymentOutValue
        {
            get
            {
                return _ReservationPaymentDb.DirectPaymentOutValue;
            }
        }
        public string InstallmentTypeNameA
        {
            set
            {
                _ReservationPaymentDb.InstallmentTypeNameA = value;
            }
            get
            {
                return _ReservationPaymentDb.InstallmentTypeNameA;
            }
        }

       
        public string PaymentTypeStr
        {
            set
            {
                _ReservationPaymentDb.PaymentTypeStr = value;
            }
            get
            {
                return _ReservationPaymentDb.PaymentTypeStr;
            }
        }
        public int Y
        {
            get
            {
                return _ReservationPaymentDb.Y;
            }
        }
        public int M
        {
            get
            {
                return _ReservationPaymentDb.M;
            }
        }
        public int D
        {
            get
            {
                return _ReservationPaymentDb.D;
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
        public string EmployeeName
        {
            get
            {
                return _ReservationPaymentDb.EmployeeName;
            }
        }
        public string BranchName
        {
            get
            {
                return _ReservationPaymentDb.BranchName;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion

    }
}
