
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class BranchTypeCol : CollectionBase
    {
        public BranchTypeCol()
        {
            BranchTypeBiz objBranchTypeBiz;

            BranchTypeDb objBranchTypeDb = new BranchTypeDb();
            DataTable dtBranchType = objBranchTypeDb.Search();


            foreach (DataRow DR in dtBranchType.Rows)
            {
                objBranchTypeBiz = new BranchTypeBiz(DR);

                this.Add(objBranchTypeBiz);
            }

        }
        public BranchTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                BranchTypeBiz objBranchTypeBiz;
                objBranchTypeBiz = new BranchTypeBiz();
                objBranchTypeBiz.ID = 0;
                objBranchTypeBiz.NameA = "غير محدد";
                this.Add(objBranchTypeBiz);
                BranchTypeDb objBranchTypeDb = new BranchTypeDb();
                DataTable dtBranchType = objBranchTypeDb.Search();


                foreach (DataRow DR in dtBranchType.Rows)
                {
                    objBranchTypeBiz = new BranchTypeBiz(DR);

                    this.Add(objBranchTypeBiz);
                }
            }

        }
        public virtual BranchTypeBiz this[int intIndex]
        {
            get
            {

                return (BranchTypeBiz)this.List[intIndex];

            }
        }
        public virtual BranchTypeBiz this[string strIndex]
        {
            get
            {
                BranchTypeBiz Returned = new BranchTypeBiz();
                foreach (BranchTypeBiz objBranchTypeBiz in this)
                {
                    if (objBranchTypeBiz.NameA == strIndex)
                    {
                        Returned = objBranchTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(BranchTypeBiz objBranchTypeBiz)
        {
            if (this[objBranchTypeBiz.NameA].NameA == null || this[objBranchTypeBiz.NameA].NameA == "")
            {
                this.List.Add(objBranchTypeBiz.Copy());
            }

        }
        public virtual void Add(BranchTypeCol objBranchTypeCol)
        {
            foreach (BranchTypeBiz objBranchTypeBiz in objBranchTypeCol)
            {
                if (this[objBranchTypeBiz.NameA].ID == 0)
                    this.List.Add(objBranchTypeBiz.Copy());

            }
        }
        public BranchTypeCol Copy()
        {
            BranchTypeCol Returned = new BranchTypeCol(true);
            foreach (BranchTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}

