using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class AttachmentClassificationCol : CollectionBase
    {
        public AttachmentClassificationCol()
        {
            AttachmentClassificationDb objAttachmentClassificationDb = new AttachmentClassificationDb();

            AttachmentClassificationBiz objAttachmentClassificationBiz;
            foreach (DataRow DR in objAttachmentClassificationDb.Search().Rows)
            {
                objAttachmentClassificationBiz = new AttachmentClassificationBiz(DR);
                this.Add(objAttachmentClassificationBiz);

            }


        }
        public AttachmentClassificationCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                AttachmentClassificationDb objAttachmentClassificationDb = new AttachmentClassificationDb();

                AttachmentClassificationBiz objAttachmentClassificationBiz;
                objAttachmentClassificationBiz = new AttachmentClassificationBiz();
                objAttachmentClassificationBiz.ID = 0;
                objAttachmentClassificationBiz.NameA = "غير محدد";
                objAttachmentClassificationBiz.NameE = "Not Specified";
                this.Add(objAttachmentClassificationBiz);
                foreach (DataRow DR in objAttachmentClassificationDb.Search().Rows)
                {
                    objAttachmentClassificationBiz = new AttachmentClassificationBiz(DR);
                    this.Add(objAttachmentClassificationBiz);

                }


 
            }


        }
        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (AttachmentClassificationBiz objAttachmentClassificationBiz in this)
            {
                if (objAttachmentClassificationBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual AttachmentClassificationBiz this[int intIndex]
        {
            get
            {

                return (AttachmentClassificationBiz)this.List[intIndex];

            }
        }
        public virtual AttachmentClassificationBiz this[string strIndex]
        {
            get
            {
                AttachmentClassificationBiz Returned = new AttachmentClassificationBiz();
                foreach (AttachmentClassificationBiz objAttachmentClassificationBiz in this)
                {
                    if (objAttachmentClassificationBiz.Name == strIndex)
                    {
                        Returned = objAttachmentClassificationBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(AttachmentClassificationBiz objAttachmentClassificationBiz)
        {
            this.List.Add(objAttachmentClassificationBiz);

        }
        public AttachmentClassificationCol Copy()
        {
            AttachmentClassificationCol Returned = new AttachmentClassificationCol(true);
            foreach (AttachmentClassificationBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }


    }
}

