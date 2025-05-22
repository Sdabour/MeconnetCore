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
    public class ApplicantCourseDb 
    {
        #region PrivateData
        
        protected int _ApplicantID;        
        protected string _CourseName;
        protected string _Description;
        protected DateTime _FromDate;
        protected DateTime _ToDate;
        private bool _StatusFromDate;        
        protected bool _StatusToDate;
        protected string _ApplicantIDs;
        protected int _CoursePlace; 
        #endregion
        #region Constractors
        public ApplicantCourseDb()
        {
        }
        public ApplicantCourseDb(int intApplicantID)
        {
            _ApplicantID = intApplicantID;            
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];  
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _CourseName = objDR["CourseName"].ToString();
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
            _CoursePlace = int.Parse(objDR["CoursePlace"].ToString());
        }
        public ApplicantCourseDb(DataRow objDR)
        {
           _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _CourseName = objDR["CourseName"].ToString();
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
            _CoursePlace = int.Parse(objDR["CoursePlace"].ToString());
        }
        public ApplicantCourseDb(DataRow objDR, bool DrBelongStatus)
        {
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _CourseName = objDR["CourseName"].ToString();
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
            _CoursePlace = int.Parse(objDR["CoursePlace"].ToString());
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
        public string CourseName
        {
            set
            {
                _CourseName = value;
            }
            get
            {
                return _CourseName;
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
                string Returned = " SELECT     HRApplicantCourse.ApplicantID, HRApplicantCourse.CourseName, HRApplicantCourse.Description,"+
                                  " HRApplicantCourse.FromDate, HRApplicantCourse.ToDate,HRApplicantCourse.CoursePlace,CoursePlaceTable.* " +
                                  " FROM         HRApplicantCourse "+
                                  " Left Outer Join (" + CoursePlaceDb.SearchStr + ") as CoursePlaceTable ON CoursePlaceTable.CoursePlaceID = HRApplicantCourse.CoursePlace";
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

                string strReturn = " INSERT INTO HRApplicantCourse " +
                            " (ApplicantID, CourseName,  Description, FromDate, ToDate,CoursePlace, UsrIns, TimIns) " +
                            " VALUES     (" + _ApplicantID + ",'" + _CourseName.Replace("'", "''") + "','" + _Description.Replace("'", "''") + "'," + strFromDate + "," + strToDate + "," + _CoursePlace + "," + SysData.CurrentUser.ID + ",GetDate())";
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
        public int CoursePlace
        {
            set
            {
                _CoursePlace = value;
            }
            get
            {
                return _CoursePlace;
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
            if (_CourseName != "" && _CourseName != null)
                strSql = strSql + " and HRApplicantCourse.CourseName like  '%" + _CourseName + "%' ";
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantCourse.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantCourse.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantCourse");
        }
        public  void Delete()
        {
            string strSql = "delete from HRApplicantCourse where ApplicantID = " + _ApplicantID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);          
        }
        #endregion


    }
}
