using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class RecoginationMediaTypeCol : CollectionBase
    {
        public RecoginationMediaTypeCol()
        {
            RecoginationMediaTypeBiz objBiz;

            RecoginationMediaTypeDb objDb = new RecoginationMediaTypeDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new RecoginationMediaTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public RecoginationMediaTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                RecoginationMediaTypeBiz objBiz;
                objBiz = new RecoginationMediaTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                RecoginationMediaTypeDb objDb = new RecoginationMediaTypeDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new RecoginationMediaTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public RecoginationMediaTypeCol(bool blIsEmpty,int intRecoginationMediaType)
        {
            if (!blIsEmpty)
            {
                RecoginationMediaTypeBiz objBiz;
                objBiz = new RecoginationMediaTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                RecoginationMediaTypeDb objDb = new RecoginationMediaTypeDb();
                objDb.ID = intRecoginationMediaType;
                DataTable dtTemp = objDb.Search();

                
                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new RecoginationMediaTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual RecoginationMediaTypeBiz this[int intIndex]
        {
            get
            {
                return (RecoginationMediaTypeBiz)this.List[intIndex];
            }
        }

        public virtual RecoginationMediaTypeBiz this[string strIndex]
        {
            get
            {
                RecoginationMediaTypeBiz Returned = new RecoginationMediaTypeBiz();
                foreach (RecoginationMediaTypeBiz objBiz in this)
                {
                    if (objBiz.Name == strIndex)
                    {
                        Returned = objBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(RecoginationMediaTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(RecoginationMediaTypeCol objCol)
        {
            foreach (RecoginationMediaTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        public RecoginationMediaTypeCol Copy()
        {
            RecoginationMediaTypeCol Returned = new RecoginationMediaTypeCol(true);
            foreach (RecoginationMediaTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public string IDs
        {
            get
            {
                string strIDs = "";
                foreach (RecoginationMediaTypeBiz objBiz in this)
                {
                    if (strIDs != "")
                        strIDs += "," + objBiz.ID.ToString();
                    else
                        strIDs += objBiz.ID.ToString();
                }
                return strIDs;
            }
        }
    }
}
