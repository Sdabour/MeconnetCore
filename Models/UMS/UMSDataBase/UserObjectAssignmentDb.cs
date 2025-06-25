using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.UMS.UMSDataBase
{
    public class UserObjectAssignmentDb
    {

        #region Constructor
        public UserObjectAssignmentDb()
        {
        }
        public UserObjectAssignmentDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _UserID;
        public int UserID
        {
            set
            {
                _UserID = value;
            }
            get
            {
                return _UserID;
            }
        }
        string _ObjectCode;
        public string ObjectCode
        {
            set
            {
                _ObjectCode = value;
            }
            get
            {
                return _ObjectCode;
            }
        }
        int _ObjectID;
        public int ObjectID
        {
            set
            {
                _ObjectID = value;
            }
            get
            {
                return _ObjectID;
            }
        }
        int _ObjectValue;
        public int ObjectValue
        {
            set
            {
                _ObjectValue = value;
            }
            get
            {
                return _ObjectValue;
            }
        }
        DateTime _StartDate;
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
        DateTime _EndDate;
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        bool _IsPermanent;
        public bool IsPermanent
        {
            set
            {
                _IsPermanent = value;
            }
            get
            {
                return _IsPermanent;
            }
        }
        DataTable _ObjectAssignTable;
        public DataTable ObjectAssignTable
        { set => _ObjectAssignTable = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UMSUserObjectAssignment (UserID,ObjectCode,ObjectID,ObjectValue,AssignmentStartDate,AssignmentEndDate,AssignmentIsPermanent) values (" + UserID + ",'" + ObjectCode + "'," + ObjectID + "," + ObjectValue + "," + (StartDate.ToOADate() - 2).ToString() + "," + (EndDate.ToOADate() - 2).ToString() + "," + (IsPermanent ? 1 : 0) + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UMSUserObjectAssignment set " + "UserID=" + UserID + "" +
           ",ObjectCode='" + ObjectCode + "'" +
           ",ObjectID=" + ObjectID + "" +
           ",ObjectValue=" + ObjectValue + "" +
           ",AssignmentStartDate=" + (StartDate.ToOADate() - 2).ToString() + "" +
           ",AssignmentEndDate=" + (EndDate.ToOADate() - 2).ToString() + "" +
           ",AssignmentIsPermanent=" + (IsPermanent ? 1 : 0) + "" + " where UserID="+_UserID + " and ObjectCode='"+ _ObjectCode +"'";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UMSUserObjectAssignment set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select UserID,ObjectCode,ObjectID,ObjectValue,AssignmentStartDate,AssignmentEndDate,AssignmentIsPermanent from UMSUserObjectAssignment  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["UserID"] != null)
                int.TryParse(objDr["UserID"].ToString(), out _UserID);

            if (objDr.Table.Columns["ObjectCode"] != null)
                _ObjectCode = objDr["ObjectCode"].ToString();

            if (objDr.Table.Columns["ObjectID"] != null)
                int.TryParse(objDr["ObjectID"].ToString(), out _ObjectID);

            if (objDr.Table.Columns["ObjectValue"] != null)
                int.TryParse(objDr["ObjectValue"].ToString(), out _ObjectValue);

            if (objDr.Table.Columns["AssignmentStartDate"] != null)
                DateTime.TryParse(objDr["AssignmentStartDate"].ToString(), out _StartDate);

            if (objDr.Table.Columns["AssignmentEndDate"] != null)
                DateTime.TryParse(objDr["AssignmentEndDate"].ToString(), out _EndDate);

            if (objDr.Table.Columns["AssignmentIsPermanent"] != null)
                bool.TryParse(objDr["AssignmentIsPermanent"].ToString(), out _IsPermanent);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + @" where (ObjectValue !=0)and ( (AssignmentIsPermanent = 1) OR
                         (AssignmentEndDate > GETDATE())) ";
            if (_UserID != 0 && _ObjectCode != null && _ObjectCode != "")
            {
                strSql += " and UserID = "+ _UserID +" and ObjectCode='"+ _ObjectCode +"'";
            }
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        public void JoinUserAssignmentObject()
        {
            if (_ObjectAssignTable == null)
                return;
            List<string> arrStr = new List<string>();
            string strSql = @"delete FROM            dbo.UMSUserObjectAssignment
WHERE ((AssignmentIsPermanent = 1) or (AssignmentEndDate > GETDATE())) AND(UserID = "+_UserID+@") AND(ObjectCode = '"+_ObjectCode+"')  ";
            arrStr.Add(strSql);
            UserObjectAssignmentDb objDb;
            foreach (DataRow objDr in _ObjectAssignTable.Rows)
            {
                objDb = new UserObjectAssignmentDb(objDr);
                objDb.UserID = _UserID;
                objDb.ObjectCode = ObjectCode;
                arrStr.Add(objDb.AddStr);
            }
            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
