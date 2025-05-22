
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class VisitEmployeeLOGINCol : BaseCol
    {
        public VisitEmployeeLOGINCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;

        }
        public VisitEmployeeLOGINCol(UMSBranchBiz objBranch, WorkGroupBiz objGroupBiz)
        {
            if (objBranch == null)
                objBranch = new UMSBranchBiz();
            if (objGroupBiz == null)
                objGroupBiz = new WorkGroupBiz();
            VisitEmployeeLOGINDb objDb = new VisitEmployeeLOGINDb();
            objDb.Branch = objBranch.ID;
            objDb.WorkGroup = objGroupBiz.ID;

            DataTable dtTemp = objDb.Search();
            VisitEmployeeLOGINBiz objBiz = new VisitEmployeeLOGINBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new VisitEmployeeLOGINBiz(objDR));
            }

        }
        public VisitEmployeeLOGINCol(int intID)
        {
            VisitEmployeeLOGINDb objDb = new VisitEmployeeLOGINDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            VisitEmployeeLOGINBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new VisitEmployeeLOGINBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual VisitEmployeeLOGINBiz this[int intIndex]
        {
            get
            {
                return (VisitEmployeeLOGINBiz)this.List[intIndex];
            }
        }

        public virtual void Add(VisitEmployeeLOGINBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public static WorkGroupCol GetGroupCol(UMSBranchBiz objBranchBiz, WorkGroupBiz objGroup)
        {
            if (objBranchBiz == null)
                objBranchBiz = new UMSBranchBiz();
            if (objGroup == null)
                objGroup = new WorkGroupBiz();

            WorkGroupCol Returned = new WorkGroupCol(true);
            VisitEmployeeLOGINDb objDb = new VisitEmployeeLOGINDb();
            objDb.Branch = objBranchBiz.ID;
            objDb.WorkGroup = objGroup.ID;

            objDb.IsCurrentDay = true;
            DataTable dtTemp = objDb.Search();
            VisitEmployeeLOGINBiz objBiz;
            Hashtable hsWG = new Hashtable();
            WorkGroupBiz objGroupBiz;
            EmployeeBiz objEmployee;
            foreach (DataRow objDr in dtTemp.Rows)
            {

                objBiz = new VisitEmployeeLOGINBiz(objDr);
                if (objBiz.LastUpdate.AddMinutes(15) < DateTime.Now)
                    continue;
                objGroupBiz = objBiz.GroupBiz;
                if (hsWG[objGroupBiz.ID.ToString()] == null)
                {
                    hsWG.Add(objGroupBiz.ID.ToString(), objGroupBiz);
                    Returned.Add(objGroupBiz);
                    objGroupBiz.EmployeeCol = new EmployeeCol(true);

                }
                else
                {
                    objGroupBiz = (WorkGroupBiz)hsWG[objGroupBiz.ID.ToString()];
                }
                objEmployee = objBiz.EmployeeBiz;
                objGroupBiz.EmployeeCol.Add(objEmployee);
            }
            return Returned;
        }
        public static EmployeeCol GetOnlineEmployeeCol(UMSBranchBiz objBranchBiz, WorkGroupBiz objGroup)
        {
            if (objBranchBiz == null)
                objBranchBiz = new UMSBranchBiz();
            if (objGroup == null)
                objGroup = new WorkGroupBiz();

            EmployeeCol Returned = new EmployeeCol(true);
            VisitEmployeeLOGINDb objDb = new VisitEmployeeLOGINDb();
            objDb.Branch = objBranchBiz.ID;
            objDb.WorkGroup = objGroup.ID;

            objDb.IsCurrentDay = true;
            DataTable dtTemp = objDb.Search();
            VisitEmployeeLOGINBiz objBiz;
            //Hashtable hsWG = new Hashtable();
            //WorkGroupBiz objGroupBiz;
            EmployeeBiz objEmployee;
            foreach (DataRow objDr in dtTemp.Rows)
            {

                objBiz = new VisitEmployeeLOGINBiz(objDr);
                if (objBiz.LastUpdate.AddMinutes(15) < DateTime.Now)
                    continue;
                //objGroupBiz = objBiz.GroupBiz;

                objEmployee = objBiz.EmployeeBiz;
                Returned.Add(objEmployee);
                // objGroupBiz.EmployeeCol.Add(objEmployee);
            }
            return Returned;
        }
    }
}

