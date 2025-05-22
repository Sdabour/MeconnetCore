using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class CityBiz : BaseSingleBiz
    {
        #region Private Data
        CountryBiz _CountryBiz; 
        #endregion
        #region Constructors
        public CityBiz()
        {
            _BaseDb = new CityDb();
            _CountryBiz = new CountryBiz();
        }
        public CityBiz(int intCityID)
        {
            _BaseDb = new CityDb(intCityID);
            _CountryBiz = new CountryBiz(((CityDb)_BaseDb).Country);

        }
        public CityBiz(DataRow objDR)
        {
            _BaseDb = new CityDb(objDR);
            _CountryBiz = new CountryBiz(objDR);

        }
        public CityBiz(CityDb objCityDb)
        {
            _BaseDb = objCityDb;
            _CountryBiz = new CountryBiz(((CityDb)_BaseDb).Country);
        }

        #endregion
        #region Public Properties
        public string NameAComp
        {
            set
            {
                ((CityDb)_BaseDb).NameAComp = value;
            }
            get
            {
                return ((CityDb)_BaseDb).NameAComp;
            }
        }
        public CountryBiz CountryBiz
        {
            set
            {
                _CountryBiz = value;
            }
            get
            {
                return _CountryBiz;
            }
        }
        #endregion
        #region Public Methods

        public static void Add(string strNameA, string strNameE,string strNameAComp,int intCountry)
        {
            CityDb objCityDb = new CityDb();
            objCityDb.NameA = strNameA;
            objCityDb.NameE = strNameE;
            objCityDb.NameAComp = strNameAComp;
            objCityDb.Country = intCountry;
            objCityDb.Add();

        }
        public static void Edit(int intID, string strNameA, string strNameE, string strNameAComp, int intCountry)
        {
            CityDb objCityDb = new CityDb();
            objCityDb.ID = intID;
            objCityDb.NameA = strNameA;
            objCityDb.NameE = strNameE;
            objCityDb.NameAComp = strNameAComp;
            objCityDb.Country = intCountry;
            objCityDb.Edit();

        }
        public static void Delete(int intID)
        {
            CityDb objCityDb = new CityDb();
            objCityDb.ID = intID;
            objCityDb.Delete();
        }
        public CityBiz Copy()
        {
            CityBiz Returned = new CityBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.NameAComp = this.NameAComp;
            Returned.CountryBiz = this.CountryBiz;

            return Returned;
        }
        #endregion
    }
}
