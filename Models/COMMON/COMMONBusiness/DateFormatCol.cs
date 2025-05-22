using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class DateFormatCol : CollectionBase
    {
        public DateFormatCol()
        {
            DateFormatBiz objDateFormatBiz;

            DateFormatDb objDateFormatDb = new DateFormatDb();
            DataTable dtDateFormat = objDateFormatDb.Search();


            foreach (DataRow DR in dtDateFormat.Rows)
            {
                objDateFormatBiz = new DateFormatBiz(DR);

                this.Add(objDateFormatBiz);
            }

        }
        public DateFormatCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                DateFormatBiz objDateFormatBiz;
                objDateFormatBiz = new DateFormatBiz();
                objDateFormatBiz.ID = 0;
                objDateFormatBiz.Name = "€Ì— „Õœœ";
                this.Add(objDateFormatBiz);
                DateFormatDb objDateFormatDb = new DateFormatDb();
                DataTable dtDateFormat = objDateFormatDb.Search();


                foreach (DataRow DR in dtDateFormat.Rows)
                {
                    objDateFormatBiz = new DateFormatBiz(DR);

                    this.Add(objDateFormatBiz);
                }
            }

        }
        public virtual DateFormatBiz this[int intIndex]
        {
            get
            {

                return (DateFormatBiz)this.List[intIndex];

            }
        }
        public virtual DateFormatBiz this[string strIndex]
        {
            get
            {
                DateFormatBiz Returned = new DateFormatBiz();
                foreach (DateFormatBiz objDateFormatBiz in this)
                {
                    if (objDateFormatBiz.Name == strIndex)
                    {
                        Returned = objDateFormatBiz;
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(DateFormatBiz objDateFormatBiz)
        {
            if (this[objDateFormatBiz.Name].Name== null || this[objDateFormatBiz.Name].Name == "")
            {
                this.List.Add(objDateFormatBiz);
            }

        }
        public virtual void Add(DateFormatCol objDateFormatCol)
        {
            foreach (DateFormatBiz objDateFormatBiz in objDateFormatCol)
            {
                if (this[objDateFormatBiz.Name].ID == 0)
                    this.List.Add(objDateFormatBiz);

            }
        }
        public DateFormatCol Copy()
        {
            DateFormatCol Returned = new DateFormatCol(true);
            foreach (DateFormatBiz objTemp in this)
            {
                Returned.Add(objTemp);
            }
            return Returned;
        }

    }
}
