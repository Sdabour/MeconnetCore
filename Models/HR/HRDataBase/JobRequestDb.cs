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
    public class JobRequestDb
    {
        #region Private Data
        protected int _ID=0;
        protected int _InterestFieldID;
        protected string _Title;
        protected string _TitleComp;
        protected string _Summary;
        protected string _Desc;
        protected DateTime _RequestDate;
        protected int _JobTypeID;
        protected int _JobTitleTypeID;
        protected int _JobNatureTypeID; 
        protected int _SubSectorID;
        protected int _SectorID;
        protected int _ScientificDegreeID;
        protected int _StartExperince;
        protected int _EndExperince;
        protected int _AvailableNum;
        protected DateTime _RequestEndDate;
        protected bool _RequestDateStatus;
        protected bool _RequestEndDateStatus;
        protected bool _AvailableJobStatusSearch;
        protected static DataTable _CashJobRequestTable;
        protected static DataTable _CashJobRequestQualificationTable;
        protected static DataTable _CashJobRequestStageTable;
        protected DataTable _QualificationTable;
        protected DataTable _StageTable;
        protected DataTable _DeleteStageTable;
        protected static string _JobRequestIDs;
        bool _EditSucceded;
        #region Search Variable
        
        protected string _TitleCompSearch;
        protected string _SummarySearch;
        protected string _DescSearch;
        
        protected int _JobTypeIDSearch;
        protected int _JobTitleTypeIDSearch;
        protected int _JobNatureTypeIDSearch;
        protected int _InterestFieldIDSearch;

        protected int _SubSectorIDSearch;
        protected int _ScientificDegreeIDSearch;
        protected int _StartExperinceSearch;
        protected int _EndExperinceSearch;
        
        protected DateTime _RequestDateSearch;
        protected DateTime _RequestEndDateSearch;
        protected bool _RequestDateStatusSearch;
        protected bool _RequestEndDateStatusSearch;
        protected string _JobRequestQualificationSearch;

        protected string _JobRequestQualificationDescSearch;
#endregion
        #endregion
        #region Constructors
        public JobRequestDb()
        {
        }
        public JobRequestDb(int intRequest)
        {
            _ID = intRequest;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public JobRequestDb(string strTitleComp)
        {
            _TitleCompSearch = strTitleComp;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public JobRequestDb(DataRow objDR)
        {
            SetData(objDR);
        }
        
              
#endregion
        #region Public Properties
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public int InterestFieldID
        {
            set { _InterestFieldID = value; }
            get { return _InterestFieldID; }
        }
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
        public string TitleComp
        {
            set { _TitleComp = value; }
            get { return _TitleComp; }
        }
        public string Summary
        {
            set { _Summary = value; }
            get { return _Summary; }
        }
        public string Desc
        {
            set { _Desc = value; }
            get { return _Desc; }
        }
        public DateTime RequestDate
        {
            set { _RequestDate = value; }
            get { return _RequestDate; }
        }
        public int JobTypeID
        {
            set { _JobTypeID = value; }
            get { return _JobTypeID; }
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
        public int SubSectorID
        {
            set { _SubSectorID = value; }
            get { return _SubSectorID; }
        }
        public int SectorID
        {
            set { _SectorID = value; }
            get { return _SectorID; }
        }
        public int ScientificDegreeID
        {
            set { _ScientificDegreeID = value; }
            get { return _ScientificDegreeID; }
        }
        public int StartExperince
        {
            set { _StartExperince = value; }
            get { return _StartExperince; }
        }
        public int EndExperince
        {
            set { _EndExperince = value; }
            get { return _EndExperince; }
        }
        public int AvailableNum
        {
            set { _AvailableNum = value; }
            get { return _AvailableNum; }
        }
        public DateTime RequestEndDate
        {
            set { _RequestEndDate = value; }
            get { return _RequestEndDate; }
        }
        public bool RequestDateStatus
        {
            set { _RequestDateStatus = value; }
            get { return _RequestDateStatus; }
        }
        public bool AvailableJobStatusSearch
        {
            set { _AvailableJobStatusSearch = value; }
            get { return _AvailableJobStatusSearch; }
        }
        public bool RequestEndDateStatus
        {
            set { _RequestEndDateStatus = value; }
            get { return _RequestEndDateStatus; }
        }
        public static string JobRequestIDs
        {
            get { return JobRequestDb._JobRequestIDs; }
            set { JobRequestDb._JobRequestIDs = value; }
        }
        public bool EditSucceded
        {
            get
            {
                return _EditSucceded;
            }
        }
        public static DataTable CashJobRequestTable 
        {
            set
            {
                _CashJobRequestTable = value;
            }
            get
            {
                return _CashJobRequestTable;
            }
        }
        public static DataTable CashJobRequestQualificationTable
        {
            set
            {
                _CashJobRequestQualificationTable = value;
            }
            get
            {
                if (_CashJobRequestQualificationTable == null && _JobRequestIDs != null && _JobRequestIDs != "")
                {
                    JobRequestQualificationDb objDb = new JobRequestQualificationDb();
                    objDb.JobRequestIDs = _JobRequestIDs;
                    _CashJobRequestQualificationTable = objDb.Search();
                }
                return _CashJobRequestQualificationTable;
            }
        }
        public static DataTable CashJobRequestStageTable
        {
            set
            {
                _CashJobRequestStageTable = value;
            }
            get
            {
                if (_CashJobRequestStageTable == null && _JobRequestIDs != null && _JobRequestIDs != "")
                {
                    JobRequestStageDb objDb = new JobRequestStageDb();
                    objDb.JobRequestIDs = _JobRequestIDs;
                    _CashJobRequestStageTable = objDb.Search();
                }
                return _CashJobRequestStageTable;
            }
        }
        public DataTable QualificationTable
        {
            set
            {
                _QualificationTable = value;
            }
        }
        public DataTable StageTable
        {
            set
            {
                _StageTable = value;
            }
        }
        public DataTable DeleteStageTable
        {
            set
            {
                _DeleteStageTable = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returnstr = "SELECT     HRJobRequest.RequestID, HRJobRequest.RequestTitle, HRJobRequest.RequestTitleComp, HRJobRequest.RequestSummary, HRJobRequest.RequestDesc, HRJobRequest.RequestDate, " +
                      "  HRJobRequest.RequestJobTypeID,HRJobRequest.RequestJobTitleTypeID,HRJobRequest.RequestJobNatureTypeID, HRJobRequest.RequestScientificDegreeID, " +
                      " HRJobRequest.RequestStartExperince,HRJobRequest.RequestEndExperince, HRJobRequest.RequestEndDate,HRJobRequest.RequestAvailableNum,HRJobRequest.RequestInterestFieldID ,SubSectorTable.*,JobTypeTable.*,ScientificDegreeTable.*," +
                      " JobTitleTypeTable.*,JobNatureTypeTable.*,FieldTypeTable.*" +
                      " FROM  HRJobRequest "+
                      " LEFT OUTER JOIN (" + SubSectorDb.SearchStr + ") as SubSectorTable On SubSectorTable.SubSectorID = HRJobRequest.SubSectorID" +
                      " LEFT OUTER JOIN (" + ScientificDegreeDb.SearchStr + ") as ScientificDegreeTable On ScientificDegreeTable.DegreeID = HRJobRequest.RequestScientificDegreeID " +
                      " lEFT OUTER JOIN (" + JobTypeDb.SearchStr + ") as JobTypeTable ON HRJobRequest.RequestJobTypeID = JobTypeTable.JobID " +
                      " lEFT OUTER JOIN (" + JobTitleTypeDb.SearchStr + ") as JobTitleTypeTable ON HRJobRequest.RequestJobTitleTypeID = JobTitleTypeTable.JobTitleID " +
                      " lEFT OUTER JOIN (" + JobNatureTypeDb.SearchStr + ") as JobNatureTypeTable ON HRJobRequest.RequestJobNatureTypeID = JobNatureTypeTable.JobNatureID "+
                      " lEFT OUTER JOIN (" + FieldTypeDb.SearchStr + ") as FieldTypeTable ON HRJobRequest.RequestInterestFieldID = FieldTypeTable.FieldID ";
                return Returnstr;
            }
        }
        public string AddStr
        {
            get
            {
                string RequestDateStr = "";
                if (_RequestDateStatus == true)
                {
                    double d = _RequestDate.ToOADate() - 2;
                    RequestDateStr = d.ToString();
                }
                else
                {
                    RequestDateStr = "Null";
                }

                string RequestEndDateStr = "";
                if (_RequestEndDateStatus == true)
                {
                    double d = _RequestEndDate.ToOADate() - 2;
                    RequestEndDateStr = d.ToString();
                }
                else
                {
                    RequestEndDateStr = "Null";
                }
                
                string strDegree = "";
                string strJob = "";
                string strSubSector = "";
                string strSector = "";
                string strStartExperince = "";
                string strEndExperince = "";
                
                //if (_JobTypeID != 0 && _JobTypeID != null)
                //    strJob = _JobTypeID.ToString();
                //else
                //    strJob = "Null";

                if (_SubSectorID != 0 )
                    strSubSector = _SubSectorID.ToString();
                else
                    strSubSector = "Null";

                if (_SectorID != 0 )
                    strSector = _SectorID.ToString();
                else
                    strSector = "Null";

                if (_ScientificDegreeID != 0 )
                    strDegree = _ScientificDegreeID.ToString();
                else
                    strDegree = "Null";

                if (_StartExperince != 0 )
                    strStartExperince = _StartExperince.ToString();
                else
                    strStartExperince = "Null";

                if (_EndExperince != 0 )
                    strEndExperince = _EndExperince.ToString();
                else
                    strEndExperince = "Null";



              


                string Returnstr = " INSERT INTO HRJobRequest"+
                      " (RequestTitle,RequestTitleComp, RequestSummary, RequestDesc," +
                      " RequestDate, RequestJobTypeID,RequestJobTitleTypeID,RequestJobNatureTypeID, SubSectorID," +
                      " SectorID, RequestScientificDegreeID, RequestStartExperince,RequestEndExperince, " +
                      " RequestEndDate,RequestAvailableNum ,RequestInterestFieldID, UsrIns, TimIns)" +
                      " VALUES     ("+
                      " '" + _Title + "','" + _TitleComp + "','" + _Summary + "','" + _Desc + "'," +
                      " " + RequestDateStr +"," + _JobTypeID +","+ _JobTitleTypeID +","+ _JobNatureTypeID +"," + strSubSector +"," +
                      " " + strSector + "," + strDegree + "," + strStartExperince + "," + strEndExperince + "," +
                      " " + RequestEndDateStr + "," + _AvailableNum + "," + _InterestFieldID + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returnstr;
            }
        }
        public string EditStr
        {
            get
            {
                string RequestDateStr = "";
                if (_RequestDateStatus == true)
                {
                    double d = _RequestDate.ToOADate() - 2;
                    RequestDateStr = d.ToString();
                }
                else
                {
                    RequestDateStr = "Null";
                }

                string RequestEndDateStr = "";
                if (_RequestEndDateStatus == true)
                {
                    double d = _RequestEndDate.ToOADate() - 2;
                    RequestEndDateStr = d.ToString();
                }
                else
                {
                    RequestEndDateStr = "Null";
                }

                string strDegree = "";
                string strJob = "";
                string strSubSector = "";
                string strSector = "";
                string strStartExperince = "";
                string strEndExperince = "";

                //if (_JobTypeID != 0 && _JobTypeID != null)
                //    strJob = _JobTypeID.ToString();
                //else
                //    strJob = "Null";

                if (_SubSectorID != 0 )
                    strSubSector = _SubSectorID.ToString();
                else
                    strSubSector = "Null";

                if (_SectorID != 0 )
                    strSector = _SectorID.ToString();
                else
                    strSector = "Null";

                if (_ScientificDegreeID != 0 )
                    strDegree = _ScientificDegreeID.ToString();
                else
                    strDegree = "Null";

                if (_StartExperince != 0 )
                    strStartExperince = _StartExperince.ToString();
                else
                    strStartExperince = "Null";

                if (_EndExperince != 0 )
                    strEndExperince = _EndExperince.ToString();
                else
                    strEndExperince = "Null";



                string Returnstr = "UPDATE    HRJobRequest " +
                " SET " +
                "  RequestTitle ='" + _Title + "'" +
                ", RequestTitleComp ='" + _TitleComp + "'" +
                ", RequestSummary ='" + _Summary + "'" +
                ", RequestDesc ='" + _Desc + "'" +
                ", RequestDate =" + RequestDateStr + "" +
                ", RequestJobTypeID =" + _JobTypeID + "" +
                ", RequestJobTitleTypeID =" + _JobTitleTypeID + "" +
                ", RequestJobNatureTypeID =" + _JobNatureTypeID + "" +
                ", SubSectorID =" + strSubSector + "" +
                ", SectorID =" + strSector + "" +
                ", RequestScientificDegreeID =" + strDegree + "" +
                ", RequestStartExperince =" + strStartExperince + "" +
                ", RequestEndExperince =" + strEndExperince + "" +
                ", RequestEndDate =" + RequestEndDateStr + "" +
                ", RequestAvailableNum =" + _AvailableNum + "" +
                ", RequestInterestFieldID = " + _InterestFieldID + ""+
                ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()"+
                " Where RequestID ="+ _ID +"";
                return Returnstr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returnstr = "DELETE FROM HRJobRequest Where RequestID = " + _ID + "";
                return Returnstr;
            }
        }

        #region Search Variable
        
        public string TitleCompSearch
        {
            set { _TitleCompSearch = value; }            
        }
        public string SummarySearch
        {
            set { _SummarySearch = value; }
            
        }
        public string DescSearch
        {
            set { _DescSearch = value; }
            get { return _DescSearch; }
        }
        public DateTime RequestDateSearch
        {
            set { _RequestDateSearch = value; }
            get { return _RequestDateSearch; }
        }
        public int JobTypeIDSearch
        {
            set { _JobTypeIDSearch = value; }
            
        }
        public int JobTitleTypeIDSearch
        {
            set { _JobTitleTypeIDSearch = value; }

        }
        public int JobNatureTypeIDSearch
        {
            set { _JobNatureTypeIDSearch = value; }

        }
        public int InterestFieldIDSearch
        {
            set { _InterestFieldIDSearch = value; }

        }
        public int SubSectorIDSearch
        {
            set { _SubSectorIDSearch = value; }
            
        }
        public int ScientificDegreeIDSearch
        {
            set { _ScientificDegreeIDSearch = value; }
            
        }
        public int StartExperinceSearch
        {
            set { _StartExperinceSearch = value; }
           
        }
        public int EndExperinceSearch
        {
            set { _EndExperinceSearch = value; }
            
        }
        public DateTime RequestEndDateSearch
        {
            set { _RequestEndDateSearch = value; }
            
        }
        public bool RequestDateStatusSearch
        {
            set { _RequestDateStatusSearch = value; }
            
        }
        public bool RequestEndDateStatusSearch
        {
            set { _RequestEndDateStatusSearch = value; }            
        }
        
        #endregion
        #endregion
        #region Private Methods
        
        void JoinJobRequestQualification()
        {
            string[] arrStr = new string[_QualificationTable.Rows.Count + 1];
            arrStr[0] = "DELETE FROM HRJobRequestQualification Where RequestID = "+ _ID +"";

            if (_QualificationTable == null || _QualificationTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                JobRequestQualificationDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _QualificationTable.Rows)
                {
                    objDb = new JobRequestQualificationDb(objDr);
                    objDb.RequestID = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinRequestStage()
        {
            string[] arrStr = new string[_StageTable.Rows.Count];

            if (_StageTable == null || _StageTable.Rows.Count == 0)
            {
                return;
            }
            else
            {

                JobRequestStageDb objDb;
                int intIndex = 0;
                string strTemp = "";
                foreach (DataRow objDr in _StageTable.Rows)
                {
                    objDb = new JobRequestStageDb(objDr);

                    if (objDb.StageID != 0)
                    {
                        //objDb.RequestStageEstimationStatement = _EstimationStatementID;
                        strTemp = objDb.EditStr;
                        arrStr[intIndex] = strTemp;
                        intIndex++;
                    }
                    else
                    {
                        objDb.StageRequest = _ID;
                        strTemp = objDb.AddStr;
                        arrStr[intIndex] = strTemp;
                        intIndex++;
                    }
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void DeleteRequestStage()
        {
            string[] arrStr = new string[_DeleteStageTable.Rows.Count];

            if (_DeleteStageTable == null || _DeleteStageTable.Rows.Count == 0)
            {
                return;
            }
            else
            {

                JobRequestStageDb objDb;
                int intIndex = 0;
                string strTemp = "";
                foreach (DataRow objDr in _DeleteStageTable.Rows)
                {
                    objDb = new JobRequestStageDb(objDr);
                    //objDb.RequestStageEstimationStatement = _EstimationStatementID;
                    strTemp = objDb.EditStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
#endregion
        #region Public Methods
        public void SetData(DataRow objDR)
        {
            try
            {
                if (objDR["RequestID"].ToString() == "" || objDR["RequestID"].ToString()=="0")
                    return;
                _ID = int.Parse(objDR["RequestID"].ToString());
                _AvailableNum = int.Parse(objDR["RequestAvailableNum"].ToString());
                if (objDR["RequestInterestFieldID"].ToString() != "")
                    _InterestFieldID = int.Parse(objDR["RequestInterestFieldID"].ToString());

                _Title = objDR["RequestTitle"].ToString();
                _TitleComp = objDR["RequestTitleComp"].ToString();
                _Summary = objDR["RequestSummary"].ToString();
                _Desc = objDR["RequestDesc"].ToString();

                if (objDR["RequestJobTypeID"].ToString() != "")
                    _JobTypeID = int.Parse(objDR["RequestJobTypeID"].ToString());
                if (objDR["RequestJobTitleTypeID"].ToString() != "")
                    _JobTitleTypeID = int.Parse(objDR["RequestJobTitleTypeID"].ToString());
                if (objDR["RequestJobNatureTypeID"].ToString() != "")
                    _JobNatureTypeID = int.Parse(objDR["RequestJobNatureTypeID"].ToString());



                if (objDR["SubSectorID"].ToString() != "")
                    _SubSectorID = int.Parse(objDR["SubSectorID"].ToString());
                else
                    _SubSectorID = 0;

                if (objDR["SectorID"].ToString() != "")
                    _SectorID = int.Parse(objDR["SectorID"].ToString());
                else
                    _SectorID = 0;

                if (objDR["RequestScientificDegreeID"].ToString() != "")
                    _ScientificDegreeID = int.Parse(objDR["RequestScientificDegreeID"].ToString());
                else
                    _ScientificDegreeID = 0;

                if (objDR["RequestStartExperince"].ToString() != "")
                    _StartExperince = int.Parse(objDR["RequestStartExperince"].ToString());
                else
                    _StartExperince = 0;

                if (objDR["RequestEndExperince"].ToString() != "")
                    _EndExperince = int.Parse(objDR["RequestEndExperince"].ToString());
                else
                    _EndExperince = 0;


                if (objDR["RequestDate"].ToString() != "")
                {
                    _RequestDateStatus = true;
                    _RequestDate = DateTime.Parse(objDR["RequestDate"].ToString());
                }
                else
                {
                    _RequestDateStatus = false;
                }
                if (objDR["RequestEndDate"].ToString() != "")
                {
                    _RequestEndDateStatus = true;
                    _RequestEndDate = DateTime.Parse(objDR["RequestEndDate"].ToString());
                }
                else
                {
                    _RequestEndDateStatus = false;
                }
            }
            catch (Exception Ex)
            {

            }
        }
        public void Add()
        {
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            JoinJobRequestQualification();
            JoinRequestStage();
            DeleteRequestStage();
        }
        public void Edit()
        {
            _EditSucceded = true;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
            JoinJobRequestQualification();
            JoinRequestStage();
            DeleteRequestStage();
            _EditSucceded = true;
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and HRJobRequest.RequestID = " + _ID;
            if(_TitleComp !="" && _TitleComp != null)
                strSql = strSql + " and HRJobRequest.RequestTitleComp like '%" + _TitleComp + "%'";
            if (_TitleCompSearch != "" && _TitleCompSearch != null)
                strSql = strSql + " and HRJobRequest.RequestTitleComp like '%" + _TitleCompSearch + "%'";
            if (_SummarySearch != "" && _SummarySearch != null)
                strSql = strSql + " and HRJobRequest.RequestSummary like '%" + _SummarySearch + "%'";
            if (_DescSearch != "" && _DescSearch != null)
                strSql = strSql + " and HRJobRequest.RequestDesc like '%" + _DescSearch + "%'";

            if (_JobTypeIDSearch != 0)
                strSql = strSql + " and HRJobRequest.RequestJobTypeID = " + _JobTypeIDSearch;
            if (_JobTitleTypeIDSearch != 0)
                strSql = strSql + " and HRJobRequest.RequestJobTitleTypeID = " + _JobTitleTypeIDSearch;
            if (_JobNatureTypeIDSearch != 0)
                strSql = strSql + " and HRJobRequest.RequestJobNatureTypeID = " + _JobNatureTypeIDSearch;
            if (_InterestFieldIDSearch != 0)
                strSql = strSql + " and HRJobRequest.RequestInterestFieldID = " + _InterestFieldIDSearch;

            if (_InterestFieldIDSearch != 0)
                strSql = strSql + " and HRJobRequest.RequestInterestFieldID = " + _InterestFieldIDSearch;

            if (_SubSectorIDSearch != 0)
                strSql = strSql + " and HRJobRequest.SubSectorID = " + _SubSectorIDSearch;

            if (_ScientificDegreeIDSearch != 0)
                strSql = strSql + " and HRJobRequest.RequestScientificDegreeID = " + _ScientificDegreeIDSearch;


            if (_RequestDateStatusSearch == true && _RequestEndDateStatusSearch == true)
            {
                int RequestDateFrom ;
                double d = _RequestDateSearch.ToOADate() - 2;
                RequestDateFrom = (int)d;

                int RequestDateTo ;
                double dd = _RequestEndDateSearch.ToOADate() - 2;
                RequestDateTo = (int)dd +1;

                strSql = strSql + " And (( " + RequestDateFrom + " <= convert(float,HRJobRequest.RequestDate)   and " + RequestDateTo + " <= convert(float,HRJobRequest.RequestDate) " +
                    "  ) or ( " + RequestDateFrom + "<= convert(float,HRJobRequest.RequestEndDate) and "+  RequestDateTo +" <= convert(float,HRJobRequest.RequestEndDate)  ))";
            }

            else if (_RequestDateStatusSearch == true)
            {
                string RequestDateFrom = "";
                double d = _RequestDateSearch.ToOADate() - 2;
                RequestDateFrom = d.ToString();

                strSql = strSql + " And ( " + RequestDateFrom + " <= convert(float,HRJobRequest.RequestDate))";
            }

            else if (_RequestEndDateStatusSearch == true)
            {                
                string RequestDateTo = "";
                double dd = _RequestEndDateSearch.ToOADate() - 2;
                RequestDateTo = dd.ToString();
                strSql = strSql + " ( " + RequestDateTo + "<= convert(float,HRJobRequest.RequestEndDate) )";
            }

            if (_AvailableJobStatusSearch == true)
            {
                strSql = strSql + " And ( ( convert(float,GetDate()) >= convert(float,HRJobRequest.RequestDate)) and ( convert(float,GetDate()) <= convert(float,HRJobRequest.RequestEndDate))  OR (HRJobRequest.RequestEndDate IS NULL))";
            }

            _JobRequestIDs = "";
            _CashJobRequestTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRJobRequest");
            foreach (DataRow objDr in _CashJobRequestTable.Rows)
            {
                if (_JobRequestIDs != "")
                    _JobRequestIDs = _JobRequestIDs + ",";
                _JobRequestIDs = _JobRequestIDs + objDr["RequestID"].ToString();
            }

            return _CashJobRequestTable;
        }
        public void Delete()
        {
            JobRequestQualificationDb ObjDb = new JobRequestQualificationDb();
            ObjDb.RequestID = _ID;
            ObjDb.Delete();

            JobRequestStageDb Obj1Db = new JobRequestStageDb();
            Obj1Db.StageRequest = _ID;
            Obj1Db.Delete();

            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        #endregion
    }
}
