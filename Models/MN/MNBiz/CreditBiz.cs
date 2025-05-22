using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatMN.MN.MNDb;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNBiz
{
    public class CreditBiz
    {

        #region Constructor
        public CreditBiz()
        {
            _CreditDb = new CreditDb();
        }
        public CreditBiz(DataRow objDr)
        {
            _CreditDb = new CreditDb(objDr);
            _ROBiz = new ROBiz(objDr);
        }

        #endregion
        #region Private Data
        CreditDb _CreditDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _CreditDb.ID = value;
            }
            get
            {
                return _CreditDb.ID;
            }
        }
        public int RO
        {
            set
            {
                _CreditDb.RO = value;
            }
            get
            {
                return _CreditDb.RO;
            }
        }
        public int Year
        {
            set
            {
                _CreditDb.Year = value;
            }
            get
            {
                return _CreditDb.Year;
            }
        }
        ProjectYearBiz _YearBiz;
        public ProjectYearBiz YearBiz
        { set => _YearBiz = value;
            get {
                if (_YearBiz == null) { _YearBiz = new ProjectYearBiz() { Year=Year,ProjectCode=ROBiz.ProjectCode}; }
                return _YearBiz;
            } 
        }
        public string Key { get => RO.ToString()+"-"+ Year.ToString(); }
        public DateTime StartDate
        {
            set
            {
                _CreditDb.StartDate = value;
            }
            get
            {
                return _CreditDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _CreditDb.EndDate = value;
            }
            get
            {
                return _CreditDb.EndDate;
            }
        }
        public double CrditInitialValue
        {
            set
            {
                _CreditDb.CrditInitialValue = value;
            }
            get
            {
                return _CreditDb.CrditInitialValue;
            }
        }
        public double BonusValue
        {
            set
            {
                _CreditDb.BonusValue = value;
            }
            get
            {
                
                return ID!=0? _CreditDb.BonusValue:(
                    (CrditInitialValue - Cost)<=0?0:
                    ((CrditInitialValue-Cost)*Days/YearBiz.Days)*(ROBiz.MaintainanceBonusPercPerYear/100));
            }
        }
        public double PaymentValue
        {
            set
            {
                _CreditDb.PaymentValue = value;
            }
            get
            {

                return  ID !=0?_CreditDb.PaymentValue : PaymentCol.TotalValue;
            }
        }
        public double DiscountValue
        {
            set
            {
                _CreditDb.DiscountValue = value;
            }
            get
            {
                return _CreditDb.DiscountValue;
            }
        }
        
        public double Cost
        {
            set
            {
                _CreditDb.Cost = value;
            }
            get
            {
                //if(ID!= 0)

                return  _CreditDb.Cost;
            }
        }
        public double Closing { get => CrditInitialValue+PaymentValue + BonusValue - Cost; }
        public double CostDiff { get => Cost- BonusValue>0?Cost-BonusValue: 0; }
        ROBiz _ROBiz;
        public ROBiz ROBiz
        { set => _ROBiz = value;
            get 
            { if (_ROBiz == null)
                    _ROBiz = new ROBiz();
                return _ROBiz;
                        } }
        public double Days
        {
            get
            {
                return EndDate.Subtract(StartDate).Days + 1;
            }
        }
        public double CostPart
        {
            get
            {
                return ROBiz.TypeWeight * Days * (double)ROBiz.Area;
            }
        }
        MaintainanceDiscountCol _DiscountCol;
        public MaintainanceDiscountCol DiscountCol
        {
            set => _DiscountCol = value;
            get
            {
                if (_DiscountCol == null)
                    _DiscountCol = new MaintainanceDiscountCol(true);
                return _DiscountCol;
            }
        }
        MaintainancePaymentCol _PaymentCol;
        public MaintainancePaymentCol PaymentCol
        { set => _PaymentCol = value;
        get
         {
                if (_PaymentCol == null)
                    _PaymentCol = new MaintainancePaymentCol(true);
                return _PaymentCol;
            }
        }
        ROCostCol _CostCol;
        public ROCostCol ROCostCol
        {
            set => _CostCol = value;
            get {
            if(_CostCol == null)
                {
                    _CostCol = new ROCostCol(true);
                }
                return _CostCol;
            }
        }
                #endregion
                #region Private Method

                #endregion
                #region Public Method 
                public void Add()
        {
            _CreditDb.BonusValue = BonusValue;
            _CreditDb.Add();
        }
        public void Edit()
        {
            _CreditDb.Edit();
        }
        public void Delete()
        {
            _CreditDb.Delete();
        }
        #endregion
    }
}
