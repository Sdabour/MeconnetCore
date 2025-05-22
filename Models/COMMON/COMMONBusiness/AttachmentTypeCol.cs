using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class AttachmentTypeCol : CollectionBase
    {
        public AttachmentTypeCol()
        {
            AttachmentTypeBiz objAttachmentTypeBiz;
            
            AttachmentTypeDb objAttachmentTypeDb = new AttachmentTypeDb();
            DataTable dtAttachmentType = objAttachmentTypeDb.Search();
            

            foreach (DataRow DR in dtAttachmentType.Rows)
            {
                objAttachmentTypeBiz = new AttachmentTypeBiz(DR);

                this.Add(objAttachmentTypeBiz);
            }

        }
        public AttachmentTypeCol(bool FlagAttachmentTypeWorker,int AttachmentTypeWorker)
        {
            AttachmentTypeBiz objAttachmentTypeBiz;

            AttachmentTypeDb objAttachmentTypeDb = new AttachmentTypeDb(FlagAttachmentTypeWorker, AttachmentTypeWorker);
            DataTable dtAttachmentType = objAttachmentTypeDb.Search();


            foreach (DataRow DR in dtAttachmentType.Rows)
            {
                objAttachmentTypeBiz = new AttachmentTypeBiz(DR);

                this.Add(objAttachmentTypeBiz);
            }

        }
        public AttachmentTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                AttachmentTypeBiz objAttachmentTypeBiz;
                objAttachmentTypeBiz = new AttachmentTypeBiz();
                objAttachmentTypeBiz.ID = 0;
                objAttachmentTypeBiz.NameA = "€Ì— „Õœœ";
                objAttachmentTypeBiz.NameE = "Not Determined";
                this.Add(objAttachmentTypeBiz);
                AttachmentTypeDb objAttachmentTypeDb = new AttachmentTypeDb();
                DataTable dtAttachmentType = objAttachmentTypeDb.Search();


                foreach (DataRow DR in dtAttachmentType.Rows)
                {
                    objAttachmentTypeBiz = new AttachmentTypeBiz(DR);

                    this.Add(objAttachmentTypeBiz);
                }
            }

        }
        public virtual AttachmentTypeBiz this[int intIndex]
        {
            get
            {

                return (AttachmentTypeBiz)this.List[intIndex];

         }   }

        public virtual AttachmentTypeBiz this[string strIndex]
        {
            get
            {
                AttachmentTypeBiz Returned = new AttachmentTypeBiz();
                foreach (AttachmentTypeBiz objAttachmentTypeBiz in this)
                {
                    if (objAttachmentTypeBiz.Name == strIndex)
                    {
                        Returned = objAttachmentTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(AttachmentTypeBiz objAttachmentTypeBiz)
        {
            if (this[objAttachmentTypeBiz.Name].Name == null || this[objAttachmentTypeBiz.Name].Name == "")
            {
                this.List.Add(objAttachmentTypeBiz.Copy());
            }
        }


        public virtual void Add(AttachmentTypeCol objAttachmentTypeCol)
        {
            foreach (AttachmentTypeBiz objAttachmentTypeBiz in objAttachmentTypeCol)
            {
                if (this[objAttachmentTypeBiz.Name].ID == 0)
                    this.List.Add(objAttachmentTypeBiz.Copy());
            }
        }

        public AttachmentTypeCol Copy()
        {
            AttachmentTypeCol Returned = new AttachmentTypeCol(true);
            foreach (AttachmentTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public AttachmentTypeCol GetCol(string strCode)
        {
            AttachmentTypeCol Returned = new AttachmentTypeCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (AttachmentTypeBiz objBiz in this)
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

    }

}
