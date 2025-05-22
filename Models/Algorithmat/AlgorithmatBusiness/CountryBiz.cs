using System;
using System.Collections.Generic;
using System.Text;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class CountryBiz : BaseSingleBiz
    {
   	
        #region Private Data
        
        #endregion
        #region Constructors
        public CountryBiz()
        {
            _BaseDb = new CountryDb();
        }
        public CountryBiz(int intCountryID)
        {
            _BaseDb = new CountryDb(intCountryID);
        }
        public CountryBiz(DataRow objDR)
        {
            _BaseDb = new CountryDb(objDR);
        }

        public CountryBiz(CountryDb objBaseDb)
        {
            _BaseDb = objBaseDb;
        }
        #endregion
        #region Public Properties
       
        
        public string NationalityA
        {
            set
            {
                ((CountryDb)_BaseDb).NationalityA = value;
            }
            get
            {
                return ((CountryDb)_BaseDb).NationalityA;
            }
        }
        public string NationalityE
        {
            set
            {
                ((CountryDb)_BaseDb).NationalityE = value;
            }
            get
            {
                return ((CountryDb)_BaseDb).NationalityE;
            }
        }
        public string CodeA
        {
            set
            {
                ((CountryDb)_BaseDb).CodeA = value;
            }
            get
            {
                return ((CountryDb)_BaseDb).CodeA;
            }
        }
        public string CodeE
        {
            set
            {
                ((CountryDb)_BaseDb).CodeE = value;
            }
            get
            {
                return ((CountryDb)_BaseDb).CodeE;
            }
        }
        public string Nationality
        {
            get
            {
                return ((CountryDb)_BaseDb).Nationality;
 
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strCountryNameA, string strCountryNameE, string strCountryNationalityA, string strCountryNationalityE, string strCountryCodeA, string strCountryCodeE)
        {

           CountryDb objBaseDb = new CountryDb();
            objBaseDb.NameA = strCountryNameA;
            objBaseDb.NameE = strCountryNameE;
            objBaseDb.NationalityA = strCountryNationalityA;
            objBaseDb.NationalityE = strCountryNationalityE;
            objBaseDb.CodeA = strCountryCodeA;
            objBaseDb.CodeE = strCountryCodeE;
            objBaseDb.Add();
        }
        public static void Edit(int intCountryID, string strCountryNameA, string strCountryNameE, string strCountryNationalityA, string strCountryNationalityE, string strCountryCodeA, string strCountryCodeE)
        {
            CountryDb objBaseDb = new CountryDb();
            objBaseDb.ID = intCountryID;
            objBaseDb.NameA = strCountryNameA;
            objBaseDb.NameE = strCountryNameE;
            objBaseDb.NationalityA = strCountryNationalityA;
            objBaseDb.NationalityE = strCountryNationalityE;
            objBaseDb.CodeA = strCountryCodeA;
            objBaseDb.CodeE = strCountryCodeE;
            objBaseDb.Edit();
        }
        public static void Delete(int intCountryID)
        {
            CountryDb objBaseDb = new CountryDb();
            objBaseDb.ID = intCountryID;
            objBaseDb.Delete();
        }
        public CountryBiz Copy()
        {
            CountryBiz Returned = new CountryBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.NationalityA = this.NationalityA;
            Returned.NationalityE = this.NationalityE;
            Returned.CodeA = this.CodeA;
            Returned.CodeE = this.CodeE;
            return Returned;
        }
        #endregion
    }
}
