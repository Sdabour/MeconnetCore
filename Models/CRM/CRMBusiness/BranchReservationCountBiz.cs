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
    public class BranchReservationCountBiz
    {
        #region Private Data
        BranchReservationCountDb _BranchReservationCountDb;
        #endregion

        #region Constractors
        public BranchReservationCountBiz()
        {
            _BranchReservationCountDb = new BranchReservationCountDb();
        }
        public BranchReservationCountBiz(DataRow objDR)
        {
            _BranchReservationCountDb = new BranchReservationCountDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _BranchReservationCountDb.ID = value;
            }
            get
            {
                return _BranchReservationCountDb.ID;
            }
        }
        public string Name
        {
            set
            {
                _BranchReservationCountDb.Name = value;
            }
            get
            {
                return _BranchReservationCountDb.Name;
            }
        }
        public double TotalValue
        {
            set
            {
                _BranchReservationCountDb.TotalValue = value;
            }
            get
            {
                return _BranchReservationCountDb.TotalValue;
            }
        }
        public double TotalTempPayment
        {
            set
            {
                _BranchReservationCountDb.TotalTempPayment = value;
            }
            get
            {
                return _BranchReservationCountDb.TotalTempPayment;
            }
        }
        public double TotalInstallmentValue
        {
            set
            {
                _BranchReservationCountDb.TotalInstallmentValue = value;
            }
            get
            {
                return _BranchReservationCountDb.TotalInstallmentValue;
            }
        }
        public double InstallmentPaymentSum
        {
            set
            {
                _BranchReservationCountDb.InstallmentPaymentSum = value;
            }
            get
            {
                return _BranchReservationCountDb.InstallmentPaymentSum;
            }
        }
        public int ClosedCount
        {
            set
            {
                _BranchReservationCountDb.ClosedCount = value;
            }
            get
            {
                return _BranchReservationCountDb.ClosedCount;
            }

        }
        public int TotalCount
        {
            get
            {
                return _BranchReservationCountDb.TotalCount;
            }
        }
        public string ProjectName
        {
            get
            {
                return _BranchReservationCountDb.ProjectName;
            }
        }
        public string TowerName
        {
            get
            {
                return _BranchReservationCountDb.TowerName;
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
        public int Y
        {
            get
            {
                return _BranchReservationCountDb.Y;
            }
        }
        public int M
        {
            get
            {
                return _BranchReservationCountDb.M;
            }
        }
        public int D
        {
            get
            {
                return _BranchReservationCountDb.D;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion


    }
}
