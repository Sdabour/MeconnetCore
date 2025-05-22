using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class CheckSimple
    {
        /*CheckID, CheckDirection,CheckDirectionDesc, CheckEditorName, CheckBeneficiaryName, CheckBank,CheckBankName, CheckCode, CheckType,CheckTypeName, CheckValue,CollectedValue, CheckCurrency,CheckCurrencyName, CheckIssueDate, CheckDueDate, CheckPaymentDate, CheckNote, CheckCurrentStatus, CheckCurrentStatusDesc,CurrentStatusDate,
                  CheckParentID, CheckIsBankOriented,CheckIsBankOrientedDesc, BankSubmissionDate, CheckPerson, CheckPersonType, CheckGLAccount, CheckCustomer,CheckCustomerName,Place,PlaceName*/

        #region Properties
        public int ID;
        public bool Direction;
        public string DirectionDesc;
        public string EditorName;
        public string BeneficiaryName;
        public int Bank;
        public string BankName;
        public string Code;
        public int Type;
        public string TypeName;
        public double Value;
        public double CollectedValue;
        public double TotalPayment;
        public int Currency;
        public string CurrencyName;
        public DateTime IssueDate;
        public string IssueDateStr { get => IssueDate.ToString("yyyy-MM-dd"); }
        public DateTime DueDate;
        public string DueDateStr { get => DueDate.ToString("yyyy-MM-dd"); }
        public DateTime PaymentDate;
        public string Note;
        public int CurrentStatus;
        public string CurrentStatusDesc;
        public DateTime CurrentStatusDate;
        public string CurrentStatusDateStr { get => CurrentStatusDate.ToString("yyyy-MM-dd"); }
        public int ParentID;
        public bool IsBankOriented;
        public string IsBankOrientedDesc;
        public DateTime BankSubmissionDate;
        public int Person;
        public int PersonType;
        public int GLAccount;
        public int Customer;
        public string CustomerName;
        public int Place;
        public string PlaceName;
        #endregion
    }
}