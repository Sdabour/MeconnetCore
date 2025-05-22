using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.UMS.UMSDataBase
{
    public class UserSystemDb
    {

        #region Constructor
        public UserSystemDb()
        {
        }
        public UserSystemDb(DataRow objDr)
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
        int _SysID;
        public int SysID
        {
            set
            {
                _SysID = value;
            }
            get
            {
                return _SysID;
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
                string Returned = " insert into UMSUserSystem (UserID,SysID,IsPermanent,StartDate,EndDate) values (" +
                    UserID + "," + SysID + "," +
                    (IsPermanent ? 1 : 0) + "," + (StartDate.ToOADate() - 2).ToString() + "," + 
                    (EndDate.ToOADate() - 2).ToString() +") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UMSUserSystem set " + "UserID=" + UserID + "" +
           ",SysID=" + SysID + "" +
           ",IsPermanent=" + (IsPermanent ? 1 : 0) + "" +
           ",StartDate=" + (StartDate.ToOADate() - 2).ToString() + "" +
           ",EndDate=" + (EndDate.ToOADate() - 2).ToString() + "" +
           ",UserSystemID=" + ID + "" +
           ",UserSystemName='" + Name + "'" +
           ",UserSystemDesc='" + Desc + "'" + " where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UMSUserSystem set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strSystem = @"SELECT   SysID AS UserSystemID, SysName AS UserSystemName, SysDesc AS UserSystemDesc
FROM            dbo.UMSSystem";
                string Returned = @" select UserID,SysID,IsPermanent,StartDate,EndDate,UserSystemID
       ,UserSystemName,UserSystemDesc 
          from UMSUserSystem  
      inner join (" + strSystem+ @") as SystemTable 
on dbo.UMSUserSystem.SysID = SystemTable.UserSystemID
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

            if (objDr.Table.Columns["SysID"] != null)
                int.TryParse(objDr["SysID"].ToString(), out _SysID);

            if (objDr.Table.Columns["IsPermanent"] != null)
                bool.TryParse(objDr["IsPermanent"].ToString(), out _IsPermanent);

            if (objDr.Table.Columns["StartDate"] != null)
                DateTime.TryParse(objDr["StartDate"].ToString(), out _StartDate);

            if (objDr.Table.Columns["EndDate"] != null)
                DateTime.TryParse(objDr["EndDate"].ToString(), out _EndDate);

            if (objDr.Table.Columns["UserSystemID"] != null)
                int.TryParse(objDr["UserSystemID"].ToString(), out _ID);

            if (objDr.Table.Columns["UserSystemName"] != null)
                _Name = objDr["UserSystemName"].ToString();

            if (objDr.Table.Columns["UserSystemDesc"] != null)
                _Desc = objDr["UserSystemDesc"].ToString();
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
            string strSql = SearchStr + " where (UMSUserSystem.IsPermanent = 1 or UMSUserSystem.EndDate >= GetDate()) ";
            if (_UserID != 0)
                strSql += " and UserID="+_UserID;
            if (_SysID != 0)
                strSql += " and SysID = "+ _SysID;


            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
