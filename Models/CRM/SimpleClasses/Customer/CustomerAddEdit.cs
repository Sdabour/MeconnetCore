using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class CustomerAddEdit
    {
        //ID,Name,IDValue,IDType,CountryID,BirthDate,CustomerType,Country,Governorate,City,HomeAddress,Mobile1,Mobile2,HomePhone,WorkPhone,Email,Sex

        #region Properties
        public int ID
        {
            set;
            get;
        }
        public string Name
        {
            set;
            get;
        }
        public string IDValue
        {
            set;
            get;
        }
        public int IDType
        {
            set;
            get;
        }
        public int CountryID
        {
            set;
            get;
        }
        public DateTime BirthDate
        {
            set;
            get;
        }
        public int CustomerType
        {
            set;
            get;
        }
        public int Country
        {
            set;
            get;
        }
        public int Governorate
        {
            set;
            get;
        }
        public int City
        {
            set;
            get;
        }
        public string HomeAddress
        {
            set;
            get;
        }
        public string Mobile1
        {
            set;
            get;
        }
        public string Mobile2
        {
            set;
            get;
        }
        public string HomePhone
        {
            set;
            get;
        }
        public string WorkPhone
        {
            set;
            get;
        }
        public string Email
        {
            set;
            get;
        }
        public int Sex
        {
            set;
            get;
        }
        #endregion

    }
}