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
    public class CompanyBiz : BaseSingleBiz
    {
        #region Private Data
        static CompanyBiz _CompanyBiz;
        #endregion
        #region Constractors
        public CompanyBiz()
        {
            _BaseDb = new CompanyDB();
        }
        public CompanyBiz(DataRow objDR)
        {
            _BaseDb = new CompanyDB(objDR);
        }
        #endregion
        #region Public Accessorice
        public string Code
        {
            set
            {
                ((CompanyDB)_BaseDb).Code = value;

            }
            get
            {
                return ((CompanyDB)_BaseDb).Code;
            }
        }
        public static CompanyBiz CurrentCompanyBiz
        {
            set
            {
                _CompanyBiz = value;
            }
            get
            {
                if (_CompanyBiz == null)
                    _CompanyBiz = new CompanyBiz();
                return _CompanyBiz;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((CompanyDB)_BaseDb).Code = Code;
            ((CompanyDB)_BaseDb).Add();
        }
        public void Edit()
        {
            //((CompanyDB)_BaseDb).Code = Code;
            ((CompanyDB)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((CompanyDB)_BaseDb).Delete();
        }
        #endregion
    }
}
