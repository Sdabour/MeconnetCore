using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public enum ProfitType
    {
        SimpleProphit,//Profit According to the Dept Age
        Compound,//Profit on the real Dept
        ConstantProphit//Constant Profit  on the whole Dept According to the whole Age
    }
    public class StrategyBiz : BaseSingleBiz
    {

        #region Private Data

        //StrategyDb _StrategyDb;
        UnitModelBiz _ModelBiz;
        StrategyInstallmentCol _StrategyInstallmentCol;
        #endregion
        #region Constructors
        public StrategyBiz()
        {
            _BaseDb = new StrategyDb();
        }
        public StrategyBiz(int intID)
        {
            _BaseDb = new StrategyDb(intID);

        }
        public StrategyBiz(DataRow objDR)
        {
            _BaseDb = new StrategyDb(objDR);

        }
        public StrategyBiz(StrategyDb objStrategyDb)
        {
            _BaseDb = objStrategyDb;
        }
        #endregion
        #region Public Properties
        public UnitModelBiz ModelBiz
        {
            set
            {
                _ModelBiz = value;
            }
            get
            {
                return _ModelBiz;
            }

        }
        public double ProfitValue
        {
            set
            {
                ((StrategyDb)_BaseDb).ProfitValue = value;
            }
            get
            {
                return ((StrategyDb)_BaseDb).ProfitValue;
            }

        }
        public double TotalValue
        {
            set
            {
                ((StrategyDb)_BaseDb).TotalValue = value;
            }
            get
            {
               
                double Returned = ((StrategyDb)_BaseDb).TotalValue + TotalProfitValue;
                return Returned;
            }

        }
        public double RemainingValue
        {
            get
            {
                double Returned = TotalValue - StrategyInstallmentCol.Value;
                return Returned;
            }
        }
        public double TotalProfitValue
        {
            get
            {
                double Returned = 0;
                if (!ProfitIsCompound)
                {

                    Returned = PeriodBiz.GetSimpleProfit(((StrategyDb)_BaseDb).TotalValue, PeriodAmount, new PeriodBiz((Period)Period)
                    , ProfitValue, new PeriodBiz((Period)ProfitPeriod));
 
                }
                return Returned;
            }
        }
        public bool ProfitIsCompound
        {
            set
            {
                ((StrategyDb)_BaseDb).ProfitIsCompound = value;
            }
            get
            {
                return ((StrategyDb)_BaseDb).ProfitIsCompound;
            }

        }
        public Period ProfitPeriod
        {
            set
            {
                ((StrategyDb)_BaseDb).ProfitPeriod =(int) value;
            }
            get
            {
                return (Period)((StrategyDb)_BaseDb).ProfitPeriod;
            }

        }
        public double PeriodAmount //Profit Period 
        {
            set
            {
                ((StrategyDb)_BaseDb).PeriodAmount = value;
            }
            get
            {
                return ((StrategyDb)_BaseDb).PeriodAmount;
            }

        }
        public int Period //total Period
        {
            set
            {
                ((StrategyDb)_BaseDb).Period = value;
            }
            get
            {
                return ((StrategyDb)_BaseDb).Period;
            }

        }
        public StrategyInstallmentCol StrategyInstallmentCol
        {
            set
            {
                _StrategyInstallmentCol = value;
            }
            get
            {
                if (_StrategyInstallmentCol == null)
                {
                    _StrategyInstallmentCol = new StrategyInstallmentCol(true);

                    if (ID != 0)
                    {
                        StrategyInstallmentBiz objBiz;    
                        DataTable dtTemp = ((StrategyDb)_BaseDb).GetInstallment();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new StrategyInstallmentBiz(objDr);
                            objBiz.StrategyBiz = this;
                            _StrategyInstallmentCol.Add(objBiz);
                        }

                    }
                }
                return _StrategyInstallmentCol;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        
        public void Add()
        {
            if (_StrategyInstallmentCol == null)
                _StrategyInstallmentCol = new StrategyInstallmentCol(true);
            ((StrategyDb)_BaseDb).ModelID = _ModelBiz.ID;
            ((StrategyDb)_BaseDb).InstallmentTable = _StrategyInstallmentCol.GetTable();
            _BaseDb.Add();
        }
        public void Edit()
        {
            if (_StrategyInstallmentCol == null)
                _StrategyInstallmentCol = new StrategyInstallmentCol(true);
            ((StrategyDb)_BaseDb).ModelID = _ModelBiz.ID;
            ((StrategyDb)_BaseDb).InstallmentTable = _StrategyInstallmentCol.GetTable();
            _BaseDb.Edit();
        }
        public void Delete(int intID)
        {
            _BaseDb.Delete();
        }
        #endregion

    }
}
