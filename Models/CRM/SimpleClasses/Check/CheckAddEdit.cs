using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class CheckAddEdit
    {
        /*
         * CheckID, CheckDirection, CheckEditorName, CheckBeneficiaryName, CheckBank, CheckCode, CheckType, CheckValue, CheckCurrency, CheckIssueDate, CheckDueDate, CheckPaymentDate, CheckNote, CheckCurrentStatus, 
                  CheckParentID, CheckIsBankOriented, BankSubmissionDate, CheckPerson, CheckPersonType, CheckGLAccount, CheckCustomer,Place

         */

        #region Properties
        public int ID
        {
            set;
            get;
        }
        public bool Direction
        {
            set;
            get;
        }
        public string EditorName
        {
            set;
            get;
        }
        public string BeneficiaryName
        {
            set;
            get;
        }
        public int Bank
        {
            set;
            get;
        }
        public int Place
        {
            set;
            get;
        }
        public int CollectingBank
        { set; get; }

        public string Code
        {
            set;
            get;
        }
        public int Type
        {
            set;
            get;
        }
        public double Value
        {
            set;
            get;
        }
        public int Currency
        {
            set;
            get;
        }
        public DateTime IssueDate
        {
            set;
            get;
        } = DateTime.Now;
        public DateTime DueDate
        {
            set;
            get;
        } = DateTime.Now;
        public int DueDateMonthNo
        { set;
            get;

        }
        public DateTime PaymentDate
        {
            set;
            get;
        } = DateTime.Now;
        public string Note
        {
            set;
            get;
        }
        public int CurrentStatus
        {
            set;
            get;
        }
        public string ParentID
        {
            set;
            get;
        }
        public bool IsBankOriented
        {
            set;
            get;
        }
        public DateTime BankSubmissionDate
        {
            set;
            get;
        }
        public int Person
        {
            set;
            get;
        }
        public int PersonType
        {
            set;
            get;
        }
        public string GLAccount
        {
            set;
            get;
        }
        public int Customer
        {
            set;
            get;
        }
        public string CodeFrom { set; get; }
        public string CodeTo { set; get; }
        #endregion
    }
}