using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CategoryProjectEvaluationDb
    {

        #region Constructor
        public CategoryProjectEvaluationDb()
        {
        }
        public CategoryProjectEvaluationDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _CategoryID;
        public int CategoryID
        {
            set
            {
                _CategoryID = value;
            }
            get
            {
                return _CategoryID;
            }
        }
        double _MaxEvaluation;
        public double MaxEvaluation
        {
            set
            {
                _MaxEvaluation = value;
            }
            get
            {
                return _MaxEvaluation;
            }
        }
        int _ProjectID;
        public int ProjectID
        {
            set
            {
                _ProjectID = value;
            }
            get
            {
                return _ProjectID;
            }
        }
        double _MinEvaluation;
        public double MinEvaluation
        {
            set
            {
                _MinEvaluation = value;
            }
            get
            {
                return _MinEvaluation;
            }
        }
        double _AVGEvaluation;
        public double AVGEvaluation
        {
            set
            {
                _AVGEvaluation = value;
            }
            get
            {
                return _AVGEvaluation;
            }
        }
        double _EqualStep;
        public double EqualStep
        {
            set
            {
                _EqualStep = value;
            }
            get
            {
                return _EqualStep;
            }
        }
        double _AVGStep;
        public double AVGStep
        {
            set
            {
                _AVGStep = value;
            }
            get
            {
                return _AVGStep;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into CRMCategoryProjectEvaluation (CategoryID,MaxEvaluation,ProjectID,MinEvaluation,AVGEvaluation,EqualStep,AVGStep,UsrIns,TimIns) values (," + CategoryID + "," + MaxEvaluation + "," + ProjectID + "," + MinEvaluation + "," + AVGEvaluation + "," + EqualStep + "," + AVGStep + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update CRMCategoryProjectEvaluation set " + "CategoryID=" + CategoryID + "" +
           ",MaxEvaluation=" + MaxEvaluation + "" +
           ",ProjectID=" + ProjectID + "" +
           ",MinEvaluation=" + MinEvaluation + "" +
           ",AVGEvaluation=" + AVGEvaluation + "" +
           ",EqualStep=" + EqualStep + "" +
           ",AVGStep=" + AVGStep + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update CRMCategoryProjectEvaluation set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                // CRMCategoryProjectEvaluation
                string Returned = @" SELECT        dbo.CRMUnitCategory.CategoryID, MAX(dbo.CRMUnitNumericalEvaluation.UnitNumericEvaluation) AS MaxEvaluation, dbo.CRMProject.ProjectID, MIN(dbo.CRMUnitNumericalEvaluation.UnitNumericEvaluation) 
                                                    AS MinEvaluation, AVG(dbo.CRMUnitNumericalEvaluation.UnitNumericEvaluation) AS AVGEvaluation, (MAX(dbo.CRMUnitNumericalEvaluation.UnitNumericEvaluation) 
                                                    - MIN(dbo.CRMUnitNumericalEvaluation.UnitNumericEvaluation)) / 3 AS EqualStep, MAX(dbo.CRMUnitNumericalEvaluation.UnitNumericEvaluation) - AVG(dbo.CRMUnitNumericalEvaluation.UnitNumericEvaluation) 
                                                    AS AVGStep
                           FROM            dbo.CRMUnit INNER JOIN
                                                    dbo.CRMUnitNumericalEvaluation ON dbo.CRMUnit.UnitID = dbo.CRMUnitNumericalEvaluation.UnitID INNER JOIN
                                                    dbo.CRMTower ON dbo.CRMUnit.UnitTower = dbo.CRMTower.TowerID INNER JOIN
                                                    dbo.CRMProject ON dbo.CRMTower.TowerProject = dbo.CRMProject.ProjectID INNER JOIN
                                                    dbo.CRMUnitCategory ON dbo.CRMUnit.UnitCategory = dbo.CRMUnitCategory.CategoryID
                           GROUP BY dbo.CRMUnitCategory.CategoryID, dbo.CRMProject.ProjectID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CategoryID"] != null)
                int.TryParse(objDr["CategoryID"].ToString(), out _CategoryID);

            if (objDr.Table.Columns["MaxEvaluation"] != null)
                double.TryParse(objDr["MaxEvaluation"].ToString(), out _MaxEvaluation);

            if (objDr.Table.Columns["ProjectID"] != null)
                int.TryParse(objDr["ProjectID"].ToString(), out _ProjectID);

            if (objDr.Table.Columns["MinEvaluation"] != null)
                double.TryParse(objDr["MinEvaluation"].ToString(), out _MinEvaluation);

            if (objDr.Table.Columns["AVGEvaluation"] != null)
                double.TryParse(objDr["AVGEvaluation"].ToString(), out _AVGEvaluation);

            if (objDr.Table.Columns["EqualStep"] != null)
                double.TryParse(objDr["EqualStep"].ToString(), out _EqualStep);

            if (objDr.Table.Columns["AVGStep"] != null)
                double.TryParse(objDr["AVGStep"].ToString(), out _AVGStep);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
