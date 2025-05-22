using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.UMS.UMSDataBase;
using System.Collections;

namespace SharpVision.UMS.UMSBusiness
{
    public class WorkGroupCol : BaseCol
    {
        static WorkGroupCol _WorkGroupCol;
        Hashtable _WorkGroupHs = new Hashtable();
        public WorkGroupCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            WorkGroupDb objDb = new WorkGroupDb();

            DataTable dtTemp = objDb.Search();
            WorkGroupBiz objBiz = new WorkGroupBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            if (!blIsEmpty)
                Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new WorkGroupBiz(objDR));
            }

        }
        public WorkGroupCol()
        {
            WorkGroupDb objDb = new WorkGroupDb();

            DataTable dtTemp = objDb.Search();
            WorkGroupBiz objBiz = new WorkGroupBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new WorkGroupBiz(objDR));
            }
        }
        public WorkGroupCol(int intID)
        {
            WorkGroupDb objDb = new WorkGroupDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            WorkGroupBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new WorkGroupBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual WorkGroupBiz this[int intIndex]
        {
            get
            {
                return (WorkGroupBiz)this.List[intIndex];
            }
        }
        public virtual WorkGroupBiz this[string strIndex]
        {
            get
            {
                return _WorkGroupHs[strIndex] == null ? (WorkGroupBiz)_WorkGroupHs[strIndex] :
                    (WorkGroupBiz)_WorkGroupHs[strIndex];
            }
        }
        public static WorkGroupCol CurrentWorkGroupCol
        {
            get
            {
                if (_WorkGroupCol == null)
                    _WorkGroupCol = new WorkGroupCol();
                return _WorkGroupCol;
            }
        }
        public static SingleClassCol ALLVisitTypeCol
        {
            get
            {
                SingleClassCol Returned = GetVisitTypeCol(0);
                return Returned;
            }
        }
        public virtual void Add(WorkGroupBiz objBiz)
        {
            if (_WorkGroupHs[objBiz.ID.ToString()] == null)
            {

                this.List.Add(objBiz);
                _WorkGroupHs.Add(objBiz.ID.ToString(), objBiz);
            }
        }
        public WorkGroupCol GetCol(string strSearch)
        {
            WorkGroupCol Returned = new WorkGroupCol(true);
            string[] arrStr;
            arrStr = strSearch.Split("%".ToCharArray());
            bool blFound;
            foreach (WorkGroupBiz objBiz in this)
            {
                blFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (objBiz.Name.IndexOf(strTemp) == -1 && objBiz.Code.IndexOf(strTemp) == -1)
                        blFound = false;


                }
                if (blFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public WorkGroupCol Copy()
        {
            WorkGroupCol Returned = new WorkGroupCol(true);
            foreach (WorkGroupBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
        public static SingleClassCol GetVisitTypeCol(int intWorkGroup)
        {
            SingleClassCol Returned = new SingleClassCol();
            WorkGroupDb objDb = new WorkGroupDb();
            objDb.ID = intWorkGroup;
            DataTable dtTemp = objDb.GetVisitType();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                int intTemp;
                if (int.TryParse(objDr["VisitTypeID"].ToString(), out intTemp))
                    Returned.Add(new SingleClassBiz() { ID = intTemp, Name = objDr["VisitTypeNameA"].ToString() });
            }
            return Returned;
        }
    }
}
