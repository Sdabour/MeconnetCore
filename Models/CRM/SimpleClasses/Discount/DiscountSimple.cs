using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class DiscountSimple
    {
        /*
         ID,InstallmentID,ReservationID,Value,Desc,Date,Type,TypeDesc,User,Branch,EMployee
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
       
        public int User;
        public int Branch;
        public int EMployee;
        #endregion
    }
}