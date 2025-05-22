using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class IDTypeCol : CollectionBase
    {
        public IDTypeCol()
        {
            IDTypeBiz objIDTypeBiz;
            
            IDTypeDb objIDTypeDb = new IDTypeDb();
            DataTable dtIDType = objIDTypeDb.Search();
            

            foreach (DataRow DR in dtIDType.Rows)
            {
                objIDTypeBiz = new IDTypeBiz(DR);

                this.Add(objIDTypeBiz);
            }

        }
        public IDTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                IDTypeBiz objIDTypeBiz;
                objIDTypeBiz = new IDTypeBiz();
                objIDTypeBiz.ID = 0;
                objIDTypeBiz.Name = "€Ì— „Õœœ";
                this.Add(objIDTypeBiz);
                IDTypeDb objIDTypeDb = new IDTypeDb();
                DataTable dtIDType = objIDTypeDb.Search();


                foreach (DataRow DR in dtIDType.Rows)
                {
                    objIDTypeBiz = new IDTypeBiz(DR);

                    this.Add(objIDTypeBiz);
                }
            }

        }
        public virtual IDTypeBiz this[int intIndex]
        {
            get
            {

                return (IDTypeBiz)this.List[intIndex];

            }
        }
        public virtual IDTypeBiz this[string strIndex]
        {
            get
            {
                IDTypeBiz Returned = new IDTypeBiz();
                foreach (IDTypeBiz objIDTypeBiz in this)
                {
                    if (objIDTypeBiz.Name == strIndex)
                    {
                        Returned = objIDTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(IDTypeBiz objIDTypeBiz)
        {
            if (this[objIDTypeBiz.Name].Name == null || this[objIDTypeBiz.Name].Name == "")
            {
                this.List.Add(objIDTypeBiz.Copy());
            }

        }
        public virtual void Add(IDTypeCol objIDTypeCol)
        {
            foreach (IDTypeBiz objIDTypeBiz in objIDTypeCol)
            {
                if (this[objIDTypeBiz.Name].ID == 0)
                    this.List.Add(objIDTypeBiz.Copy());

            }
        }
        public IDTypeCol Copy()
        {
            IDTypeCol Returned = new IDTypeCol(true);
            foreach (IDTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}
