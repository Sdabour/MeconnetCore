using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatMN.MN.MNDb;

namespace AlgorithmatMN.MN.MNBiz
{
    public class ProjectCostBiz
    {

        #region Constructor
        public ProjectCostBiz()
        {
            _ProjectCostDb = new ProjectCostDb();
            
        }
        public ProjectCostBiz(DataRow objDr)
        {
            _ProjectCostDb = new ProjectCostDb(objDr);
            _TypeBiz = new CostTypeBiz(objDr);
        }
public double RemainingValue { set => _ProjectCostDb.RemainingValue = value; get => _ProjectCostDb.RemainingValue; }
        public double TotalROCostValue { set => _ProjectCostDb.TotalROCostValue = value; get => _ProjectCostDb.TotalROCostValue; }
        #endregion
        #region Private Data
        ProjectCostDb _ProjectCostDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _ProjectCostDb.ID = value;
            }
            get
            {
                return _ProjectCostDb.ID;
            }
        }
        public int Type
        {
            set
            {
                _ProjectCostDb.Type = value;
            }
            get
            {
                return _ProjectCostDb.Type;
            }
        }
        CostTypeBiz _TypeBiz;
        public CostTypeBiz TypeBiz
        { set => _TypeBiz = value;
        get
            { if (_TypeBiz == null)
                    _TypeBiz = new CostTypeBiz();
                return _TypeBiz;
            }
        }
        public string Project
        {
            set
            {
                _ProjectCostDb.Project = value;
            }
            get
            {
                return _ProjectCostDb.Project;
            }
        }
        public double Value
        {
            set
            {
                _ProjectCostDb.Value = value;
            }
            get
            {
                return _ProjectCostDb.Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _ProjectCostDb.Date = value;
            }
            get
            {
                return _ProjectCostDb.Date;
            }
        }
        public int ROType
        {
            set
            {
                _ProjectCostDb.ROType = value;
            }
            get
            {
                return _ProjectCostDb.ROType;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _ProjectCostDb.StartDate = value;
            }
            get
            {
                return _ProjectCostDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _ProjectCostDb.EndDate = value;
            }
            get
            {
                return _ProjectCostDb.EndDate;
            }
        }
        public int Year
        {
            set
            {
                _ProjectCostDb.Year = value;
            }
            get
            {
                return _ProjectCostDb.Year;
            }
        }
        public double Factor1
        {
            set
            {
                _ProjectCostDb.Factor1 = value;
            }
            get
            {
                return _ProjectCostDb.Factor1;
            }
        }
        public double Factor2
        {
            set
            {
                _ProjectCostDb.Factor2 = value;
            }
            get
            {
                return _ProjectCostDb.Factor2;
            }
        }
        public double Factor3
        {
            set
            {
                _ProjectCostDb.Factor3 = value;
            }
            get
            {
                return _ProjectCostDb.Factor3;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _ProjectCostDb.Add();
        }
        public void Edit()
        {
            _ProjectCostDb.Edit();
        }
        public void Delete()
        {
            _ProjectCostDb.Delete();
        }
        public ROCostCol GetCostCol(ROCol objRoCol)
        {
            ROCostCol Returned = new ROCostCol(true);
            List<ROCostBiz> lstRoCost = (from objRo in objRoCol.Cast<ROBiz>()
                                 where objRo.ProjectCode == Project && objRo.DeliveryDate.Date <= Date.Date && 
                                 (!objRo.IsEnded || objRo.EndDate.Date > Date.Date)
                                select new ROCostBiz() { Date = Date, StartDate = objRo.DeliveryDate> StartDate?objRo.DeliveryDate :StartDate, EndDate = objRo.IsEnded && objRo.EndDate<EndDate?objRo.EndDate : EndDate, Factor1 = Factor1, Factor2 = Factor2, Factor3 = Factor3, ProjectCost = ID, RO = objRo.ID, Type = Type, TypeBiz = TypeBiz, Year = Year, ROBiz = objRo }).ToList();
            ROCostBiz objCostBiz;
            //return ROBiz.TypeWeight * Days * (double)ROBiz.Area;
            double dblCostPart =lstRoCost.Sum(x=> { return x.CostPart; }) ;
            double dblRemaining = RemainingValue;
            if (dblRemaining >= 100)
            {
                foreach (ROCostBiz objRoCostBiz in lstRoCost)
                {
                    objRoCostBiz.Value = objRoCostBiz.CostPart * (Value / dblCostPart);
                    Returned.Add(objRoCostBiz);

                }
            }
            double dblTemp = Returned.Cast<ROCostBiz>().Sum(x => x.Value);
            DataTable dtTemp = Returned.GetTable();
            return Returned;
        }
        #endregion
    }
}
