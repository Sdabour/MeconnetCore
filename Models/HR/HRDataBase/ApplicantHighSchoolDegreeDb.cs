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
    public class ApplicantHighSchoolDegreeDb
    {
        #region Private Data
        protected int _ApplicantID;
        protected int _HighSchoolDegree;
        protected string _HighSchoolName;
        protected float _GradeValue;
        protected string _HighSchoolDegreeOther;
        protected string _ApplicantIDs;
        #endregion
        #region Constructors
        public ApplicantHighSchoolDegreeDb()
        {
        }
        public ApplicantHighSchoolDegreeDb(DataRow objDR)
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
        public int HighSchoolDegree
        {
            set
            {
                _HighSchoolDegree = value;
            }
            get
            {
                return _HighSchoolDegree;
            }
        }
        public string HighSchoolName
        {
            set
            {
                _HighSchoolName = value;
            }
            get
            {
                return _HighSchoolName;
            }
        }
        public float GradeValue
        {
            set
            {
                _GradeValue = value;
            }
            get
            {
                return _GradeValue;
            }
        }
        public string HighSchoolDegreeOther
        {
            set
            {
                _HighSchoolDegreeOther = value;
            }
            get
            {
                return _HighSchoolDegreeOther;
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
                string Returned = " SELECT HRApplicantHighSchoolDegree.ApplicantID, HRApplicantHighSchoolDegree.HighSchoolDegree, HRApplicantHighSchoolDegree.HighSchoolName, "+
                                  " HRApplicantHighSchoolDegree.GradeValue, HRApplicantHighSchoolDegree.HighSchoolDegreeOther,HighSchoolDegreeTable.* " +
                                  " FROM HRApplicantHighSchoolDegree"+
                                  " Left Outer Join (" + HighSchoolDegreeDb.SearchStr + ") as HighSchoolDegreeTable On HighSchoolDegreeTable.HighSchoolDegreeID = HRApplicantHighSchoolDegree.HighSchoolDegree " +
                                  "";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO HRApplicantHighSchoolDegree"+
                                  " (ApplicantID, HighSchoolDegree, HighSchoolName,"+
                                  " GradeValue, HighSchoolDegreeOther, UsrIns, TimIns)"+
                                  " VALUES ("+
                                  " " + _ApplicantID + "," + _HighSchoolDegree + ",'" + _HighSchoolName + "'," +
                                  " " + _GradeValue + ",'" + _HighSchoolDegreeOther + "'," +
                                  " " + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " Delete from HRApplicantHighSchoolDegree where ApplicantID = " + _ApplicantID;
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _HighSchoolDegree = int.Parse(objDR["HighSchoolDegree"].ToString());
            _HighSchoolName = objDR["HighSchoolName"].ToString();
            _GradeValue = float.Parse(objDR["GradeValue"].ToString());
            _HighSchoolDegreeOther = objDR["HighSchoolDegreeOther"].ToString();       
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
                strSql = strSql + " and HRApplicantHighSchoolDegree.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantHighSchoolDegree.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantHighSchoolDegree");
        }
        #endregion
    }
}
