using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.CRM.CRMBusiness
{
    [Serializable]
    public class SingleCustomer
    {
        public int ID;

        public string Name;
        public string UnitCode;
        public string Project;
        public string IDNo;
        public SingleCustomer()
        {
            Name = "";
            UnitCode = "";
            Project = "";
            IDNo = "";

        }
    }

    [Serializable]
    public class CustomerSimple
    {
        //ID,Name,UnitCode,TowerCode,ProjectCode,ProjectName,Mobile1,Mobile2,Phone1,Phone2

        #region Properties
         

        public int ID;
        public string Name;
        public string UnitCode;
        public string TowerCode;
        public string ProjectCode;
        public string ProjectName;
        public string Mobile1;
        public string Mobile2;
        public string Phone1;
        public string Phone2;
        public string EditStr;
        #endregion
    }
}