using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class StrategyInstallmentBiz
    {
        #region Private Data
        StrategyInstallmentDb _StrategyInstallmentDb;
        InstallmentTypeBiz _TypeBiz;
        StrategyBiz _StrategyBiz;
        ReservationInstallmentCol _InstallmentCol;
        #endregion
        #region Constructors
        public StrategyInstallmentBiz()
        {
            _TypeBiz = new InstallmentTypeBiz();
            _StrategyInstallmentDb = new StrategyInstallmentDb();

        }
        public StrategyInstallmentBiz(DataRow objDR)
        {
            _StrategyInstallmentDb = new StrategyInstallmentDb(objDR);
            _TypeBiz = new InstallmentTypeBiz(objDR);
        }
        #endregion
        #region Public Properties
        public int StrategyID
        {
            set
            {
                _StrategyInstallmentDb.StrategyID = value;
            }
            get
            {
                return _StrategyInstallmentDb.StrategyID;
            }

        }
        public int InstallmentNo
        {
            set
            {

                _StrategyInstallmentDb.InstallmentNo = value;
            }
            get
            
            {
                if (_StrategyInstallmentDb == null)
                    _StrategyInstallmentDb = new StrategyInstallmentDb();

                int Returned = _StrategyInstallmentDb.InstallmentNo;
                if (_InstallmentCol != null && _InstallmentCol.Count > 0)
                    Returned = _InstallmentCol.Count;
                return Returned;
            }

        }
        public InstallmentTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                return _TypeBiz;
            }

        }
        public double InstallmentValue
        {
            set
            {
                _StrategyInstallmentDb.InstallmentValue = value;
            }
            get
            {
                return _StrategyInstallmentDb.InstallmentValue;
            }

        }
        public double Perc
        {
            set
            {
                _StrategyInstallmentDb.Perc = value;
            }
            get
            {
                return _StrategyInstallmentDb.Perc;
            }
        }
        public int InstallmentPeriod
        {
            set
            {
                _StrategyInstallmentDb.InstallmentPeriod = value;
            }
            get
            {
                return _StrategyInstallmentDb.InstallmentPeriod;
            }

        }
        public double PeriodAmount
        {
            set
            {
                _StrategyInstallmentDb.PeriodAmount = value;
            }
            get
            {
                return _StrategyInstallmentDb.PeriodAmount;
            }

        }
        public StrategyBiz StrategyBiz
        {
            set
            {
                _StrategyBiz = value;
            }
            get
            {
                return _StrategyBiz;
            }
        }
        public double ProfitValue
        {
            get
            {
                double Returned;
                if (_StrategyBiz.ProfitIsCompound)
                    Returned = PeriodBiz.GetCompoundProfit(InstallmentValue, InstallmentNo,
                        new PeriodBiz((Period)InstallmentPeriod, (int)PeriodAmount), _StrategyBiz.ProfitValue,
                        new PeriodBiz((Period)_StrategyBiz.ProfitPeriod));
                else
                    Returned = 0;
                    //Returned = PeriodBiz.GetSimpleProfit(InstallmentValue, InstallmentNo,
                    //new PeriodBiz((Period)InstallmentPeriod, (int)PeriodAmount), _StrategyBiz.ProfitValue,
                    //new PeriodBiz((Period)_StrategyBiz.ProfitPeriod));
                return Returned;
            }

        }
        public double OneInstallmentValue
        {
            get
            {
                double dblProfit;
                if (_StrategyBiz.ProfitIsCompound)
                    dblProfit = PeriodBiz.GetCompoundProfit(InstallmentValue, InstallmentNo,
                        new PeriodBiz((Period)InstallmentPeriod, (int)PeriodAmount), _StrategyBiz.ProfitValue,
                        new PeriodBiz((Period)_StrategyBiz.ProfitPeriod));
                else
                    dblProfit = 0;
                    //dblProfit = PeriodBiz.GetSimpleProfit(InstallmentValue, InstallmentNo,
                    //new PeriodBiz((Period)InstallmentPeriod, (int)PeriodAmount), _StrategyBiz.ProfitValue,
                    //new PeriodBiz((Period)_StrategyBiz.ProfitPeriod));
                double dblTotalValue = InstallmentValue + dblProfit;
                return SysUtility.Approximate(dblTotalValue/InstallmentNo, 1);

            }
        }
        public ReservationInstallmentCol InstallmentCol
        {
            set
            {
                _InstallmentCol = value;
            }
            get
            {
                if (_InstallmentCol == null)
                    _InstallmentCol = new ReservationInstallmentCol(true);
                return _InstallmentCol;
            }
        }
        public double PaidValue
        {
            get
            {
                double Returned = 0;
                Returned = InstallmentCol.PaidValue;
                return Returned;
            }
        }
        public double TotalCheckValue
        {
            get
            {
                double Returned = 0;
                Returned = InstallmentCol.TotalCheckValue;
                return Returned;
            }
        }
        public double TotalCollectedCheckValue
        {
            get
            {
                double Returned = 0;
                Returned = InstallmentCol.TotalCollectedCheckValue;
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
            _StrategyInstallmentDb.InstallmentType = _TypeBiz.ID;
            _StrategyInstallmentDb.Add();
        }
        public void Edit()
        {
            _StrategyInstallmentDb.InstallmentType = _TypeBiz.ID;
            _StrategyInstallmentDb.Edit();
        }
        public void Delete()
        {
            
            _StrategyInstallmentDb.Delete();
        }
        public ReservationInstallmentCol GetInstallmentCol(ReservationBiz objReservationBiz, DateTime dtStartDate,VacancyDeal objDeal,double dblApproximate)
        {
            if (_InstallmentCol != null && _InstallmentCol.Count != 0)
                return _InstallmentCol;
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            ReservationInstallmentBiz objInstallmentBiz;
            PeriodBiz objPeriodBiz;
            double dblProfit;
            if (_StrategyBiz == null)
                _StrategyBiz = new StrategyBiz();
            if (_StrategyBiz.ProfitIsCompound)
                dblProfit = PeriodBiz.GetCompoundProfit(InstallmentValue, InstallmentNo,
                    new PeriodBiz((Period)InstallmentPeriod, (int)PeriodAmount), _StrategyBiz.ProfitValue,
                    new PeriodBiz((Period)_StrategyBiz.ProfitPeriod));
            else
            {
                dblProfit = 0;
               
            }
            double dblTotalValue = InstallmentValue + dblProfit;
            for (int intIndex = 1; intIndex <= InstallmentNo; intIndex++)
            {
                objInstallmentBiz = new ReservationInstallmentBiz();
                objInstallmentBiz.Type = TypeBiz;
                objInstallmentBiz.Reservation = objReservationBiz;
                objInstallmentBiz.InstallmentNo = intIndex;
               
                objInstallmentBiz.InstallmentValue = SysUtility.Approximate((dblTotalValue / InstallmentNo), dblApproximate);

                objPeriodBiz = new PeriodBiz((Period)InstallmentPeriod,(intIndex * PeriodAmount));
                objInstallmentBiz.InstallmentDueDate = PeriodBiz.GetDate(objPeriodBiz, dtStartDate, objDeal);
                Returned.Add(objInstallmentBiz);

 
            }
            double dblRemainingValue = SysUtility.Approximate(dblTotalValue - Returned.Value,dblApproximate);
            if (Returned.Count > 0)
                Returned[Returned.Count - 1].InstallmentValue = Returned[Returned.Count - 1].InstallmentValue + dblRemainingValue;
            _InstallmentCol = Returned;
            return Returned;
        }
        public ReservationInstallmentCol DeservedInstallmentCol(DateTime dtDate)
        {
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            foreach (ReservationInstallmentBiz objBiz in InstallmentCol)
            {
                if (objBiz.InstallmentDueDate <= dtDate && objBiz.InstallmentStatus != InstallmentStatus.Paid )
                {
                    Returned.Add(objBiz);
                }

 
            }
            return Returned;
        }
        public ReservationInstallmentCol GetNonPaidInstallmentCol()
        {
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            ReservationInstallmentCol objCol = new ReservationInstallmentCol(true);
            foreach (ReservationInstallmentBiz objBiz in InstallmentCol)
            {
                if (objBiz.PaidValue != 0)
                {
                    objCol.Add(objBiz);
                    if ( objBiz.InstallmentStatus != InstallmentStatus.Paid)
                    {
                        objBiz.InstallmentValue = objBiz.PaidValue + objBiz.DiscountValue;
                        objBiz.InstallmentStatus = InstallmentStatus.Paid;
                    }

                }
                else
                    Returned.Add(objBiz);
               
 
            }
            InstallmentCol = objCol;
            return Returned;
 
        }
        #endregion
    }
}
