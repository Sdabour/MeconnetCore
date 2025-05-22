using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using System.Collections;

namespace SharpVision.HR.HRBusiness
{
    public class EstimationStatementBiz
    {
        #region Private Data
        protected EstimationStatementDb _EstimationStatementDb;
        protected EstimationStatementTypeBiz _StatementTypeBiz;

        protected DetailStatementCol _DetailStatementCol;
        protected DetailStatementCol _DeleteDetailStatementCol;

        protected EstimationStatementElementCol _ElementCol;
        //protected EstimationStatementElementCol _DeleteEstimationElementCol;

        protected ApplicantEstimationCol _ApplicantEstimationCol;
        protected ApplicantEstimationCol _DeleteApplicantEstimationCol;

        protected EstimationStatementAttendanceStatementCol _AttendanceStatementCol;
        protected EstimationStatementGlobalStatementCol _GlobalStatementCol;
        protected EstimationStatementJobCategoryEstimationCol _JobCategoryEstimationCol;

        #endregion
        #region Constructors
        public EstimationStatementBiz()
        {
            _EstimationStatementDb = new EstimationStatementDb();
            _StatementTypeBiz = new EstimationStatementTypeBiz();
            _DetailStatementCol = null;
        }
        public EstimationStatementBiz(int intEstimationStatementID)
        {
            _DetailStatementCol = null;
            _EstimationStatementDb = new EstimationStatementDb(intEstimationStatementID);
        }
        public EstimationStatementBiz(DataRow objDR)
        {
            _DetailStatementCol = null;
            _EstimationStatementDb = new EstimationStatementDb(objDR);
            if (objDR["EstimationStatementTypeID"].ToString() != "")
                _StatementTypeBiz = new EstimationStatementTypeBiz(objDR);
            else
                _StatementTypeBiz = new EstimationStatementTypeBiz();
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set { _EstimationStatementDb.ID = value; }
            get { return _EstimationStatementDb.ID; }
        }
        public string MonthName
        {
            set { _EstimationStatementDb.MonthName = value; }
            get
            {
                if (_EstimationStatementDb.MonthName == null || _EstimationStatementDb.MonthName == "")
                {
                    if (StartDateTo.Year == 1 || StartDateTo.Year == 1900)
                        return "";
                    if (StartDateTo.Month == 1)
                    {
                        return " يناير " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 2)
                    {
                        return " فبراير " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 3)
                    {
                        return " مارس " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 4)
                    {
                        return " ابريل " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 5)
                    {
                        return " مايو " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 6)
                    {
                        return " يونية " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 7)
                    {
                        return " يولبو " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 8)
                    {
                        return " اغسطس " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 9)
                    {
                        return " سبتمبر " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 10)
                    {
                        return " اكتوبر " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 11)
                    {
                        return " نوفمبر " + StartDateTo.Year.ToString();
                    }
                    else if (StartDateTo.Month == 12)
                    {
                        return " ديسمبر " + StartDateTo.Year.ToString();
                    }
                }
                return _EstimationStatementDb.MonthName;
            }
        }
        public int MonthValue
        {
            get
            {
                return StartDateTo.Month;
            }
        }
        public DateTime EstimationStatementDate
        {
            set { _EstimationStatementDb.EstimationStatementDate = value; }
            get { return _EstimationStatementDb.EstimationStatementDate; }
        }
        public string EstimationStatementDesc
        {
            set { _EstimationStatementDb.EstimationStatementDesc = value; }
            get { return _EstimationStatementDb.EstimationStatementDesc; }
        }
        public EstimationStatementTypeBiz EstimationStatementTypeBiz
        {
            set { _StatementTypeBiz = value; }
            get { return _StatementTypeBiz; }
        }
        public bool IsDependOnStartDate
        {
            set { _EstimationStatementDb.IsDependOnStartDate = value; }
            get { return _EstimationStatementDb.IsDependOnStartDate; }
        }
        public bool IsSummation
        {
            set { _EstimationStatementDb.IsSummation = value; }
            get { return _EstimationStatementDb.IsSummation; }
        }
        public DateTime StartDateFrom
        {
            set { _EstimationStatementDb.StartDateFrom = value; }
            get { return _EstimationStatementDb.StartDateFrom; }
        }
        public DateTime StartDateTo
        {
            set { _EstimationStatementDb.StartDateTo = value; }
            get { return _EstimationStatementDb.StartDateTo; }
        }
        public string Note
        {
            set
            {
                _EstimationStatementDb.Note = value;

            }
            get
            {
                return _EstimationStatementDb.Note;
            }
        }
        public bool IsGlobal
        {

            set => _EstimationStatementDb.IsGlobal = value;
            get => _EstimationStatementDb.IsGlobal;
        }
        public bool IsMixed
        {

            set => _EstimationStatementDb.IsMixed = value;
            get => _EstimationStatementDb.IsMixed;
        }
        public double FreeElementPerc
        { set => _EstimationStatementDb.FreeElementPerc = value;
            get => _EstimationStatementDb.FreeElementPerc; }
        public EstimationStatementElementCol ElementCol
        {
            set
            {
                _ElementCol = value;
            }
            get
            {
                if (_ElementCol == null)
                {
                    _ElementCol = new EstimationStatementElementCol(true);
                    if (ID != 0)
                    {
                        EstimationStatementElementDb objDb = new EstimationStatementElementDb();
                        objDb.EstimationStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ElementCol.Add(new EstimationStatementElementBiz(objDr));
                        }
                    }
                }
                return _ElementCol;
            }
        }
        public EstimationStatementAttendanceStatementCol AttendanceStatementCol
        {
            set
            {
                _AttendanceStatementCol = value;
            }
            get
            {
                if (_AttendanceStatementCol == null)
                {
                    _AttendanceStatementCol = new EstimationStatementAttendanceStatementCol(true);
                    if (ID != 0)
                    {
                        EstimationStatementAttendanceStatementDb objDb = new EstimationStatementAttendanceStatementDb();
                        objDb.EstimationStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _AttendanceStatementCol.Add(new EstimationStatementAttendanceStatementBiz(objDr));
                        }

                    }
                }
                return _AttendanceStatementCol;
            }
        }
        public EstimationStatementGlobalStatementCol GlobalStatementCol
        {
            set
            {
                _GlobalStatementCol = value;
            }
            get
            {
                if (_GlobalStatementCol == null)
                {
                    _GlobalStatementCol = new EstimationStatementGlobalStatementCol(true);
                    if (ID != 0)
                    {
                        EstimationStatementGlobalStatementDb objDb = new EstimationStatementGlobalStatementDb();
                        objDb.EstimationStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _GlobalStatementCol.Add(new EstimationStatementGlobalStatementBiz(objDr));
                        }

                    }
                }
                return _GlobalStatementCol;
            }
        }
        public EstimationStatementJobCategoryEstimationCol JobCategoryEstimationCol
        {
            set
            {
                _JobCategoryEstimationCol = value;
            }
            get
            {
                if (_JobCategoryEstimationCol == null)
                {
                    _JobCategoryEstimationCol = new EstimationStatementJobCategoryEstimationCol(true);
                    if (ID != 0)
                    {
                        EstimationStatementJobCategoryEstimationDb objDb = new EstimationStatementJobCategoryEstimationDb();
                        objDb.EstimationStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _JobCategoryEstimationCol.Add(new EstimationStatementJobCategoryEstimationBiz(objDr));
                        }
                    }
                }
                return _JobCategoryEstimationCol;
            }
        }

        public DetailStatementCol DetailStatementCol
        {
            set
            {
                _DetailStatementCol = value;
            }
            get
            {
                if (_DetailStatementCol == null)
                {
                    _DetailStatementCol = new DetailStatementCol(true);
                    if (ID != 0)
                    {
                        DetailStatementDb objDb = new DetailStatementDb();
                        objDb.DetailStatementEstimationStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _DetailStatementCol.Add(new DetailStatementBiz(objDr));
                        }

                    }
                }
                return _DetailStatementCol;
            }
        }
        public DetailStatementCol DeleteDetailStatementCol
        {
            set
            {
                _DeleteDetailStatementCol = value;
            }
            get
            {
                if (_DeleteDetailStatementCol == null)
                    _DeleteDetailStatementCol = new DetailStatementCol(true);
                return _DeleteDetailStatementCol;
            }
        }
        public ApplicantEstimationCol ApplicantEstimationCol
        {
            set
            {
                _ApplicantEstimationCol = value;
            }
            get
            {
                if (_ApplicantEstimationCol == null)
                {
                    _ApplicantEstimationCol = new ApplicantEstimationCol(true);
                    if (ID != 0)
                    {
                        ApplicantEstimationDb objDb = new ApplicantEstimationDb();
                        objDb.EstimationStatementID = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ApplicantEstimationCol.Add(new ApplicantEstimationBiz(objDr));
                        }

                    }
                }
                return _ApplicantEstimationCol;
            }
        }
        public ApplicantEstimationCol DeleteApplicantEstimationCol
        {
            set
            {
                _DeleteApplicantEstimationCol = value;
            }
            get
            {
                if (_DeleteApplicantEstimationCol == null)
                    _DeleteApplicantEstimationCol = new ApplicantEstimationCol(true);
                return _DeleteApplicantEstimationCol;
            }
        }
        public static EstimationStatementBiz CurrentStatementBiz
        {
            get
            {
                EstimationStatementDb objDb = new EstimationStatementDb();
                DataTable dtTemp = objDb.GetLatestStatement();
                if (dtTemp.Rows.Count == 0)
                    return new EstimationStatementBiz();
                else
                    return new EstimationStatementBiz(dtTemp.Rows[0]);


            }
        }
        EstimationStatetmentGroupCol _GroupElementCol;
        public EstimationStatetmentGroupCol GroupElementCol
        {
            set => _GroupElementCol = value;
            get
            {
                if (_GroupElementCol == null)
                {
                    _GroupElementCol = new EstimationStatetmentGroupCol(true);
                    if (ID != 0)
                    {
                        EstimationStatetmentGroupDb objDb = new EstimationStatetmentGroupDb();
                        objDb.StatementID = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                            _GroupElementCol.Add(new EstimationStatetmentGroupBiz(objDr));
                    }
                }
                return _GroupElementCol;
            }
        }
        Hashtable _ApplicantHash;
        public Hashtable ApplicantHash
        {
            set { _ApplicantHash = value; }
            get
            {
                if (_ApplicantHash == null)
                {
                    _ApplicantHash = new Hashtable();
                    EstimationStatementDb objDb = new EstimationStatementDb();
                    objDb.ID = ID;
                    DataTable dtTemp = objDb.GetApplicantIDs();
                    double dblPerc = 0;
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        if (_ApplicantHash[objDr["Applicant"].ToString()] == null)
                        {
                            dblPerc = 0;
                            double.TryParse(objDr["EstimationPerc"].ToString(), out dblPerc);
                            _ApplicantHash.Add(objDr["Applicant"].ToString(), dblPerc.ToString("0"));

                        }
                    }

                }
                return _ApplicantHash;
            }

        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _EstimationStatementDb.EstimationStatementTypeID = _StatementTypeBiz.ID;
            _EstimationStatementDb.AttendanceStatementTable = AttendanceStatementCol.GetTable();
            _EstimationStatementDb.GlobalStatementTable = GlobalStatementCol.GetTable();
            _EstimationStatementDb.ElementTable = ElementCol.GetTable();
            _EstimationStatementDb.JobCategoryEstimationTable = JobCategoryEstimationCol.GetTable();
            _EstimationStatementDb.GroupTable = GroupElementCol.GetTable();

            _EstimationStatementDb.Add();
        }
        public void Edit()
        {
            _EstimationStatementDb.EstimationStatementTypeID = _StatementTypeBiz.ID;
            _EstimationStatementDb.AttendanceStatementTable = AttendanceStatementCol.GetTable();
            _EstimationStatementDb.GlobalStatementTable = GlobalStatementCol.GetTable();
            _EstimationStatementDb.JobCategoryEstimationTable = JobCategoryEstimationCol.GetTable();
            _EstimationStatementDb.ElementTable = ElementCol.GetTable();

            //_EstimationStatementDb.DetailStatementTable = DetailStatementCol.GetTable();
            //_EstimationStatementDb.DeleteDetailStatementTable = DeleteDetailStatementCol.GetTable();            
            //_EstimationStatementDb.DeleteEstimationElementTable = DeleteEstimationElementCol.GetTable();            
            //_EstimationStatementDb.DeleteEstimationElementTable = DeleteEstimationElementCol.GetTable();            
            //_EstimationStatementDb.ApplicantEstimationTable = _ApplicantEstimationCol.GetTable();
            _EstimationStatementDb.GroupTable = GroupElementCol.GetTable();
            _EstimationStatementDb.Edit();
        }
        public void EditNote()
        {
            _EstimationStatementDb.EditNote();
        }
        public void Delete()
        {
            _EstimationStatementDb.Delete();
        }
        public void InitialJoinApplicants()
        {
            ApplicantEstimationDb objDb = new ApplicantEstimationDb();
            objDb.EstimationStatementID = ID;
            objDb.ApplicantIDs = ApplicantEstimationCol.IDsStr;
            objDb.AddMultiple();
            objDb.ApplicantIDs = DeleteApplicantEstimationCol.IDsStr;
            objDb.DeleteMultiple();

        }
        #endregion
    }
}
