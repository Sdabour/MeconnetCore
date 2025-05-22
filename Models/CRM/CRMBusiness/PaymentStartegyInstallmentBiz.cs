using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class PaymentStartegyInstallmentBiz
    {
        #region Private Data
        PaymentStartegyInstallmentDb _PaymentStartegyInstallmentDb;
        #endregion
        #region Constructors
        public PaymentStartegyInstallmentBiz()
        { 

        }
        public PaymentStartegyInstallmentBiz(DataRow objDR)
        {
            _PaymentStartegyInstallmentDb = new PaymentStartegyInstallmentDb(objDR);
        }
        #endregion
        #region Public Properties
        public int StrategyID
        {
            set
            {
                _PaymentStartegyInstallmentDb.StrategyID = value;
            }
            get
            {
                return _PaymentStartegyInstallmentDb.StrategyID;
            }

        }
        public int InstallmentNo
        {
            set
            {
                _PaymentStartegyInstallmentDb.InstallmentNo = value;
            }
            get
            {
                return _PaymentStartegyInstallmentDb.InstallmentNo;
            }

        }
        public int InstallmentType
        {
            set
            {
                _PaymentStartegyInstallmentDb.InstallmentType = value;
            }
            get
            {
                return _PaymentStartegyInstallmentDb.InstallmentType;
            }

        }
        public double InstallmentValue
        {
            set
            {
                _PaymentStartegyInstallmentDb.InstallmentValue = value;
            }
            get
            {
                return _PaymentStartegyInstallmentDb.InstallmentValue;
            }

        }
        public int InstallmentPeriod
        {
            set
            {
                _PaymentStartegyInstallmentDb.InstallmentPeriod = value;
            }
            get
            {
                return _PaymentStartegyInstallmentDb.InstallmentPeriod;
            }

        }
        #endregion
        #region Private Methods

        #endregion

        #region Public Methods
        public void Add(int intInstallmentNo, int intInstallmentPeriod, int intInstallmentType,double dblInstallmentValue,int intStrategyID)
        {
            _PaymentStartegyInstallmentDb = new PaymentStartegyInstallmentDb();
            _PaymentStartegyInstallmentDb.InstallmentNo = intInstallmentNo;
            _PaymentStartegyInstallmentDb.InstallmentPeriod = intInstallmentPeriod;
            _PaymentStartegyInstallmentDb.InstallmentType = intInstallmentType;
            _PaymentStartegyInstallmentDb.InstallmentValue = dblInstallmentValue;
            _PaymentStartegyInstallmentDb.StrategyID = intStrategyID;
            _PaymentStartegyInstallmentDb.Add();
        }
        public void Edit(int intInstallmentNo, int intInstallmentPeriod, int intInstallmentType, double dblInstallmentValue, int intStrategyID)
        {
            _PaymentStartegyInstallmentDb = new PaymentStartegyInstallmentDb();
            _PaymentStartegyInstallmentDb.InstallmentNo = intInstallmentNo;
            _PaymentStartegyInstallmentDb.InstallmentPeriod = intInstallmentPeriod;
            _PaymentStartegyInstallmentDb.InstallmentType = intInstallmentType;
            _PaymentStartegyInstallmentDb.InstallmentValue = dblInstallmentValue;
            _PaymentStartegyInstallmentDb.StrategyID = intStrategyID;
            _PaymentStartegyInstallmentDb.Edit();
        }
        public void Delete(int intStrategyID)
        {
            _PaymentStartegyInstallmentDb = new PaymentStartegyInstallmentDb();
            _PaymentStartegyInstallmentDb.StrategyID = intStrategyID;
            _PaymentStartegyInstallmentDb.Delete();
        }
    
        #endregion
    }
}
