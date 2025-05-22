using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;


namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class CustomerBiz
    {

        #region Private Data and Public Properties
        CustomerDb _CustomerDb;
        public int ID
        {
            get { return _CustomerDb.ID; }
            set { _CustomerDb.ID = value; }
        }
       

        public string Mail
        {
            get { return _CustomerDb.Mail; }
            set { _CustomerDb.Mail = value; }
        }
       

        public string Password
        {
            get { return _CustomerDb.Password; }
            set { _CustomerDb.Password = value; }
        }
       
        public bool Confirmed
        {
            get { return _CustomerDb.Confirmed; }
            set { _CustomerDb.Confirmed = value; }
        }
       

        public DateTime Dis
        {
            get { return _CustomerDb.Dis; }
            set { _CustomerDb.Dis = value; }
        }
        public int LastSentID
        {
            get { return _CustomerDb.LastSentID; }
            set { _CustomerDb.LastSentID = value; }
        }
        public DateTime LastSentIDTime
        {
            get { return _CustomerDb.LastSentIDTime; }
            set { _CustomerDb.LastSentIDTime = value; }
        }
        #endregion
        #region Constructors
        public CustomerBiz()
        {
            _CustomerDb = new CustomerDb();
        }
        public CustomerBiz(DataRow objDr)
        {
            _CustomerDb = new CustomerDb(objDr);
        }
        public CustomerBiz(string strMail)
        {
            CustomerDb objDb = new CustomerDb();
            objDb.Mail = strMail;

        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _CustomerDb.Add();
        }
        public void Edit()
        {
            _CustomerDb.Edit();
        }
        public void Delete()
        {
            _CustomerDb.Delete();
        }
        public static int GetNewSentID()
        {
            int Returned = 0;
          double dblTemp = DateTime.Now.ToOADate();
           Returned = (int)(dblTemp*1000);
            return Returned;
        }
        public static CustomerBiz GetCustomerBiz(string strMail, string strPass)
        {
           
            CustomerBiz Returned = new CustomerBiz();
            CustomerDb objDb = new CustomerDb();
            int intLastID = GetNewSentID();
            objDb.LastSentID = intLastID;
            objDb.Mail = strMail;
            objDb.Password = strPass;
            objDb.Add();
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
                Returned = new CustomerBiz(dtTemp.Rows[0]);
            return Returned;
        }
        public void Confirm()
        {
            _CustomerDb.Confirmed = true;
            _CustomerDb.Confirm();

        }
        public static CustomerBiz GetCustomerBiz(int intCustomerID,int intLastID)
        {

            CustomerBiz Returned = new CustomerBiz();
            CustomerDb objDb = new CustomerDb();
            objDb.ID =intCustomerID;
            objDb.LastSentID = intLastID;
         
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
                Returned = new CustomerBiz(dtTemp.Rows[0]);
            return Returned;
        }
        #endregion
    }
}