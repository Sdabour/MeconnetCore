using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class AccountTypeBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        
        #endregion

        #region Constructors
        public AccountTypeBiz()
        {
            _BaseDb = new AccountTypeDb();
        }
        public AccountTypeBiz(int intID)
        {
            DataRow[] arrDr = AccountTypeDb.AccountTypeTable.Select("AccountTypeID=" + intID);
            if (arrDr.Length > 0)
            {
                _BaseDb = new AccountTypeDb(arrDr[0]);
            }
            else
                _BaseDb = new AccountTypeDb();
        }
        public AccountTypeBiz(DataRow objDR)
        {
            _BaseDb = new AccountTypeDb(objDR);
        }
        #endregion

        #region Public Properties

        public AccountTypeCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {
                    //((AccountTypeDb)_BaseDb).Level = Level;
                    _Children = new AccountTypeCol(ID, ((AccountTypeDb)_BaseDb).GetChildrenTable());

                }
                return (AccountTypeCol)_Children;
            }
        }
        
       
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public void Add()
        {
            ((AccountTypeDb)_BaseDb).ParentID = ParentBiz.ID;
            ((AccountTypeDb)_BaseDb).FamilyID = ParentBiz.FamilyID;
            ((AccountTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((AccountTypeDb)_BaseDb).ParentID = ParentBiz.ID;
            ((AccountTypeDb)_BaseDb).FamilyID = ParentBiz.FamilyID;
            ((AccountTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((AccountTypeDb)_BaseDb).Delete();
        }

        #endregion
    }
}
