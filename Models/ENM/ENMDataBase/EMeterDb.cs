using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatENM.ENM.ENMDb
{
    public class EMeterDb
    {


        #region Constructor
        public EMeterDb()
        {
        }
        public EMeterDb(DataRow objDr)
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
        string _WordStartAddress;
        public string WordStartAddress
        {
            set
            {
                _WordStartAddress = value;
            }
            get
            {
                return _WordStartAddress;
            }
        }
        int _WordNo;
        public int WordNo
        {
            set
            {
                _WordNo = value;
            }
            get
            {
                return _WordNo;
            }
        }
        int _EService;
        public int EService
        {
            set
            {
                _EService = value;
            }
            get
            {
                return _EService;
            }
        }
        int _Address;
        public int Address
        {
            set
            {
                _Address = value;
            }
            get
            {
                return _Address;
            }
        }
        bool _Swap;
        public bool Swap
        {
            set
            {
                _Swap = value;
            }
            get
            {
                return _Swap;
            }
        }
        bool _Stopped;
        public bool Stopped
        {
            set
            {
                _Stopped = value;
            }
            get
            {
                return _Stopped;
            }
        }
        int _StoppedStatus;
        public int StoppedStatus { set => _StoppedStatus = value; }
        int _Group;
        public int Group { set => _Group = value; get => _Group; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ENMEMeter (EMeterGroup,EMeterType,EMeterDesc,EMeterWordStartAddress,EMeterWordNo,EMeterEService,EMeterAddress,EMeterSwap,EMeterStopped,UsrIns,TimIns) values ("+_Group +"," + Type + ",'" + Desc + "','" + WordStartAddress + "'," + WordNo + "," + EService + "," + Address +","+ (_Swap?1:0)+ "," + (Stopped ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ENMEMeter set EMeterGroup ="+_Group
                    +", EMeterType=" + Type + "" +
           ",EMeterDesc='" + Desc + "'" +
           ",EMeterWordStartAddress='" + WordStartAddress + "'" +
           ",EMeterWordNo=" + WordNo + "" +
           ",EMeterEService=" + EService + "" +
           ",EMeterAddress=" + Address + "" +
           ",EMeterStopped=" + (Stopped ? 1 : 0) + ""
           +",EMeterSwap="+(_Swap?1:0)
           + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where EMeterID="+ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ENMEMeter set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select EMeterID,EMeterType,EMeterDesc,EMeterWordStartAddress,EMeterWordNo,EMeterEService,EMeterAddress,EMeterSwap,EMeterStopped,MeterTypeTable.*,GroupTable.*  from ENMEMeter  inner join (" + new EMeterTypeDb().SearchStr + @") as MeterTypeTable on ENMEMeter.EMeterType = MeterTypeTable.EMeterTypeID 
    left outer join ("+new EMeterGroupDb().SearchStr+ @")  as GroupTable on  ENMEMeter.EMeterGroup = GroupTable.GroupID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["EMeterID"] != null)
                int.TryParse(objDr["EMeterID"].ToString(), out _ID);

            if (objDr.Table.Columns["EMeterType"] != null)
                int.TryParse(objDr["EMeterType"].ToString(), out _Type);

            if (objDr.Table.Columns["EMeterDesc"] != null)
                _Desc = objDr["EMeterDesc"].ToString();

            if (objDr.Table.Columns["EMeterWordStartAddress"] != null)
                _WordStartAddress = objDr["EMeterWordStartAddress"].ToString();

            if (objDr.Table.Columns["EMeterWordNo"] != null)
                int.TryParse(objDr["EMeterWordNo"].ToString(), out _WordNo);

            if (objDr.Table.Columns["EMeterEService"] != null)
                int.TryParse(objDr["EMeterEService"].ToString(), out _EService);

            if (objDr.Table.Columns["EMeterAddress"] != null)
                int.TryParse(objDr["EMeterAddress"].ToString(), out _Address);

            if (objDr.Table.Columns["EMeterStopped"] != null)
                bool.TryParse(objDr["EMeterStopped"].ToString(), out _Stopped);
            if (objDr.Table.Columns["EMeterSwap"] != null)
                bool.TryParse(objDr["EMeterSwap"].ToString(), out _Swap);
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

            if (_EService != 0)
                strSql += " and EMeterEService="+_EService;
            if (_StoppedStatus == 2)
                strSql += "  and EMeterStopped = 1 ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
