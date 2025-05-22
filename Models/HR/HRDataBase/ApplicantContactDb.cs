using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;


namespace SharpVision.HR.HRDataBase
{
    public class ApplicantContactDb 
    {
        #region PrivateData

        protected int _ApplicantID;
        protected int _ContactID;
        protected string _ContactValue;
        protected string _ApplicantIDs;
        protected string _ContactIDs;
        #endregion

        #region Constractors

        public ApplicantContactDb()
        {
        }

        public ApplicantContactDb(int intApplicantID,int intContactID)
        {
            _ApplicantID = intApplicantID;
            _ContactID = intContactID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];  
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _ContactID = int.Parse(objDR["ContactID"].ToString());
            _ContactValue = objDR["ContactValue"].ToString();
                                       
        }

        public ApplicantContactDb(DataRow objDR)
        {
            _ContactID = int.Parse(objDR["ContactID"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _ContactValue = objDR["ContactValue"].ToString();            
        }
        #endregion
        #region PublicAccessories
        public int ApplicantID
        {
            set
            {
                _ApplicantID = value;
            }
            get
            {
                return _ApplicantID;
            }

        }
        public int ContactID
        {
            set
            {
                _ContactID = value;
            }
            get
            {
                return _ContactID;
            }

        }
        public string ContactValue
        {
            set
            {
                _ContactValue = value;
            }
            get
            {
                return _ContactValue;
            }
        }
       
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantContact.ApplicantID, HRApplicantContact.ContactID , HRApplicantContact.ContactValue ,ContactTypeTable.*" +
                                  " FROM         HRApplicantContact" +
                                  " inner join (" + ContactTypeDb.SearchStr + ") as ContactTypeTable " +
                                  " on ContactTypeTable.ContactTypeID = HRApplicantContact.ContactID ";                                  
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {                                  
                string strReturn=" INSERT INTO HRApplicantContact " +
                            " (ApplicantID, ContactID, ContactValue, UsrIns, TimIns) " +
                            " VALUES     (" + _ApplicantID + "," + _ContactID + ",'" + _ContactValue.Replace("'", "''") + "'," + SysData.CurrentUser.ID + ",GetDate())";
                return strReturn;
            }

        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        public string ContactIDs
        {
            set
            {
                _ContactIDs = value;
            }
        }
        #endregion
        #region Private Methods
     
        #endregion
        #region Public Methods
        public  void Add()
        {                      
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public  void Edit()
        {           
        }
        public  DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ContactID != 0)
                strSql = strSql + " and HRApplicantContact.ContactID = " + _ContactID;
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantContact.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantContact.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            if (_ContactIDs != null && _ContactIDs != "")
            {
                strSql = strSql + " and HRApplicantContact.ContactID in (" + _ContactIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantContact");
        }
        public  void Delete()
        {
            string strSql = "delete from HRApplicantContact where ApplicantID = " + _ApplicantID;
            if (_ContactIDs != null && _ContactIDs != "")
            {
                strSql += " And (ContactID in (" + _ContactIDs + "))";
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);          
        }
        #endregion


    }
}
