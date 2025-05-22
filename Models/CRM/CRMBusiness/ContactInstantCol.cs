using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using SharpVision.SystemBase;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class ContactInstantCol : CollectionBase
    {
        public ContactInstantCol()
        {
            ContactInstantDb objContactInstantDb = new ContactInstantDb();
            DataTable dtContact = objContactInstantDb.Search();
            ContactInstantBiz objContactInstantBiz;

            foreach (DataRow DR in dtContact.Rows)
            {
                objContactInstantBiz = new ContactInstantBiz(DR);

                this.Add(objContactInstantBiz);
            }

        }
        public ContactInstantCol(bool blIsEmpty)
        {

        }
        public virtual ContactInstantBiz this[int intIndex]
        {
            get
            {

                return (ContactInstantBiz)this.List[intIndex];

            }
        }
        public virtual ContactInstantBiz this[string strIndex]
        {
            get
            {
                ContactInstantBiz Returned = new ContactInstantBiz();
                foreach (ContactInstantBiz objContactInstantBiz in this)
                {
                    if (objContactInstantBiz.Name == strIndex)
                    {
                        Returned = objContactInstantBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(ContactInstantBiz objContactInstantBiz)
        {
            if (!Contains(objContactInstantBiz))
            {
                this.List.Add(objContactInstantBiz.Copy());
            }

        }
        public virtual void Add(ContactInstantCol objContactInstantCol)
        {
            foreach (ContactInstantBiz objContactInstantBiz in objContactInstantCol)
            {
                if (!Contains(objContactInstantBiz))
                    this.List.Add(objContactInstantBiz.Copy());

            }
        }
        public bool Contains(ContactInstantBiz objBiz)
        {
            foreach (ContactInstantBiz objTemp in this)
            {
                if (objTemp.ID == objBiz.ID && objTemp.ContactValue == objBiz.ContactValue)
                    return true;
            }
            return false;
        }
        public ContactInstantCol GetInstantCol(int intType)
        {
            ContactInstantCol Returned = new ContactInstantCol(true);
            foreach (ContactInstantBiz objBiz in this)
            {
                if (objBiz.ID== intType)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public ContactInstantCol Copy()
        {
            ContactInstantCol Returned = new ContactInstantCol(true);
            foreach (ContactInstantBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }


    }
}
