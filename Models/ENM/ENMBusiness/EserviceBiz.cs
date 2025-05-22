using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatENM.ENM.ENMDb;
using System.Data;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public enum IterationPeriod
    {
        Second,
        Minute,
        Hour,
        Day
    }
    public class EServiceBiz
    {

        #region Constructor
        public EServiceBiz()
        {
            _EServiceDb = new EServiceDb();
        }
        public EServiceBiz(int intService)
        {

            _EServiceDb = new EServiceDb();
            if (intService == 0)
                return;
            EServiceDb objDb = new EServiceDb();
            objDb.ID = intService;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
                objDb = new EServiceDb(dtTemp.Rows[0]);


        }
        public EServiceBiz(DataRow objDr)
        {
            _EServiceDb = new EServiceDb(objDr);
        }

        #endregion
        #region Private Data
        EServiceDb _EServiceDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _EServiceDb.ID = value;
            }
            get
            {
                return _EServiceDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _EServiceDb.Desc = value;
            }
            get
            {
                return _EServiceDb.Desc;
            }
        }

        public IterationPeriod IterationPeriod
        {
            set
            {
                _EServiceDb.IterationPeriod =(int) value;
            }
            get
            {
                return (IterationPeriod)_EServiceDb.IterationPeriod;
            }
        }
        public int IterationValue
        {
            set
            {
                _EServiceDb.IterationValue = value;
            }
            get
            {
                return _EServiceDb.IterationValue;
            }
        }
        public int IterationValueInMiliSeconds
        {
            get
            {
                int Returned = 1000;
                switch(IterationPeriod)
                {
                    case IterationPeriod.Second:Returned*=1; break;
                    case IterationPeriod.Minute: Returned *= 60; break;
                    case IterationPeriod.Hour: Returned *= 60*60; break;
                    case IterationPeriod.Day: Returned *= 24*60 * 60; break;
                    default:Returned = 1000;break;
                }
                return Returned;
            }
        }
        public string PortName
        {
            set
            {
                _EServiceDb.PortName = value;
            }
            get
            {
                return _EServiceDb.PortName;
            }
        }
        public int Parity
        {
            set
            {
                _EServiceDb.Parity = value;
            }
            get
            {
                return _EServiceDb.Parity;
            }
        }
        public int StopBits
        {
            set
            {
                _EServiceDb.StopBits = value;
            }
            get
            {
                return _EServiceDb.StopBits;
            }
        }
        public int DataBits
        {
            set
            {
                _EServiceDb.DataBits = value;
            }
            get
            {
                return _EServiceDb.DataBits;
            }
        }
        public int BaudRate
        {
            set
            {
                _EServiceDb.BaudRate = value;
            }
            get
            {
                return _EServiceDb.BaudRate;
            }
        }
        public bool Stopped
        {
            set
            {
                _EServiceDb.Stopped = value;
            }
            get
            {
                return _EServiceDb.Stopped;
            }
        }
        EMeterCol _MeterCol;
        public EMeterCol MeterCol
        { set => _MeterCol = value;
            get {
                if (_MeterCol == null)
                {
                    _MeterCol = new EMeterCol(true);
                    if (ID != 0)
                    {
                        EMeterDb objDb = new EMeterDb() { EService = ID };
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _MeterCol.Add(new EMeterBiz(objDr) { ServiceBiz = this }) ;

                        }
                    }
                }
                return _MeterCol; }
        }
        public static List<string> IterationPeriodLst
        {
            get
            {
                return new List<string>()
                {
                    "Second",
                    "Minute",
                    "Hour",
                    "Day"
                };
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _EServiceDb.Add();
        }
        public void Edit()
        {
            _EServiceDb.Edit();
        }
        public void Delete()
        {
            _EServiceDb.Delete();
        }
        #endregion
    }
}
