using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ElementBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public ElementBiz()
        {
            _BaseDb = new ElementDb();
        }
        public ElementBiz(int intID)
        {
            _BaseDb = new ElementDb(intID);
        }
        public ElementBiz(DataRow objDR)
        {
            _BaseDb = new ElementDb(objDR);
            if (((ElementDb)_BaseDb).Group != 0)
            {
                _GroupBiz = new GroupElementBiz(objDR);

            }
        }

        public ElementBiz(ElementDb objDb)
        {
            _BaseDb = objDb;
        }
        #endregion
        #region Public Properties
        public double ElementValue { set { ((ElementDb)_BaseDb).ElementValue = value; } get { return ((ElementDb)_BaseDb).ElementValue; } }
        public double ElementEstimation { set { ((ElementDb)_BaseDb).ElementEstimation = value; } get { return ((ElementDb)_BaseDb).ElementEstimation; } }
        public bool IsFuzzy
        {
            set => ((ElementDb)_BaseDb).IsFuzzy = value;
            get => ((ElementDb)_BaseDb).IsFuzzy;
        }
        GroupElementBiz _GroupBiz;
        public GroupElementBiz GroupBiz
        {
            set => _GroupBiz = value;
            get
            {
                if (_GroupBiz == null) _GroupBiz = new GroupElementBiz();
                return _GroupBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            ((ElementDb)_BaseDb).Group = GroupBiz.ID;
            ((ElementDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((ElementDb)_BaseDb).Group = GroupBiz.ID;
            ((ElementDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((ElementDb)_BaseDb).Delete();
        }
        public ElementBiz Copy()
        {
            ElementBiz Returned = new ElementBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.ElementValue = this.ElementValue;
            Returned.GroupBiz = GroupBiz;
            return Returned;
        }
        #endregion
    }
}
