using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpVision.UMS.UMSBusiness;

namespace AlgorithmatENMMVCCore.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        [HttpGet]
        public List<UserSimple> GetUserList()
        {
            UserCol objUserCol = new UserCol(0,"","",0);
            List<UserSimple> Returned = objUserCol.Cast<UserBiz>().Select(x => x.GetSimple()).ToList();
            return Returned;

        }

       

        [HttpPost]
        public int AddEditUser(UserSimple objUser)
        {
            if (!objUser.ChangePass)
            {
                UserFunctionInstantCol objFunctionCol = new UserFunctionInstantCol(true);
                foreach (FunctionInstantSimple objSimple in objUser.LstFunction)
                    objFunctionCol.Add(objSimple.GetUserFunctionInstant());
                if (objUser.Name != "" && objUser.FullName != "" && objUser.Password != "")
                {
                    if (objUser.ID == 0)
                        UserBiz.Add(objUser.FullName, objUser.Name, objUser.Password, objUser.Group, false, false, objFunctionCol, new EmployeeBiz() { ID = objUser.EmployeeID }, new UserBiz());
                    else
                        UserBiz.Edit(objUser.ID, objUser.FullName, objUser.Name, objUser.Password, objUser.Group, false, false, objFunctionCol, new EmployeeBiz() { ID = objUser.EmployeeID }, new UserBiz());
                }
                return objUser.ID;
            }
            else if (objUser.ID != 0)
            {
                UserBiz objUserBiz = new UserBiz();
                UserBiz.CheckUser(objUser.Name, objUser.OldPass, out objUserBiz);
                if (objUserBiz.ID != 0)
                {
                    objUserBiz.EditPassword(objUser.Password);

                }
                return objUserBiz.ID;
            }
            else { return objUser.ID; }

        }
    }
}
