using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class NewsAttachmentTypeCol : CollectionBase
    {
        public NewsAttachmentTypeCol()
        {
            NewsAttachmentTypeBiz objNewsAttachmentTypeBiz;

            NewsAttachmentTypeDb objNewsAttachmentTypeDb = new NewsAttachmentTypeDb();
            DataTable dtNewsAttachmentType = objNewsAttachmentTypeDb.Search();


            foreach (DataRow DR in dtNewsAttachmentType.Rows)
            {
                objNewsAttachmentTypeBiz = new NewsAttachmentTypeBiz(DR);

                this.Add(objNewsAttachmentTypeBiz);
            }

        }
        public NewsAttachmentTypeCol(bool FlagNewsAttachmentTypeWorker, int NewsAttachmentTypeWorker)
        {
            NewsAttachmentTypeBiz objNewsAttachmentTypeBiz;

            NewsAttachmentTypeDb objNewsAttachmentTypeDb = new NewsAttachmentTypeDb(FlagNewsAttachmentTypeWorker, NewsAttachmentTypeWorker);
            DataTable dtNewsAttachmentType = objNewsAttachmentTypeDb.Search();


            foreach (DataRow DR in dtNewsAttachmentType.Rows)
            {
                objNewsAttachmentTypeBiz = new NewsAttachmentTypeBiz(DR);

                this.Add(objNewsAttachmentTypeBiz);
            }

        }
        public NewsAttachmentTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                NewsAttachmentTypeBiz objNewsAttachmentTypeBiz;
                objNewsAttachmentTypeBiz = new NewsAttachmentTypeBiz();
                objNewsAttachmentTypeBiz.ID = 0;
                objNewsAttachmentTypeBiz.NameA = "€Ì— „Õœœ";
                objNewsAttachmentTypeBiz.NameE = "Not Determined";
                this.Add(objNewsAttachmentTypeBiz);
                NewsAttachmentTypeDb objNewsAttachmentTypeDb = new NewsAttachmentTypeDb();
                DataTable dtNewsAttachmentType = objNewsAttachmentTypeDb.Search();


                foreach (DataRow DR in dtNewsAttachmentType.Rows)
                {
                    objNewsAttachmentTypeBiz = new NewsAttachmentTypeBiz(DR);

                    this.Add(objNewsAttachmentTypeBiz);
                }
            }

        }
        public virtual NewsAttachmentTypeBiz this[int intIndex]
        {
            get
            {

                return (NewsAttachmentTypeBiz)this.List[intIndex];

            }
        }

        public virtual NewsAttachmentTypeBiz this[string strIndex]
        {
            get
            {
                NewsAttachmentTypeBiz Returned = new NewsAttachmentTypeBiz();
                foreach (NewsAttachmentTypeBiz objNewsAttachmentTypeBiz in this)
                {
                    if (objNewsAttachmentTypeBiz.Name == strIndex)
                    {
                        Returned = objNewsAttachmentTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(NewsAttachmentTypeBiz objNewsAttachmentTypeBiz)
        {
            if (this[objNewsAttachmentTypeBiz.Name].Name == null || this[objNewsAttachmentTypeBiz.Name].Name == "")
            {
                this.List.Add(objNewsAttachmentTypeBiz.Copy());
            }
        }


        public virtual void Add(NewsAttachmentTypeCol objNewsAttachmentTypeCol)
        {
            foreach (NewsAttachmentTypeBiz objNewsAttachmentTypeBiz in objNewsAttachmentTypeCol)
            {
                if (this[objNewsAttachmentTypeBiz.Name].ID == 0)
                    this.List.Add(objNewsAttachmentTypeBiz.Copy());
            }
        }

        public NewsAttachmentTypeCol Copy()
        {
            NewsAttachmentTypeCol Returned = new NewsAttachmentTypeCol(true);
            foreach (NewsAttachmentTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}
