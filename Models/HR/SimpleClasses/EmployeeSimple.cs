using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.UMS.UMSBusiness
{
    public class EmployeeSimple
    {
        public int ID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string FamousName { set; get; }
        public string BranchName { set; get; }
        public string Department { set; get; }
        public int User { set; get; }
        public string UserName { set; get; }
        public string EditStr
        {
            get
            {
                string Returned = "Index?EmpID=" + ID;
                return Returned;
            }
        }
        public string UserAddEditStr
        {
            get
            {
                string Returned = "/User/UserAddEditIndex";
             
                    Returned += "?UserID=" + User +"&EmpID="+ID;
               // Returned += "&EmpID="+ID;
                return Returned;
            }
        }

        public string UserAddEditHeader
        {
            get
            {
                string Returned = "مستخدم جديد";
                if (User > 0)
                    Returned = "تعديل مستخدم";
                return Returned;
            }
        }

    }
}