using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
    public class MaintainanceDiscountDb
    {

        #region Constructor
        public MaintainanceDiscountDb()
        {
        }
        public MaintainanceDiscountDb(DataRow objDr)
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
        int _CreditROID;
        public int CreditROID
        {
            set
            {
                _CreditROID = value;
            }
            get
            {
                return _CreditROID;
            }
        }
        int _CreditID;
        public int CreditID
        {
            set
            {
                _CreditID = value;
            }
            get
            {
                return _CreditID;
            }
        }
        int _Type;
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        DateTime _Date;
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
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
        double _Value;
        public double Value
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
        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; }
        string _ROIDs;
        public string ROIDs 
        { set => _ROIDs = value; }
        int _CreditedStatus;
        public int CreditedStatus { set => _CreditedStatus = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNROCreditDiscount (CreditROID,CreditID,CreditDiscountType,CreditDiscountDate,CreditDiscountDesc,CreditDiscountValue,UsrIns,TimIns) values (" + CreditROID + "," + CreditID + "," + Type + "," + (Date.ToOADate() - 2).ToString() + ",'" + Desc + "'," + Value + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNROCreditDiscount set CreditID=" + CreditID + "" +
           ",CreditDiscountType=" + Type + "" +
           ",CreditDiscountDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",CreditDiscountDesc='" + Desc + "'" +
           ",CreditDiscountValue=" + Value + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where CreditROID = "+_CreditROID + " and CreditDiscountID = "+_ID + " and CreditID=0  ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " delete from MNROCreditDiscount where CreditROID = " + _CreditROID + " and CreditDiscountID = " + _ID + " and CreditID=0 ";




                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select CreditDiscountID,CreditROID,CreditID,CreditDiscountType,CreditDiscountDate,CreditDiscountDesc,CreditDiscountValue,ROTable.*,DiscountTypeTable.* 
      from MNROCreditDiscount  
     inner join (" + new RODb().SearchStr + @") as ROTable 
    on MNROCreditDiscount.CreditROID = ROTable.ROID 
    left outer join ("+new MaintainanceDiscountTypeDb().SearchStr + @") as DiscountTypeTable 
    on MNROCreditDiscount.CreditDiscountType =  DiscountTypeTable.DiscountTypeID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CreditDiscountID"] != null)
                int.TryParse(objDr["CreditDiscountID"].ToString(), out _ID);

            if (objDr.Table.Columns["CreditROID"] != null)
                int.TryParse(objDr["CreditROID"].ToString(), out _CreditROID);

            if (objDr.Table.Columns["CreditID"] != null)
                int.TryParse(objDr["CreditID"].ToString(), out _CreditID);

            if (objDr.Table.Columns["CreditDiscountType"] != null)
                int.TryParse(objDr["CreditDiscountType"].ToString(), out _Type);

            if (objDr.Table.Columns["CreditDiscountDate"] != null)
                DateTime.TryParse(objDr["CreditDiscountDate"].ToString(), out _Date);

            if (objDr.Table.Columns["CreditDiscountDesc"] != null)
                _Desc = objDr["CreditDiscountDesc"].ToString();

            if (objDr.Table.Columns["CreditDiscountValue"] != null)
                double.TryParse(objDr["CreditDiscountValue"].ToString(), out _Value);
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
            string strSql = SearchStr + " where (1=1) ";
            if (_ROIDs != null && _ROIDs != "")
            {
                strSql += " and CreditROID in (" + _ROIDs + ")";
            }
            if (_IsDateRange)
                strSql += " and CreditDiscountDate between " + (_StartDate.Date.ToOADate() - 2) + " and " + (_EndDate.Date.ToOADate() - 1) + " "; 
            if (_CreditedStatus == 1)
                strSql += " and CreditID >0 ";
            else if(_CreditedStatus==2)
                strSql += " and CreditID =0 ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
