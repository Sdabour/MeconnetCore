using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class CheckSimpleSearch
    {
        /*ID,Code,Benificiary,Currency,BankID,IssueStart,IssueEnd,DueStart,DueEnd,ValueStart,ValueEnd*/

        #region Properties
        public int ID
        {
            set;
            get;
        }
        public string Code
        {
            set;
            get;
        }
        public string Benificiary
        {
            set;
            get;
        }
        public int Currency
        {
            set;
            get;
        }
        public int BankID
        {
            set;
            get;
        }
        public int Place
        {
            set;
            get;
        }
        public DateTime IssueStart
        {
            set;
            get;
        }
        public DateTime IssueEnd
        {
            set;
            get;
        }
        public bool IssueRange { get => IssueStart != null && IssueEnd != null && IssueEnd.Date >= IssueStart.Date && IssueStart.Date.Year > 2001; }
       
        public DateTime DueStart
        {
            set;
            get;
        }
        public DateTime DueEnd
        {
            set;
            get;
        }
        public bool DueRange { get => DueStart != null && DueEnd != null && DueEnd.Date >= DueStart.Date && DueStart.Date.Year > 2001; }

        public DateTime StatusStart
        {
            set;
            get;
        }
        public DateTime StatusEnd
        {
            set;
            get;
        }
        public bool StatusRange { get => StatusStart != null && StatusEnd != null && StatusEnd.Date >= StatusStart.Date && StatusStart.Date.Year > 2001; }

        public DateTime PaymentStart
        {
            set;
            get;
        }
        public DateTime PaymentEnd
        {
            set;
            get;
        }
        public bool PaymentRange { get => PaymentStart != null && PaymentEnd != null && PaymentEnd.Date >= PaymentStart.Date && PaymentStart.Date.Year > 2001; }

        public double ValueStart
        {
            set;
            get;
        }
        public double ValueEnd
        {
            set;
            get;
        }
        public bool Direction { set; get; }
        public int Status { set; get; }
        public string IDsStr { set; get; }
        public int Type { set; get; }
        public int CollectingPaymentStatus { set; get; }
        public string Note { set; get; } = "";

        public bool StatusLimitDateCheked { set; get; }
        public DateTime StatusLimitDate{ set; get; }
        public bool IsSubmission { set; get; }
        public DateTime StartSubmissionDate { set; get; }
        public DateTime EndSubmissionDate { set; get; }
        public int OrientedStatus { set; get; }
        public int Account { set; get; }
        #endregion
    }
}