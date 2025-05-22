using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatMN.MN.MNDb
{
   public  class CostTypeDb
    {
        #region Constructor
        public CostTypeDb()
        {
        }
        public CostTypeDb(DataRow objDr)
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
        string _Unit;
      
        
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNCostType (CostTypeCode,CostTypeNameA,CostTypeNameE,UsrIns,TimIns) values ('" + Code + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNCostType set CostTypeCode='" + Code + "'" +
           ",CostTypeNameA='" + NameA + "'" +
           ",CostTypeNameE='" + NameE + "'" +
           ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where CostTypeID=" + ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNCostType set Dis = GetDate() where  CostTypeID=" + ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select CostTypeID,CostTypeCode,CostTypeNameA,CostTypeNameE from MNCostType  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CostTypeID"] != null)
                int.TryParse(objDr["CostTypeID"].ToString(), out _ID);

            if (objDr.Table.Columns["CostTypeCode"] != null)
                _Code = objDr["CostTypeCode"].ToString();

            if (objDr.Table.Columns["CostTypeNameA"] != null)
                _NameA = objDr["CostTypeNameA"].ToString();

            if (objDr.Table.Columns["CostTypeNameE"] != null)
                _NameE = objDr["CostTypeNameE"].ToString();

      
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
