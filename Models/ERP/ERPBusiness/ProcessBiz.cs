using System.Data;
using AlgorithmatENM.ERP.ERPDataBase;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class ProcessBiz
    {

        #region Constructor
        public ProcessBiz()
        {
            _ProcessDb = new ProcessDb();
        }
        public ProcessBiz(DataRow objDr)
        {
            _ProcessDb = new ProcessDb(objDr);
        }

        #endregion
        #region Private Data
        ProcessDb _ProcessDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _ProcessDb.ID = value;
            get => _ProcessDb.ID;
        }
        public string Code
        {
            set => _ProcessDb.Code = value;
            get => _ProcessDb.Code;
        }
        public string NameA
        {
            set => _ProcessDb.NameA = value;
            get => _ProcessDb.NameA;
        }
        public string NameE
        {
            set => _ProcessDb.NameE = value;
            get => _ProcessDb.NameE;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _ProcessDb.Add();
        }
        public void Edit()
        {
            _ProcessDb.Edit();
        }
        public void Delete()
        {
            _ProcessDb.Delete();
        }
        #endregion
    }
}
