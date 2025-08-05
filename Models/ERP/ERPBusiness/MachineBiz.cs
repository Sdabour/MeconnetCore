using System.Data;
using AlgorithmatENM.ERP.ERPDataBase;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class MachineBiz
    {

        #region Constructor
        public MachineBiz()
        {
            _MachineDb = new MachineDb();
        }
        public MachineBiz(DataRow objDr)
        {
            _MachineDb = new MachineDb(objDr);
        }

        #endregion
        #region Private Data
        MachineDb _MachineDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _MachineDb.ID = value;
            get => _MachineDb.ID;
        }
        public int Process
        {
            set => _MachineDb.Process = value;
            get => _MachineDb.Process;
        }
        public int Center
        {
            set => _MachineDb.Center = value;
            get => _MachineDb.Center;
        }
        public int Flow
        {
            set => _MachineDb.Flow = value;
            get => _MachineDb.Flow;
        }
        public string Code
        {
            set => _MachineDb.Code = value;
            get => _MachineDb.Code;
        }
        public string Desc
        {
            set => _MachineDb.Desc = value;
            get => _MachineDb.Desc;
        }
        public string NameA
        {
            set => _MachineDb.NameA = value;
            get => _MachineDb.NameA;
        }
        public string NameE
        {
            set => _MachineDb.NameE = value;
            get => _MachineDb.NameE;
        }
        ProcessBiz _ProcessBiz;
        public ProcessBiz ProcessBiz { set => _ProcessBiz = value;
            get {
                if(_ProcessBiz==null)
                {
                    _ProcessBiz = new ProcessBiz() { Code=_MachineDb.ProcessCode,ID=_MachineDb.ProcessID,NameA=_MachineDb.ProcessNameA,NameE=_MachineDb.ProcessNameE};
                }
                return _ProcessBiz;
            }
        }
        WorkCenterBiz _CenterBiz;
        public WorkCenterBiz CenterBiz
        {
            set => _CenterBiz = value;
            get {
                if (_CenterBiz == null)
                {
                    _CenterBiz = new WorkCenterBiz() { Code = _MachineDb.CenterCode, ID = _MachineDb.CenterID, NameA = _MachineDb.CenterNameA, NameE = _MachineDb.CenterNameE };
                }
                    return _CenterBiz;
                } }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MachineDb.Add();
        }
        public void Edit()
        {
            _MachineDb.Edit();
        }
        public void Delete()
        {
            _MachineDb.Delete();
        }
        #endregion
    }
}
