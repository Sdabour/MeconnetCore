using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNBiz
{
    public class ProjectYearBiz
    {
        int _Year;
        public int Year { set => _Year = value; get => _Year; }
        string _ProjectCode;
        public string ProjectCode { set => _ProjectCode = value; get => _ProjectCode; }
        public string Key
        { get => _ProjectCode.Trim().ToUpper() + "-" + Year.ToString(); }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; get =>Year> 0?new DateTime(Year, 1, 1):_StartDate; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; get =>Year>0? new DateTime(Year, 12, 31):_EndDate; }
        public int Days { get => EndDate.Subtract(StartDate).Days + 1; }
        ProjectCostCol _CostCol;
        public ProjectCostCol CostCol
        { set => _CostCol = value;
            get 
            {
                if (_CostCol == null)
                    _CostCol = new ProjectCostCol(true);
                return _CostCol;
            }

        }
        public double CostPart
        { get =>CreditCol.Count>0? CostCol.TotalValue / CreditCol.TotalCostPart:0; }
        CreditCol _CreditCol;
        public CreditCol CreditCol
        { set => _CreditCol = value; 
            get 
            {
                if (_CreditCol == null)
                    _CreditCol = new CreditCol(true);
                return _CreditCol;
            } }
        public void SetCostCol(ProjectCostCol objCostCol)
        {
            int intYear = Year;
            string strProjectCode = ProjectCode;


            List<ProjectCostBiz> lstCost = (from objCost in objCostCol.Cast<ProjectCostBiz>()
                                            where objCost.Year == intYear && objCost.Project == strProjectCode
                                            orderby objCost.Year
                                            select objCost).ToList();
            foreach (ProjectCostBiz objBiz in lstCost)
            {

                 CostCol.Add(objBiz);
            }
            //return Returned;
        }
    }
}
