using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
   public  class UnitCategoryDb : BaseSingleDb
    {

        #region Constructor
        public UnitCategoryDb()
        {
        }
        public UnitCategoryDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        
        public   string AddStr
        {
            get
            {
                string Returned = " insert into CRMUnitCategory (CategoryID,CategoryNameA,CategoryNameE,CategoryCode,UsrIns,TimIns) values (," + ID + ",'" + NameA + "','" + NameE + "','" + Code + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update CRMUnitCategory set CategoryNameA='" + NameA + "'" +
           ",CategoryNameE='" + NameE + "'" +
           ",CategoryCode='" + Code + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where CategoryID="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update CRMUnitCategory set Dis = GetDate() where  CategoryID = "+ _ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select CategoryID,CategoryNameA,CategoryNameE,CategoryCode
from CRMUnitCategory  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CategoryID"] != null)
                int.TryParse(objDr["CategoryID"].ToString(), out _ID);

            if (objDr.Table.Columns["CategoryNameA"] != null)
                _NameA = objDr["CategoryNameA"].ToString();

            if (objDr.Table.Columns["CategoryNameE"] != null)
                _NameE = objDr["CategoryNameE"].ToString();

            if (objDr.Table.Columns["CategoryCode"] != null)
                _Code = objDr["CategoryCode"].ToString();
        }

        #endregion
        #region Public Method 
        public override void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
