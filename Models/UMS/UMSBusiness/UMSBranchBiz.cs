using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.UMS.UMSBusiness
{
    public class UMSBranchBiz
    {
        #region Private Data
        UMSBranchDb _BranchDb;
        #endregion
        #region Constructors
        public UMSBranchBiz()
        {
            _BranchDb = new UMSBranchDb();

        }
        public UMSBranchBiz(DataRow objDr)
        {
            _BranchDb = new UMSBranchDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _BranchDb.ID = value;
            }
            get
            {
                return _BranchDb.ID;
            }
        }
        public string Name
        {
            set
            {
                _BranchDb.Name = value;
            }
            get
            {
                return _BranchDb.Name;
            }
        }
        bool _IsStopped;

        public bool IsStopped
        {
            get { return _IsStopped; }
            set { _IsStopped = value; }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public UMSBranchBiz Copy()
        {
            UMSBranchBiz Returned = new UMSBranchBiz();
            Returned.ID = ID;
            Returned.Name = Name;
            return Returned;
        }
        #endregion
    }
}
