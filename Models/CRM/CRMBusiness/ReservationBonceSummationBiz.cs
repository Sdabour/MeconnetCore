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
    public class ReservationBonceSummationBiz
    {
        #region Private Data
        ReservationBonceSummationDb _ReservationBonceSummationDb; 
        #endregion

        #region Constractors
        public ReservationBonceSummationBiz()
        {
            _ReservationBonceSummationDb = new ReservationBonceSummationDb();
        }
        public ReservationBonceSummationBiz(DataRow objDR)
        {
            _ReservationBonceSummationDb = new ReservationBonceSummationDb(objDR);
        }

        #endregion

        #region Public Accessorice
        public int CustomerID
        {
            set
            {
                _ReservationBonceSummationDb.CustomerID = value;
            }
            get
            {
                return _ReservationBonceSummationDb.CustomerID;
            }
        }
        public int CellID
        {
            set
            {
                _ReservationBonceSummationDb.CellID = value;
            }
            get
            {
                return _ReservationBonceSummationDb.CellID;
            }
        }
        public int BonceTypeID
        {
            set
            {
                _ReservationBonceSummationDb.BonceTypeID = value;
            }
            get
            {
                return _ReservationBonceSummationDb.BonceTypeID;
            }
        }
        public bool IsCustomerShow
        {
            set
            {
                _ReservationBonceSummationDb.IsCustomerShow = value;
            }
            get
            {
                return _ReservationBonceSummationDb.IsCustomerShow;
            }
        }
        public bool IsCellShow
        {
            set
            {
                _ReservationBonceSummationDb.IsCellShow = value;
            }
            get
            {
                return _ReservationBonceSummationDb.IsCellShow;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}
