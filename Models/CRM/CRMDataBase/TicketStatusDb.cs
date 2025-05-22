using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class TicketStatusDb
    {
        #region Private Data
        
       
        #endregion
        #region Constructors
        public TicketStatusDb() 
        { }
        public TicketStatusDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        int _ID;
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
        int _TicketID;

        public int TicketID
        {
            get { return _TicketID; }
            set { _TicketID = value; }
        }
        string _TicketIDs;

        public string TicketIDs
        {
            get { return _TicketIDs; }
            set { _TicketIDs = value; }
        }
        int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        int _EmployeeID;

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        string _EmployeeName;

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        int _SourceTicket;

        public int SourceTicket
        {
            get { return _SourceTicket; }
            set { _SourceTicket = value; }
        }
        string _UsrName;

        public string UsrName
        {
            get { return _UsrName; }
            set { _UsrName = value; }
        }
        int _Parent;

        public int Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        bool _HasPostponementDate;

        public bool HasPostponementDate
        {
            get { return _HasPostponementDate; }
            set { _HasPostponementDate = value; }
        }
        DateTime _PostponementDate;

        public DateTime PostponementDate
        {
            get { return _PostponementDate; }
            set { _PostponementDate = value; }
        }

        public string AddStr
        {
            get
            {
                string strTicket = _TicketID != 0 ? _TicketID.ToString() : "@ID";
                string strPotponmentDate = _HasPostponementDate ? 
                    SysUtility.Approximate(_PostponementDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "NULL";
                string Returned = "insert into CRMTicketStatus (TicketID,TicketStatus, TicketStatusComment, TicketStatusAplicant" +
                    ",TicketStatusSourceTicket,TicketPostponementDate, UsrIns, TimIns)" +
                    " values ("+ strTicket  + "," + _Status + ",'"+ _Desc  + "'," +_EmployeeID+","+ _SourceTicket + "," +
                   strPotponmentDate + "," +  SysData.CurrentUser.ID  +",GetDate()) ";
                return Returned;
            }
        }
        public string AddSuccessorStatusStr
        {
            get
            {
                TicketDb objTicketDb = new TicketDb();
                objTicketDb.ID = _TicketID;
                string strSuccessor = objTicketDb.SuccessorSearchStr;
                string strTicket = _TicketID != 0 ? _TicketID.ToString() : "@ID";
                

                string Returned =  strSuccessor +
                    " insert into CRMTicketStatus (TicketID,TicketStatus, TicketStatusComment, TicketStatusAplicant" +
                    ",TicketStatusSourceTicket, UsrIns, TimIns)" +
                    "   SELECT TicketID,"+ _Status +" AS TicketStatus1,'"+ _Desc +"' AS StatusComment"+
                    ","+ _EmployeeID +" AS Applicant1,"+ _SourceTicket +" AS TicketStatusSource,"+ SysData.CurrentUser.ID +
                    " AS UsrIns,GETDATE() AS TimIns FROM TicketSuccessorTable "+
                    " WHERE TicketID <>"+ _TicketID +" ; ";
                return Returned;
            }
        }
        public string AddAncestorStatusStr
        {
            get
            {
                TicketDb objTicketDb = new TicketDb();
                objTicketDb.ID = _TicketID;
                string strAncestor = objTicketDb.AncestorSearchStr;
                string strTicket = _TicketID != 0 ? _TicketID.ToString() : "@ID";


                string Returned = strAncestor +
                    " insert into CRMTicketStatus (TicketID,TicketStatus, TicketStatusComment, TicketStatusAplicant" +
                    ",TicketStatusSourceTicket, UsrIns, TimIns)" +
                    "   SELECT TicketID," + _Status + " AS TicketStatus1,'" + _Desc + "' AS StatusComment" +
                    "," + _EmployeeID + " AS Applicant1," + _SourceTicket + " AS TicketStatusSource," + SysData.CurrentUser.ID +
                    " AS UsrIns,GETDATE() AS TimIns FROM TicketAncestorTable " +
                    " WHERE TicketID <>" + _TicketID + " ";
                return Returned;
            }
        }
        public string AddParentProcessingStatusStr
        {
           
            get
            {
                TicketDb objTicketDb = new TicketDb();
                objTicketDb.ID = _TicketID;
                objTicketDb.Parent = Parent;
                string strParent = objTicketDb.ParentEndedWaiting;
              //  string strTicket = _TicketID != 0 ? _TicketID.ToString() : "@ID";


                string Returned = strParent +
                    " insert into CRMTicketStatus (TicketID,TicketStatus, TicketStatusComment, TicketStatusAplicant" +
                    ",TicketStatusSourceTicket, UsrIns, TimIns)" +
                    "   SELECT TicketParent," + _Status + " AS TicketStatus1,'" + _Desc + "' AS StatusComment" +
                    "," + _EmployeeID + " AS Applicant1," + _SourceTicket + " AS TicketStatusSource," + SysData.CurrentUser.ID +
                    " AS UsrIns,GETDATE() AS TimIns "+
                    " FROM  ("+ strParent +") as  TicketParentTable " ;
                return Returned;
            }
            
        }
        public string EditStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strEmployee = "SELECT        ApplicantID as EmployeeID, ApplicantFirstName as EmployeeName " +
                      " FROM            dbo.HRApplicant ";
                string Returned = "SELECT  StatusID,TicketID TicketStatusTicketID, TicketStatus"+
                    ", TicketStatusComment, TicketStatusAplicant,TicketPostponementDate, UsrIns as StatusUsrIns, TimIns as StatusTimIns " +
                    ",EmployeeTable.*,StatusUserTable.UN as ENStatusUN,'' as DEStatusUN " +
                       " FROM            dbo.CRMTicketStatus " +
                       " left outer join (" + strEmployee + ") as EmployeeTable "+
                       " on CRMTicketStatus.TicketStatusAplicant = EmployeeTable.EmployeeID  "+
                       " left outer join UMSUser as StatusUserTable  "+
                       " on CRMTicketStatus.UsrIns = StatusUserTable.UID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _TicketID = int.Parse(objDr["TicketStatusTicketID"].ToString());
            _ID = int.Parse(objDr["StatusID"].ToString());
            //StatusID,TicketID TicketStatusTicketID, TicketStatus"+
              //      ", TicketStatusComment, TicketStatusAplicant, UsrIns as StatusUsrIns, TimIns as StatusTimIns " +
            _Status = int.Parse(objDr["TicketStatus"].ToString());
            _Desc = objDr["TicketStatusComment"].ToString();
            _EmployeeID = int.Parse(objDr["EmployeeID"].ToString());
            _EmployeeName = objDr["EmployeeName"].ToString();
            _Date = DateTime.Parse(objDr["StatusTimIns"].ToString());
            SharpVision.UMS.UMSDataBase.UserDb.SetUserDecrypted(ref objDr, "ENStatusUN", "DEStatusUN", "%");
            _UsrName = objDr["DEStatusUN"].ToString();
            _HasPostponementDate = DateTime.TryParse(objDr["TicketPostponementDate"].ToString(), out _PostponementDate);


        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_TicketID != 0)
                strSql += " and TicketID =" + _TicketID ;
            if(_TicketIDs != null && _TicketIDs!= "")
              strSql += " and TicketID in (" + _TicketIDs + ") " ;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
