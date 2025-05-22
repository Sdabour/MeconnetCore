using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReactionTypeCol : BaseCol
    {
        public ReactionTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            ReactionTypeDb objDb = new ReactionTypeDb();

            DataTable dtTemp = objDb.Search();
            ReactionTypeBiz objBiz = new ReactionTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new ReactionTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new ReactionTypeBiz(objDR));
            }

        }
        public ReactionTypeCol()
        {
            ReactionTypeDb objDb = new ReactionTypeDb();

            DataTable dtTemp = objDb.Search();
            ReactionTypeBiz objBiz = new ReactionTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new ReactionTypeBiz(objDR));
            }

        }
        public ReactionTypeCol(int intID)
        {
            ReactionTypeDb objDb = new ReactionTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            ReactionTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ReactionTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual ReactionTypeBiz this[int intIndex]
        {
            get
            {
                return (ReactionTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ReactionTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public ReactionTypeCol GetCol(string strCode)
        {
            ReactionTypeCol Returned = new ReactionTypeCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (ReactionTypeBiz objBiz in this)
            {
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
        public ReactionTypeCol Copy()
        {
            ReactionTypeCol Returned = new ReactionTypeCol(true);
            foreach (ReactionTypeBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
