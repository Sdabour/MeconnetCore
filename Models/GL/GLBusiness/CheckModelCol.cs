using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLDataBase;
using System.Collections;
namespace SharpVision.GL.GLBusiness
{
    public class CheckModelCol:CollectionBase
    {
         public CheckModelCol()
        {
            CheckModelBiz objCheckModelBiz;

            CheckModelDb objCheckModelDb = new CheckModelDb();
            DataTable dtCheckModel = objCheckModelDb.Search();


            foreach (DataRow DR in dtCheckModel.Rows)
            {
                objCheckModelBiz = new CheckModelBiz(DR);

                this.Add(objCheckModelBiz);
            }

        }
        public CheckModelCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CheckModelBiz objCheckModelBiz;
                objCheckModelBiz = new CheckModelBiz();
                objCheckModelBiz.ID = 0;
                objCheckModelBiz.Name = "€Ì— „Õœœ";
                this.Add(objCheckModelBiz);
                CheckModelDb objCheckModelDb = new CheckModelDb();
                DataTable dtCheckModel = objCheckModelDb.Search();


                foreach (DataRow DR in dtCheckModel.Rows)
                {
                    objCheckModelBiz = new CheckModelBiz(DR);

                    this.Add(objCheckModelBiz);
                }
            }

        }
        public virtual CheckModelBiz this[int intIndex]
        {
            get
            {

                return (CheckModelBiz)this.List[intIndex];

            }
        }
        public virtual CheckModelBiz this[string strIndex]
        {
            get
            {
                CheckModelBiz Returned = new CheckModelBiz();
                foreach (CheckModelBiz objCheckModelBiz in this)
                {
                    if (objCheckModelBiz.Name == strIndex)
                    {
                        Returned = objCheckModelBiz;
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(CheckModelBiz objCheckModelBiz)
        {
            if (this[objCheckModelBiz.Name].Name== null || this[objCheckModelBiz.Name].Name == "")
            {
                this.List.Add(objCheckModelBiz);
            }

        }
        public virtual void Add(CheckModelCol objCheckModelCol)
        {
            foreach (CheckModelBiz objCheckModelBiz in objCheckModelCol)
            {
                if (this[objCheckModelBiz.Name].ID == 0)
                    this.List.Add(objCheckModelBiz);

            }
        }
        public CheckModelCol Copy()
        {
            CheckModelCol Returned = new CheckModelCol(true);
            foreach (CheckModelBiz objTemp in this)
            {
                Returned.Add(objTemp);
            }
            return Returned;
        }

    }
}
