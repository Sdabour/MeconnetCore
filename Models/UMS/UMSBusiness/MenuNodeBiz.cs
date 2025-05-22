using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.UMS.UMSBusiness
{
    public class MenuNodeBiz
    {

        #region Constructor
        public MenuNodeBiz()
        {
            _MenuNodeDb = new MenuNodeDb();
        }
        public MenuNodeBiz(DataRow objDr)
        {
            _MenuNodeDb = new MenuNodeDb(objDr);


            if (_MenuNodeDb.Parent != 0)
            {
                _ParentBiz = new MenuNodeBiz() { ID = _MenuNodeDb.Parent, NameA = _MenuNodeDb.ParentNameA, NameE = _MenuNodeDb.ParentNameE, System = _MenuNodeDb.ParentSys };
            }
            if (_MenuNodeDb.Function != 0)
            {
                _FunctionBiz = new FunctionBiz() { ID = _MenuNodeDb.Function, NameA = _MenuNodeDb.FunctionNameA, NameE = _MenuNodeDb.FunctionNameE, SysID = _MenuNodeDb.FunctionSysID, Url = _MenuNodeDb.FunctionUrl };
            }
            if (_MenuNodeDb.System != 0)
            {
                _SystemBiz = new SystemBiz() { ID = _MenuNodeDb.System, Name = _MenuNodeDb.SystemName, Desc = _MenuNodeDb.SystemDesc };

            }


        }

        #endregion
        #region Private Data
        MenuNodeDb _MenuNodeDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _MenuNodeDb.ID = value;
            }
            get
            {
                return _MenuNodeDb.ID;
            }
        }
        public string Code
        {
            set
            {
                _MenuNodeDb.Code = value;
            }
            get
            {
                return _MenuNodeDb.Code;
            }
        }
        public string NameA
        {
            set
            {
                _MenuNodeDb.NameA = value;
            }
            get
            {
                return _MenuNodeDb.NameA;
            }
        }
        public string NameE
        {
            set
            {
                _MenuNodeDb.NameE = value;
            }
            get
            {
                return _MenuNodeDb.NameE;
            }
        }
        public string URL
        {
            get => _MenuNodeDb.URL;
            set => _MenuNodeDb.URL = value;
        }
        public string AppliedURL
        {
            get
            {
                return URL == null || URL == "" ? FunctionBiz.Url : URL;
            }
        }
        public bool IsNotDisplayed
        {
            get => _MenuNodeDb.IsNotDisplayed;
            set => _MenuNodeDb.IsNotDisplayed = value;
        }
        public virtual string Name
        {
            get
            {
                return UserBiz.Language == 0 && _MenuNodeDb.NameA != null && _MenuNodeDb.NameA != "" ? _MenuNodeDb.NameA :
                    (_MenuNodeDb.NameE != null && _MenuNodeDb.NameE != "" ? _MenuNodeDb.NameE : _MenuNodeDb.NameA);
            }
        }
        public int Parent
        {
            set
            {
                _MenuNodeDb.Parent = value;
            }
            get
            {
                return _MenuNodeDb.Parent;
            }
        }
        public int Order
        {
            set
            {
                _MenuNodeDb.Order = value;
            }
            get
            {
                return _MenuNodeDb.Order;
            }
        }
        MenuNodeBiz _ParentBiz;
        public MenuNodeBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                if (_ParentBiz == null)
                    _ParentBiz = new MenuNodeBiz();
                return _ParentBiz;
            }
        }
        MenuNodeBiz _AncestorBiz;
        public MenuNodeBiz AncestorBiz
        {
            get { return _AncestorBiz; }
            set
            {
                _AncestorBiz = value;
            }
        }
        SystemBiz _SystemBiz;
        public SystemBiz SystemBiz
        {
            set
            {
                _SystemBiz = value;
            }
            get
            {
                if (_SystemBiz == null)
                    _SystemBiz = new SystemBiz();
                return _SystemBiz;
            }
        }
        FunctionBiz _FunctionBiz;
        public FunctionBiz FunctionBiz
        {
            set
            {
                _FunctionBiz = value;
            }
            get
            {
                if (_FunctionBiz == null)
                    _FunctionBiz = new FunctionBiz();
                return _FunctionBiz;
            }
        }

        public int Function
        {
            set
            {
                _MenuNodeDb.Function = value;
            }
            get
            {
                return _MenuNodeDb.Function;
            }
        }
        public int System
        {
            set
            {
                _MenuNodeDb.System = value;
            }
            get
            {
                return _MenuNodeDb.System;
            }
        }
        public bool IsStopped
        {
            set
            {
                _MenuNodeDb.IsStopped = value;
            }
            get
            {
                return _MenuNodeDb.IsStopped;
            }
        }
        MenuNodeCol _Children;
        public MenuNodeCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                    _Children = new MenuNodeCol(true);
                return _Children;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MenuNodeDb.Parent = ParentBiz.ID;
            _MenuNodeDb.Function = FunctionBiz.ID;
            _MenuNodeDb.System = SystemBiz.ID;
            _MenuNodeDb.Add();
        }
        public void Edit()
        {
            _MenuNodeDb.Parent = ParentBiz.ID;
            _MenuNodeDb.Function = FunctionBiz.ID;
            _MenuNodeDb.System = SystemBiz.ID;
            _MenuNodeDb.Edit();
        }
        public void Delete()
        {
            _MenuNodeDb.Delete();
        }
        #endregion
    }
}
