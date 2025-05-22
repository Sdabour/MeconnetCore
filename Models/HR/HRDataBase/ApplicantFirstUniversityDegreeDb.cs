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
    public class ApplicantFirstUniversityDegreeDb
    {
        #region Private Data
        protected int _ApplicantID;
        protected int _FirstUniversityDegree;
        protected int _University;
        protected int _FacultyInstitute;
        protected int _FacultyInstituteMajor;
        protected int _Grade;
        protected int _GraduationYear;
        protected string _GraduationProject;
        protected string _FirstUniversityDegreeOther;
        protected string _UniversityOther;
        protected string _FacultyInstituteOther;
        protected string _FacultyInstituteMajorOther;
        protected string _ApplicantIDs;
        #endregion
        #region Constructors
        public ApplicantFirstUniversityDegreeDb()
        {
        }
        public ApplicantFirstUniversityDegreeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
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
        public int FirstUniversityDegree
        {
            set
            {
                _FirstUniversityDegree = value;
            }
            get
            {
                return _FirstUniversityDegree;
            }
        }
        public int University
        {
            set
            {
                _University = value;
            }
            get
            {
                return _University;
            }
        }
        public int FacultyInstitute
        {
            set
            {
                _FacultyInstitute = value;
            }
            get
            {
                return _FacultyInstitute;
            }
        }
        public int FacultyInstituteMajor
        {
            set
            {
                _FacultyInstituteMajor = value;
            }
            get
            {
                return _FacultyInstituteMajor;
            }
        }
        public int Grade
        {
            set
            {
                _Grade = value;
            }
            get
            {
                return _Grade;
            }
        }
        public int GraduationYear
        {
            set
            {
                _GraduationYear = value;
            }
            get
            {
                return _GraduationYear;
            }
        }
        public string GraduationProject
        {
            set
            {
                _GraduationProject = value;
            }
            get
            {
                return _GraduationProject;
            }
        }
        public string FirstUniversityDegreeOther
        {
            set
            {
                _FirstUniversityDegreeOther = value;
            }
            get
            {
                return _FirstUniversityDegreeOther;
            }
        }
        public string UniversityOther
        {
            set
            {
                _UniversityOther = value;
            }
            get
            {
                return _UniversityOther;
            }
        }
        public string FacultyInstituteOther
        {
            set
            {
                _FacultyInstituteOther = value;
            }
            get
            {
                return _FacultyInstituteOther;
            }
        }
        public string FacultyInstituteMajorOther
        {
            set
            {
                _FacultyInstituteMajorOther = value;
            }
            get
            {
                return _FacultyInstituteMajorOther;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantFirstUniversityDegree.ApplicantID, HRApplicantFirstUniversityDegree.FirstUniversityDegree, " +
                                  " HRApplicantFirstUniversityDegree.University, HRApplicantFirstUniversityDegree.FacultyInstitute, " +
                                  " HRApplicantFirstUniversityDegree.FacultyInstituteMajor, HRApplicantFirstUniversityDegree.Grade, " +
                                  " HRApplicantFirstUniversityDegree.GraduationProject, HRApplicantFirstUniversityDegree.GraduationYear, " +
                                  " HRApplicantFirstUniversityDegree.FirstUniversityDegreeOther, HRApplicantFirstUniversityDegree.UniversityOther, " +
                                  " HRApplicantFirstUniversityDegree.FacultyInstituteOther, HRApplicantFirstUniversityDegree.FacultyInstituteMajorOther, " +
                                  " FirstUniversityDegreeTable.*,UniversityTable.*,FacultyInstituteTable.*,FacultyInstituteMajorTable.*,GradeTable.* FROM         HRApplicantFirstUniversityDegree" +
                                  " Left Outer Join (" + FirstUniversityDegreeDb.SearchStr + ") as FirstUniversityDegreeTable On FirstUniversityDegreeTable.FirstUniversityDegreeID = HRApplicantFirstUniversityDegree.FirstUniversityDegree " +
                                  " Left Outer Join (" + UniversityDb.SearchStr + ") as UniversityTable On UniversityTable.UniversityID = HRApplicantFirstUniversityDegree.University " +
                                  " Left Outer Join (" + FacultyInstituteDb.SearchStr + ") as FacultyInstituteTable On FacultyInstituteTable.FacultyInstituteID = HRApplicantFirstUniversityDegree.FacultyInstitute " +
                                  " Left Outer Join (" + FacultyInstituteMajorDb.SearchStr + ") as FacultyInstituteMajorTable On FacultyInstituteMajorTable.FacultyInstituteMajorID = HRApplicantFirstUniversityDegree.FacultyInstituteMajor " +
                                  " Left Outer Join (" + GradeDb.SearchStr + ") as GradeTable On GradeTable.GradeID = HRApplicantFirstUniversityDegree.Grade " +
                                  "";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO HRApplicantFirstUniversityDegree"+
                                  " (ApplicantID, FirstUniversityDegree, University,"+
                                  " FacultyInstitute, FacultyInstituteMajor, Grade,"+
                                  " GraduationProject, GraduationYear, FirstUniversityDegreeOther,"+
                                  " UniversityOther, FacultyInstituteOther,"+
                                  " FacultyInstituteMajorOther, UsrIns, TimIns)"+
                                  " VALUES ("+ _ApplicantID +","+ _FirstUniversityDegree +","+ _University +","+
                                  " "+ _FacultyInstitute +","+ _FacultyInstituteMajor +","+ _Grade +","+
                                  " '"+ _GraduationProject +"',"+ _GraduationYear +",'"+ _FirstUniversityDegreeOther +"',"+
                                  " '"+ _UniversityOther +"','"+ _FacultyInstituteOther +"',"+
                                  " '"+ _FacultyInstituteMajorOther +"',"+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " Delete from HRApplicantFirstUniversityDegree where ApplicantID = " + _ApplicantID;
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _FirstUniversityDegree = int.Parse(objDR["FirstUniversityDegree"].ToString());
            _University = int.Parse(objDR["University"].ToString());
            _FacultyInstitute = int.Parse(objDR["FacultyInstitute"].ToString());
            _FacultyInstituteMajor = int.Parse(objDR["FacultyInstituteMajor"].ToString());
            _Grade = int.Parse(objDR["Grade"].ToString());
            _GraduationYear = int.Parse(objDR["GraduationYear"].ToString());
            _GraduationProject = objDR["GraduationProject"].ToString();
            _FirstUniversityDegreeOther = objDR["FirstUniversityDegreeOther"].ToString();
            _UniversityOther = objDR["UniversityOther"].ToString();
            _FacultyInstituteOther = objDR["FacultyInstituteOther"].ToString();
            _FacultyInstituteMajorOther = objDR["FacultyInstituteMajorOther"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";           
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantFirstUniversityDegree.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantFirstUniversityDegree.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantFirstUniversityDegree");
        }
        #endregion
    }
}
