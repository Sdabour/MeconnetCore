using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class CommentTypeCol : BaseCol
    {
        public CommentTypeCol(bool blIsEmpty)
        {
            CommentTypeDb objDb = new CommentTypeDb();

            DataTable dtTemp = objDb.Search();
            CommentTypeBiz objBiz = new CommentTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            if (!blIsEmpty)
                Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new CommentTypeBiz(objDR));
            }

        }
        public CommentTypeCol()
        {
            CommentTypeDb objDb = new CommentTypeDb();

            DataTable dtTemp = objDb.Search();
            CommentTypeBiz objBiz = new CommentTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new CommentTypeBiz(objDR));
            }
        }
        public CommentTypeCol(int intID)
        {
            CommentTypeDb objDb = new CommentTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            CommentTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CommentTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual CommentTypeBiz this[int intIndex]
        {
            get
            {
                return (CommentTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(CommentTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}
