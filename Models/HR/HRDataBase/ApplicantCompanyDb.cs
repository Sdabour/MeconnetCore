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
    public class ApplicantCompanyDb 
    {
        #region PrivateData
        
        protected int _ApplicantID;        
        protected string _CompanyName;
        protected string _Description;
        protected DateTime _FromDate;
        protected DateTime _ToDate;
        private bool _StatusFromDate;        
        protected bool _StatusToDate;
        protected int _JobTypeID;
        protected int _JobTitleTypeID;
        protected int _JobNatureTypeID;    
        protected string _ApplicantIDs;
        #endregion

        #region Constractors

        public ApplicantCompanyDb()
        {
        }

        public ApplicantCompanyDb(int intApplicantID)
        {
            _ApplicantID = intApplicantID;            
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];  
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _CompanyName = objDR["CompanyName"].ToString();
            _Description = objDR["Description"].ToString();
            if ((objDR["FromDate"].ToString() == "") || (objDR["FromDate"].ToString() == null))
            {
                _StatusFromDate = false;
            }
            else
            {
                _StatusFromDate = true;
                _FromDate = DateTime.Parse(objDR["FromDate"].ToString());
            }

            if ((objDR["ToDate"].ToString() == "") || (objDR["ToDate"].ToString() == null))
            {
                _StatusToDate = false;
            }
            else
            {
                _StatusToDate = true;
                _ToDate = DateTime.Parse(objDR["ToDate"].ToString());
            }
            if (objDR["JobTypeID"].ToString() != "")
                _JobTypeID = int.Parse(objDR["JobTypeID"].ToString());
            if (objDR["JobTitleTypeID"].ToString() != "")
                _JobTitleTypeID = int.Parse(objDR["JobTitleTypeID"].ToString());
            if (objDR["JobNatureTypeID"].ToString() != "")
                _JobNatureTypeID = int.Parse(objDR["JobNatureTypeID"].ToString());
        }

        public ApplicantCompanyDb(DataRow objDR)
        {
           _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _CompanyName = objDR["CompanyName"].ToString();
            _Description = objDR["Description"].ToString();
            if ((objDR["FromDate"].ToString() == "") || (objDR["FromDate"].ToString() == null))
            {
                _StatusFromDate = false;
            }
            else
            {
                _StatusFromDate = true;
                _FromDate = DateTime.Parse(objDR["FromDate"].ToString());
            }

            if ((objDR["ToDate"].ToString() == "") || (objDR["ToDate"].ToString() == null))
            {
                _StatusToDate = false;
            }
            else
            {
                _StatusToDate = true;
                _ToDate = DateTime.Parse(objDR["ToDate"].ToString());
            }
            if (objDR["JobTypeID"].ToString() != "")
                _JobTypeID = int.Parse(objDR["JobTypeID"].ToString());
            if (objDR["JobTitleTypeID"].ToString() != "")
                _JobTitleTypeID = int.Parse(objDR["JobTitleTypeID"].ToString());
            if (objDR["JobNatureTypeID"].ToString() != "")
                _JobNatureTypeID = int.Parse(objDR["JobNatureTypeID"].ToString());

        }

        public ApplicantCompanyDb(DataRow objDR, bool DrBelongStatus)
        {
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _CompanyName = objDR["CompanyName"].ToString();
            _Description = objDR["Description"].ToString();
            if (bool.Parse(objDR["StatusFromDate"].ToString()) == false)
            {
                _StatusFromDate = false;
            }
            else
            {
                _StatusFromDate = true;
                _FromDate = DateTime.Parse(objDR["FromDate"].ToString());
            }

            if (bool.Parse(objDR["StatusToDate"].ToString()) == false)
            {
                _StatusToDate = false;
            }
            else
            {
                _StatusToDate = true;
                _ToDate = DateTime.Parse(objDR["ToDate"].ToString());
            }
            if (objDR["JobTypeID"].ToString() != "")
                _JobTypeID = int.Parse(objDR["JobTypeID"].ToString());
            if (objDR["JobTitleTypeID"].ToString() != "")
                _JobTitleTypeID = int.Parse(objDR["JobTitleTypeID"].ToString());
            if (objDR["JobNatureTypeID"].ToString() != "")
                _JobNatureTypeID = int.Parse(objDR["JobNatureTypeID"].ToString());

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
        public string CompanyName
        {
            set
            {
                _CompanyName = value;
            }
            get
            {
                return _CompanyName;
            }
        }
        public string Description
        {
            set
            {
                _Description = value;
            }
            get
            {
                return _Description;
            }
        }
        public DateTime FromDate
        {
            set { _FromDate = value; }
            get { return _FromDate; }
        }
        public DateTime ToDate
        {
            set { _ToDate = value; }
            get { return _ToDate; }
        }
        public bool StatusFromDate
        {
            set
            {
                _StatusFromDate = value;
            }
            get
            {
                return _StatusFromDate;
            }
        }
        public bool StatusToDate
        {
            set
            {
                _StatusToDate = value;
            }
            get
            {
                return _StatusToDate;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantCompany.ApplicantID, HRApplicantCompany.CompanyName, HRApplicantCompany.Description,"+
                                  " HRApplicantCompany.JobTypeID, HRApplicantCompany.JobTitleTypeID, HRApplicantCompany.JobNatureTypeID, " +
                                  " HRApplicantCompany.FromDate, HRApplicantCompany.ToDate FROM         HRApplicantCompany";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
               
                
                string strFromDate = "";
                string strToDate="";
                if (StatusFromDate == true)
                {
                    double FromDate = _FromDate.ToOADate() - 2;
                    strFromDate = FromDate.ToString();
                }
                else
                {
                    strFromDate = "Null";
                }

                if (StatusToDate == true)
                {
                    double ToDate = _ToDate.ToOADate() - 2;
                    strToDate = ToDate.ToString();
                }
                else
                {
                    strToDate = "Null";
                }

                string strReturn = " INSERT INTO HRApplicantCompany " +
                            " (ApplicantID, CompanyName,  Description, FromDate, ToDate,JobTypeID,JobTitleTypeID,JobNatureTypeID, UsrIns, TimIns) " +
                            " VALUES     (" + _ApplicantID + ",'" + _CompanyName.Replace("'", "''") + "','" + _Description.Replace("'", "''") + "'," + strFromDate + "," + strToDate + ","+
                            " " + _JobTypeID + "," + _JobTitleTypeID + "," + _JobNatureTypeID + "," + SysData.CurrentUser.ID + ",GetDate())";
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
        public int JobTypeID
        {
            set
            {
                _JobTypeID = value;
            }
            get
            {
                return _JobTypeID;
            }
        }
        public int JobTitleTypeID
        {
            set
            {
                _JobTitleTypeID = value;
            }
            get
            {
                return _JobTitleTypeID;
            }
        }
        public int JobNatureTypeID
        {
            set
            {
                _JobNatureTypeID = value;
            }
            get
            {
                return _JobNatureTypeID;
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
            if (_CompanyName != "")
                strSql = strSql + " and HRApplicantCompany.CompanyName like  '%" + _CompanyName + "%' ";
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantCompany.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantCompany.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantCompany");
        }
        public  void Delete()
        {
            string strSql = "delete from HRApplicantDegree where ApplicantID = " + _ApplicantID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);          
        }
        #endregion


    }
}
