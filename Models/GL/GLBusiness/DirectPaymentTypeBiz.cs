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
    public class DirectPaymentTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public DirectPaymentTypeBiz()
        {
            _BaseDb = new DirectPaymentTypeDB();
        }
        public DirectPaymentTypeBiz(DataRow objDR)
        {
            _BaseDb = new DirectPaymentTypeDB(objDR);
        }
        #endregion
        #region Public Accessorice
        public string Code
        {
            set
            {
                ((DirectPaymentTypeDB)_BaseDb).Code = value;

            }
            get
            {
                return ((DirectPaymentTypeDB)_BaseDb).Code;
            }
        }

        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((DirectPaymentTypeDB)_BaseDb).Code = Code;
            ((DirectPaymentTypeDB)_BaseDb).Add();
        }
        public void Edit()
        {
            //((DirectPaymentTypeDB)_BaseDb).Code = Code;
            ((DirectPaymentTypeDB)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((DirectPaymentTypeDB)_BaseDb).Delete();
        }
        public DirectPaymentTypeBiz Copy()
        {
            DirectPaymentTypeBiz Returned = new DirectPaymentTypeBiz();
            Returned.ID = ID;
            Returned.Code = Code;
            Returned.NameA = NameA;
            Returned.NameE = NameE;
            return Returned;
        }
        #endregion
    }
}
