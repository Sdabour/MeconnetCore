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
    public class SpecificBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public SpecificBiz()
        {
            _BaseDb = new SpecificDB();
        }
        public SpecificBiz(DataRow objDR)
        {
            _BaseDb = new SpecificDB(objDR);
        }
        #endregion
        #region Public Accessorice
        public string Code
        {
            set
            {
                ((SpecificDB)_BaseDb).Code = value;

            }
            get
            {
                return ((SpecificDB)_BaseDb).Code;
            }
        }

        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((SpecificDB)_BaseDb).Code = Code;
            ((SpecificDB)_BaseDb).Add();
        }
        public void Edit()
        {
            //((SpecificDB)_BaseDb).Code = Code;
            ((SpecificDB)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((SpecificDB)_BaseDb).Delete();
        }
        public SpecificBiz Copy()
        {
            SpecificBiz Returned = new SpecificBiz();
            Returned.ID = ID;
            Returned.Code = Code;
            Returned.NameA = NameA;
            Returned.NameE = NameE;
            return Returned;
        }
        #endregion
    }
}
