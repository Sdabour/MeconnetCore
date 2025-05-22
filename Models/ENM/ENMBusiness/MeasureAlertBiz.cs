using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatENM.ENM.ENMDb;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeasureAlertBiz
    {
       
        #region Constructor
        public MeasureAlertBiz()
        {
            _MeasureAlertDb = new MeasureAlertDb();
        }
        public MeasureAlertBiz(DataRow objDr)
        {
            _MeasureAlertDb = new MeasureAlertDb(objDr);
            _MeterBiz = new EMeterBiz() { ID=_MeasureAlertDb.Meter,Desc=_MeasureAlertDb.EMeterDesc};
            _MeasureTypeBiz = new EMeasureTypeBiz() { ID=_MeasureAlertDb.MeasureType,NameA=_MeasureAlertDb.EMeasureTypeNameA,NameE=_MeasureAlertDb.EMeasureTypeNameE,Accumulated=_MeasureAlertDb.EMeasureTypeAccumulated};

        }

        #endregion
        #region Private Data
        MeasureAlertDb _MeasureAlertDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _MeasureAlertDb.ID = value;
            get => _MeasureAlertDb.ID;
        }
        public int Meter
        {
            set => _MeasureAlertDb.Meter = value;
            get => _MeasureAlertDb.Meter;
        }
        public int MeasureType
        {
            set => _MeasureAlertDb.MeasureType = value;
            get => _MeasureAlertDb.MeasureType;
        }
        public DateTime Time
        {
            set => _MeasureAlertDb.Time = value;
            get => _MeasureAlertDb.Time;
        }
        public double MinValue
        {
            set => _MeasureAlertDb.MinValue = value;
            get => _MeasureAlertDb.MinValue;
        }
        public double MaxValue
        {
            set => _MeasureAlertDb.MaxValue = value;
            get => _MeasureAlertDb.MaxValue;
        }
        public double Value
        {
            set => _MeasureAlertDb.Value = value;
            get => _MeasureAlertDb.Value;
        }
        public int Reason
        {
            set => _MeasureAlertDb.Reason = value;
            get => _MeasureAlertDb.Reason;
        }
        public bool Stop
        {
            set => _MeasureAlertDb.Stop = value;
            get => _MeasureAlertDb.Stop;
        }
        public DateTime StopTime
        {
            set => _MeasureAlertDb.StopTime = value;
            get => _MeasureAlertDb.StopTime;
        }
        public bool Ack
        {
            set => _MeasureAlertDb.Ack = value;
            get => _MeasureAlertDb.Ack;
        }
        public int AckUser
        {
            set => _MeasureAlertDb.AckUser = value;
            get => _MeasureAlertDb.AckUser;
        }
        public DateTime AckTime
        {
            set => _MeasureAlertDb.AckTime = value;
            get => _MeasureAlertDb.AckTime;
        }
        public DateTime SnoozeTime
        {
            set => _MeasureAlertDb.SnoozeTime = value;
            get => _MeasureAlertDb.SnoozeTime;
        }
        public string EMeasureTypeNameA
        {
            set => _MeasureAlertDb.EMeasureTypeNameA = value;
            get => _MeasureAlertDb.EMeasureTypeNameA;
        }
        public string EMeasureTypeNameE
        {
            set => _MeasureAlertDb.EMeasureTypeNameE = value;
            get => _MeasureAlertDb.EMeasureTypeNameE;
        }
        public string EMeasureTypeUnit
        {
            set => _MeasureAlertDb.EMeasureTypeUnit = value;
            get => _MeasureAlertDb.EMeasureTypeUnit;
        }
        public bool EMeasureTypeAccumulated
        {
            set => _MeasureAlertDb.EMeasureTypeAccumulated = value;
            get => _MeasureAlertDb.EMeasureTypeAccumulated;
        }
        public string EMeterDesc
        {
            set => _MeasureAlertDb.EMeterDesc = value;
            get => _MeasureAlertDb.EMeterDesc;
        }
        public string UFN
        {
            set => _MeasureAlertDb.UFN = value;
            get => _MeasureAlertDb.UFN;
        }
        public string UN
        {
            set => _MeasureAlertDb.UN = value;
            get => _MeasureAlertDb.UN;
        }
        EMeterBiz _MeterBiz;
        public EMeterBiz MeterBiz
        { set => _MeterBiz = value;
            get
            {
                if (_MeterBiz == null)
                    _MeterBiz = new EMeterBiz();
                return _MeterBiz;
            }
        }
        EMeasureTypeBiz _MeasureTypeBiz;
        public EMeasureTypeBiz MeasureTypeBiz
        {
            set => _MeasureTypeBiz = value;
            get
            {
                if (_MeasureTypeBiz == null)
                    _MeasureTypeBiz = new EMeasureTypeBiz();
                return _MeasureTypeBiz;
            }
        }
        public static int UMSAckAlert { get => 2316; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MeasureAlertDb.Add();
        }
        public void Edit()
        {
            _MeasureAlertDb.Edit();
        }
        public void Delete()
        {
            _MeasureAlertDb.Delete();
        }
        public static void AckAlert(int intAlertID,int intUser)
        {
            MeasureAlertDb objDb = new MeasureAlertDb() { ID = intAlertID,AckUser=intUser };
            objDb.AckAlert();
        }
        #endregion
    }
}