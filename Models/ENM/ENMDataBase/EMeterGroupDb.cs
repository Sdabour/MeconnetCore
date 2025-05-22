using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ENM.ENMDb
{
    public class EMeterGroupDb
    {

        #region Constructor
        public EMeterGroupDb()
        {
        }
        public EMeterGroupDb(DataRow objDr)
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
        string _NameA;
        public string NameA
        {
            set
            {
                _NameA = value;
            }
            get
            {
                return _NameA;
            }
        }
        string _NameE;
        public string NameE
        {
            set
            {
                _NameE = value;
            }
            get
            {
                return _NameE;
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
                string Returned = " insert into ENMEMeterGroup (GroupCode,GroupNameA,GroupNameE,GroupDesc,UsrIns,TimIns) values ('" + Code + "','" + NameA + "','" + NameE + "','" + Desc + "',"  + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ENMEMeterGroup set GroupCode='" + Code + "'" +
           ",GroupNameA='" + NameA + "'" +
           ",GroupNameE='" + NameE + "'" +
           ",GroupDesc='" + Desc + "'"
           + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where GroupID=" + ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ENMEMeterGroup set Dis = GetDate() where   GroupID=" + ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select GroupID,GroupCode,GroupNameA,GroupNameE,GroupDesc from ENMEMeterGroup  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["GroupID"] != null)
                int.TryParse(objDr["GroupID"].ToString(), out _ID);

            if (objDr.Table.Columns["GroupCode"] != null)
                _Code = objDr["GroupCode"].ToString();

            if (objDr.Table.Columns["GroupNameA"] != null)
                _NameA = objDr["GroupNameA"].ToString();

            if (objDr.Table.Columns["GroupNameE"] != null)
                _NameE = objDr["GroupNameE"].ToString();

            if (objDr.Table.Columns["GroupDesc"] != null)
                _Desc = objDr["GroupDesc"].ToString();
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
