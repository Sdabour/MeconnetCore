using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class TowerCol : BaseCol
    {
        static TowerCol _CacheTowerCol;
        ProjectCol _ProjectCol;

        public static TowerCol CacheTowerCol
        {
            get
            {
                if (_CacheTowerCol == null)
                {
                    _CacheTowerCol = new TowerCol(true);
                    TowerDb objDb = new TowerDb();
                    DataTable dtTemp = objDb.Search();
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        _CacheTowerCol.Add(new TowerBiz(objDr));
                    }

                }
                return TowerCol._CacheTowerCol;
            }
            set { TowerCol._CacheTowerCol = value; }
        }
        public virtual TowerBiz this[int intIndex]
        {
            get
            {
                return (TowerBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (TowerBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public ProjectCol ProjectCol
        {
            get
            {
                
                ProjectCol Returned = new ProjectCol(true);
                Hashtable hsTemp = new Hashtable();
                ProjectBiz objProjectBiz = new ProjectBiz();
                objProjectBiz.NameA = "€Ì— „Õœœ";
                objProjectBiz.NameE = "Not Specified";
                objProjectBiz.TowerCol = new TowerCol(true);
                TowerBiz objTowerBiz = new TowerBiz();
                objTowerBiz.Name = "€Ì— „Õœœ";
                objProjectBiz.TowerCol.Add(objTowerBiz);

                Returned.Add(objProjectBiz);
                hsTemp.Add(objProjectBiz.ID.ToString(), objProjectBiz);
                foreach (TowerBiz objBiz in this)
                {
                    if (hsTemp[objBiz.ProjectBiz.ID.ToString()] == null)
                    {
                        objProjectBiz = objBiz.ProjectBiz;
                        objProjectBiz.TowerCol = new TowerCol(true);
                        objProjectBiz.TowerCol.Add(objTowerBiz);
                        objProjectBiz.TowerCol.Add(objBiz);
                        hsTemp.Add(objProjectBiz.ID.ToString(), objProjectBiz);
                        Returned.Add(objProjectBiz);
                    }
                    else
                    {
                        objProjectBiz = (ProjectBiz)hsTemp[objBiz.ProjectBiz.ID.ToString()];
                        objProjectBiz.TowerCol.Add(objBiz);
                    }
                }
                return Returned;

            }
        }
        public TowerCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;


        }
        public TowerCol()
        {
            TowerDb objDb = new TowerDb();

            DataTable dtTemp = objDb.Search();
            TowerBiz objBiz = new TowerBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new TowerBiz(objDR));
            }

        }
        public TowerCol(ProjectBiz objProjectBiz, TowerTypeBiz objTypeBiz, TowerUsageTypeBiz objUsageTypeBiz)
        {
            TowerDb objDb = new TowerDb();
            objDb.Project = objProjectBiz == null ? 0 : objProjectBiz.ID;
            objDb.UsageType = objUsageTypeBiz == null ? 0 : objUsageTypeBiz.ID;
            objDb.BulidingType = objTypeBiz.ID;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "TowerProject,TowerOrder");
            foreach (DataRow objDr in arrDr)
            {
                Add(new TowerBiz(objDr));
            }
        }


        public virtual void Add(TowerBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public TowerCol GetCol(ProjectBiz objProjectBiz, string strCode, bool blHasNotSpecified)
        {
            TowerCol Returned = new TowerCol(true);

            if (blHasNotSpecified)
            {
                TowerBiz objTemp = new TowerBiz();
                objTemp.Name = "€Ì— „Õœœ";
                Returned.Add(objTemp);
                if (objProjectBiz == null || objProjectBiz.ID == 0)
                    return Returned;

            }
            if (objProjectBiz == null)
                objProjectBiz = new ProjectBiz();
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (TowerBiz objBiz in this)
            {
                if (objProjectBiz.ID != 0 && objProjectBiz.ID != objBiz.ProjectBiz.ID)
                    continue;



                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Code).IndexOf(SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1 &&
                        SysUtility.ReplaceStringComp(objBiz.Name).IndexOf(SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                        blIsFound = false;

                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public TowerCol Copy()
        {
            TowerCol Returned = new TowerCol(true);
            foreach (TowerBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}