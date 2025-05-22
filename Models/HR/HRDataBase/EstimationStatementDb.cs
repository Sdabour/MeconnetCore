using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class EstimationStatementDb
    {
        #region Private Data

        protected int _ID;
        protected DateTime _EstimationStatementDate;
        protected string _EstimationStatementDesc;
        protected int _EstimationStatementTypeID;
        protected bool _IsDependOnStartDate;
        protected DateTime _StartDateFrom;
        protected DateTime _StartDateTo;
        protected string _MonthName;
        protected bool _IsSummation;
        protected DataTable _ElementTable;
        protected DataTable _AttendanceStatementTable;
        protected DataTable _GlobalStatementTable;
        protected DataTable _JobCategoryEstimationTable;

        protected DataTable _DetailStatementTable;
        protected DataTable _DeleteDetailStatementTable;
        protected DataTable _ApplicantEstimationTable;

        //protected bool _SaveDetails;

        protected bool _EstimationDateSearch;
        protected DateTime _EstimationDateFromSearch;
        protected DateTime _EstimationDateToSearch;
        #endregion
        #region Constructors
        public EstimationStatementDb()
        {
        }
        public EstimationStatementDb(int intEstimationStatementID)
        {
            _ID = intEstimationStatementID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public EstimationStatementDb(DataRow objDR)
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

        public int EstimationStatementTypeID
        {
            set { _EstimationStatementTypeID = value; }
            get { return _EstimationStatementTypeID; }
        }

        public DateTime EstimationStatementDate
        {
            set { _EstimationStatementDate = value; }
            get { return _EstimationStatementDate; }
        }

        public string EstimationStatementDesc
        {
            set { _EstimationStatementDesc = value; }
            get { return _EstimationStatementDesc; }
        }
        public string MonthName
        {
            set { _MonthName = value; }
            get { return _MonthName; }
        }

        public bool IsDependOnStartDate
        {
            set { _IsDependOnStartDate = value; }
            get { return _IsDependOnStartDate; }
        }
        public bool IsSummation
        {
            set { _IsSummation = value; }
            get { return _IsSummation; }
        }
        public DateTime StartDateFrom
        {
            set { _StartDateFrom = value; }
            get { return _StartDateFrom; }
        }
        public DateTime StartDateTo
        {
            set { _StartDateTo = value; }
            get { return _StartDateTo; }
        }

        public DataTable ElementTable
        {
            set { _ElementTable = value; }
            get { return _ElementTable; }
        }
        //public DataTable DeleteEstimationElementTable
        //{
        //    set { _DeleteElementTable = value; }
        //    get { return _DeleteElementTable; }
        //}

        public DataTable DetailStatementTable
        {
            set { _DetailStatementTable = value; }
            get { return _DetailStatementTable; }
        }
        public DataTable DeleteDetailStatementTable
        {
            set { _DeleteDetailStatementTable = value; }
            get { return _DeleteDetailStatementTable; }
        }
        public DataTable ApplicantEstimationTable
        {
            set { _ApplicantEstimationTable = value; }
            get { return _ApplicantEstimationTable; }
        }
        public DataTable AttendanceStatementTable
        {
            set { _AttendanceStatementTable = value; }
            get { return _AttendanceStatementTable; }
        }
        public DataTable GlobalStatementTable
        {
            set { _GlobalStatementTable = value; }
            get { return _GlobalStatementTable; }
        }
        public DataTable JobCategoryEstimationTable
        {
            set { _JobCategoryEstimationTable = value; }
            get { return _JobCategoryEstimationTable; }
        }
        //DataTable 
        string _Note;

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        bool _IsGlobal;
        public bool IsGlobal
        {
            set => _IsGlobal = value;
            get => _IsGlobal;
        }
        bool _IsMixed;
        public bool IsMixed
        {
            set => _IsMixed = value;
            get => _IsMixed;
        }
        double _FreeElementPerc;
        public double FreeElementPerc
        {
            set => _FreeElementPerc = value;
            get => _FreeElementPerc;
        }
        public bool EstimationDateSearch
        {
            set { _EstimationDateSearch = value; }
        }
        public DateTime EstimationDateFromSearch
        {
            set { _EstimationDateFromSearch = value; }
        }
        public DateTime EstimationDateToSearch
        {
            set { _EstimationDateToSearch = value; }
        }
        DataTable _GroupTable;
        public DataTable GroupTable
        {
            set => _GroupTable = value;
        }
        public static string SearchStr
        {
            get
            {
                string ReturnStr = " SELECT     HREstimationStatement.EstimationStatementID, HREstimationStatement.EstimationStatementDate," +
                                   " HREstimationStatement.EstimationStatementDesc,HREstimationStatement.IsDependOnStartDate,HREstimationStatement.IsSummation,HREstimationStatement.MonthName" +
                                   " ,HREstimationStatement.StartDateFrom,HREstimationStatement.StartDateTo,EstimationStatementNote,EstimationStatementIsGlobal ,EstimationStatementIsMixed,EstimationStatementFreeElementPerc"+
                                   " ,EstimationStatementTypeTable.*" + //HREstimationStatement.EstimationStatementTypeID
                                   " FROM HREstimationStatement Left Outer join ( " + EstimationStatementTypeDb.SearchStr + " ) EstimationStatementTypeTable On HREstimationStatement.EstimationStatementTypeID = EstimationStatementTypeTable.EstimationStatementTypeID";
                return ReturnStr;
            }
        }
        public string AddStr
        {
            get
            {
                double dblEstimationStatementDate = _EstimationStatementDate.ToOADate() - 2;
                int intIsDependOnStartDate = _IsDependOnStartDate ? 1 : 0;
                double dblStartDateFrom = _StartDateFrom.ToOADate() - 2;
                double dblStartDateTo = _StartDateTo.ToOADate() - 2;
                int intIsSummation = _IsSummation ? 1 : 0;
                string Returned = " INSERT INTO HREstimationStatement " +
                                " (EstimationStatementDate, EstimationStatementDesc, EstimationStatementTypeID," +
                                " IsDependOnStartDate,StartDateFrom,StartDateTo,MonthName,IsSummation,EstimationStatementNote,EstimationStatementIsGlobal,EstimationStatementIsMixed, UsrIns, TimIns)" +
                                " VALUES " +
                                " (" + dblEstimationStatementDate + ",'" + _EstimationStatementDesc + "'," + _EstimationStatementTypeID + "," +
                                " " + intIsDependOnStartDate + "," + dblStartDateFrom + "," + dblStartDateTo + ",'" + _MonthName + "'," + intIsSummation + " " +
                                " ,'" + _Note + "'," + (_IsGlobal ? "1" : "0") + "," +
                                (_IsMixed?"1":"0") +","+SysData.CurrentUser.ID + ",GetDate())";
                return Returned;

            }
        }
        public string EditStr
        {
            get
            {
                double dblEstimationStatementDate = _EstimationStatementDate.ToOADate() - 2;
                int intIsDependOnStartDate = _IsDependOnStartDate ? 1 : 0;
                double dblStartDateFrom = _StartDateFrom.ToOADate() - 2;
                double dblStartDateTo = _StartDateTo.ToOADate() - 2;
                int intIsSummation = _IsSummation ? 1 : 0;
                string Returned = " UPDATE    HREstimationStatement " +
                                " SET EstimationStatementDate = " + dblEstimationStatementDate + "" +
                                " , EstimationStatementDesc = '" + _EstimationStatementDesc + "'" +
                                " , EstimationStatementTypeID = " + _EstimationStatementTypeID + "" +
                                " , IsDependOnStartDate = " + intIsDependOnStartDate + "" +
                                " , StartDateFrom = " + dblStartDateFrom + "" +
                                " , StartDateTo = " + dblStartDateTo + "" +
                                " , MonthName = '" + _MonthName + "'" +
                                " , IsSummation = " + intIsSummation + "" +
                                ",EstimationStatementNote='" + _Note + "'" +
                                ",EstimationStatementIsGlobal=" + (_IsGlobal ? "1" : "0") +
                                ",EstimationStatementIsMixed="+(_IsMixed?"1":"0")+
                                " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                                " , TimUpd = GetDate()" +
                                " WHERE (EstimationStatementID = " + _ID + ")";
                return Returned;
            }
        }
        public virtual string DeleteStr
        {
            get
            {
                string Returned = " UPDATE HREstimationStatement" +
                                  " Set Dis = GetDate()" +
                                  " Where   (EstimationStatementID = " + _ID + ")";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["EstimationStatementID"].ToString() == "" || objDR["EstimationStatementID"].ToString() == "0")
                return;
            _ID = int.Parse(objDR["EstimationStatementID"].ToString());
            if (objDR["EstimationStatementTypeID"].ToString() != "")
                _EstimationStatementTypeID = int.Parse(objDR["EstimationStatementTypeID"].ToString());
            _EstimationStatementDesc = objDR["EstimationStatementDesc"].ToString();
            _MonthName = objDR["MonthName"].ToString();
            _EstimationStatementDate = DateTime.Parse(objDR["EstimationStatementDate"].ToString());
            if (objDR["IsDependOnStartDate"].ToString() != "")
                _IsDependOnStartDate = bool.Parse(objDR["IsDependOnStartDate"].ToString());
            if (objDR["StartDateFrom"].ToString() != "")
                _StartDateFrom = DateTime.Parse(objDR["StartDateFrom"].ToString());
            if (objDR["StartDateTo"].ToString() != "")
                _StartDateTo = DateTime.Parse(objDR["StartDateTo"].ToString());

            if (objDR["IsSummation"].ToString() != "")
                _IsSummation = bool.Parse(objDR["IsSummation"].ToString());
            _Note = objDR["EstimationStatementNote"].ToString();
            if (objDR.Table.Columns["EstimationStatementIsGlobal"] != null && objDR["EstimationStatementIsGlobal"].ToString() != "")
                bool.TryParse(objDR["EstimationStatementIsGlobal"].ToString(), out _IsGlobal);
            if (objDR.Table.Columns["EstimationStatementIsMixed"] != null && objDR["EstimationStatementIsMixed"].ToString() != "")
                bool.TryParse(objDR["EstimationStatementIsMixed"].ToString(), out _IsMixed);
            if (objDR.Table.Columns["EstimationStatementFreeElementPerc"] != null)
                double.TryParse(objDR["EstimationStatementFreeElementPerc"].ToString(), out _FreeElementPerc);
        }
        void JoinElement()
        {
            string[] arrStr = new string[_ElementTable.Rows.Count + 1];

            arrStr[0] = "DELETE FROM HREstimationStatementElement WHERE     (EstimationStatement = " + _ID + ")";
            if (_ElementTable == null || _ElementTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {

                EstimationStatementElementDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _ElementTable.Rows)
                {
                    objDb = new EstimationStatementElementDb(objDr);
                    objDb.EstimationStatement = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinAttendanceStatement()
        {
            string[] arrStr = new string[_AttendanceStatementTable.Rows.Count + 1];
            arrStr[0] = "Delete from HREstimationStatementAttendanceStatement where EstimationStatement = " + _ID;

            if (_AttendanceStatementTable == null || _AttendanceStatementTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {

                EstimationStatementAttendanceStatementDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _AttendanceStatementTable.Rows)
                {
                    objDb = new EstimationStatementAttendanceStatementDb(objDr);
                    objDb.EstimationStatement = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinGlobalStatement()
        {
            string[] arrStr = new string[_GlobalStatementTable.Rows.Count + 1];
            arrStr[0] = "Delete from HREstimationStatementGlobalStatement where EstimationStatement = " + _ID;

            if (_GlobalStatementTable == null || _GlobalStatementTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {

                EstimationStatementGlobalStatementDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _GlobalStatementTable.Rows)
                {
                    objDb = new EstimationStatementGlobalStatementDb(objDr);
                    objDb.EstimationStatement = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinJobCategoryEstimation()
        {
            string[] arrStr = new string[_JobCategoryEstimationTable.Rows.Count + 1];
            arrStr[0] = "Delete from HREstimationStatementJobCategoryEstimation where EstimationStatement = " + _ID;

            if (_JobCategoryEstimationTable == null || _JobCategoryEstimationTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {

                EstimationStatementJobCategoryEstimationDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _JobCategoryEstimationTable.Rows)
                {
                    objDb = new EstimationStatementJobCategoryEstimationDb(objDr);
                    objDb.EstimationStatement = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinGroupTable()
        {
            if (_GroupTable == null || _GroupTable.Rows.Count == 0)
                return;
            List<string> arrStr = new List<string>();
            string strSql = @"delete FROM            dbo.HREstimationStatetmentGroup
WHERE(StatementID = " + _ID + ")";
            arrStr.Add(strSql);
            EstimationStatetmentGroupDb objGroupDb;
            foreach (DataRow objDr in _GroupTable.Rows)
            {
                objGroupDb = new EstimationStatetmentGroupDb(objDr);
                objGroupDb.StatementID = ID;
                arrStr.Add(objGroupDb.AddStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #region Deleted Code
        /*
           void DeleteEstimationStatement()
        {
            //string[] arrStr = new string[_DeleteElementTable.Rows.Count];

            //if (_DeleteElementTable == null || _DeleteElementTable.Rows.Count == 0)
            //{
            //    return;
            //}
            //else
            //{

            //    EstimationElementDb objDb;
            //    int intIndex = 0;
            //    string strTemp = "";
            //    foreach (DataRow objDr in _DeleteElementTable.Rows)
            //    {
            //        objDb = new EstimationElementDb(objDr);
            //        strTemp = objDb.EditStr;
            //        arrStr[intIndex] = strTemp;
            //        intIndex++;
            //    }
            //}
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinDetailStatement()
        {
            string[] arrStr = new string[_DetailStatementTable.Rows.Count];

            if (_DetailStatementTable == null || _DetailStatementTable.Rows.Count == 0)
            {
                   return;
            }
            else
            {

                DetailStatementDb objDb;
                int intIndex = 0;
                string strTemp = "";
                foreach (DataRow objDr in _DetailStatementTable.Rows)
                {
                    objDb = new DetailStatementDb(objDr, true);

                    if (objDb.DetailStatementID != 0)
                    {
                        //objDb.DetailStatementEstimationStatement = _EstimationStatementID;
                        strTemp = objDb.EditStr;
                        arrStr[intIndex] = strTemp;
                        intIndex++;
                    }
                    else
                    {
                        objDb.DetailStatementEstimationStatement = _ID;
                        strTemp = objDb.AddStr;
                        arrStr[intIndex] = strTemp;
                        intIndex++;
                    }
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void DeleteDetailStatement()
        {
            string[] arrStr = new string[_DeleteDetailStatementTable.Rows.Count];

            if (_DeleteDetailStatementTable == null || _DeleteDetailStatementTable.Rows.Count == 0)
            {
                   return;
            }
            else
            {

                DetailStatementDb objDb;
                int intIndex = 0;
                string strTemp = "";
                foreach (DataRow objDr in _DeleteDetailStatementTable.Rows)
                {
                    objDb = new DetailStatementDb(objDr, true);
                    //objDb.DetailStatementEstimationStatement = _EstimationStatementID;
                    strTemp = objDb.EditStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }        
        void JoinApplicantEstimation()
        {
            string[] arrStr = new string[_ApplicantEstimationTable.Rows.Count];

            if (_ApplicantEstimationTable == null || _ApplicantEstimationTable.Rows.Count == 0)
            {
                //   return;
            }
            else
            {

                ApplicantEstimationDb objDb;
                int intIndex = 0;
                string strTemp = "";
                foreach (DataRow objDr in _ApplicantEstimationTable.Rows)
                {
                    objDb = new ApplicantEstimationDb(objDr, true);
                    if (objDb.StatusDelete == true)
                    {
                        if (objDb.ApplicantEstimationID != 0)                        {
                            //objDb.DetailStatementEstimationStatement = _EstimationStatementID;
                            strTemp = objDb.DeleteStr;
                            arrStr[intIndex] = strTemp;
                            intIndex++;
                        }
                    }
                    else
                    {
                        if (objDb.ApplicantEstimationID != 0)
                        {
                            //objDb.DetailStatementEstimationStatement = _EstimationStatementID;
                            strTemp = objDb.EditStr;
                            arrStr[intIndex] = strTemp;
                            intIndex++;
                        }
                        else
                        {
                            objDb.EstimationStatementID = _ID;
                            strTemp = objDb.AddStr;
                            arrStr[intIndex] = strTemp;
                            intIndex++;
                        }

                    }


                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
         * */
        #endregion               
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            JoinElement();
            JoinAttendanceStatement();
            JoinGlobalStatement();
            JoinJobCategoryEstimation();
            JoinGroupTable();
            //JoinApplicantEstimation();
            //JoinDetailStatement();
            //DeleteDetailStatement();
            //DeleteEstimationStatement();

        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
            JoinElement();
            JoinAttendanceStatement();
            JoinGlobalStatement();
            JoinJobCategoryEstimation();
            JoinGroupTable();
            //JoinApplicantEstimation();
            //JoinDetailStatement();
            //DeleteDetailStatement();
            //DeleteEstimationStatement();

        }
        public void EditNote()
        {
            string Returned = " UPDATE HREstimationStatement" +
                               " Set EstimationStatementNote ='" + _Note + "'" +
                               " Where   (EstimationStatementID = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(Returned);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " And   (EstimationStatementID = " + _ID + ")";
            if (_EstimationStatementTypeID != 0)
                strSql = strSql + " And   (EstimationStatementTypeTable.EstimationStatementTypeID = " + _EstimationStatementTypeID + ")";
            if (_EstimationStatementDesc != null && _EstimationStatementDesc != "")
                strSql = strSql + " And   (EstimationStatementDesc like  '%" + _EstimationStatementDesc + "%')";

            if (_EstimationDateSearch == true)
            {
                double dblFrom = _EstimationDateFromSearch.ToOADate() - 2;
                double dblTo = _EstimationDateToSearch.ToOADate() - 2;
                strSql = strSql + " And   (EstimationStatementDate Between " + dblFrom + " And " + dblTo + ")";
            }

            strSql += " Order by EstimationStatementDate desc";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetApplicantIDs()
        {
            string strSql = @"SELECT        Applicant 
FROM dbo.HRApplicantWorkerEstimationStatement
WHERE(EstimationStatement = " + ID + ")";
            strSql = ApplicantWorkerEstimationStatementDb.EstimationPercStr;
            strSql += " where dbo.HRApplicantWorkerEstimationStatement.EstimationStatement = "+ID;
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            return Returned;
        }
        public DataTable GetLatestStatement()
        {
            string strSql = SearchStr + " where EstimationStatementID = (select max(EstimationStatementID)  from  HREstimationStatement where EstimationStatementIsActive = 1 and Dis Is Null )";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        #endregion
    }
}
