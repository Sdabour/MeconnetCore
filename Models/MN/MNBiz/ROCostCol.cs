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
    public class ROCostCol : CollectionBase
    {

        #region Constructor
        public ROCostCol()
        {

        }
        public ROCostCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ROCostBiz objBiz = new ROCostBiz();


            ROCostDb objDb = new ROCostDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ROCostBiz(objDR);
                Add(objBiz);
            }
        }
        public ROCostCol(int intRO, List<int> lstYears)
        {

            ROCostBiz objBiz = new ROCostBiz();

            string strYears = "";
            foreach (int intYear in lstYears)
            {
                if (strYears != "")
                    strYears += ",";
                strYears += intYear.ToString();
            }
            ROCostDb objDb = new ROCostDb();
            objDb.YearStr = strYears;
            objDb.RO = intRO;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ROCostBiz(objDR);
                Add(objBiz);
            }
        }
        public ROCostCol(string strProjectCode,int intRO, CostTypeBiz objCostType, bool blIsDate, DateTime dtSTartDate, DateTime dtEndDate)
        {

            ROCostBiz objBiz = new ROCostBiz();


            ROCostDb objDb = new ROCostDb();
            objDb.ProjectCode = strProjectCode;
            objDb.RO = intRO;
            objDb.Type = objCostType.ID;
            objDb.IsDateRange = blIsDate;
            objDb.StartDate = dtSTartDate;
            objDb.EndDate = dtEndDate;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ROCostBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public ROCostBiz this[int intIndex]
        {
            get
            {
                return (ROCostBiz)this.List[intIndex];
            }
        }
        public List<int> YearLst
        {
            get
            {
                List<int> Returned = new List<int>();
                var vrRO = from objCost in this.Cast<ROCostBiz>()
                                orderby objCost.Date.Year
                                group objCost by new { Year = objCost.Date.Year } into objCode
                                select objCode;
                foreach (var vrROCode in vrRO)
                {
                    Returned.Add(vrROCode.Key.Year);
                }
                return Returned;
            }
        }
        public double TotalValue
        {
            get => Count > 0 ? this.Cast<ROCostBiz>().Sum(x => x.Value) : 0;
        }
       
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(ROCostBiz objBiz)
        {
            List.Add(objBiz);
        }
        public void Add(ROCostCol objCol)
        {
            foreach(ROCostBiz objBiz in objCol)
              List.Add(objBiz);
        }
        public ROCostCol GetCol(string strTemp)
        {
            ROCostCol Returned = new ROCostCol(true);
            foreach (ROCostBiz objBiz in this)
            {
                //if (objBiz.RO.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
       
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CostID"), new DataColumn("CostType"), new DataColumn("CostProjectCost"), new DataColumn("CostRO"), new DataColumn("CostValue"), new DataColumn("CostDate", System.Type.GetType("System.DateTime")), new DataColumn("CostStartDate", System.Type.GetType("System.DateTime")), new DataColumn("CostEndDate", System.Type.GetType("System.DateTime")), new DataColumn("CostYear"), new DataColumn("CostFactor1"), new DataColumn("CostFactor2"), new DataColumn("CostFactor3"),new DataColumn("CostCredit") });
            DataRow objDr;
            foreach (ROCostBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CostID"] = objBiz.ID;
                objDr["CostType"] = objBiz.Type;
                objDr["CostProjectCost"] = objBiz.ProjectCost;
                objDr["CostRO"] = objBiz.RO;
                
                objDr["CostValue"] = objBiz.Value;
                objDr["CostDate"] = objBiz.Date;
                
                objDr["CostStartDate"] = objBiz.StartDate;
                objDr["CostEndDate"] = objBiz.EndDate;
                objDr["CostYear"] = objBiz.Year;
                objDr["CostFactor1"] = objBiz.Factor1;
                objDr["CostFactor2"] = objBiz.Factor2;
                objDr["CostFactor3"] = objBiz.Factor3;
                objDr["CostCredit"] = 0;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void IntializeValue()
        {
            foreach (ROCostBiz objCost in this)
            {
                if (objCost.Year == 0)
                    objCost.Year = objCost.Date.Year;
            }
        }
        public ROCostCol GetROCostCol(double dblPerc)
        {
            ROCostCol Returned = new ROCostCol(true);
            return Returned;
        }
        #endregion
    }
}
