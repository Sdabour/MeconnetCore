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
    public class ProjectImageCol : BaseCol
    {
        public ProjectImageCol(int intID)
        {
            ProjectImageDb objDb = new ProjectImageDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ProjectImageBiz(objDr));
            }
        }
        public ProjectImageCol()
        { 

        }

        public virtual ProjectImageBiz this[int intIndex]
        {
            get
            {
                return (ProjectImageBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ProjectImageBiz objProjectImageBiz)
        {

            this.List.Add(objProjectImageBiz);
        }
    }
}
