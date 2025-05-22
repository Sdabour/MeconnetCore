using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class ContactCol : CollectionBase
    {
        public ContactCol()
        {
            ContactDb objContactDb = new ContactDb();
            DataTable dtContact = objContactDb.Search();
            ContactBiz objContactBiz;
            if (dtContact == null)
                dtContact = new DataTable();
            foreach (DataRow DR in dtContact.Rows)
            {
                objContactBiz = new ContactBiz(DR);

                this.Add(objContactBiz);
            }

        }
        public ContactCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                ContactDb objContactDb = new ContactDb();

                ContactBiz objContactBiz;
                objContactBiz = new ContactBiz();
                objContactBiz.ID = 0;
                objContactBiz.NameA = "€Ì— „Õœœ";
                objContactBiz.NameE = "Not Specified";
                this.Add(objContactBiz);
                foreach (DataRow DR in objContactDb.Search().Rows)
                {
                    objContactBiz = new ContactBiz(DR);
                    this.Add(objContactBiz);

                }



            }
        }
        public virtual ContactBiz this[int intIndex]
        {
            get
            {

                return (ContactBiz)this.List[intIndex];

            }
        }
        public virtual ContactBiz this[string strIndex]
        {
            get
            {
                ContactBiz Returned = new ContactBiz();
                foreach (ContactBiz objContactBiz in this)
                {
                    if (objContactBiz.Name == strIndex)
                    {
                        Returned = objContactBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(ContactBiz objContactBiz)
        {
            if (this[objContactBiz.Name].Name == null || this[objContactBiz.Name].Name == "")
            {
                this.List.Add(objContactBiz.Copy());
            }

        }
        public virtual void Add(ContactCol objContactCol)
        {
            foreach (ContactBiz objContactBiz in objContactCol)
            {
                if (this[objContactBiz.Name].ID == 0)
                    this.List.Add(objContactBiz.Copy());

            }
        }
        public ContactCol Copy()
        {
            ContactCol Returned = new ContactCol(true);
            foreach (ContactBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}

