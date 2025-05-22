using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    public class CustomerSimpleSearch
    {
        /* ID,Name,
 Phone,UnitCode
 ,IDNo,
 ProjectIDs*/

        #region Properties
        public int ID
        {
            set;
            get;
        }
        public string Name
        {
            set;
            get;
        }
        public string Phone
        {
            set;
            get;
        }
        public string UnitCode
        {
            set;
            get;
        }
        public string IDNo
        {
            set;
            get;
        }
        public string ProjectIDs
        {
            set;
            get;
        }
        #endregion
    }
}