using SharpVision.SystemBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class WorkCenterDb
    {

        #region Constructor
        public WorkCenterDb()
        {
        }
        public WorkCenterDb(DataRow objDr)
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
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPWorkCenter (CenterID,CenterCode,CenterNameA,CenterNameE,CenterDesc,UsrIns,TimIns) values (," + ID + ",'" + Code + "','" + NameA + "','" + NameE + "','" + Desc + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPWorkCenter set " + "CenterID=" + ID + "" +
           ",CenterCode='" + Code + "'" +
           ",CenterNameA='" + NameA + "'" +
           ",CenterNameE='" + NameE + "'" +
           ",CenterDesc='" + Desc + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPWorkCenter set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select CenterID,CenterCode,CenterNameA,CenterNameE,CenterDesc from ERPWorkCenter  ";
                return Returned;
            }
        }
        #endregion 
            #region Private Method
                 void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CenterID"] != null)
                int.TryParse(objDr["CenterID"].ToString(), out _ID);

            if (objDr.Table.Columns["CenterCode"] != null)
                _Code = objDr["CenterCode"].ToString();

            if (objDr.Table.Columns["CenterNameA"] != null)
                _NameA = objDr["CenterNameA"].ToString();

            if (objDr.Table.Columns["CenterNameE"] != null)
                _NameE = objDr["CenterNameE"].ToString();

            if (objDr.Table.Columns["CenterDesc"] != null)
                _Desc = objDr["CenterDesc"].ToString();
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