using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

using SharpVision.HR.HRBusiness;
using SharpVision.GL.GLBusiness;
using System.Collections;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationCheckBiz :CheckBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public ReservationCheckBiz()
        { 
        }
        public ReservationCheckBiz(bool blIsEmpty)
        { }
        public ReservationCheckBiz(DataRow objDr)
            : base(objDr)
        { }
        public ReservationCheckBiz(int intID, string strStatus, bool blDirection)
            : base(intID, strStatus, blDirection)
        {
 
        }
        #endregion
        #region Public Properties
        ReservationPaymentCol _ReservationPaymentCol;

        public ReservationPaymentCol ReservationPaymentCol
        {
            get {
                if (_ReservationPaymentCol == null)
                {
                    _ReservationPaymentCol = new ReservationPaymentCol(true);
                    


                }
                return _ReservationPaymentCol; }
            set { _ReservationPaymentCol = value; }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
