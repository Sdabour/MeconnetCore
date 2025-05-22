using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatMN.MN.MNDb;
namespace AlgorithmatMN.MN.MNBiz
{
    public class CostTypeBiz
    {

        #region Constructor
        public CostTypeBiz()
        {
            _CostTypeDb = new CostTypeDb();
        }
        public CostTypeBiz(DataRow objDr)
        {
            _CostTypeDb = new CostTypeDb(objDr);
        }

        #endregion
        #region Private Data
        CostTypeDb _CostTypeDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _CostTypeDb.ID = value;
            }
            get
            {
                return _CostTypeDb.ID;
            }
        }
        public string Code
        {
            set
            {
                _CostTypeDb.Code = value;
            }
            get
            {
                return _CostTypeDb.Code;
            }
        }
        public string NameA
        {
            set
            {
                _CostTypeDb.NameA = value;
            }
            get
            {
                return _CostTypeDb.NameA;
            }
        }
        public string NameE
        {
            set
            {
                _CostTypeDb.NameE = value;
            }
            get
            {
                return _CostTypeDb.NameE;
            }
        }
     
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _CostTypeDb.Add();
        }
        public void Edit()
        {
            _CostTypeDb.Edit();
        }
        public void Delete()
        {
            _CostTypeDb.Delete();
        }
        #endregion
    }
}
