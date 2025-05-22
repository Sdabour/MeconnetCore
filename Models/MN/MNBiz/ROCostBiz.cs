using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatMN.MN.MNDb;

namespace AlgorithmatMN.MN.MNBiz
{
    public class ROCostBiz
    {

        #region Constructor
        public ROCostBiz()
        {
            _ROCostDb = new ROCostDb();

        }
        public ROCostBiz(DataRow objDr)
        {
            _ROCostDb = new ROCostDb(objDr);
            _TypeBiz = new CostTypeBiz(objDr);
            _ROBiz = new ROBiz(objDr);
        }

        #endregion
        #region Private Data
        ROCostDb _ROCostDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _ROCostDb.ID = value;
            }
            get
            {
                return _ROCostDb.ID;
            }
        }
        public int Type
        {
            set
            {
                _ROCostDb.Type = value;
            }
            get
            {
                return _ROCostDb.Type;
            }
        }
        CostTypeBiz _TypeBiz;
        public CostTypeBiz TypeBiz
        {
            set => _TypeBiz = value;
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new CostTypeBiz();
                return _TypeBiz;
            }
        }
        public int RO
        {
            set
            {
                _ROCostDb.RO = value;
            }
            get
            {
                return _ROCostDb.RO;
            }
        }
        ROBiz _ROBiz;
        public ROBiz ROBiz
        { set => _ROBiz = value; 
            get {
                if (_ROBiz == null)
                    _ROBiz = new ROBiz();
                return _ROBiz;
            } }
        public int CreditID
        { get => _ROCostDb.CreditID;
            
        }
        public double CostPart
        { get => (EndDate.Subtract(StartDate).Days + 1) * ROBiz.TypeWeight * ROBiz.Area; }
        public int ProjectCost
        {
            set
            {
                _ROCostDb.ProjectCost = value;
            }
            get
            {
                return _ROCostDb.ProjectCost;
            }
        }
        public double Value
        {
            set
            {
                _ROCostDb.Value = value;
            }
            get
            {
                return _ROCostDb.Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _ROCostDb.Date = value;
            }
            get
            {
                return _ROCostDb.Date;
            }
        }
        
        public DateTime StartDate
        {
            set
            {
                _ROCostDb.StartDate = value;
            }
            get
            {
                return _ROCostDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _ROCostDb.EndDate = value;
            }
            get
            {
                return _ROCostDb.EndDate;
            }
        }
        public int Year
        {
            set
            {
                _ROCostDb.Year = value;
            }
            get
            {
                return _ROCostDb.Year;
            }
        }
        public double Factor1
        {
            set
            {
                _ROCostDb.Factor1 = value;
            }
            get
            {
                return _ROCostDb.Factor1;
            }
        }
        public double Factor2
        {
            set
            {
                _ROCostDb.Factor2 = value;
            }
            get
            {
                return _ROCostDb.Factor2;
            }
        }
        public double Factor3
        {
            set
            {
                _ROCostDb.Factor3 = value;
            }
            get
            {
                return _ROCostDb.Factor3;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _ROCostDb.RO = ROBiz.ID;
            _ROCostDb.Year = Date.Year;
            _ROCostDb.Add();
        }
        public void Edit()
        {
            _ROCostDb.RO = ROBiz.ID;
            _ROCostDb.Year = Date.Year;
            _ROCostDb.Edit();
        }
        public void Delete()
        {
            
            _ROCostDb.Delete();
        }
        #endregion
    }
}
