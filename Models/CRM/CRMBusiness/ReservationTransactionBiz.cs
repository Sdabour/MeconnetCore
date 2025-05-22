using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationTransactionBiz
    {
        #region Private Data
        ReservationTransactionDb _ReservationTransactionDb;
        #endregion
        #region Constructors
        public ReservationTransactionBiz()
        {
            _ReservationTransactionDb = new ReservationTransactionDb();
        }
     
        public ReservationTransactionBiz(DataRow objDR)
        {
            _ReservationTransactionDb = new ReservationTransactionDb(objDR);
        }
        #endregion
        #region Public Properties
        public int ReservationID
        {
            set
            {
                _ReservationTransactionDb.ReservationID = value;
            }
            get
            {
                return _ReservationTransactionDb.ReservationID;
            }

        }
        public int TransactionType
        {
            set
            {
                _ReservationTransactionDb.TransactionType = value;
            }
            get
            {
                return _ReservationTransactionDb.TransactionType;
            }
        }
        public int TransactionID
        {
            set
            {
                _ReservationTransactionDb.TransactionID = value;
            }
            get
            {
                return _ReservationTransactionDb.TransactionID;
            }
        }
        public string UnitStr
        {
            set
            {
                _ReservationTransactionDb.UnitStr = value;
            }
            get
            {
                return _ReservationTransactionDb.UnitStr;
            }
        }
        public string TowerStr
        {
            set
            {
                _ReservationTransactionDb.TowerStr = value;
            }
            get
            {

                return _ReservationTransactionDb.TowerStr;
            }
        }
        public string ProjectStr
        {
            set
            {
                _ReservationTransactionDb.ProjectStr = value;
            }
            get
            {
                return _ReservationTransactionDb.ProjectStr;
            }
        }
        public int ReservationStatus
        {
            set
            {
                _ReservationTransactionDb.ReservationStatus = value;
            }
            get
            {
                return _ReservationTransactionDb.ReservationStatus;
            }
        }
        public double ReservationValue
        {
            set
            {
                _ReservationTransactionDb.ReservationValue = value;
            }
            get
            {
                return _ReservationTransactionDb.ReservationValue;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ReservationTransactionDb.Add();
        }
        public void Edit()
        {
            _ReservationTransactionDb.Edit();
        }
        public void Delete()
        {
            _ReservationTransactionDb.Delete();
        }
        #endregion
    }
}
