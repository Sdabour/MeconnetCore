using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.RP.RPBusiness;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPDataBase;
using SharpVision.GL.GLBusiness;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
  

    public class ReservationInstallmentSumCol : BaseCol
    {
        #region Private Data

        #endregion
        #region Constructors
        public ReservationInstallmentSumCol()
        { }
        public ReservationInstallmentSumCol(bool blIsDayGroup, bool blIsMonthGroup, bool blIsYearGroup, bool blIsTowerGroup, bool blIsProjectGroup, bool blIsTypeGroup,
            bool blIsInstallmentTypeGroup, bool blIsCustomerGroup, bool blIsUnitGroup,
            bool blIsContractingDateRange, DateTime dtContractingFrom, DateTime dtContractingTo
            , CellBiz objCellBiz,
         CustomerBiz objCustomerBiz, DateTime dtStartDueDate,
         DateTime dtEndDueDate, int intRangeDateStatus, int intPaymentDateStatus, DateTime dtPaymentDateFrom, DateTime dtPaymentDateTo
         , InstallmentTypeCol objTypeCol, int intStatus,
            CampaignBiz objCampaignBiz, int intContactedStatus,
            bool blIgnorCampaign, int intCampaignMonitorStatus, int intUnitDeliveryStatus, int intTowerDeliveryStatus,int intAfterDeliveryStatus)
        {
            ReservationInstallmentDb objInstallmentDb = new ReservationInstallmentDb();
           
            objInstallmentDb.IsDayGroup = blIsDayGroup;
            objInstallmentDb.IsMonthGroup = blIsMonthGroup;
            objInstallmentDb.IsYearGroup = blIsYearGroup;
            objInstallmentDb.IsTowerGroup = blIsTowerGroup;
            objInstallmentDb.IsProjectGroup = blIsProjectGroup;
            objInstallmentDb.IsMainTypeGroup = blIsTypeGroup;
            objInstallmentDb.IsInstallmentTypeGroup = blIsInstallmentTypeGroup;
            objInstallmentDb.IsCustomerGroup = blIsCustomerGroup;
            objInstallmentDb.IsUnitGroup = blIsUnitGroup;
            objInstallmentDb.AfterDeliveryStatus = intAfterDeliveryStatus;
            if (objCellBiz.ID == objCellBiz.ParentID)
                objInstallmentDb.CellFamilyID = objCellBiz.ID;
            else
            {
                objInstallmentDb.CellIDs = objCellBiz.IDsStr;
            }
            objInstallmentDb.StartDueDate = dtStartDueDate;
            objInstallmentDb.EndDueDate = dtEndDueDate;
            objInstallmentDb.ReservationStatus = 1;
            objInstallmentDb.ReservationParentStatus = 1;
            objInstallmentDb.PaymentDateStatus = intPaymentDateStatus;
            objInstallmentDb.PaymentDateStart = dtPaymentDateFrom;
            objInstallmentDb.PaymentDateEnd = dtPaymentDateTo;
            objInstallmentDb.StatusSearch = intStatus;
            objInstallmentDb.IsContractingDateRange = blIsContractingDateRange;
            objInstallmentDb.StartContractingDate = dtContractingFrom;
            objInstallmentDb.EndContractingDate = dtContractingTo;
            objInstallmentDb.UnitDeliveryStatus = intUnitDeliveryStatus;
            objInstallmentDb.TowerDeliveryStatus = intTowerDeliveryStatus;
            if (intPaymentDateStatus != 0)
                objInstallmentDb.StatusSearch = 2;
            if (objTypeCol.Count > 0)
            {
                objInstallmentDb.TypeIDs = objTypeCol.IDsStr;
            }
            objInstallmentDb.DateRangeStatus = intRangeDateStatus;

            if (objCampaignBiz == null)
                objCampaignBiz = new CampaignBiz();
            if (objCampaignBiz.ID != 0)
            {
                objInstallmentDb.Campaign = objCampaignBiz.ID;
                objInstallmentDb.CampaignStatus = blIgnorCampaign ? 1 : 2;
                objInstallmentDb.CampaignContactStatus = intContactedStatus;
                objInstallmentDb.CampaignMonitorStatus = intCampaignMonitorStatus;
            }
            DataTable dtTemp = objInstallmentDb.SumSearch();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationInstallmentSumBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public ReservationInstallmentSumBiz this[int intIndex]
        {
            get
            {
                return (ReservationInstallmentSumBiz)this[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ReservationInstallmentSumBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            return Returned;
        }
        #endregion
    }
}
