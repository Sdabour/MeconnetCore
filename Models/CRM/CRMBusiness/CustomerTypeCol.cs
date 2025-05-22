using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class CustomerTypeCol : CollectionBase
    {
        public CustomerTypeCol()
        {
            CustomerTypeBiz objCustomerTypeBiz;

            CustomerTypeDb objCustomerTypeDb = new CustomerTypeDb();
            DataTable dtCustomerType = objCustomerTypeDb.Search();
            if (dtCustomerType == null)
                dtCustomerType = new DataTable();

            foreach (DataRow DR in dtCustomerType.Rows)
            {
                objCustomerTypeBiz = new CustomerTypeBiz(DR);

                this.Add(objCustomerTypeBiz);
            }

        }
        public CustomerTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CustomerTypeBiz objCustomerTypeBiz;
                objCustomerTypeBiz = new CustomerTypeBiz();
                objCustomerTypeBiz.ID = 0;
                objCustomerTypeBiz.NameA = "€Ì— „Õœœ";
                this.Add(objCustomerTypeBiz);
                CustomerTypeDb objCustomerTypeDb = new CustomerTypeDb();
                DataTable dtCustomerType = objCustomerTypeDb.Search();


                foreach (DataRow DR in dtCustomerType.Rows)
                {
                    objCustomerTypeBiz = new CustomerTypeBiz(DR);

                    this.Add(objCustomerTypeBiz);
                }
            }

        }
        public virtual CustomerTypeBiz this[int intIndex]
        {
            get
            {

                return (CustomerTypeBiz)this.List[intIndex];

            }
        }
        public virtual CustomerTypeBiz this[string strIndex]
        {
            get
            {
                CustomerTypeBiz Returned = new CustomerTypeBiz();
                foreach (CustomerTypeBiz objCustomerTypeBiz in this)
                {
                    if (objCustomerTypeBiz.Name == strIndex)
                    {
                        Returned = objCustomerTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        static CustomerTypeCol _CacheCustomerTypeCol;
        public static CustomerTypeCol CacheCustomerTypeCol
        {
            get
            {
                if(_CacheCustomerTypeCol == null)
                {
                    _CacheCustomerTypeCol = new CustomerTypeCol(false);
                }
                return _CacheCustomerTypeCol;
            }
        }
        public virtual void Add(CustomerTypeBiz objCustomerTypeBiz)
        {
            if (this[objCustomerTypeBiz.Name].Name == null || this[objCustomerTypeBiz.Name].Name == "")
            {
                this.List.Add(objCustomerTypeBiz.Copy());
            }

        }
        public virtual void Add(CustomerTypeCol objCustomerTypeCol)
        {
            foreach (CustomerTypeBiz objCustomerTypeBiz in objCustomerTypeCol)
            {
                if (this[objCustomerTypeBiz.Name].ID == 0)
                    this.List.Add(objCustomerTypeBiz.Copy());

            }
        }
        public CustomerTypeCol Copy()
        {
            CustomerTypeCol Returned = new CustomerTypeCol(true);
            foreach (CustomerTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}
