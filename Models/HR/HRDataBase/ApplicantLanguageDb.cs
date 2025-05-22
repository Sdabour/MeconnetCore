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
    public class ApplicantLanguageDb
    {
        #region Private Data
        protected int _ApplicantID;
        protected int _LanguageID;
        protected int _LanguageQualificationID;
        protected int _OrderLanguage;
        protected string _OtherLanguage;
        protected string _Description;
        protected string _ApplicantIDs;
        #endregion
        #region Constructors
        public ApplicantLanguageDb()
        {
           
        }
        public ApplicantLanguageDb(DataRow objDR)
        {
            _LanguageID = int.Parse(objDR["LanguageID"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _LanguageQualificationID = int.Parse(objDR["LanguageQualificationID"].ToString());
            _Description = objDR["Description"].ToString();
            _OrderLanguage = int.Parse(objDR["OrderLanguage"].ToString());
            _OtherLanguage = objDR["OtherLanguage"].ToString();
        }
        public ApplicantLanguageDb(int intApplicantID)
        {
            _ApplicantID = intApplicantID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _LanguageID = int.Parse(objDR["LanguageID"].ToString());
            _OrderLanguage = int.Parse(objDR["OrderLanguage"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _LanguageQualificationID = int.Parse(objDR["LanguageQualificationID"].ToString());
            _Description = objDR["Description"].ToString();
            _OtherLanguage = objDR["OtherLanguage"].ToString();
            
        }
        #endregion
        #region Public Properties
        public int ApplicantID
        {
            set { _ApplicantID = value; }
            get { return _ApplicantID; }           
        }

        public int LanguageID
        {
            set { _LanguageID = value; }
            get { return _LanguageID; }           
        }
        public int OrderLanguage
        {
            set { _OrderLanguage = value; }
            get { return _OrderLanguage; }
        }
        public string OtherLanguage
        {
            set { _OtherLanguage = value; }
            get { return _OtherLanguage; }
        }
        public int LanguageQualificationID
        {
            set { _LanguageQualificationID = value; }
            get { return _LanguageQualificationID; }            
        }

        public string Description
        {
            set { _Description = value; }
            get { return _Description; }            
        }

        public static string SearchStr
        {
            get
            {
                string strReturn = " SELECT     HRApplicantLanguage.ApplicantID, HRApplicantLanguage.LanguageID, HRApplicantLanguage.LanguageQualificationID, HRApplicantLanguage.Description,HRApplicantLanguage.OrderLanguage,HRApplicantLanguage.OtherLanguage, " +
                                   " COMMONLanguageQualification.LanguageQualificationID AS Expr1, COMMONLanguageQualification.LanguageQualificationNameA, " +
                                   " COMMONLanguageQualification.LanguageQualificationNameE, COMMONLanguage.LanguageID AS Expr2, COMMONLanguage.LanguageNameA, " +
                                   " COMMONLanguage.LanguageNameE " +
                                   " FROM  HRApplicantLanguage INNER JOIN " +
                                   " COMMONLanguage ON HRApplicantLanguage.LanguageID = COMMONLanguage.LanguageID INNER JOIN " +
                                   " COMMONLanguageQualification ON HRApplicantLanguage.LanguageQualificationID = COMMONLanguageQualification.LanguageQualificationID";
                return strReturn;
            }
        }

        public  string AddStr
        {
            get
            {
                string strReturn = " INSERT INTO HRApplicantLanguage "+
                                   " (ApplicantID, LanguageID, LanguageQualificationID, Description,OrderLanguage,OtherLanguage, UsrIns, TimIns) " +
                                   " VALUES     (" + _ApplicantID + "," + _LanguageID + "," + _LanguageQualificationID + ",'" + _Description + "'," + _OrderLanguage + ",'" + _OtherLanguage + "'," + SysData.CurrentUser.ID + ",GetDate())";
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
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Delete()
        {
            string strSql = "delete from HRApplicantLanguage where ApplicantID = " + _ApplicantID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_LanguageID != 0)
                strSql = strSql + " and HRApplicantLanguage.LanguageID = " + _LanguageID;
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantLanguage.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantLanguage.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            strSql += " Order By OrderLanguage";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantLanguage");
        }
        #endregion
    }
}
