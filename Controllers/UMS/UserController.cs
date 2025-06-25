using Microsoft.AspNetCore.Mvc;
using SharpVision.UMS.UMSBusiness;
using System.Text.Json;
namespace AlgorithmatENMMVCCore.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GroupIndex()
        {
            GroupBiz objBiz = new GroupBiz();
            return View("GroupDisplay", objBiz);
        }
        public ActionResult GroupAddEditIndex()
        {
            string strTemp = Request.Query["GroupID"];
            int intGroup = 0;
            if (strTemp != "")
                int.TryParse(strTemp, out intGroup);

            GroupBiz objBiz = new GroupBiz(intGroup);
            return View("GroupAddEdit", objBiz);
        }
        public ActionResult AddEditSaveGroup(GroupBiz objBiz)
        {
            if (objBiz == null)
                objBiz = new GroupBiz();
            string strFunction = Request.Form["lblAllFunctionInstant"];
            List<FunctionInstantSimple> arrFunction =JsonSerializer.Deserialize<List<FunctionInstantSimple>>(strFunction);
            GroupFunctionInstantCol objFunctionCol = new GroupFunctionInstantCol(true);
            foreach (FunctionInstantSimple objSimple in arrFunction)
                objFunctionCol.Add(objSimple.GetGroupFunctionInstant());
            //objBiz.GroupFunctionInstantCol = objFunctionCol;
            if (objBiz.Name != null && objBiz.Name != "")
            {
                if (objBiz.ID == 0)
                    GroupBiz.Add(objBiz.Name, objBiz.ParentID, objBiz.FamilyID, objBiz.GroupTypeID, objFunctionCol);
                else
                    GroupBiz.Edit(objBiz.ID, objBiz.Name, objBiz.ParentID, objBiz.FamilyID, objBiz.GroupTypeID, objFunctionCol);
            }
            return View("GroupAddEdit", objBiz);
        }
        public ActionResult UserAddEditIndex()
        {
            string strTemp = "";//Request["UserID"];
            int intTemp = 0;
            int.TryParse(strTemp, out intTemp);
            UserBiz objBiz = new UserBiz(intTemp);
            if (objBiz.EmployeeBiz.ID == 0)
            {
                strTemp = "";//Request["EmpID"];
                intTemp = 0;
                int.TryParse(strTemp, out intTemp);
                if (intTemp > 0)
                    objBiz.EmployeeBiz = new EmployeeBiz(intTemp);
            }
            return View("UserAddEdit", objBiz);
        }

      
    }
}
