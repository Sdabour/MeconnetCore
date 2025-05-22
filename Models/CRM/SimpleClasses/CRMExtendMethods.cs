using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.UMS.UMSBusiness;
using SharpVision.SystemBase;
using SharpVision.GL.GLBusiness;
using System.Globalization;

namespace SharpVision.CRM.CRMBusiness
{

    public static class CRMExtendMethods
    {
        #region UMS
        //539,87,566,174,567
        public static int UMSAddEditCustomer = 539;
        public static bool UMSAddEditCustomerAuthorized = SysData.CurrentUser.UserFunctionInstantCol.GetIndex(UMSAddEditCustomer) > -1;
        public static int UMSAddEditReservation = 87;
        public static bool UMSAddEditReservationAuthorized = SysData.CurrentUser.UserFunctionInstantCol.GetIndex(UMSAddEditReservation) > -1;

        public static int UMSCancelContract = 566;
        public static bool UMSCancelContractAuthorized = SysData.CurrentUser.UserFunctionInstantCol.GetIndex(UMSCancelContract) > -1;


        public static int UMSCancelReservation = 174;
        public static bool UMSCancelReservationAuthorized = SysData.CurrentUser.UserFunctionInstantCol.GetIndex(UMSCancelReservation) > -1;

        public static int UMSUndoCancelReservation = 567;
        public static bool UMSUndoCancelReservationAuthorized = SysData.CurrentUser.UserFunctionInstantCol.GetIndex(UMSUndoCancelReservation) > -1;
        #endregion
        public static UnitSimple GetSimple(this UnitBiz objUnit)
        {
            UnitSimple Returned = new UnitSimple()
            {
                Code = objUnit.FullName,
                Survey=objUnit.Survey
                ,
                Customer = objUnit.CustomerStr,
                Floor = objUnit.FloorStr,
                FloorID = objUnit.FloorBiz.ID,
                ID = objUnit.ID,
                Project = objUnit.TowerBiz.ProjectBiz.Name,
                ProjectID = objUnit.TowerBiz.ProjectBiz.ID,
                StatusStr = objUnit.StatusStr,
                Tower = objUnit.TowerBiz.Name,
                TowerID = objUnit.TowerBiz.ID,
                Order = objUnit.Order,
                UnitPricePerMeter = (int)objUnit.UnitSalesPrice
            };
            return Returned;
        }
        public static List<UnitSimple> GetSimpleLst(this UnitCol objUnitCol)
        {
            List<UnitSimple> lstUnit = (from objUnit in objUnitCol.Cast<UnitBiz>()
                                        select objUnit.GetSimple()).ToList();
            return lstUnit;
        }
        public static CustomerSimple GetSimple(this CustomerBiz objCustomer)
        {

            string strEditURL = UMSAddEditCustomerAuthorized ? "AddEditCustomer?CustomerID="+objCustomer.ID.ToString() : "#";
           // return strEditURL;
            string strRef = "";
            if(strEditURL!= "")
            strRef = @"<a href='"+strEditURL+"'  target='_blank' class='btn btn-dark'>تعديل </a>";
            CustomerSimple Returned = new CustomerSimple() { ID = objCustomer.ID, Name = objCustomer.Name, Mobile1 = objCustomer.Mobile, Mobile2 = objCustomer.SecondMobile, Phone1 = objCustomer.HomePhone, Phone2 = objCustomer.HomePhone, ProjectName = objCustomer.ProjectName, TowerCode = objCustomer.TowerName, UnitCode = objCustomer.UnitFullName, EditStr = strEditURL };
            return Returned;
        }
        public static List<CustomerSimple> GetSimpleLst(this CustomerCol objCustomerCol)
        {
          
            List<CustomerSimple> Returned = (from objCustomer in objCustomerCol.Cast<CustomerBiz>()
                                             select objCustomer.GetSimple()).ToList();


            return Returned;
        }
        public static ReservationSimple GetSimple(this ReservationBiz objBiz)
        {
            string strReservationFunction = objBiz.Status != ReservationStatus.Cancellation ?  "AddEdit?ReservationID=": "#";
            if((int)objBiz.Status <3)
                strReservationFunction = "AddEditReservation?ReservationID=";
            else if(objBiz.Status == ReservationStatus.Cancellation && UMSUndoCancelReservationAuthorized)
            {
                strReservationFunction = "Cancelation?ReservationID=";
            }

            string strEditURL =  UMSAddEditReservationAuthorized || UMSUndoCancelReservationAuthorized  ? strReservationFunction + objBiz.ID.ToString() : "#";

            ReservationSimple Returned = new ReservationSimple() { Branch = objBiz.BranchBiz.Name, CustomerName = objBiz.DirectCustomerStr, ID = objBiz.ID, Project = objBiz.DirectProjectName, SalesMen = objBiz.DirectSalesStr, StatusStr = objBiz.StatusStr, TimIns = objBiz.TimeIns.ToString("yyyy-MM_dd HH:mm"), TimUpd = objBiz.TimeUpd.ToString("yyyy-MM_dd HH:mm"), UnitCOde = objBiz.DirectUnitCodeStr, UnitFullName = objBiz.DirectUnitNameStr, UsrIns = objBiz.UserIns.EmployeeBiz.ID == 0 ? objBiz.UserIns.Name : objBiz.UserIns.EmployeeBiz.Name, UsrUpd = objBiz.UserUpd.EmployeeBiz.ID == 0 ? objBiz.UserUpd.Name : objBiz.UserUpd.EmployeeBiz.Name,EditStr=strEditURL,PaidValue=objBiz.TotalPaidValue,RemainingValue=objBiz.RemainingValue,Status=(int)objBiz.Status};
            Type objType = objBiz.GetType();
            if(objType.Name == "ReservationCanceledBiz")
            {
//Returned.
            }
            //if(objBiz.GetType() )
            return Returned;
        }
        public static List<ReservationSimple> GetSimpleSearch(this ReservationCol objReservationCol)
        {
            List<ReservationSimple> Returned = (from objBiz in objReservationCol.Cast<ReservationBiz>() select objBiz.GetSimple()).ToList();
            return Returned;
        }
       public static ReservationBiz GetReservationBiz(this ReservationAddEdit objBiz)
        {
            ReservationBiz Returned = new ReservationBiz() { ID=objBiz.ID,CachePrice=objBiz.Value,Date= objBiz.Date,ContractingDate=objBiz.ContractingDate,Status= (ReservationStatus)objBiz.Status,DeliveryDate=objBiz.DeliveryDate,BranchBiz=new HR.HRBusiness.BranchBiz() { ID=objBiz.Branch},Period=(COMMON.COMMONBusiness.Period)objBiz.Period,PeriodAmount=objBiz.PeriodAmount };
            
            foreach(CustomerSimple objCustomerSimple in objBiz.CustomerLst) {Returned.CustomerCol.Add(new CustomerBiz() { ID = objCustomerSimple.ID }); };
           
            foreach (UnitSimple objUnitSimple in objBiz.UnitLst) { Returned.UnitCol.Add(new ReservationUnitBiz() {DeliveryDate=objBiz.DeliveryDate,UnitBiz=new UnitBiz() { ID=objUnitSimple.ID},CachPrice=(objBiz.Value/objBiz.UnitLst.Count) }); };
            CultureInfo provider = CultureInfo.InvariantCulture;
            #region Bonus

            foreach (SimpleValue objValue in objBiz.BonusLst)
            {
                objValue.Date = objValue.Date.Substring(0, 10);
                Returned.BonusCol.Add(new ReservationBonusBiz() { ID = objValue.ID, Date = DateTime.ParseExact(objValue.Date, "yyyy-MM-dd", provider), Reason = objValue.Desc, TypeBiz = new BonusTypeBiz { ID = objValue.TypeID }, Value = objValue.Value });
            }
            foreach (SimpleValue objValue in objBiz.DeletedBonusLst)
                Returned.DeletedBonusCol.Add(new ReservationBonusBiz() { ID = objValue.ID, Date = DateTime.ParseExact(objValue.Date.Substring(0,10), "yyyy-MM-dd", provider), Reason = objValue.Desc, TypeBiz = new BonusTypeBiz { ID = objValue.TypeID }, Value = objValue.Value });
            #endregion
            #region Discount
            foreach (SimpleValue objValue in objBiz.DiscountLst)
                Returned.DiscountCol.Add(new ReservationDiscountBiz() { ID = objValue.ID, Date = DateTime.ParseExact(objValue.Date.Substring(0, 10), "yyyy-MM-dd", provider), Reason = objValue.Desc, TypeBiz = new DiscountTypeBiz { ID = objValue.TypeID }, Value = objValue.Value });
            foreach (SimpleValue objValue in objBiz.DeletedDiscountLst)
                Returned.DeletedDiscountCol.Add(new ReservationDiscountBiz() { ID = objValue.ID, Date = DateTime.ParseExact(objValue.Date.Substring(0, 10), "yyyy-MM-dd", provider), Reason = objValue.Desc, TypeBiz = new DiscountTypeBiz { ID = objValue.TypeID }, Value = objValue.Value });
            #endregion
            #region Utility
            foreach (SimpleValue objValue in objBiz.UtilityLst)
                Returned.UtilityCol.Add(new ReservationUtilityBiz() { ID = objValue.ID,  UtilityTypeBiz= new UtilityTypeBiz { ID = objValue.TypeID }, Value = objValue.Value });
            foreach (SimpleValue objValue in objBiz.DeletedUtilityLst)
                Returned.DeletedUtilityCol.Add(new ReservationUtilityBiz() { ID = objValue.ID, UtilityTypeBiz = new UtilityTypeBiz { ID = objValue.TypeID }, Value = objValue.Value });
            #endregion
            #region TempPayment
            foreach (SimpleValue objValue in objBiz.TempPaymentLst)
                Returned.PaymentCol.Add(new TempReservationPaymentBiz() { ID = objValue.ID, Date = DateTime.ParseExact(objValue.Date.Substring(0, 10), "yyyy-MM-dd", provider), Desc = objValue.Desc, Value = objValue.Value });
            foreach (SimpleValue objValue in objBiz.DeletedTempPaymentLst)
                Returned.DeletedPaymentCol.Add(new TempReservationPaymentBiz() { ID = objValue.ID, Date = DateTime.ParseExact(objValue.Date.Substring(0, 10), "yyyy-MM-dd", provider), Desc = objValue.Desc, Value = objValue.Value });
            #endregion
            #region INstallment
            Returned.InstallmentTypeCol = objBiz.InstallmentGroup.GetStrategyInstallmentCol();
            Returned.DeletedInstallmentCol = objBiz.DeletedInstallment.GetReservationInstallmentCol();
            #endregion
            #region Sales
            Returned.WorkerCol = new WorkerContributionCol(true);
            if (objBiz.EmpLst == null)
                objBiz.EmpLst = new List<EmployeeSimple>();
            foreach(EmployeeSimple objEmployee in objBiz.EmpLst)
            {
                Returned.WorkerCol.Add(new WorkerContributionBiz() { ContributionPerc = 100 / objBiz.EmpLst.Count, WorkerID = objEmployee.ID, SalesManBiz = new SalesManBiz() { ID = objEmployee.ID, Name = objEmployee.Name } });
            }
            #endregion
            return Returned;
        }
        public static ReservationSimple GetReservationSimple(this ReservationAddEdit objBiz)
        {
            ReservationSimple Returned = new ReservationSimple() { Branch = objBiz.Branch.ToString(), CustomerName = objBiz.CustomerStr, ID = objBiz.ID, Project = objBiz.ProjectStr, StatusStr = objBiz.Status.ToString(),UnitCOde = objBiz.UnitStr, UnitFullName = objBiz.UnitStr,  PaidValue = objBiz.PaidValue, RemainingValue = objBiz.RemainingValue, Status = (int)objBiz.Status };
            return Returned;
        }
        public static ReservationAddEdit GetReservationAddEdit(this ReservationBiz objBiz)
        {
            ReservationAddEdit Returned = new ReservationAddEdit() { ID = objBiz.ID,Value=objBiz.CachePrice,Branch =objBiz.BranchBiz.ID,Allowance=objBiz.Allowance, Brand=objBiz.BrandBiz.ID,ContractingDate=objBiz.ContractingDate,Date=objBiz.Date,DeliveryDate=objBiz.DelegationDate,Note =objBiz.Note,CachePrice=objBiz.CachePrice,PaidValue=objBiz.TotalPaidValue,RemainingValue=objBiz.RemainingValue,Status=(int)objBiz.Status,DirectUnitStr=objBiz.UnitStr};
            Returned.BonusLst = objBiz.BonusCol.Cast<ReservationBonusBiz>().Select(x => new SimpleValue() { ID = x.ID, Date = x.Date.ToString("yyyy-MM-dd"), Desc = x.Reason, TypeID = x.TypeBiz.ID, TypeName = x.TypeBiz.Name }).ToList();
            Returned.CustomerLst = objBiz.CustomerCol.Cast<CustomerBiz>().Select(x => new CustomerSimple() { ID = x.ID, Mobile1 = x.Mobile, Mobile2 = x.SecondMobile, Name = x.Name, Phone1 = x.HomePhone, Phone2 = x.WorkPhone, ProjectName = x.ProjectName, UnitCode = x.UnitFullName, TowerCode = x.TowerName }).ToList();

            Returned.DiscountLst = objBiz.DiscountCol.Cast<ReservationDiscountBiz>().Select(x => new SimpleValue() { ID = x.ID, Date = x.Date.ToString("yyyy-MM-dd"), Desc = x.Reason, TypeID = x.TypeBiz.ID, TypeName = x.TypeBiz.Name ,Value=x.Value}).ToList();
            Returned.TempPaymentLst = objBiz.PaymentCol.Cast<TempReservationPaymentBiz>().Select(x => new SimpleValue() { ID = x.ID, Date = x.Date.ToString("yyyy-MM-dd"), Desc = x.Desc,TypeID=(int)x.Type,TypeName=x.TypeStr, Value=x.Value}).ToList();
            Returned.UtilityLst = objBiz.UtilityCol.Cast<ReservationUtilityBiz>().Select(x => new SimpleValue() { ID = x.ID,  TypeID = x.UtilityTypeBiz.ID, TypeName = x.UtilityTypeBiz.Name }).ToList();
            Returned.UnitLst = objBiz.UnitCol.Cast<ReservationUnitBiz>().Select(x => new UnitSimple() { ID = x.UnitBiz.ID,Code=x.UnitBiz.FullName,Floor=x.UnitBiz.FloorBiz.Name,Project=x.UnitBiz.TowerBiz.ProjectBiz.Code,Tower =x.UnitBiz.TowerBiz.Code,TotalPrice=(int)x.CachPrice,Survey=x.UnitBiz.Survey }).ToList();
            Returned.InstallmentGroup = objBiz.InstallmentTypeCol.Cast<StrategyInstallmentBiz>().Select(x => new InstallmentGroupSimple() { Count=x.InstallmentNo,InstallmentLst=x.InstallmentCol.GetSimpleList(),InstallmentTypeID=x.TypeBiz.ID,InstallmentTypeName=x.TypeBiz.Name,TotalValue= x.InstallmentCol.Cast<ReservationInstallmentBiz>().Sum(objIns=>objIns.InstallmentValue), StartDate = x.InstallmentCol.Cast<ReservationInstallmentBiz>().Min(objIns => objIns.InstallmentDueDate.Date).ToString("yyyy-MM-dd") ,PeriodName=""}).ToList();

            Returned.EmpLst = new List<EmployeeSimple>();
            foreach(WorkerContributionBiz objContribution in objBiz.WorkerCol)
            {
                Returned.EmpLst.Add(new EmployeeSimple() { ID = objContribution.WorkerID, Name = objContribution.SalesManBiz.Name });
            }
            Type objType = objBiz.GetType();
            if (objType.Name == "ReservationCanceledBiz")
            {
                Returned.CancelationCost = ((ReservationCanceledBiz)objBiz).CancelationBiz.Cost;
                Returned.CancelationDate = ((ReservationCanceledBiz)objBiz).CancelationBiz.Date;
                Returned.CancelationNote = ((ReservationCanceledBiz)objBiz).CancelationBiz.Note;
                Returned.CancelationType = ((ReservationCanceledBiz)objBiz).CancelationBiz.TypeBiz.ID;
                Returned.CancelationTypeNameA = ((ReservationCanceledBiz)objBiz).CancelationBiz.TypeBiz.NameA;
                Returned.CancelationTypeNameE = ((ReservationCanceledBiz)objBiz).CancelationBiz.TypeBiz.NameE;
            }
            return Returned;
        }
        public static StrategyInstallmentCol GetStrategyInstallmentCol(this List<InstallmentGroupSimple> objCol)
        {
            StrategyInstallmentCol Returned = new StrategyInstallmentCol(true);
            foreach(InstallmentGroupSimple objBiz in objCol)
            {
                Returned.Add(objBiz.GetStrategyInstallmentBIz());
            }
            return Returned;
        }
        public static StrategyInstallmentBiz GetStrategyInstallmentBIz(this InstallmentGroupSimple objBiz)
        {
            StrategyInstallmentBiz Returned = new StrategyInstallmentBiz() { InstallmentCol =objBiz.InstallmentLst.GetReservationInstallmentCol(), InstallmentNo=objBiz.InstallmentLst.Count,InstallmentPeriod =objBiz.PeriodID,InstallmentValue=objBiz.TotalValue,TypeBiz=new InstallmentTypeBiz() { ID=objBiz.InstallmentTypeID} };
            return Returned;
        }
        #region Installment
        public static ReservationInstallmentBiz GetReservationInstallmentBiz(this InstallmentSimple objBiz)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            objBiz.DueDate = objBiz.DueDate.Substring(0, 10);
            ReservationInstallmentBiz Returned = new ReservationInstallmentBiz() { ID=objBiz.ID,Desc=objBiz.Note,InstallmentValue=objBiz.Value,InstallmentDueDate =DateTime.ParseExact(objBiz.DueDate,"yyyy-MM-dd",provider),Type =new InstallmentTypeBiz() { ID=objBiz.TypeID} };
            return Returned;
        }
        public static ReservationInstallmentCol GetReservationInstallmentCol(this List<InstallmentSimple> objCol)
        {
            ReservationInstallmentCol Returned = new ReservationInstallmentCol(true);
            foreach (InstallmentSimple objSimple in objCol)
                Returned.Add(objSimple.GetReservationInstallmentBiz());
            return Returned;
        }
        public static InstallmentSimple GetInstallmentSimple(this ReservationInstallmentBiz objBiz)
        {
            double dblRemaining = objBiz.InstallmentValue- objBiz.PaymentCol.Cast<InstallmentPaymentBiz>().Sum(x => x.Value) -objBiz.DiscountValue;
            InstallmentSimple Returned = new InstallmentSimple() { DiscountVaue = objBiz.DiscountValue, DueDate = objBiz.InstallmentDueDate.Date.ToString("yyyy-MM-dd"), ID = objBiz.ID, Note = objBiz.Note, PaidValue = objBiz.PaidValue, RemainingValue =dblRemaining, TypeID = objBiz.Type.ID, TypeName = objBiz.Type.Name,Value=objBiz.InstallmentValue,DueDateStr=objBiz.InstallmentDueDate.ToString("yyyy-MM-dd"),StatusStr=objBiz.StatusStr};
            Returned.PaymentLst = objBiz.PaymentCol.GetPaymentSimpleLst();

            Returned.DiscountLst = objBiz.InstallmentDiscountCol.GetSimpleLst();
            return Returned;
        }
        public static List<InstallmentSimple> GetSimpleList(this ReservationInstallmentCol objCol)
        {
            List<InstallmentSimple> Returned = (objCol.Cast<ReservationInstallmentBiz>().Select(x => x.GetInstallmentSimple())).ToList();
            return Returned;
        }
        public static PaymentSimple GetSimplePayment(this InstallmentPaymentBiz objBiz)
        {
            PaymentSimple Returned = new PaymentSimple() { CheckBankID=objBiz.CheckBiz.BankBiz.ID,CheckBankName=objBiz.CheckBiz.BankBiz.Name,CheckDueDate=objBiz.CheckBiz.DueDate,CheckID=objBiz.CheckBiz.ID,CheckNo=objBiz.CheckBiz.Code,CheckStatus=(int)objBiz.CheckBiz.Status,CheckStatusDate=objBiz.CheckBiz.StatusDate,CheckValue=objBiz.CheckBiz.Value,CollectingDate=objBiz.CollectingDate,CollectingType=(int)objBiz.Type,CollectingTypeDesc="",Date=objBiz.Date,Desc=objBiz.Desc,ID=objBiz.ID,InstallmentID=objBiz.InstallmentID,IsCollected=objBiz.IsCollected,Type=(int)objBiz.Type,Value=objBiz.Value,TypeDesc=objBiz.TypeStr};
            return Returned;
        }

        public static List<PaymentSimple> GetPaymentSimpleLst(this InstallmentPaymentCol objCol)
        {
            List<PaymentSimple> Returned = new List<PaymentSimple>();
            foreach(InstallmentPaymentBiz objBiz in objCol)
            {
                Returned.Add(objBiz.GetSimplePayment());
            }
            return Returned;
        }
        public static InstallmentPaymentBiz GetInstallmentPayment(this PaymentSimple objBiz)
        {
            InstallmentPaymentBiz Returned = new InstallmentPaymentBiz() {CheckBiz=new CheckBiz() { ID = objBiz.CheckID },InstallmentBiz=new ReservationInstallmentBiz() { ID=objBiz.InstallmentID},Value=objBiz.Value };
            return Returned;
        }
        public static DiscountSimple GetDiscountSimple(this InstallmentDiscountBiz objBiz)
        {
            DiscountSimple Returned = new DiscountSimple() { Branch=0,Desc=objBiz.Reason,Date=objBiz.Date,ID=objBiz.ID,InstallmentID=objBiz.InstallmentID,ReservationID=objBiz.InstallmentBiz.ReservationID,TypeDesc=objBiz.TypeBiz.Name,Type=objBiz.TypeBiz.ID,Value=objBiz.Value};
            return Returned;
        }
        public static List<DiscountSimple> GetSimpleLst(this InstallmentDiscountCol objCol)
        {
            List<DiscountSimple> Returned = objCol.Cast<InstallmentDiscountBiz>().Select(x => x.GetDiscountSimple()).ToList();

                return Returned;
        }
        #endregion
        #region Payment

        #endregion
        #region Check
        public static CheckSimple GetSimple(this CheckBiz objBiz)
        {
            CheckSimple Returned = new CheckSimple() { Bank = objBiz.BankBiz.ID, BankName = objBiz.BankBiz.Name, BankSubmissionDate = objBiz.SubmissionDate, BeneficiaryName = objBiz.BeneficialName, Code = objBiz.Code, CollectedValue = objBiz.CollectedValue, Currency = objBiz.CurrencyBiz.ID, CurrencyName = objBiz.CurrencyBiz.Name, CurrentStatus = (int)objBiz.Status, CurrentStatusDate = objBiz.StatusDate, CurrentStatusDesc = objBiz.StatusStr, Customer = 0, CustomerName = "", Direction = objBiz.Direction, DirectionDesc = objBiz.Direction ? "in" : "out", DueDate = objBiz.DueDate, EditorName = objBiz.EditorName, ID = objBiz.ID,IsBankOriented=objBiz.IsBankOriented,IsBankOrientedDesc=objBiz.IsBankOriented?"يقدم الى البنك" :"",IssueDate=objBiz.IssueDate,Note=objBiz.CheckNote,Place=objBiz.PlaceBiz.ID,PlaceName=objBiz.PlaceBiz.Name,Type=(int)objBiz.Type,TypeName=objBiz.TypeStr,Value=objBiz.Value,TotalPayment=objBiz.TotalPayment};
            return Returned;
        }
        public static List<CheckSimple> GetSimpleSearch(this CheckCol objCol)
        {
            List<CheckSimple> Returned = (from objBiz in objCol.Cast<CheckBiz>()
                                          select objBiz.GetSimple()).ToList();

            return Returned;
        }
        public static CheckBiz GetCheck(this ReservationInstallmentBiz objBiz)
        {
            CheckBiz Returned = new CheckBiz() { Direction = true, CustomerID = objBiz.Reservation.CustomerBiz.ID, Value = objBiz.VirtualRemainingValue,DueDate=objBiz.InstallmentDueDate };
            return Returned;
        }
        public static void SetCheckData(this CheckAddEdit objCheck,ref CheckBiz objBiz)
        {
            CofferBiz objPlaceBiz = new CofferBiz() { ID = objCheck.Place };

            BankBiz objCollectingBankBiz = new BankBiz() { ID = objCheck.CollectingBank };
            objBiz.BankBiz = new BankBiz() { ID = objCheck.Bank };
            objBiz.BeneficialName = objCheck.BeneficiaryName;
            objBiz.CheckNote = objCheck.Note;
            objBiz.Code = objCheck.Code;
            objBiz.CurrencyBiz = new SharpVision.COMMON.COMMONBusiness.CurrencyBiz() { ID = objCheck.Currency };
            //objBiz.CustomerID = intCustomer;
            objBiz.CollectingBankBiz = objCollectingBankBiz;
            //Direction = objCheck.Direction;
            //DueDate = objCheck.DueDate;
            objBiz.EditorName = objCheck.EditorName;
            objBiz.IsBankOriented = objCheck.IsBankOriented; objBiz.IssueDate = objCheck.IssueDate;
            objBiz.PlaceBiz = objPlaceBiz;
            //Status = objStatus,
            objBiz.Type = (CheckType)objCheck.Type;
            //Value = objCheck.Value,StatusDate = DateTime.Now
        }
        #endregion
        public static string GetStr(this List<int> objLst)
        {
            string Returned = "";
            foreach(int intId in objLst)
            {
                if (Returned != "")
                    Returned += ",";
                Returned += intId.ToString();
            }
            return Returned;
        }

        
    }
}