using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatMN.MN.MNDb;
using System.Collections;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
   public class ProjectCostCol:CollectionBase
    {

        #region Constructor
        public ProjectCostCol()
        {

        }
        public ProjectCostCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ProjectCostBiz objBiz = new ProjectCostBiz();
           

            ProjectCostDb objDb = new ProjectCostDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ProjectCostBiz(objDR);
                Add(objBiz);
            }
        }
        public ProjectCostCol(string strProjectCode,List<int> lstYears)
        {
           
            ProjectCostBiz objBiz = new ProjectCostBiz();

            string strYears = "";
            foreach(int intYear in lstYears)
            {
                if (strYears != "")
                    strYears += ",";
                strYears += intYear.ToString();
            }
            ProjectCostDb objDb = new ProjectCostDb();
            objDb.YearStr = strYears;
            objDb.Project = strProjectCode;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ProjectCostBiz(objDR);
                Add(objBiz);
            }
        }
        public ProjectCostCol(string strProjectCode,CostTypeBiz objCostType,bool blIsDate,DateTime dtSTartDate,DateTime dtEndDate)
        {

            ProjectCostBiz objBiz = new ProjectCostBiz();

            
            ProjectCostDb objDb = new ProjectCostDb();
           
            objDb.Project = strProjectCode;
            objDb.Type = objCostType.ID;
            objDb.IsDateRange = blIsDate;
            objDb.StartDate = dtSTartDate;
            objDb.EndDate = dtEndDate;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ProjectCostBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public ProjectCostBiz this[int intIndex]
        {
            get
            {
                return (ProjectCostBiz)this.List[intIndex];
            }
        }
        public List<int> YearLst
        {
            get
            {
                List<int> Returned = new List<int>();
                var vrProject = from objCost in this.Cast<ProjectCostBiz >()
                                orderby objCost.Date.Year
                                group objCost by new { Year = objCost.Date.Year } into objCode
                                select objCode;
                foreach (var vrProjectCode in vrProject)
                {
                    Returned.Add(vrProjectCode.Key.Year);
                }
                return Returned;
            }
        }
        public List<string> ProjectLst
        { get
            { List<string> Returned = new List<string>();
                var vrProjectCol = from objCost in this.Cast<ProjectCostBiz>()
                                group objCost by objCost.Project into strProject
                                select strProject;
                foreach (var vrProject in vrProjectCol)
                    Returned.Add(vrProject.Key);
                return Returned;
            }
        }
        public double TotalValue
        { get => Count>0? this.Cast<ProjectCostBiz>().Sum(x => x.Value):0;
                }
        public ProjectYearCol GetYearCol(ref Hashtable hsProjectYear)
        {

            string strKey = "";
                ProjectYearCol Returned = new ProjectYearCol();
                var vrYearCol = from objCost in this.Cast<ProjectCostBiz>()
                            orderby objCost.Year
                                group objCost by new ProjectYearBiz{ProjectCode=  objCost.Project,Year= objCost.Year ,StartDate=new DateTime(objCost.Year,1,1),EndDate=new DateTime(objCost.Year,12,31)} into objProjectYear
                             select objProjectYear;
                ProjectYearBiz objYearBiz;
                foreach(var vrYear in vrYearCol)
                {
                    objYearBiz = vrYear.Key;
                strKey = objYearBiz.ProjectCode + "-" + objYearBiz.Year.ToString();
                if (hsProjectYear[strKey] == null)
                {
                   // objYearBiz.CostCol = new ProjectCostCol(true);
                    hsProjectYear.Add(strKey, objYearBiz);
                }
                else
                {
                    objYearBiz = (ProjectYearBiz)hsProjectYear[strKey];
                }
                   
                    foreach (ProjectCostBiz objCostBiz in vrYear.ToList())
                        objYearBiz.CostCol.Add(objCostBiz);
                    Returned.Add(objYearBiz);

                }
                return Returned;

            
        }
        public string IDsStr
        { get
            {
                string Returned = "";
                foreach(ProjectCostBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned+= ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(ProjectCostBiz objBiz)
        {
            List.Add(objBiz);
        }
        public ProjectCostCol GetCol(string strTemp)
        {
            ProjectCostCol Returned = new ProjectCostCol(true);
            foreach (ProjectCostBiz objBiz in this)
            {
                if (objBiz.Project.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public void SetCostCol(ref ProjectYearBiz objYearBiz)
        {
            int intYear = objYearBiz.Year;
            string strProjectCode = objYearBiz.ProjectCode;

          
            List<ProjectCostBiz> lstCost = (from objCost in this.Cast<ProjectCostBiz>()
                                            where objCost.Year==intYear && objCost.Project==strProjectCode 
                                           orderby objCost.Year
                                           select objCost).ToList();
            foreach (ProjectCostBiz objBiz in lstCost)
            {
                
                    objYearBiz.CostCol.Add(objBiz);
            }
            //return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CostID"), new DataColumn("CostType"), new DataColumn("CostProject"), new DataColumn("CostValue"), new DataColumn("CostDate", System.Type.GetType("System.DateTime")), new DataColumn("CostROType"), new DataColumn("CostStartDate", System.Type.GetType("System.DateTime")), new DataColumn("CostEndDate", System.Type.GetType("System.DateTime")), new DataColumn("CostYear"), new DataColumn("CostFactor1"), new DataColumn("CostFactor2"), new DataColumn("CostFactor3") });
            DataRow objDr;
            foreach (ProjectCostBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CostID"] = objBiz.ID;
                objDr["CostType"] = objBiz.Type;
                objDr["CostProject"] = objBiz.Project;
                objDr["CostValue"] = objBiz.Value;
                objDr["CostDate"] = objBiz.Date;
                objDr["CostROType"] = objBiz.ROType;
                objDr["CostStartDate"] = objBiz.StartDate;
                objDr["CostEndDate"] = objBiz.EndDate;
                objDr["CostYear"] = objBiz.Year;
                objDr["CostFactor1"] = objBiz.Factor1;
                objDr["CostFactor2"] = objBiz.Factor2;
                objDr["CostFactor3"] = objBiz.Factor3;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void IntializeValue()
        {
            foreach (ProjectCostBiz objCost in this)
            {
                if (objCost.Year == 0)
                    objCost.Year = objCost.Date.Year;
            }
        }
        public ROCostCol GetRoCostCol(ROCol objRoCol)
        {
            ROCostCol Returned = new ROCostCol(true);
            double dblTemp = 0;
            DataTable dtTemp;
            foreach (ProjectCostBiz objProjectCostBiz in this)
            {
                Returned.Add(objProjectCostBiz.GetCostCol(objRoCol));
                dtTemp = Returned.GetTable();
            }
            return Returned;
        }
        public void DevideCostBetweenRo()
        {
            List<string> lstProject = ProjectLst;
            if(lstProject.Count == 0)
            {
                return;
            }
            ROCol objRoCol = new ROCol(lstProject);
            ROCostCol objCostCol = GetRoCostCol(objRoCol);
            DataTable dtCost = objCostCol.GetTable();
            if (objCostCol.Count == 0)
                return;
            ROCostDb objDb = new ROCostDb();
            objDb.CostTable = dtCost;
            objDb.AddProjectCostTable();

        }
        public void CancelDevision()
        {
            ProjectCostDb objDb = new ProjectCostDb() { IDs = IDsStr };
            objDb.CancelDevision();
        }
        #endregion
    }
}
