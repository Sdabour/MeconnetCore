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
    public class ApplicantHighestUniversityDegreeDb
    {
        #region Private Data
        protected int _ApplicantID;
        protected int _HighestUniversityDegree;
        protected string _HighestUniversityDegreeOther;
        protected string _FieldOfResearch;
        protected int _GraduationYear;
        protected int _Grade;
        protected string _ApplicantIDs;
        #endregion
        #region Constructors
        public ApplicantHighestUniversityDegreeDb()
        {
        }
        public ApplicantHighestUniversityDegreeDb(DataRow objDR)
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
        public int HighestUniversityDegree
        {
            set
            {
                _HighestUniversityDegree = value;
            }
            get
            {
                return _HighestUniversityDegree;
            }
        }
        public string HighestUniversityDegreeOther
        {
            set
            {
                _HighestUniversityDegreeOther = value;
            }
            get
            {
                return _HighestUniversityDegreeOther;
            }
        }
        public string FieldOfResearch
        {
            set
            {
                _FieldOfResearch = value;
            }
            get
            {
                return _FieldOfResearch;
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
                string Returned = " SELECT     HRApplicantHighestUniversityDegree.ApplicantID, HRApplicantHighestUniversityDegree.HighestUniversityDegree, "+
                                  " HRApplicantHighestUniversityDegree.HighestUniversityDegreeOther, HRApplicantHighestUniversityDegree.FieldOfResearch, "+
                                  " HRApplicantHighestUniversityDegree.GraduationYear, HRApplicantHighestUniversityDegree.Grade,HighestUniversityDegreeTable.*,GradeTable.*" +
                                  " FROM         HRApplicantHighestUniversityDegree" +
                                  " Left Outer Join (" + HighestUniversityDegreeDb.SearchStr + ") as HighestUniversityDegreeTable On HighestUniversityDegreeTable.HighestUniversityDegreeID = HRApplicantHighestUniversityDegree.HighestUniversityDegree " +
                                  " Left Outer Join (" + GradeDb.SearchStr + ") as GradeTable On GradeTable.GradeID = HRApplicantHighestUniversityDegree.Grade " +
                                  "";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO HRApplicantHighestUniversityDegree"+
                                  " (ApplicantID, HighestUniversityDegree, HighestUniversityDegreeOther,"+
                                  " FieldOfResearch, GraduationYear,"+
                                  " Grade, UsrIns, TimIns)"+
                                  " VALUES ("+
                                  " " + _ApplicantID + "," + _HighestUniversityDegree + ",'" + _HighestUniversityDegreeOther + "'," +
                                  " '" + _FieldOfResearch + "'," + _GraduationYear + "," +
                                  " " + _Grade + "," + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " Delete from HRApplicantHighestUniversityDegree where ApplicantID = " + _ApplicantID;
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _HighestUniversityDegree = int.Parse(objDR["HighestUniversityDegree"].ToString());
            _HighestUniversityDegreeOther = objDR["HighestUniversityDegreeOther"].ToString();
            _GraduationYear = int.Parse(objDR["GraduationYear"].ToString());
            _FieldOfResearch = objDR["FieldOfResearch"].ToString();
            _Grade = int.Parse(objDR["Grade"].ToString());
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
                strSql = strSql + " and HRApplicantHighestUniversityDegree.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantHighestUniversityDegree.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantHighestUniversityDegree");
        }
        #endregion
    }
}
