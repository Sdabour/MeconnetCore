using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using AlgorithmatMN.MN.MNDb;
namespace AlgorithmatMN.MN.MNBiz
{
    public class ProjectYearCol:CollectionBase
    {
        #region Private Data and Public Properties
        Hashtable _HsProjectYear= new Hashtable();

        #endregion
        #region Constructors
        public ProjectYearCol()
        { }
        public ProjectYearCol(int intLastYear,ProjectCostCol objCostCol,ROCol objRoCol)
        {
            List<int> lstYear = objRoCol.YearLst;
            lstYear.AddRange(objCostCol.YearLst);
            List<string> lstProject = objRoCol.ProjectCodeLst;
            Add(intLastYear, lstYear, lstProject);
            objRoCol.SetCredit( this,false);

        }
        public ProjectYearCol(int intLastYear,string strProject)
        {
            List<string> lstProjectCodes = new List<string>();
            lstProjectCodes.Add(strProject);
            ROCol objRoCol = new ROCol(lstProjectCodes);
            List<int> lstYear = objRoCol.YearLst;
            ProjectCostCol objCostCol =new ProjectCostCol(strProject,new List<int>());
            lstYear.AddRange(objCostCol.YearLst);
            List<string> lstProject = objRoCol.ProjectCodeLst;
            Add(intLastYear,lstYear, lstProject);
            objRoCol.SetCredit(this,false);
           

        }
        #endregion

        #region properties
        public ProjectYearBiz this[int intIndex]
        { get
            {
                return (ProjectYearBiz)List[intIndex];
            }
        }
        public ProjectYearBiz this[string strKey]
        {
            get { ProjectYearBiz Returned = new ProjectYearBiz();
                if (_HsProjectYear[strKey] != null)
                    Returned = (ProjectYearBiz)_HsProjectYear[strKey];
                return Returned;
            }
        }
        List<int> YearLst
        { get
            {
                List<int> Returned = new List<int>();
                var vrYear = from objYear in this.Cast<ProjectYearBiz>()
                             orderby objYear.Year
                             group objYear by objYear.Year into Year
                             select Year;
                foreach(var intyear in vrYear)
                {
                    Returned.Add(intyear.Key);
                }
                return Returned;
            }
        }
        public ROCol ROCol
        { get
            {
                ROCol Returned = new ROCol();
                Hashtable hsTemp = new Hashtable();
                foreach(ProjectYearBiz objYearBiz in this)
                {
                    foreach(ROBiz objRo in objYearBiz.CreditCol.ROCol)
                    {
                        if(hsTemp[objRo.Key]== null)
                        {
                            hsTemp.Add(objRo.Key, "");
                            Returned.Add(objRo);
                        }    
                    }
                }
                return Returned;
            }
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ProjectYearBiz objBiz)
        {
            if (_HsProjectYear[objBiz.Key] == null)
            {
                _HsProjectYear.Add(objBiz.Key, objBiz);
                List.Add(objBiz);

            }
        }
        public void Add(int intLastYear,List<int> lstYear,List<string> lstProject)
        {
            intLastYear = intLastYear == 0 ? DateTime.Now.Year - 1 : intLastYear;
            ProjectYearBiz objBiz;
            List<int> lstOrderedYear = (from objYear in lstYear
                                        orderby objYear
                                        select objYear).ToList();
            int intYear;
            if (lstOrderedYear.Count > 0)
            {
                intYear = lstOrderedYear[0];
                while (intYear <= intLastYear) 
                {
                    foreach(string strProject in lstProject)
                    {
                        objBiz = new ProjectYearBiz() { ProjectCode = strProject, Year = intYear };
                        Add(objBiz);
                    }
                    intYear++;
                }
            }
        }
        public  DataTable GetPivotTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("مشروع"), new DataColumn("وحدة"), new DataColumn("رقم_العقد"), new DataColumn("مساحة"), new DataColumn("عميل"), new DataColumn("رقم العميل"), new DataColumn("قيمة_الوديعة"), new DataColumn("تاريخ_استلام") });
            int intMainColumnCount = Returned.Columns.Count;
            List<int> lstYear = YearLst;
            foreach (int objYear in lstYear)
            {
                Returned.Columns.Add("مصاريف_السنة" + objYear.ToString());
                Returned.Columns.Add("وحدة_الحساب" + objYear.ToString());
                Returned.Columns.Add("عدد_الايام" + objYear.ToString());

                Returned.Columns.Add("افتتاحى" + objYear.ToString());
                Returned.Columns.Add("تكلفة" + objYear.ToString());
                Returned.Columns.Add("فايدة" + objYear.ToString());
                Returned.Columns.Add("اغلاق" + objYear.ToString());

            }
            DataRow objDr;
            string strTempColumnName = "";
             
                foreach (ROBiz objRo in ROCol)
                {
                    objDr = Returned.NewRow();
                    objDr["مشروع"] = objRo.ProjectCode;
                    objDr["وحدة"] = objRo.Code;
                    objDr["رقم_العقد"] = objRo.SapContract;
                    objDr["مساحة"] = objRo.Area.ToString();
                    objDr["عميل"] = objRo.Customer;
                    objDr["رقم العميل"] = objRo.SapCustomerNo;
                    objDr["قيمة_الوديعة"] = objRo.InitialMaintainanceValue;
                    objDr["تاريخ_استلام"] = ((DateTime)objRo.DeliveryDate).ToString("yyyy-MM-dd");
                    foreach (CreditBiz objCredit in objRo.CreditCol)
                    {
                        strTempColumnName = "مصاريف_السنة" + objCredit.Year.ToString();
                        objDr[strTempColumnName] = objCredit.YearBiz.CostCol.TotalValue;
                        strTempColumnName = "وحدة_الحساب" + objCredit.Year.ToString();
                        objDr[strTempColumnName] = objCredit.YearBiz.CostPart.ToString();
                        strTempColumnName = "عدد_الايام" + objCredit.Year.ToString();
                        objDr[strTempColumnName] = objCredit.Days;
                        strTempColumnName = "افتتاحى" + objCredit.Year.ToString();
                        objDr[strTempColumnName] = objCredit.CrditInitialValue.ToString("0,0.0");
                        strTempColumnName = "تكلفة" + objCredit.Year.ToString();
                        objDr[strTempColumnName] = objCredit.Cost.ToString("0,0.0");
                        strTempColumnName = "فايدة" + objCredit.Year.ToString();
                        objDr[strTempColumnName] = objCredit.BonusValue.ToString("0,0.0");
                        strTempColumnName = "اغلاق" + objCredit.Year.ToString();
                        objDr[strTempColumnName] = objCredit.Closing.ToString("0,0.0");

                    }
                    Returned.Rows.Add(objDr);
                }
             
                return Returned;
        }
        #endregion
    }
}
