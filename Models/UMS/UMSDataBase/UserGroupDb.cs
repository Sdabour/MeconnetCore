using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.UMS.UMSDataBase
{
    public class UserGroupDb
    {

        #region Constructor
        public UserGroupDb()
        {
        }
        public UserGroupDb(DataRow objDr)
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
        int _GroupID;
        public int GroupID
        {
            set
            {
                _GroupID = value;
            }
            get
            {
                return _GroupID;
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
        string _Name;
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }
        string _Desc;
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
        public string AddStr
        {
            get
            {
                string Returned = " insert into UMSUserGroup (UserID,GroupID,IsPermanent,StartDate,EndDate) values (" + UserID + "," + GroupID + "," +
                    (IsPermanent ? 1 : 0) + "," + (StartDate.ToOADate() - 2).ToString() + "," +
                    (EndDate.ToOADate() - 2).ToString() + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UMSUserGroup set " + "UserID=" + UserID + "" +
           ",GroupID=" + GroupID + "" +
           ",IsPermanent=" + (IsPermanent ? 1 : 0) + "" +
           ",StartDate=" + (StartDate.ToOADate() - 2).ToString() + "" +
           ",EndDate=" + (EndDate.ToOADate() - 2).ToString() + "" +
           " where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UMSUserGroup set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strGroup = @"SELECT   GroupID AS UserGroupID, GroupName AS UserGroupName, '' AS UserGroupDesc
FROM            dbo.UMSGroup";
                string Returned = @" select UserID,GroupID,IsPermanent,StartDate,EndDate,UserGroupID
       ,UserGroupName,UserGroupDesc 
          from UMSUserGroup  
      inner join (" + strGroup + @") as GroupTable 
on dbo.UMSUserGroup.GroupID = GroupTable.UserGroupID
";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["UserID"] != null)
                int.TryParse(objDr["UserID"].ToString(), out _UserID);

            if (objDr.Table.Columns["GroupID"] != null)
                int.TryParse(objDr["GroupID"].ToString(), out _GroupID);

            if (objDr.Table.Columns["IsPermanent"] != null)
                bool.TryParse(objDr["IsPermanent"].ToString(), out _IsPermanent);

            if (objDr.Table.Columns["StartDate"] != null)
                DateTime.TryParse(objDr["StartDate"].ToString(), out _StartDate);

            if (objDr.Table.Columns["EndDate"] != null)
                DateTime.TryParse(objDr["EndDate"].ToString(), out _EndDate);

            if (objDr.Table.Columns["UserGroupID"] != null)
                int.TryParse(objDr["UserGroupID"].ToString(), out _ID);

            if (objDr.Table.Columns["UserGroupName"] != null)
                _Name = objDr["UserGroupName"].ToString();

            if (objDr.Table.Columns["UserGroupDesc"] != null)
                _Desc = objDr["UserGroupDesc"].ToString();
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
            string strSql = SearchStr + @" where ( (dbo.UMSUserGroup.IsPermanent = 1) OR
                         (dbo.UMSUserGroup.EndDate >= GETDATE())) ";

            if (_UserID != 0)
                strSql += " and UserID = "+ _UserID;

            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
