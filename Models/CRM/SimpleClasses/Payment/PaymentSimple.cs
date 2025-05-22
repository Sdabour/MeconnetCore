using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class PaymentSimple
    {
        #region Static UMS
        static int _UMSInstallmentDiscount = 130;
        static int _UMSInstallmentDiscountCancel = 169;
        static int _UMSInstallmentDiscountEdit = 168;
        static int _UMSInstallmentPayment = 111;
        static int _UMSInstallmentPaymentCancel = 166;
       public  static bool UMSInstallmentPaymentCancelAuthorize;
        static int _UMSInstallmentPaymentEdit = 165;
        static bool UMSInstallmentPaymentEditAuthorized;
        int _InstallmentTempPaymentEdit = 411;
        int _InstallmentTempPaymentCancel = 410;

       static int _UMSCancelAllNonCollectedPayment = 1151;
       static bool UMSCancelAllNonCollectedPaymentEnabled = false;

       static int _UMSEditCheckPayment = 1154;
       static bool _UMSEditCheckPaymentAuthorised = true;

       static int _UMSDeleteCheckPayment = 1155;
       static bool UMSDeleteCheckPaymentAuthorised = true;

        static int _UMSChangePaymentDate = 1203;
        public static bool UMSChangePaymentDateAuthorised { get
            {
                bool Returned = true;
                Returned = SysData.CurrentUser.UserFunctionInstantCol.GetIndex(_UMSChangePaymentDate) > -1;

                return Returned;
            } }
        static int _UMSReceiptMaking = 1053;
        static bool UMSReceiptMakingAuthorised = true;

        #endregion
        /*
         ID,InstallmentID,ReservationID,Value,Desc,Date,Type,TypeDesc,CheckID,CheckNo,CheckDueDate,CheckValue,CheckStatus,CheckStatusDate,CheckBankID,CheckBankName,IsCollected,CollectingDate,CollectingType,CollectingTypeDesc,User,Branch,EMployee,CollectedValue
         */

        #region Properties
        public int ID;
        public int InstallmentID;
        public int ReservationID;
        public double Value;
        public string Desc;
        public DateTime Date;
        public string DateStr { get => Date.ToString("yyyy-MM-dd"); }
        public int Type;
        public string TypeDesc;
        public int CheckID;
        public string CheckNo;
        public DateTime CheckDueDate;
        public double CheckValue;
        public int CheckStatus;
        public DateTime CheckStatusDate;
        public int CheckBankID;
        public string CheckBankName;
        public bool IsCollected;
        public DateTime CollectingDate;
        public int CollectingType;
        public string CollectingTypeDesc;
        public double CollectedValue;
        public int User;
        public int Branch;
        public int EMployee;
        public bool ChangePaymentDateAuthorized;
        #endregion
    }
}