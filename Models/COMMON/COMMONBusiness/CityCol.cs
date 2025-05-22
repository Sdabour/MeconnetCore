using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class CityCol : CollectionBase
    {
        public CityCol()
        {
            CityDb objCityDb = new CityDb();

            CityBiz objCityBiz;
            foreach (DataRow DR in objCityDb.Search().Rows)
            {
                objCityBiz = new CityBiz(DR);
                this.Add(objCityBiz);
            }


        }
        public CityCol(int intCountry)
        {
            CityDb objCityDb = new CityDb();
            objCityDb.CountrySearch = intCountry;
            CityBiz objCityBiz;
            objCityBiz = new CityBiz();
            objCityBiz.ID = 0;
            objCityBiz.NameA = "غير محدد";
            objCityBiz.NameE = "Not Specified";
            this.Add(objCityBiz);
            DataTable dtTemp = objCityDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                objCityBiz = new CityBiz(DR);
                this.Add(objCityBiz);
            }
        }
        public CityCol(string strNameAComp, int intCityID)
        {
            CityDb objCityDb = new CityDb();

            CityBiz objCityBiz;
            objCityDb.NameACompSearch = strNameAComp;
            objCityDb.CityIDSearch = intCityID;
            foreach (DataRow DR in objCityDb.Search().Rows)
            {
                objCityBiz = new CityBiz(DR);
                this.Add(objCityBiz);
            }


        }
        public CityCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CityDb objCityDb = new CityDb();

                CityBiz objCityBiz;
                objCityBiz = new CityBiz();
                objCityBiz.ID = 0;
                objCityBiz.NameA = "غير محدد";
                objCityBiz.NameE = "Not Specified";
                this.Add(objCityBiz);
                foreach (DataRow DR in objCityDb.Search().Rows)
                {
                    objCityBiz = new CityBiz(DR);
                    this.Add(objCityBiz);

                }


 
            }


        }

        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (CityBiz objCityBiz in this)
            {
                if (objCityBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual CityBiz this[int intIndex]
        {
            get
            {

                return (CityBiz)this.List[intIndex];

            }
        }

        public virtual CityBiz this[string strIndex]
        {
            get
            {
                CityBiz Returned = new CityBiz();
                foreach (CityBiz objCityBiz in this)
                {
                    if (objCityBiz.Name == strIndex)
                    {
                        Returned = objCityBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(CityBiz objCityBiz)
        {
            this.List.Add(objCityBiz);

        }

        public CityCol Copy()
        {
            CityCol Returned = new CityCol(true);
            foreach (CityBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }


    }
}

