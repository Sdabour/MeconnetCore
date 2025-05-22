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
                _Name = "����� ����";

            }
            else if (objPaymentType == PaymentType.Cash)
            {
                _Name = "���";

            }
            else
                _Name = "��� ����";
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
