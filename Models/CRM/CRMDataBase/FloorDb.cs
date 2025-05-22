using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

using SharpVision.UMS.UMSDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class FloorDb:BaseSingleDb
    {

        #region Constructor
        public FloorDb()
        {
        }
        public FloorDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        
        int _Value;
        public int Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        
        public string AddStr
        {
            get
            {
                string Returned = " insert into CRMFloor (FloorValue,FloorCode,FloorNameA,FloorNameE,UsrIns,TimIns) values (" + Value + ",'" + Code + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update CRMFloor set FloorValue=" + Value + "" +
           ",FloorCode='" + Code + "'" +
           ",FloorNameA='" + NameA + "'" +
           ",FloorNameE='" + NameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where FloorID="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update CRMFloor set Dis = GetDate() where  FloorID = "+_ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select FloorID,FloorValue,FloorCode,FloorNameA,FloorNameE from CRMFloor  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["FloorID"] != null)
                int.TryParse(objDr["FloorID"].ToString(), out _ID);

            if (objDr.Table.Columns["FloorValue"] != null)
                int.TryParse(objDr["FloorValue"].ToString(), out _Value);

            if (objDr.Table.Columns["FloorCode"] != null)
                _Code = objDr["FloorCode"].ToString();

            if (objDr.Table.Columns["FloorNameA"] != null)
                _NameA = objDr["FloorNameA"].ToString();

            if (objDr.Table.Columns["FloorNameE"] != null)
                _NameE = objDr["FloorNameE"].ToString();
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
