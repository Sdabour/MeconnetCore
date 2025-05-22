using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class TitleCol : CollectionBase
    {
        public TitleCol()
        {
            TitleDb objTitleDb = new TitleDb();

            TitleBiz objTitleBiz;
            foreach (DataRow DR in objTitleDb.Search().Rows)
            {
                objTitleBiz = new TitleBiz(DR);
                this.Add(objTitleBiz);

            }


        }
        public TitleCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                TitleDb objTitleDb = new TitleDb();

                TitleBiz objTitleBiz;
                objTitleBiz = new TitleBiz();
                objTitleBiz.ID = 0;
                objTitleBiz.NameA = "غير محدد";
                objTitleBiz.NameE = "Not Specified";
                this.Add(objTitleBiz);
                foreach (DataRow DR in objTitleDb.Search().Rows)
                {
                    objTitleBiz = new TitleBiz(DR);
                    this.Add(objTitleBiz);

                }

            }
        }

        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (TitleBiz objTitleBiz in this)
            {
                if (objTitleBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual TitleBiz this[int intIndex]
        {
            get
            {

                return (TitleBiz)this.List[intIndex];

            }
        }

        public virtual TitleBiz this[string strIndex]
        {
            get
            {
                TitleBiz Returned = new TitleBiz();
                foreach (TitleBiz objTitleBiz in this)
                {
                    if (objTitleBiz.Name == strIndex)
                    {
                        Returned = objTitleBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(TitleBiz objTitleBiz)
        {
            this.List.Add(objTitleBiz);

        }

        public TitleCol Copy()
        {
            TitleCol Returned = new TitleCol(true);
            foreach (TitleBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }


    }
}

