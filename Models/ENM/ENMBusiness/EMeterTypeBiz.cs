using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatENM.ENM.ENMDb;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class EMeterTypeBiz
    {

        #region Constructor
        public EMeterTypeBiz()
        {
            _EMeterTypeDb = new EMeterTypeDb();
        }
        public EMeterTypeBiz(DataRow objDr)
        {
            _EMeterTypeDb = new EMeterTypeDb(objDr);
        }

        #endregion
        #region Private Data
        EMeterTypeDb _EMeterTypeDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _EMeterTypeDb.ID = value;
            }
            get
            {
                return _EMeterTypeDb.ID;
            }
        }
        public string Code
        {
            set
            {
                _EMeterTypeDb.Code = value;
            }
            get
            {
                return _EMeterTypeDb.Code;
            }
        }
        public string NameA
        {
            set
            {
                _EMeterTypeDb.NameA = value;
            }
            get
            {
                return _EMeterTypeDb.NameA;
            }
        }
        public string NameE
        {
            set
            {
                _EMeterTypeDb.NameE = value;
            }
            get
            {
                return _EMeterTypeDb.NameE;
            }
        }
        public string WordStartAddress
        {
            set
            {
                _EMeterTypeDb.WordStartAddress = value;
            }
            get
            {
                return _EMeterTypeDb.WordStartAddress;
            }
        }
        public int WordNo
        {
            set
            {
                _EMeterTypeDb.WordNo = value;
            }
            get
            {
                return _EMeterTypeDb.WordNo;
            }
        }
        public bool Swap
        { set => _EMeterTypeDb.Swap = value; get => _EMeterTypeDb.Swap; }
        public int DataType
        { set => _EMeterTypeDb.DataType = value; get => _EMeterTypeDb.DataType; }
        EMeterTypeMeasureTypeCol _MeasureCol;
        public EMeterTypeMeasureTypeCol MeasureCol
        {
            set => _MeasureCol = value;
            get
            {
                if (_MeasureCol == null)
                {
                    _MeasureCol = new EMeterTypeMeasureTypeCol(true);
                    if (ID != 0)
                    {
                        EMeterTypeMeasureTypeDb objDb = new EMeterTypeMeasureTypeDb();
                        objDb.MeterType = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _MeasureCol.Add(new EMeterTypeMeasureTypeBiz(objDr));

                        }
                    }
                }
                return _MeasureCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _EMeterTypeDb.MeasureTypeTable = MeasureCol.GetTable();
            _EMeterTypeDb.Add();
        }
        public void Edit()
        {
            _EMeterTypeDb.MeasureTypeTable = MeasureCol.GetTable();
            _EMeterTypeDb.Edit();
        }
        public void Delete()
        {
            _EMeterTypeDb.Delete();
        }
        #endregion
    }
}
