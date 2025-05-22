using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ENM.ENMDb
{
   public  class EServiceDb
    {

        #region Constructor
        public EServiceDb()
        {
        }
        public EServiceDb(DataRow objDr)
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
        int _IterationPeriod;
        public int IterationPeriod
        {
            set
            {
                _IterationPeriod = value;
            }
            get
            {
                return _IterationPeriod;
            }
        }
        int _IterationValue;
        public int IterationValue
        {
            set
            {
                _IterationValue = value;
            }
            get
            {
                return _IterationValue;
            }
        }
        string _PortName;
        public string PortName
        {
            set
            {
                _PortName = value;
            }
            get
            {
                return _PortName;
            }
        }
        int _Parity;
        public int Parity
        {
            set
            {
                _Parity = value;
            }
            get
            {
                return _Parity;
            }
        }
        int _StopBits;
        public int StopBits
        {
            set
            {
                _StopBits = value;
            }
            get
            {
                return _StopBits;
            }
        }
        int _DataBits;
        public int DataBits
        {
            set
            {
                _DataBits = value;
            }
            get
            {
                return _DataBits;
            }
        }
        int _BaudRate;
        public int BaudRate
        {
            set
            {
                _BaudRate = value;
            }
            get
            {
                return _BaudRate;
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
        public int StoppedStatus
        { set => _StoppedStatus = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ENMEService (EServiceDesc,EServiceIterationPeriod,EServiceIterationValue,EServicePortName,EServiceParity,EServiceStopBits,EServiceDataBits,EServiceBaudRate,EServiceStopped,UsrIns,TimIns) values ('" + Desc + "'," + IterationPeriod + "," + IterationValue + ",'" + PortName + "'," + Parity + "," + StopBits + "," + DataBits + "," + BaudRate + "," + (Stopped ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ENMEService set EServiceDesc='" + Desc + "'" +
           ",EServiceIterationPeriod=" + IterationPeriod + "" +
           ",EServiceIterationValue=" + IterationValue + "" +
           ",EServicePortName='" + PortName + "'" +
           ",EServiceParity=" + Parity + "" +
           ",EServiceStopBits=" + StopBits + "" +
           ",EServiceDataBits=" + DataBits + "" +
           ",EServiceBaudRate=" + BaudRate + "" +
           ",EServiceStopped=" + (Stopped ? 1 : 0) + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where EServiceID ="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ENMEService set Dis = GetDate() where EServiceID= "+ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select EServiceID,EServiceDesc,EServiceIterationPeriod,EServiceIterationValue,EServicePortName,EServiceParity,EServiceStopBits,EServiceDataBits,EServiceBaudRate,EServiceStopped from ENMEService  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["EServiceID"] != null)
                int.TryParse(objDr["EServiceID"].ToString(), out _ID);

            if (objDr.Table.Columns["EServiceDesc"] != null)
                _Desc = objDr["EServiceDesc"].ToString();

            if (objDr.Table.Columns["EServiceIterationPeriod"] != null)
                int.TryParse(objDr["EServiceIterationPeriod"].ToString(), out _IterationPeriod);

            if (objDr.Table.Columns["EServiceIterationValue"] != null)
                int.TryParse(objDr["EServiceIterationValue"].ToString(), out _IterationValue);

            if (objDr.Table.Columns["EServicePortName"] != null)
                _PortName = objDr["EServicePortName"].ToString();

            if (objDr.Table.Columns["EServiceParity"] != null)
                int.TryParse(objDr["EServiceParity"].ToString(), out _Parity);

            if (objDr.Table.Columns["EServiceStopBits"] != null)
                int.TryParse(objDr["EServiceStopBits"].ToString(), out _StopBits);

            if (objDr.Table.Columns["EServiceDataBits"] != null)
                int.TryParse(objDr["EServiceDataBits"].ToString(), out _DataBits);

            if (objDr.Table.Columns["EServiceBaudRate"] != null)
                int.TryParse(objDr["EServiceBaudRate"].ToString(), out _BaudRate);

            if (objDr.Table.Columns["EServiceStopped"] != null)
                bool.TryParse(objDr["EServiceStopped"].ToString(), out _Stopped);
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

            if (_StoppedStatus == 1)
                strSql += " and EServiceStopped=1 ";
            if (ID != 0)
                strSql += " and EServiceID="+ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
