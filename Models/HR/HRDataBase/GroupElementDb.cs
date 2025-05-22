using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class GroupElementDb : BaseSingleDb
    {

        #region Constructor
        public GroupElementDb()
        {
        }
        public GroupElementDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties

        double _Perc;
        public double Perc
        { set => _Perc = value;
            get => _Perc;
        }
        int _Order;
        public int Order
        { set => _Order = value;
            get => _Order;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into HRElementGroup (GroupElementCode,GroupElementNameA,GroupElementNameE,UsrIns,TimIns) values ('" + Code + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HRElementGroup set GroupElementCode='" + Code + "'" +
           ",GroupElementNameA='" + NameA + "'" +
           ",GroupElementNameE='" + NameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where GroupElementID = "+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HRElementGroup set Dis = GetDate() where  GroupElementID = " + _ID ;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select GroupElementID,GroupElementCode,GroupElementNameA,GroupElementNameE from HRElementGroup  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["GroupElementID"] != null)
                int.TryParse(objDr["GroupElementID"].ToString(), out _ID);

            if (objDr.Table.Columns["GroupElementCode"] != null)
                _Code = objDr["GroupElementCode"].ToString();

            if (objDr.Table.Columns["GroupElementNameA"] != null)
                _NameA = objDr["GroupElementNameA"].ToString();

            if (objDr.Table.Columns["GroupElementNameE"] != null)
                _NameE = objDr["GroupElementNameE"].ToString();
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
