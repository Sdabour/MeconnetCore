using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    internal class ContactCol : CollectionBase
    {
        public ContactCol()
        {
            ContactDb1 objContactDb = new ContactDb1();
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
