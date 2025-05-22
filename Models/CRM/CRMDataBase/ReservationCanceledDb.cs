using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationCanceledDb : ReservationDb
    {
        #region Private Data
        ReservationCancelationDb _CancelationDb;
        #endregion
        #region Constructors
        public ReservationCanceledDb() : base()
        {
 
        }
        public ReservationCanceledDb(DataRow objDr)
            : base(objDr)
        {
            _CancelationDb= new ReservationCancelationDb(objDr);
        }
        #endregion
        #region Public Properties
        public ReservationCancelationDb CancelationDb
        {
            set
            {
                _CancelationDb = value;
            }
            get
            {
                return _CancelationDb;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
