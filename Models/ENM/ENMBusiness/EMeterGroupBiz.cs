using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatENM.ENM.ENMDb;
using System.Data;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class EMeterGroupBiz
    {

        #region Constructor
        public EMeterGroupBiz()
        {
            _EMeterGroupDb = new EMeterGroupDb();
        }
        public EMeterGroupBiz(DataRow objDr)
        {
            _EMeterGroupDb = new EMeterGroupDb(objDr);
        }

        #endregion
        #region Private Data
        EMeterGroupDb _EMeterGroupDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _EMeterGroupDb.ID = value;
            get => _EMeterGroupDb.ID;
        }
        public string Code
        {
            set => _EMeterGroupDb.Code = value;
            get => _EMeterGroupDb.Code;
        }
        public string NameA
        {
            set => _EMeterGroupDb.NameA = value;
            get => _EMeterGroupDb.NameA;
        }
        public string NameE
        {
            set => _EMeterGroupDb.NameE = value;
            get => _EMeterGroupDb.NameE;
        }
        public string Desc
        {
            set => _EMeterGroupDb.Desc = value;
            get => _EMeterGroupDb.Desc;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _EMeterGroupDb.Add();
        }
        public void Edit()
        {
            _EMeterGroupDb.Edit();
        }
        public void Delete()
        {
            _EMeterGroupDb.Delete();
        }
        #endregion
    }
}
