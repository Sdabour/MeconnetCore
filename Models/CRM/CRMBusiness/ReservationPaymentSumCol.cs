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
    public class ReservationPaymentSumCol : BaseCol
    {
        #region Private Data
          bool _IsDayGroup;
        bool _IsMonthGroup;
        bool _IsYearGroup;
        bool _IsTowerGroup;
        bool _IsProjectGroup;
        bool _IsTypeGroup;
        bool _IsInstallmentTypeGroup;
        bool _IsCustomerGroup;
        bool _IsUnitGroup;
        bool _IsEmployeeGroup;
        bool _IsBranchGroup;
        bool _IsContractDate;
        DateTime _ContractStartDate;
        DateTime _ContractEndDate;
        #endregion
        #region Constructors
        public ReservationPaymentSumCol(bool blIsPaymentDateStatus,
            DateTime dtStartPayment, DateTime dtEndPayment, bool blIsDueDate, DateTime dtStartDue, DateTime dtEndDue,
            bool blIncludeInstallmentPayment, bool blIncludeTempPayment, bool blIncludeMulctPayment,
            bool blIncludePaybackPayment,bool blIncludeAdminstartivePayment, bool blIncludeDirectPayment ,int intOnlyHasCheckStatus, string strUnitCode, CellBiz objCellBiz,
            int intReservationStatus, int intGlTransactionStatus,
            bool blIsDayGroup,bool blIsMonthGroup,bool blIsYearGroup,bool blIsTowerGroup,bool blIsProjectGroup,bool blIsTypeGroup,
            bool blIsInstallmentTypeGroup,bool blIsCustomerGroup,bool blIsUnitGroup,bool blIsEmployeeGroup,bool blIsBranchGroup
            ,InstallmentTypeCol objTypeCol,int intEmployeeID,int intBranchID
            ,bool blContractDateRange,DateTime dtContractStart,DateTime dtContractEnd)
        {
            SetDataIntially(blIsDayGroup, blIsMonthGroup, blIsYearGroup, blIsTowerGroup, blIsProjectGroup, blIsTypeGroup, blIsInstallmentTypeGroup,
                blIsCustomerGroup, blIsUnitGroup, blIsEmployeeGroup, blIsBranchGroup);
            ReservationPaymentDb objDb = new ReservationPaymentDb();
            int intCellFamilyID = 0;
            string strCellIDs = "";
            if (objCellBiz == null)
                objCellBiz = new CellBiz();
            if (objTypeCol == null)
                objTypeCol = new InstallmentTypeCol(true);
            intCellFamilyID = objCellBiz.ID == objCellBiz.ParentID ? objCellBiz.FamilyID : 0;
            strCellIDs = objCellBiz.ID == objCellBiz.ParentID ? "" : objCellBiz.IDsStr;
            objDb.CellFamilyID = intCellFamilyID;
            objDb.CellIDs = strCellIDs;
            objDb.IsPaymentDateStatus = blIsPaymentDateStatus;
            objDb.StartPaymentDate = dtStartPayment;
            objDb.EndPaymentDate = dtEndPayment;
            objDb.IsDueDateStatus = blIsDueDate;
            objDb.StartDueDate = dtStartDue;
            objDb.EndDueDate = dtEndDue;
            objDb.IncludeInstallmentPayment = blIncludeInstallmentPayment;
            objDb.IncludeTempPayment = blIncludeTempPayment;
            objDb.IncludeMulctPayment = blIncludeMulctPayment;
            objDb.IncludePayBackPayment = blIncludePaybackPayment;
            objDb.IncludeAdministrativePayment = blIncludeAdminstartivePayment;
            objDb.IncludeDirectPayment = blIncludeDirectPayment;
            objDb.OnlyHasCheckStatus = intOnlyHasCheckStatus;
            objDb.UnitCode = strUnitCode;
            objDb.ReservationStatus = intReservationStatus;
            objDb.GLTransactionStatus = intGlTransactionStatus;
            objDb.IsDayGroup = blIsDayGroup;
            objDb.IsMonthGroup = blIsMonthGroup;
            objDb.IsYearGroup = blIsYearGroup;
            objDb.IsTowerGroup = blIsTowerGroup;
            objDb.IsProjectGroup = blIsProjectGroup;
            objDb.IsTypeGroup = blIsTypeGroup;
            objDb.IsInstallmentTypeGroup = blIsInstallmentTypeGroup;
            objDb.IsCustomerGroup = blIsCustomerGroup;
            objDb.IsUnitGroup = blIsUnitGroup;
            objDb.IsEmployeeGroup = blIsEmployeeGroup;
            objDb.IsBranchGroup = blIsBranchGroup;
            objDb.InstallmentTypeIDs = objTypeCol.IDsStr;
            objDb.EmployeeID = intEmployeeID;
            objDb.BranchID = intBranchID;
            objDb.ContractDateRange = blContractDateRange;
            objDb.ContractStartDate = dtContractStart;
            objDb.ContractEndDate = dtContractEnd;
            DataTable dtTemp = objDb.SearchSum();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationPaymentSumBiz(objDr));
            }



        }
        
        #endregion
        #region Public Properties
        public ReservationPaymentSumBiz this[int intIndex]
        {
            get
            {
                return (ReservationPaymentSumBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ReservationPaymentSumBiz objBiz in this)
                {
                    Returned += objBiz.PaymentValue;
                }
                return Returned;
            }
        }
        public bool IsDayGroup
        {
            get
            {
                return _IsDayGroup;
            }
        }
        public bool IsMonthGroup
        {
            get
            {
                return _IsMonthGroup;
            }
        }
        public bool IsYearGroup
        {
            get
            {
                return _IsYearGroup;
            }
        }
        public bool IsTowerGroup
        {
            get
            {
                return _IsTowerGroup;
            }
        }
        public bool IsProjectGroup
        {
            get 
            {
                return _IsProjectGroup;
            }
        }
        public bool IsTypeGroup
        {
            get
            {
                return _IsTypeGroup;
            }
        }
        public bool IsInstallmentTypeGroup
        {
            get 
            {
                return _IsInstallmentTypeGroup;
            }
        }
        public bool IsCustomerGroup
        {
            get
            {
                return _IsCustomerGroup;
            }
        }
        public bool IsUnitGroup
        {
            get
            {
                return _IsUnitGroup;
            }
        }
        public bool IsEmployeeGroup
        {
            get
            {
                return _IsEmployeeGroup;
            }
        }
        public bool IsBranchGroup
        {
            get
            {
                return _IsBranchGroup;
            }
        }
        #endregion
        #region Private Methods
        void SetDataIntially(bool blIsDayGroup, bool blIsMonthGroup, bool blIsYearGroup, bool blIsTowerGroup, bool blIsProjectGroup, bool blIsTypeGroup,
            bool blIsInstallmentTypeGroup, bool blIsCustomerGroup, bool blIsUnitGroup, bool blIsEmployeeGroup, bool blIsBranchGroup
           )
        {
            _IsDayGroup = blIsDayGroup;
            _IsMonthGroup = blIsMonthGroup;
            _IsYearGroup = blIsYearGroup;
            _IsTowerGroup = blIsTowerGroup;
            _IsProjectGroup = blIsProjectGroup;
            _IsTypeGroup = blIsTypeGroup;
            _IsInstallmentTypeGroup = blIsInstallmentTypeGroup;
            _IsCustomerGroup = blIsCustomerGroup;
            _IsUnitGroup = blIsUnitGroup;
            _IsEmployeeGroup = blIsEmployeeGroup;
            _IsBranchGroup = blIsBranchGroup;
        }
        #endregion
        #region Public Methods
        public void Add(ReservationPaymentSumBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("Value"),new DataColumn("Project"),new DataColumn("Tower"),
                new DataColumn("Period"),new DataColumn("Type"),new DataColumn("InstallmentType"),
                new DataColumn("Customer"),new DataColumn("Unit"),new DataColumn("Employee"),new DataColumn("Branch") });
            DataRow objDr;
            foreach (ReservationPaymentSumBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["Value"] = objBiz.PaymentValue.ToString();
                objDr["Project"]= objBiz.ProjectName;
                objDr["Tower"] = objBiz.TowerName;
                objDr["Period"] = objBiz.PeriodStr;
                objDr["Type"] = objBiz.PaymentTypeStr;


                objDr["InstallmentType"] = objBiz.InstallmentTypeNameA;
               objDr["Customer"] = objBiz.CustomerStr;

                objDr["Unit"] = objBiz.UnitStr;
                objDr["Employee"] = objBiz.EmployeeName;
                objDr["Branch"] = objBiz.BranchName;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}
