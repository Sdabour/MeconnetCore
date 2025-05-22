using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class AssignmentDB : BaseSelfRelatedDb
    {

        #region Private Data
        protected int _Event;
        protected int _Group;
        protected int _User;
        protected string _Desc;
        protected string _Status;
        protected DateTime _Date;
        protected DateTime _Satisfactiondate;
        protected bool _IsSatisfied;
        #endregion
        #region Constructors
        public AssignmentDB()
        { 
        }
        public AssignmentDB(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _Event = int.Parse(objDR["AssignmentEvent"].ToString());
            _Group = int.Parse(objDR["AssignmentGroup"].ToString());
            _User = int.Parse(objDR["AssignmentUser"].ToString());
            _Desc = objDR["AssignmentDesc"].ToString();
            _Status = objDR["AssignmentStatus"].ToString();
            _Date = DateTime.Parse(objDR["AssignmentDate"].ToString());
            _Satisfactiondate = DateTime.Parse(objDR["AssignmentSatisfactiondate"].ToString());
        }
        public AssignmentDB(DataRow objDR)
        {
            _ID = int.Parse(objDR["EventID"].ToString());
            _Event = int.Parse(objDR["AssignmentEvent"].ToString());
            _Group = int.Parse(objDR["AssignmentGroup"].ToString());
            _User = int.Parse(objDR["AssignmentUser"].ToString());
            _Desc = objDR["AssignmentDesc"].ToString();
            _Status = objDR["AssignmentStatus"].ToString();
            _Date = DateTime.Parse(objDR["AssignmentDate"].ToString());
            _Satisfactiondate = DateTime.Parse(objDR["AssignmentSatisfactiondate"].ToString());
        }
        #endregion
        #region Public Properties
        public int Event
        {
            set 
            { 
                _Event = value;
            }
            get
            { 
                return _Event;
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
        public string Desc
        {
            set 
            {
                _Desc = value;
            }
            get 
            { 
                return _Desc;
            }
            
        }
        public string Status
        {
            set
            {
                _Status = value;
            }
            get
            { 
                return _Status; 
            }
            
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            { 
                return _Date;
            }
            
        }
        public DateTime Satisfactiondate
        {
            set
            { 
                _Satisfactiondate = value; 
            }
            get
            {
                return _Satisfactiondate;
            }
            
        }
        public bool IsSatisfied
        {
            set
            {
                _IsSatisfied = value;
            }
            get
            {
                return _IsSatisfied;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     AssignmentID, AssignmentEvent, AssignmentGroup, AssignmentUser, AssignmentDesc, AssignmentStatus, AssignmentDate, " +
                                  " AssignmentSatisfactiondate, AssinmentParentID, AssignmentFamilyID,EventTable.* " +
                                  " from CRMAssignment inner join (" + Event1DB.SearchStr + ") as EventTable  on CRMAssignment.AssignmentEvent = EventTable.EventID ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            double dblAssignmentDate = Date.ToOADate() - 2;
            string strSatisfied = _IsSatisfied ? "GetDate()" : "null";

            string strSql = " INSERT INTO CRMAssignment"+
                      " (AssignmentEvent, AssignmentGroup, AssignmentUser, AssignmentDesc, AssignmentStatus, AssignmentDate, AssignmentSatisfactiondate, "+
                      " AssinmentParentID, AssignmentFamilyID, UsrIns, TimIns)"+
                      " VALUES     (" + _Event + "," + _Group + "," + _User + "," + _Desc + "," + _Status + "," + dblAssignmentDate + "," + strSatisfied + "," + _ParentID + "," + _FamilyID + "," + SysData.CurrentUser.ID + ",GetDate()) ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }

        public override void Edit()
        {
             double dblAssignmentDate = Date.ToOADate() - 2;
            string strSatisfied = _IsSatisfied ? "GetDate()" : "null";

            string strSql = " UPDATE    CRMAssignment" +
                            " SET  AssignmentEvent = " + _Event + "" +
                            ", AssignmentGroup =" + _Group + "" +
                            ", AssignmentUser =" + _User + "" +
                            ", AssignmentDesc =" + _Desc + "" +
                            ", AssignmentStatus =" + _Status + "" +
                            ", AssignmentDate =" + dblAssignmentDate + "" +
                            ", AssignmentSatisfactiondate =" + strSatisfied + "" +
                            ", AssinmentParentID =" + _ParentID + "" +
                            ", AssignmentFamilyID =" + _FamilyID + "" +
                            ", UsrUpd =" + SysData.CurrentUser.ID + "" +
                            ", TimUpd = Getdate()" +
                            "where AssignmentID = "+_ID+"";

        }

        public override void Delete()
        {
            string strSql = " DELETE FROM CRMAssignment where AssignmentID = " + _ID;
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion

    }
}
