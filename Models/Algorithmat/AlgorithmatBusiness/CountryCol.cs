
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using System.Collections;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class CountryCol : CollectionBase
    {
        public CountryCol()
        {
            CountryBiz objCountryBiz;
            
            CountryDb objCountryDb = new CountryDb();
            DataTable dtCountry = objCountryDb.Search();
            

            foreach (DataRow DR in dtCountry.Rows)
            {
                objCountryBiz = new CountryBiz(DR);

                this.Add(objCountryBiz);
            }

        }
        public CountryCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CountryBiz objCountryBiz;
                objCountryBiz = new CountryBiz();
                objCountryBiz.ID = 0;
                objCountryBiz.NameA = "€Ì— „Õœœ";
                objCountryBiz.NameE = "Not Determined";
                objCountryBiz.NationalityA = "€Ì— „Õœœ";
                objCountryBiz.NationalityE = "Not Determined";
                this.Add(objCountryBiz);
                CountryDb objCountryDb = new CountryDb();
                DataTable dtCountry = objCountryDb.Search();


                foreach (DataRow DR in dtCountry.Rows)
                {
                    objCountryBiz = new CountryBiz(DR);

                    this.Add(objCountryBiz);
                }
            }

        }
        public virtual CountryBiz this[int intIndex]
        {
            get
            {

                return (CountryBiz)this.List[intIndex];

         }   }

        public virtual CountryBiz this[string strIndex]
        {
            get
            {
                CountryBiz Returned = new CountryBiz();
                foreach (CountryBiz objCountryBiz in this)
                {
                    if (objCountryBiz.Name == strIndex)
                    {
                        Returned = objCountryBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(CountryBiz objCountryBiz)
        {
            if (this[objCountryBiz.Name].Name == null || this[objCountryBiz.Name].Name == "")
            {
                this.List.Add(objCountryBiz.Copy());
            }
        }


        public virtual void Add(CountryCol objCountryCol)
        {
            foreach (CountryBiz objCountryBiz in objCountryCol)
            {
                if (this[objCountryBiz.Name].ID == 0)
                    this.List.Add(objCountryBiz.Copy());
            }
        }

        public CountryCol Copy()
        {
            CountryCol Returned = new CountryCol(true);
            foreach (CountryBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}
