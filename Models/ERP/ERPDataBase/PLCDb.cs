using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class PLCDb
    {

        #region Constructor
        public PLCDb()
        {
        }
        public PLCDb(DataRow objDr)
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
        string _Desc;
        public string Desc { set => _Desc = value; get => _Desc; }
        int _Type;
        public int Type
        {
            set => _Type = value;
            get => _Type;
        }
        int _CpuType;
        public int CpuType
        {
            set => _CpuType = value;
            get => _CpuType;
        }
        string _IP;
        public string IP
        {
            set => _IP = value;
            get => _IP;
        }
        int _Slot;
        public int Slot
        {
            set => _Slot = value;
            get => _Slot;
        }
        int _Rack;
        public int Rack
        {
            set => _Rack = value;
            get => _Rack;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPPLC (PLCID,PLCDesc,PLCType,PLCCpuType,PLCIP,PLCSlot,PLCRack,UsrIns,TimIns) values ('"+_Desc+"'," + Type + "," + CpuType + ",'" + IP + "'," + Slot + "," + Rack + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPPLC set PLCDsc='"+_Desc+"',  PLCType=" + Type + "" +
           ",PLCCpuType=" + CpuType + "" +
           ",PLCIP='" + IP + "'" +
           ",PLCSlot=" + Slot + "" +
           ",PLCRack=" + Rack + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where PLCID="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPPLC set Dis = GetDate() where PLCID ="+_ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select PLCID,PLCDesc,PLCType,PLCCpuType,PLCIP,PLCSlot,PLCRack from ERPPLC  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["PLCID"] != null)
                int.TryParse(objDr["PLCID"].ToString(), out _ID);

            if (objDr.Table.Columns["PLCDesc"] != null)
                _Desc = objDr["PLCDesc"].ToString();
            if (objDr.Table.Columns["PLCType"] != null)
                int.TryParse(objDr["PLCType"].ToString(), out _Type);

            if (objDr.Table.Columns["PLCCpuType"] != null)
                int.TryParse(objDr["PLCCpuType"].ToString(), out _CpuType);

            if (objDr.Table.Columns["PLCIP"] != null)
                _IP = objDr["PLCIP"].ToString();

            if (objDr.Table.Columns["PLCSlot"] != null)
                int.TryParse(objDr["PLCSlot"].ToString(), out _Slot);

            if (objDr.Table.Columns["PLCRack"] != null)
                int.TryParse(objDr["PLCRack"].ToString(), out _Rack);
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