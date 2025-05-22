using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class WorkerDb
    {
        #region Private Data
        protected int _ID;
        protected string _FirstName;
        protected string _MidleName;
        protected string _LastName;
        protected string _IDValue;
        IDTypeInstantDb _IDTypeDb;
        protected int _IDType;
        UserDb _UserDb;
        DateTime _StartDate;
        protected double _StartSalary;
        protected int _StartSalaryCurrency;
        protected double _CurrentSalary;
        protected int _User;
        protected int _Group;
        protected GroupDb _GroupDb;
        protected int _TitleID;
        protected int _JobID;
        protected int _DegreeID;
        protected TitleDb _WOrkerTitleDb;
        protected JobDb _WorkerJobDb;
       
        protected int _SubSectorID;

        #region Private Data For Search
        protected string _FirstNameLike;
        protected string _MideleNameLike;
        protected string _LastNameLike;
        #endregion

        #endregion

        #region Constructors
        public WorkerDb()
        {
            _UserDb = new UserDb();
            _IDTypeDb = new IDTypeInstantDb();
        }
        public WorkerDb(int intID)
        {
            _UserDb = new UserDb();
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _FirstName = objDR["WorkerFirstName"].ToString();
            _MidleName = objDR["WorkerMidleName"].ToString();
            _LastName = objDR["WorkerLastName"].ToString();
            _IDValue = objDR["WorkerIDValue"].ToString();
            _IDType = int.Parse(objDR["WorkerIDType"].ToString());
            _Group = int.Parse(objDR["WorkerGroup"].ToString());
            _User = int.Parse(objDR["WorkerUser"].ToString());
            _StartDate = DateTime.Parse(objDR["WorkerStartDate"].ToString());
            _StartSalary = double.Parse(objDR["WorkerSatrtSalary"].ToString());
            _StartSalaryCurrency = int.Parse(objDR["WorkerStartSalaryCurrency"].ToString());
            _CurrentSalary = double.Parse(objDR["WorkerCurrentSalary"].ToString());
            _IDTypeDb = new IDTypeInstantDb(objDR);

        }
        public WorkerDb(DataRow objDR)
        {
            _UserDb = new UserDb();
            _ID = int.Parse(objDR["WorkerID"].ToString());
            _FirstName = objDR["WorkerFirstName"].ToString();
            _MidleName = objDR["WorkerMidleName"].ToString();
            _LastName = objDR["WorkerLastName"].ToString();
            _IDValue = objDR["WorkerIDValue"].ToString();
            _IDType = int.Parse(objDR["WorkerIDType"].ToString());
            _Group = int.Parse(objDR["WorkerGroup"].ToString());
            _User = int.Parse(objDR["WorkerUser"].ToString());
            _StartDate = DateTime.Parse(objDR["WorkerStartDate"].ToString());
            _StartSalary = double.Parse(objDR["WorkerSatrtSalary"].ToString());
            _StartSalaryCurrency = int.Parse(objDR["WorkerStartSalaryCurrency"].ToString());
            _CurrentSalary = double.Parse(objDR["WorkerCurrentSalary"].ToString());
            if (_IDType != 0)
                _IDTypeDb = new IDTypeInstantDb(objDR);
            else
                _IDTypeDb = new IDTypeInstantDb();
            if (_Group != 0)
                _GroupDb = new GroupDb(objDR);
            else
                _GroupDb = new GroupDb();
            _TitleID = int.Parse(objDR["WorkerTitle"].ToString());
            _JobID = int.Parse(objDR["WorkerJob"].ToString());
            _DegreeID = int.Parse(objDR["WorkerDegree"].ToString());
            if (_TitleID != 0)
                _WOrkerTitleDb = new TitleDb(objDR);
            else
                _WOrkerTitleDb = new TitleDb();
            if (_JobID != 0)
                _WorkerJobDb = new JobDb(objDR);
            else
                _WorkerJobDb = new JobDb();
        


            
               

        }
        #endregion

        #region Public Properties
        public int ID
        {
            set 
            {
                _ID = value;
            }
            get 
            { 
                return _ID;
            }
        }
        public string FirstName
        {
            set 
            {
                _FirstName = value;
            }
            get
            {
                return _FirstName; 
            }

        }
        public string MidleName
        {
            set
            {
                _MidleName = value; 
            }
            get 
            { 
                return _MidleName; 
            }

        }
        public string LastName
        {
            set 
            {
                _LastName = value;
            }
            get 
            { 
                return _LastName; 
            }

        }
        public string IDValue
        {
            set 
            { 
                _IDValue = value; 
            }
            get
            { 
                return _IDValue; 
            }
        }
        public IDTypeInstantDb IDTypeInstantDb
        {
            set
            {
                _IDTypeDb = value;
            }
            get
            {
                return _IDTypeDb;
            }
        }
        public int IDType
        {
            set
            {
                _IDType = value;
            }
            get
            {
                return _IDType;
            }
        }   
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get 
            {
                return _StartDate;
            }

        }
        public double SatrtSalary
        {
            set
            {
                _StartSalary = value;
            }
            get 
            {
                return _StartSalary; 
            }

        }
        public int StartSalaryCurrency
        {
            set 
            {
                _StartSalaryCurrency = value;
            }
            get 
            {
                return _StartSalaryCurrency;
            }

        }
        public double CurrentSalary
        {
            set 
            {
                _CurrentSalary = value;
            }
            get 
            { 
                return _CurrentSalary;
            }

        }
        public int User
        {
            set
            {
                _User = value;
            }
            get 
            { 
                return _User; 
            }

        }
        public int Group
        {
            set 
            {
                _Group = value;
            }
            get 
            { 
                return _Group; 
            }

        }
        public int TitleID
        {
            set
            {
                _TitleID = value;
            }
            get
            {
                return _TitleID;
            }
        }
        public int DegreeID
        {
            set
            {
                _DegreeID = value;
            }
            get
            {
                return _DegreeID;
            }
        }
        public int JobID
        {
            set
            {
                _JobID = value;
            }
            get
            {
                return _JobID;

            }
        }
        public TitleDb WorkerTitleDb
        {
            set
            {
                _WOrkerTitleDb = value;
            }
            get
            {
                return _WOrkerTitleDb;
            }
        }
        public JobDb WorkerJobDb
        {
            set
            {
                _WorkerJobDb = value;
            }
            get
            {
                return _WorkerJobDb;
            }
        }
     
        public string FirstNameLike
        {
            set
            {
                _FirstNameLike = value;
            }
        }
        public string MideleNameLike
        {
            set
            {
                _MideleNameLike = value;
            }
        }
        public string LastNameLike
        {
            set
            {
                _LastNameLike = value;
            }
        }
        public GroupDb GroupDb
        {
            get
            {
                return _GroupDb;
            }
        }
        public int SubSectorID
        {
            set
            {
                _SubSectorID = value;
            }
            get
            {
                return _SubSectorID;
            }
        }
        public static string SearchStr
        {
            get
            {

                string Returned = " SELECT     HRWorker.WorkerID, HRWorker.WorkerFirstName, HRWorker.WorkerMidleName, " +
                      " HRWorker.WorkerLastName, HRWorker.WorkerIDValue, " +
                      " HRWorker.WorkerIDType ,HRWorker.WorkerDegree, HRWorker.WorkerTitle, HRWorker.WorkerJob, HRWorker.WorkerStartDate," +
                      " HRWorker.WorkerSatrtSalary, " +
                      " HRWorker.WorkerStartSalaryCurrency, HRWorker.WorkerCurrentSalary,HRWorker.WorkerGroup,HRWorker.WorkerUser,HRWorker.WorkerSubSectorID,IDTable.*,GroupTable.* " +
                      ",TitleTable.*,JobTable.*,DegreeTable.* " +
                      " FROM    HRWorker  LEFT OUTER JOIN " +
                      " (" + IDTypeDb.SearchStr + ") as IDTable ON HRWorker.WorkerIDType = IDTable.IDtypeID  LEFT OUTER JOIN" +
                      " (" + GroupDb.SearchStr + ") as GroupTable ON HRWorker.WorkerGroup = GroupTable.GroupID  " +
                      " left outer join (" + TitleDb.SearchStr + ") as TitleTable on HRWorker.WorkerTitle = TitleTable.TitleID " +
                      " left outer join (" + JobDb.SearchStr +
                      ") as JobTable on  HRWorker.WorkerJob = JobTable.JobID  ";
                     // " left outer join (" + ScientificDegreeDb.SearchStr + ") as DegreeTable on HRWorker.WorkerDegree=DegreeTable.DegreeID ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
            double StartDate = _StartDate.ToOADate() - 2;
            string strSql = " INSERT INTO HRWorker " +
                            " (WorkerFirstName, WorkerMidleName, WorkerLastName, WorkerIDValue, WorkerIDType,WorkerDegree, "+
                            "WorkerTitle, WorkerJob, WorkerStartDate, WorkerSatrtSalary, " +
                            " WorkerStartSalaryCurrency, WorkerCurrentSalary, WorkerUser, WorkerGroup,WorkerSubSectorID)" +
                            " VALUES     ('" + _FirstName + "','" + _MidleName + "','" + _LastName + "','" + 
                            _IDValue + "'," + _IDType + ","  + _DegreeID + "," + _TitleID + "," + _JobID + ","+
                            + StartDate + ","+_StartSalary+","+_StartSalaryCurrency+","+_CurrentSalary+","+_User+","+_Group+","+_SubSectorID+") ";
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            double StartDate = _StartDate.ToOADate() - 2;
            string strSql = " UPDATE    HRWorker" +
                            " SET   WorkerFirstName ='"+_FirstName+"'" +
                            " , WorkerMidleName ='"+_MidleName+"'" +
                            " , WorkerLastName ='"+_LastName+"'" +
                            " , WorkerIDValue ='"+_IDValue+"'" +
                            " , WorkerIDType ="+_IDType+"" +
                            " , WorkerDegree =" + _DegreeID + "" +
                            " , WorkerTitle =" + _TitleID + "" +
                            " , WorkerJob =" + _JobID + "" +
                            " , WorkerStartDate ="+StartDate+"" +
                            " , WorkerSatrtSalary =" + _StartSalary + "" +
                            " , WorkerStartSalaryCurrency ="+_StartSalaryCurrency+"" +
                            " , WorkerCurrentSalary ="+_CurrentSalary+"" +
                            " , WorkerUser ="+_User+"" +
                            " , WorkerGroup = "+_Group+""+
                            " ,WorkerSubSectorID ="+_SubSectorID+"";

            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " UPDATE    HRWorker SET  Dis = GetDate() WHERE     (WorkerID = " + _ID + ")";
            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where HRWorker.Dis IS NULL";
            if (_ID != 0)
                strSql = strSql + " And (WorkerID = "+_ID+")";
            if (_FirstNameLike != null && _FirstNameLike != "")
                strSql = strSql + " And WorkerFirstName Like '%"+_FirstNameLike+"%'";
            if (_MideleNameLike != null && _MideleNameLike != "")
                strSql = strSql + " And WorkerMidleName Like '%"+_MideleNameLike+"%'";
            if (_LastNameLike != null && _LastNameLike != "")
                strSql = strSql + " And WorkerLastName Like '%"+_LastNameLike+"%'";
            if (_CurrentSalary != 0)
                strSql = strSql + " And WorkerCurrentSalary = "+_CurrentSalary+"";
            //if (_StartDate != null)
            //    strSql = strSql + " And WorkerStartDate = "+_StartDate+"";
            if (_StartSalary != 0)
                strSql = strSql + " And WorkerStartSalary = "+_StartSalary+"";
            if (_SubSectorID != 0)
                strSql = strSql + " And WorkerSubSectorID ="+_SubSectorID+" ";

           return SystemBase.SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            
        }
        #endregion
    }
}
