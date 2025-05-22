using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class BufferTypeDb
    {

        #region Constructor
        public BufferTypeDb()
        {
        }
        public BufferTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        string _NameA;
        public string NameA
        {
            set => _NameA = value;
            get => _NameA;
        }
        string _NameE;
        public string NameE
        {
            set => _NameE = value;
            get => _NameE;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPBufferType (TypeID,TypeCode,TypeNameA,TypeNameE,UsrIns,TimIns) values (," + ID + ",'" + Code + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPBufferType set " + "TypeID=" + ID + "" +
           ",TypeCode='" + Code + "'" +
           ",TypeNameA='" + NameA + "'" +
           ",TypeNameE='" + NameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPBufferType set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select TypeID,TypeCode,TypeNameA,TypeNameE from ERPBufferType  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["TypeID"] != null)
                int.TryParse(objDr["TypeID"].ToString(), out _ID);

            if (objDr.Table.Columns["TypeCode"] != null)
                _Code = objDr["TypeCode"].ToString();

            if (objDr.Table.Columns["TypeNameA"] != null)
                _NameA = objDr["TypeNameA"].ToString();

            if (objDr.Table.Columns["TypeNameE"] != null)
                _NameE = objDr["TypeNameE"].ToString();
        }

        #endregion
        #region Public Method 
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
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}