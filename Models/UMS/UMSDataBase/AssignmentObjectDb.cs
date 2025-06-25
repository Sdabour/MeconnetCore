using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.UMS.UMSDataBase
{
    public class AssignmentObjectDb
    {

        #region Constructor
        public AssignmentObjectDb()
        {
        }
        public AssignmentObjectDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
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
        string _Code;
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        string _TableName;
        public string TableName
        {
            set
            {
                _TableName = value;
            }
            get
            {
                return _TableName;
            }
        }
        string _TableValueName;
        public string TableValueName
        {
            set
            {
                _TableValueName = value;
            }
            get
            {
                return _TableValueName;
            }
        }
        string _TableDisplayNameA;
        public string TableDisplayNameA
        {
            set
            {
                _TableDisplayNameA = value;
            }
            get
            {
                return _TableDisplayNameA;
            }
        }
        string _TableDisplayNameE;
        public string TableDisplayNameE
        {
            set
            {
                _TableDisplayNameE = value;
            }
            get
            {
                return _TableDisplayNameE;
            }
        }
        string _ConditionStr;
        public string ConditionStr
        { set => _ConditionStr = value; get => _ConditionStr; }
        int _UserID;
        public int UserID
        { set => _UserID = value; }
        public string AddStr
        {
            get
            {
                string Returned = @" insert into UMSAssignmentObject (ObjectDesc,ObjectCode,ObjectTableName,ObjectTableValueName,ObjectTableDisplayNameA,ObjectTableDisplayNameE,ObjectConditionStr) values ('" + Desc + "','" + Code + "','" + TableName + "','" + TableValueName + "','" + TableDisplayNameA + "','" + TableDisplayNameE + "','"+_ConditionStr+"') ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UMSAssignmentObject set ObjectDesc='" + Desc + "'" +
           ",ObjectCode='" + Code + "'" +
           ",ObjectTableName='" + TableName + "'" +
           ",ObjectTableValueName='" + TableValueName + "'" +
           ",ObjectTableDisplayNameA='" + TableDisplayNameA + "'" +
           ",ObjectTableDisplayNameE='" + TableDisplayNameE + "'"+
           ",ObjectConditionStr='"+ _ConditionStr +"'"+
           "  where ObjectID= " +ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UMSAssignmentObject set Dis = GetDate() where  ObjectID ="+ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select ObjectID,ObjectDesc,ObjectCode,ObjectTableName,ObjectTableValueName,ObjectTableDisplayNameA,ObjectTableDisplayNameE,ObjectConditionStr  from UMSAssignmentObject  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ObjectID"] != null)
                int.TryParse(objDr["ObjectID"].ToString(), out _ID);

            if (objDr.Table.Columns["ObjectDesc"] != null)
                _Desc = objDr["ObjectDesc"].ToString();

            if (objDr.Table.Columns["ObjectCode"] != null)
                _Code = objDr["ObjectCode"].ToString();

            if (objDr.Table.Columns["ObjectTableName"] != null)
                _TableName = objDr["ObjectTableName"].ToString();

            if (objDr.Table.Columns["ObjectTableValueName"] != null)
                _TableValueName = objDr["ObjectTableValueName"].ToString();

            if (objDr.Table.Columns["ObjectTableDisplayNameA"] != null)
                _TableDisplayNameA = objDr["ObjectTableDisplayNameA"].ToString();

            if (objDr.Table.Columns["ObjectTableDisplayNameE"] != null)
                _TableDisplayNameE = objDr["ObjectTableDisplayNameE"].ToString();

            if (objDr.Table.Columns["ObjectConditionStr"] != null)
                _ConditionStr = objDr["ObjectConditionStr"].ToString();
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
            string strSql = SearchStr + " where Dis is null ";
            if (_Code != null && _Code != "")
                strSql += " and (ObjectCode='"+_Code+"' or ObjectTableName='"+ _Code +"')";

            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetSimpleObject()
        {if (ID == 0)
                return new DataTable();

            string strSql = "";
            strSql = "select distinct " + TableValueName +" as ID"+
                ","+TableDisplayNameA +" as NameA" ;
            if (TableDisplayNameE != "")
                strSql += "," + TableDisplayNameE + " as NameE";
            else
                strSql += ",'' as NameE";
            strSql += " from " + TableName;
            if (_UserID != 0)
            {
                string strAssignedSql = @"SELECT       ObjectValue
FROM            dbo.UMSUserObjectAssignment
WHERE        (UserID = "+_UserID+@") AND (ObjectCode = '"+ _Code +@"') AND (AssignmentIsPermanent = 1) OR
                         (UserID = "+_UserID+@") AND (ObjectCode = '"+ _Code +@"') AND (AssignmentEndDate > GETDATE())";
                strSql += " inner join (" +strAssignedSql+@") as AssignedTable 
      on "+_TableName +"."+ _TableValueName + " = AssignedTable.ObjectValue ";
            }
            strSql += " where (1=1) " ;
            if (_ConditionStr != "")
                strSql += " and " + _ConditionStr;
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
