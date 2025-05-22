using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
 
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationResubmissionCol:BaseCol
    {
        #region Private Data

        #endregion
        #region Constructors
        public ReservationResubmissionCol()
        { 
        }
        public ReservationResubmissionCol(bool blIsEmpty)
        { 
        }

        #endregion
        #region Public Properties
        public ReservationResubmissionBiz this[int intIndex]
        {
            get
            {
                return (ReservationResubmissionBiz)List[intIndex];
            }
        }
        public ReservationResubmissionCol LegalCol
        {
            get
            {
                ReservationResubmissionCol Returned = new ReservationResubmissionCol(true);
                foreach (ReservationResubmissionBiz objBiz in this)
                {
                    if (objBiz.IsLegal)
                        Returned.Add(objBiz);
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ReservationResubmissionBiz objBiz)
        {
            List.Add(objBiz);
        }
        public ReservationResubmissionCol GetCol(string strText)
        {
            ReservationResubmissionCol Returned = new ReservationResubmissionCol(true);
            bool blIsFound = false;
            string[] arrStr = strText.Split("%".ToCharArray());

            foreach (ReservationResubmissionBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {

                    if (objBiz.Desc.IndexOf(strTemp) == -1 && objBiz.TypeBiz.Name.IndexOf(strTemp) == -1)
                    {
                        blIsFound = false;
                        break;
                    }
                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        #endregion
    }
}
