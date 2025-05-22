using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationAddEdit
    {
        /*ReservationID, ReservationStrategy, ReservationValue, ReservationDate, ReservationContractingDate, ReservationDeliveryDate, ReservationRealDeliveryDate, ReservationCachePrice, ReservationFinishing, 
                  ReservationProfitIsCompound, ReservationProfitValue, ReservationProfitPeriodAmount, ReservationProfitPeriod, ReservationPeriodAmount, ReservationPeriod, ReservationAllowance, ReservationNote, ReservationStatus, 
                  ReservationLimitDate, ReservationBranch, ReservationStopReason, ReservationOpenTime, ReservationStopedPermanently, ReservationDataIsHidden, ReservationIsFree, ReservationIsNew, ReservationIsReviewed, 
                  ReservationBrand,ReservationIsContracted
        ,CancelationDate, CancelationNote, CancelationCost, PayBackComplete, PayBackCompleteDate, PayBackCompleteUsr, CancelationType, CancelationTypeNameA, CancelationTypeNameE

*/
        #region Properties
        public int ID
        {
            set;
            get;
        }
        public int Strategy
        {
            set;
            get;
        }
        public double Value
        {
            set;
            get;
        }
        public DateTime Date
        {
            set;
            get;
        }
        public DateTime ContractingDate
        {
            set;
            get;
        }
        public DateTime DeliveryDate
        {
            set;
            get;
        }
        public DateTime RealDeliveryDate
        {
            set;
            get;
        }
        public double CachePrice
        {
            set;
            get;
        }
        public int Finishing
        {
            set;
            get;
        }
        public bool ProfitIsCompound
        {
            set;
            get;
        }
        public double ProfitValue
        {
            set;
            get;
        }
        public int ProfitPeriodAmount
        {
            set;
            get;
        }
        public int ProfitPeriod
        {
            set;
            get;
        }
        public int PeriodAmount
        {
            set;
            get;
        }
        public int Period
        {
            set;
            get;
        }
        public int Allowance
        {
            set;
            get;
        }
        public string Note
        {
            set;
            get;
        }
        public int Status
        {
            set;
            get;
        }
        public DateTime LimitDate
        {
            set;
            get;
        }
        public int Branch
        {
            set;
            get;
        }
        public string StopReason
        {
            set;
            get;
        }
        public DateTime OpenTime
        {
            set;
            get;
        }
        public bool StopedPermanently
        {
            set;
            get;
        }
        public bool DataIsHidden
        {
            set;
            get;
        }
        public bool IsFree
        {
            set;
            get;
        }
        public bool IsNew
        {
            set;
            get;
        }
        public bool IsReviewed
        {
            set;
            get;
        }
        public int Brand
        {
            set;
            get;
        }
        public double PaidValue { set; get; }
        public double RemainingValue { set; get; }
        #region Properties
        public DateTime CancelationDate
        {
            set;
            get;
        }
        public string CancelationNote
        {
            set;
            get;
        }
        public double CancelationCost
        {
            set;
            get;
        }
        public bool PayBackComplete
        {
            set;
            get;
        }
        public DateTime PayBackCompleteDate
        {
            set;
            get;
        }
        public int PayBackCompleteUsr
        {
            set;
            get;
        }
        public int CancelationType
        {
            set;
            get;
        }
        public string CancelationTypeNameA
        {
            set;
            get;
        }
        public string CancelationTypeNameE
        {
            set;
            get;
        }
        #endregion
        public List<SimpleValue> TempPaymentLst
        {
            set;
            get;
        } = new List<SimpleValue>();
        public List<SimpleValue> DeletedTempPaymentLst
        {
            set;
            get;
        } = new List<SimpleValue>();
        public List<SimpleValue> BonusLst
        {
            set;
            get;
        } = new List<SimpleValue>();
        
        public List<SimpleValue> DeletedBonusLst
        {
            set;
            get;
        } = new List<SimpleValue>();
        public List<SimpleValue> DiscountLst
        {
            set;
            get;
        } = new List<SimpleValue>();

        public List<SimpleValue> DeletedDiscountLst
        {
            set;
            get;
        } = new List<SimpleValue>();
        public List<SimpleValue> UtilityLst
        {
            set;
            get;
        } = new List<SimpleValue>();
        public List<SimpleValue> DeletedUtilityLst
        {
            set;
            get;
        } = new List<SimpleValue>();
        public List<CustomerSimple> CustomerLst
        { set; get; } = new List<CustomerSimple>();
        public string CustomerStr
        {
            get
            {
                string Returned = "";
                foreach(CustomerSimple objCustomer in CustomerLst)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objCustomer.Name;
                }
                return Returned;
            }
        }
        public List<UnitSimple> UnitLst
        { set; get; } = new List<UnitSimple>();
        public string ProjectStr { get
            {
                string Returned = "";
              var arrProject= from objUnit in UnitLst
                               group objUnit by  objUnit.Project into XProject
                               select XProject;
                               
                foreach(var vrProject in arrProject)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += vrProject.Key.ToString();
                }
                return Returned;
            } }
        public string UnitStr
        {
            get
            {
                string Returned = "";
                foreach(UnitSimple objUnit in UnitLst)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objUnit.Code;
                }
                return Returned;
            }
        }
        public string DirectUnitStr { set; get; }
        public List<InstallmentGroupSimple> InstallmentGroup { set; get; } = new List<InstallmentGroupSimple>();
        public List<InstallmentSimple> DeletedInstallment { set; get; } = new List<InstallmentSimple>();
        public List<EmployeeSimple> EmpLst { set; get; } = new List<EmployeeSimple>();
        #endregion
    }
}