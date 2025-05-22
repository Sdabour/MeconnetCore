using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentSimple
    {
        /*ID,TypeID,TypeName,DueDate,Value,Note,PaidValue*/
        #region Properties
        public int ID;
        public int TypeID;
        public string TypeName;
        public string DueDate;
        public string DueDateStr;
        public double Value;
        public string Note;
        public string StatusStr;
        public double PaidValue;
        public double DiscountVaue;
        public double RemainingValue;

        public List<PaymentSimple> PaymentLst=new List<PaymentSimple>();

        public List<DiscountSimple> DiscountLst = new List<DiscountSimple>();
        #endregion

    }
}