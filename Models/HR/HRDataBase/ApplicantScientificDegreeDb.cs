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
    public class ApplicantScientificDegreeDb 
    {
        #region PrivateData
        protected int _ApplicantID;
        private int _UnivercityID;
        int _ApplicantGrade;

       
     
        protected int _ScientificDegreeID;
        protected int _DegreeFieldID;
        protected int _DegreeSubFieldID;
        protected string _Description;
        protected int _GraduationYear;
        protected DateTime _FromDate;
        protected DateTime _ToDate;
        private bool _StatusFromDate;        
        protected bool _StatusToDate;
        protected bool _Active;
        protected string _ApplicantIDs;
        #endregion

        #region Constractors

        public ApplicantScientificDegreeDb()
        {
        }

        public ApplicantScientificDegreeDb(int intApplicantID, int intScientificDegreeID)
        {
            _ApplicantID = intApplicantID;
            _ScientificDegreeID = intScientificDegreeID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _GraduationYear = int.Parse(objDR["GraduationYear"].ToString());
            _ApplicantGrade = int.Parse(objDR["ApplicantGrade"].ToString());
            _ScientificDegreeID = int.Parse(objDR["ScientificDegreeID"].ToString());
            
            if (objDR["DegreeFieldID"].ToString() != "")
                _DegreeFieldID = int.Parse(objDR["DegreeFieldID"].ToString());
            else
                _DegreeFieldID = 0;
            if (objDR["DegreeSubFieldID"].ToString() != "")
                _DegreeSubFieldID = int.Parse(objDR["DegreeSubFieldID"].ToString());
            else
                _DegreeSubFieldID = 0;

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

            if (objDR["Active"].ToString() == "True")
            {
                _Active = true;
            }
            else
            {
                _Active = false;
            }
        }

        public ApplicantScientificDegreeDb(DataRow objDR)
        {
            _ScientificDegreeID = int.Parse(objDR["ScientificDegreeID"].ToString());
            if (objDR["DegreeFieldID"].ToString() != "")
                _DegreeFieldID = int.Parse(objDR["DegreeFieldID"].ToString());
            else
                _DegreeFieldID = 0;
            if (objDR["DegreeSubFieldID"].ToString() != "")
                _DegreeSubFieldID = int.Parse(objDR["DegreeSubFieldID"].ToString());
            else
                _DegreeSubFieldID = 0;

            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _ApplicantGrade = int.Parse(objDR["ApplicantGrade"].ToString());
            if (objDR["GraduationYear"].ToString() != "")
                _GraduationYear = int.Parse(objDR["GraduationYear"].ToString());
            else
                _GraduationYear = 0;
                
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
            if (objDR["Active"].ToString() == "True")
            {
                _Active = true;
            }
            else
            {
                _Active = false;
            }
            
   

        }

        public ApplicantScientificDegreeDb(DataRow objDR, bool DrBelongStatus)
        {
            _ScientificDegreeID = int.Parse(objDR["ScientificDegreeID"].ToString());
            _ApplicantGrade = int.Parse(objDR["ApplicantGrade"].ToString());
            if (objDR["DegreeField"].ToString() != "")
                _DegreeFieldID = int.Parse(objDR["DegreeField"].ToString());
            else
                _DegreeFieldID = 0;
            if (objDR["DegreeSubField"].ToString() != "")
                _DegreeSubFieldID = int.Parse(objDR["DegreeSubField"].ToString());
            else
                _DegreeSubFieldID = 0;
            if (objDR["UnivercityID"].ToString() != "")
                _UnivercityID = int.Parse(objDR["UnivercityID"].ToString());
            else
                _UnivercityID = 0;

            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _GraduationYear = int.Parse(objDR["GraduationYear"].ToString());
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

            if (objDR["Active"].ToString() == "True")
            {
                _Active = true;
            }
            else
            {
                _Active = false;
            }
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
        public int UnivercityID
        {
            get { return _UnivercityID; }
            set { _UnivercityID = value; }
        }
        public int ApplicantGrade
        {
            get { return _ApplicantGrade; }
            set { _ApplicantGrade = value; }
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

        public int ScientificDegreeID
        {
            set
            {
                _ScientificDegreeID = value;
            }
            get
            {
                return _ScientificDegreeID;
            }

        }
        public int DegreeFieldID
        {
            set
            {
                _DegreeFieldID = value;
            }
            get
            {
                return _DegreeFieldID;
            }

        }
        public int DegreeSubFieldID
        {
            set
            {
                _DegreeSubFieldID = value;
            }
            get
            {
                return _DegreeSubFieldID;
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
        public bool Active
        {
            set
            {
                _Active = value;
            }
            get
            {
                return _Active;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantScientificDegree.ApplicantID ,HRApplicantScientificDegree.UnivercityID,HRApplicantScientificDegree.Active,HRApplicantScientificDegree.ScientificDegreeID,HRApplicantScientificDegree.GraduationYear , HRApplicantScientificDegree.Description ,HRApplicantScientificDegree.ApplicantGrade, " +
                                  " HRApplicantScientificDegree.FromDate , HRApplicantScientificDegree.ToDate,HRApplicantScientificDegree.DegreeFieldID,HRApplicantScientificDegree.DegreeSubFieldID ,ScientificDegreeTable.* ,DegreeFieldTable.*,DegreeSubFieldTable.* , UniversityTable.* " +
                                  " FROM  HRApplicantScientificDegree Left Outer JOIN " +
                                  " (" + ScientificDegreeDb.SearchStr + ") as ScientificDegreeTable ON HRApplicantScientificDegree.ScientificDegreeID = ScientificDegreeTable.DegreeID " +
                                  " Left Outer JOIN  (" + DegreeFieldDb.SearchStr + ") as DegreeFieldTable ON HRApplicantScientificDegree.DegreeFieldID = DegreeFieldTable.FieldID " +
                                  " Left Outer JOIN  (" + DegreeSubFieldDb.SearchStr + ") as DegreeSubFieldTable ON HRApplicantScientificDegree.DegreeSubFieldID = DegreeSubFieldTable.SubFieldID " +
                                  " Left Outer Join (" + COMMON.COMMONDataBase.UniversityDb.SearchStr + ") as UniversityTable on HRApplicantScientificDegree.UnivercityID = UniversityTable.UniversityID ";
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
                int intActive;
                if (_Active == true)
                    intActive = 1;
                else
                    intActive = 0;
                string strReturn=" INSERT INTO HRApplicantScientificDegree " +
                            " (ApplicantID, ScientificDegreeID,UnivercityID,GraduationYear, Description, FromDate, ToDate,DegreeFieldID,DegreeSubFieldID,ApplicantGrade,Active ,UsrIns, TimIns) " +
                            " VALUES     (" + _ApplicantID + "," + _ScientificDegreeID + "," + _UnivercityID + "," + _GraduationYear + ",'" + _Description + "'," + strFromDate + "," + strToDate + "," + _DegreeFieldID + "," + _DegreeSubFieldID + "," + intActive + ","+_ApplicantGrade+"," + SysData.CurrentUser.ID + ",GetDate())";
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
            if (_ScientificDegreeID != 0)
                strSql = strSql + " and HRApplicantScientificDegree.ScientificDegreeID = " + _ScientificDegreeID;
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantScientificDegree.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantScientificDegree.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            if(_UnivercityID != 0)
            {
                strSql = strSql + " and HRApplicantScientificDegree.UnivercityID = (" + _UnivercityID + ") ";
            }
            if (_ApplicantGrade != 0)
            {
                strSql = strSql + " and  HRApplicantScientificDegree.ApplicantGrade =(" + _ApplicantGrade + ") ";
            }
                
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantScientificDegree");
        }
        public  void Delete()
        {
            string strSql = "delete from HRApplicantScientificDegree where ApplicantID = " + _ApplicantID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);          
        }
        #endregion


    }
}
