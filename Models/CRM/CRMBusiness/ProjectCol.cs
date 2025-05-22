using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ProjectCol : BaseCol
    {
        static ProjectCol _ProjectCol;

        public static ProjectCol CacheProjectCol
        {
            get
            {
                if (_ProjectCol == null)
                {
                    _ProjectCol = new ProjectCol(true);
                    ProjectBiz objProjectBiz = new ProjectBiz();
                    objProjectBiz.NameA = "€Ì— „Õœœ";
                    _ProjectCol.Add(objProjectBiz);
                    ProjectDb objDb = new ProjectDb();
                    DataTable dtTemp = objDb.Search();
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        _ProjectCol.Add(new ProjectBiz(objDr));
                    }
                }
                return ProjectCol._ProjectCol;
            }
            set { ProjectCol._ProjectCol = value; }
        }
        public ProjectCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            ProjectBiz objBiz;
            objBiz = new ProjectBiz();
            objBiz.ID = 0;
            objBiz.NameA = "„‘—Ê⁄";
            Add(objBiz);
            ProjectDb objDb = new ProjectDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ProjectBiz(objDr));
            }
        }
        public ProjectCol()
        {

        }

        public virtual ProjectBiz this[int intIndex]
        {
            get
            {
                return (ProjectBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ProjectBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public virtual void Add(ProjectBiz objProjectBiz)
        {

            this.List.Add(objProjectBiz);
        }
        public ProjectCol GetCol(string strText)
        {
            ProjectCol Returned = new ProjectCol(true);
            string[] arrStr = strText.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (ProjectBiz objBiz in this)
            {
                //blIsFound = true;
                //foreach (string strTemp in arrStr)
                //{
                //    if (SysUtility.ReplaceStringComp(objBiz.Name).IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1 &&
                //        SysUtility.ReplaceStringComp(objBiz.Code).IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1)
                //    { blIsFound = false; }
                //}
                if (objBiz.Name.CheckStr(strText) || objBiz.Code.CheckStr(strText))
                    Returned.Add(objBiz);
            }
            return Returned;
        }

    }
}
