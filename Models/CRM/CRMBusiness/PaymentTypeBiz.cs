using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.GL.GLBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class PaymentTypeBiz
    {
        #region Private Data
        PaymentType _PaymentType;
        string _Name;
        #endregion
        #region Constructor
        public PaymentTypeBiz(PaymentType objPaymentType)
        {
            _PaymentType = objPaymentType;
            if (objPaymentType == PaymentType.BankingTransfering)
            {
                _Name = " ÕÊÌ· »‰ﬂÏ";

            }
            else if (objPaymentType == PaymentType.Cash)
            {
                _Name = "ﬂ«‘";

            }
            else
                _Name = "œ›⁄ »‘Ìﬂ";
        }
        #endregion
        #region Public Properties
        public PaymentType PaymentType
        {
            get
            {
                return _PaymentType;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
        }
        #endregion
    }
}
