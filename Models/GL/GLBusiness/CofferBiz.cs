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
    public class CofferBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public CofferBiz()
        {
            _BaseDb = new CofferDB();
        }
        public CofferBiz(DataRow objDR)
        {
            _BaseDb = new CofferDB(objDR);
        }
        #endregion
        #region Public Accessorice
        public string Code
        {
            set
            {
                ((CofferDB)_BaseDb).Code = value;

            }
            get
            {
                return ((CofferDB)_BaseDb).Code;
            }
        }
        public bool IsBank
        {
            set
            {
                ((CofferDB)_BaseDb).IsBank = value;
            }
            get
            {
                return ((CofferDB)_BaseDb).IsBank;
            }
        }
        public bool IsMain
        {
            set
            {
                ((CofferDB)_BaseDb).IsMain = value;
            }
            get
            {
                return ((CofferDB)_BaseDb).IsMain;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((CofferDB)_BaseDb).Code = Code;
            ((CofferDB)_BaseDb).Add();
        }
        public void Edit()
        {
            //((CofferDB)_BaseDb).Code = Code;
            ((CofferDB)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((CofferDB)_BaseDb).Delete();
        }
        #endregion
    }
}
