using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatMN.MN.MNDb
{
    public class MaintainanceDiscountTypeDb
    {

        #region Constructor
        public MaintainanceDiscountTypeDb()
        {
        }
        public MaintainanceDiscountTypeDb(DataRow objDr)
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
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNDiscountType (DiscountTypeCode,DiscountTypeNameA,DiscountTypeNameE,UsrIns,TimIns) values ('" + Code + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNDiscountType set  DiscountTypeCode='" + Code + "'" +
           ",DiscountTypeNameA='" + NameA + "'" +
           ",DiscountTypeNameE='" + NameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where DiscountTypeID ="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNDiscountType set Dis = GetDate() where DiscountTypeID= "+_ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select DiscountTypeID,DiscountTypeCode,DiscountTypeNameA,DiscountTypeNameE from MNDiscountType  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["DiscountTypeID"] != null)
                int.TryParse(objDr["DiscountTypeID"].ToString(), out _ID);

            if (objDr.Table.Columns["DiscountTypeCode"] != null)
                _Code = objDr["DiscountTypeCode"].ToString();

            if (objDr.Table.Columns["DiscountTypeNameA"] != null)
                _NameA = objDr["DiscountTypeNameA"].ToString();

            if (objDr.Table.Columns["DiscountTypeNameE"] != null)
                _NameE = objDr["DiscountTypeNameE"].ToString();
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
