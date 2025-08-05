using SharpVision.SystemBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class ProcessDb
    {

        #region Constructor
        public ProcessDb()
        {
        }
        public ProcessDb(DataRow objDr)
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
                string Returned = " insert into ERPProcess (ProcessID,ProcessCode,ProcessNameA,ProcessNameE,UsrIns,TimIns) values (," + ID + ",'" + Code + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPProcess set " + "ProcessID=" + ID + "" +
           ",ProcessCode='" + Code + "'" +
           ",ProcessNameA='" + NameA + "'" +
           ",ProcessNameE='" + NameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPProcess set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select ProcessID,ProcessCode,ProcessNameA,ProcessNameE from ERPProcess  ";
                return Returned;
            }
        }
        #endregion 
            #region Private Method
                 void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ProcessID"] != null)
                int.TryParse(objDr["ProcessID"].ToString(), out _ID);

            if (objDr.Table.Columns["ProcessCode"] != null)
                _Code = objDr["ProcessCode"].ToString();

            if (objDr.Table.Columns["ProcessNameA"] != null)
                _NameA = objDr["ProcessNameA"].ToString();

            if (objDr.Table.Columns["ProcessNameE"] != null)
                _NameE = objDr["ProcessNameE"].ToString();
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
