using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatENM.ERP.ERPDataBase;
using System.Data;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class BufferTypeBiz
    {

        #region Constructor
        public BufferTypeBiz()
        {
            _BufferTypeDb = new BufferTypeDb();
        }
        public BufferTypeBiz(DataRow objDr)
        {
            _BufferTypeDb = new BufferTypeDb(objDr);
        }

        #endregion
        #region Private Data
        BufferTypeDb _BufferTypeDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _BufferTypeDb.ID = value;
            get => _BufferTypeDb.ID;
        }
        public string Code
        {
            set => _BufferTypeDb.Code = value;
            get => _BufferTypeDb.Code;
        }
        public string NameA
        {
            set => _BufferTypeDb.NameA = value;
            get => _BufferTypeDb.NameA;
        }
        public string NameE
        {
            set => _BufferTypeDb.NameE = value;
            get => _BufferTypeDb.NameE;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _BufferTypeDb.Add();
        }
        public void Edit()
        {
            _BufferTypeDb.Edit();
        }
        public void Delete()
        {
            _BufferTypeDb.Delete();
        }
        #endregion
    }
}