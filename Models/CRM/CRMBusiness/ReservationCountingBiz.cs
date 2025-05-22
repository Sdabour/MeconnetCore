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
    public class ReservationCountingBiz
    {
        #region Private Data
        ReservaionCountingDb _ReservationCountingDb;
        #endregion
        #region Constructors
        public ReservationCountingBiz(DataRow objDr)
        {
            _ReservationCountingDb = new ReservaionCountingDb(objDr);
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public string DateStr
        {
            get 
            {
                return _ReservationCountingDb.DateStr;
            }
        }
        public int No
        {
            get
            {
                return _ReservationCountingDb.No;
            }
        }
        #endregion

    }
}
