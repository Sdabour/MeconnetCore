using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatENM.ENM.ENMDb;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class EMeasureTypeBiz
    {

        #region Constructor
        public EMeasureTypeBiz()
        {
            _EMeasureTypeDb = new EMeasureTypeDb();
        }
        public EMeasureTypeBiz(DataRow objDr)
        {
            _EMeasureTypeDb = new EMeasureTypeDb(objDr);
        }

        #endregion
        #region Private Data
        EMeasureTypeDb _EMeasureTypeDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _EMeasureTypeDb.ID = value;
            }
            get
            {
                return _EMeasureTypeDb.ID;
            }
        }
        public string Code
        {
            set
            {
                _EMeasureTypeDb.Code = value;
            }
            get
            {
                return _EMeasureTypeDb.Code;
            }
        }
        public string NameA
        {
            set
            {
                _EMeasureTypeDb.NameA = value;
            }
            get
            {
                return _EMeasureTypeDb.NameA;
            }
        }
        public string NameE
        {
            set
            {
                _EMeasureTypeDb.NameE = value;
            }
            get
            {
                return _EMeasureTypeDb.NameE;
            }
        }
        public string Unit
        {
            set
            {
                _EMeasureTypeDb.Unit = value;
            }
            get
            {
                return _EMeasureTypeDb.Unit;
            }
        }
        public bool Accumulated { set => _EMeasureTypeDb.Accumolated = value; get => _EMeasureTypeDb.Accumolated; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _EMeasureTypeDb.Add();
        }
        public void Edit()
        {
            _EMeasureTypeDb.Edit();
        }
        public void Delete()
        {
            _EMeasureTypeDb.Delete();
        }
        #endregion
    }
}
