using System.Data;
using AlgorithmatENM.ERP.ERPDataBase;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    

    public class WorkCenterBiz
    {

        #region Constructor
        public WorkCenterBiz()
        {
            _WorkCenterDb = new WorkCenterDb();
        }
        public WorkCenterBiz(DataRow objDr)
        {
            _WorkCenterDb = new WorkCenterDb(objDr);
        }

        #endregion
        #region Private Data
        WorkCenterDb _WorkCenterDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _WorkCenterDb.ID = value;
            get => _WorkCenterDb.ID;
        }
        public string Code
        {
            set => _WorkCenterDb.Code = value;
            get => _WorkCenterDb.Code;
        }
        public string NameA
        {
            set => _WorkCenterDb.NameA = value;
            get => _WorkCenterDb.NameA;
        }
        public string NameE
        {
            set => _WorkCenterDb.NameE = value;
            get => _WorkCenterDb.NameE;
        }
        public string Desc
        {
            set => _WorkCenterDb.Desc = value;
            get => _WorkCenterDb.Desc;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _WorkCenterDb.Add();
        }
        public void Edit()
        {
            _WorkCenterDb.Edit();
        }
        public void Delete()
        {
            _WorkCenterDb.Delete();
        }
        #endregion
    }
}
