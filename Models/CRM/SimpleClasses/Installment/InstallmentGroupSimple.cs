using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentGroupSimple
    {
        /* TotalValue,InstallmentTypeID,InstallmentTypeName,Count,StartDate,PeriodID,PeriodName,InstallmentLst*/


        #region Properties
        public double TotalValue;
        public int InstallmentTypeID;
        public string InstallmentTypeName;
        public int Count;
        
        public string StartDate;
        public int PeriodID;
        public string PeriodName;
        public List<InstallmentSimple> InstallmentLst = new List<InstallmentSimple>();
        #endregion
    }
}