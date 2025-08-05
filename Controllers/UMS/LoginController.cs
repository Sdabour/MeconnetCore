using AlgorithmatENMMVCCore.Hubs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using SharpVision.HR.HRBusiness;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
using System.Diagnostics.SymbolStore;
using System.Security.Claims;

namespace AlgorithmatENMMVCCore.Controllers
{
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }
        public  async Task<ActionResult> CheckUser(UserSimple objUserBiz)
        {


           
            UserBiz objNewUser = new UserBiz();
            if (objUserBiz == null)
                objUserBiz = new UserSimple();
            string strUserName = objUserBiz.Name;//Request.Form["Name"];
            //Session[]
            string strPass = objUserBiz.Password;
             
           
            
          
            if (strUserName == null)
                strUserName = "";
            if (strPass == null)
                strPass = "";

            if (strUserName == "" || strPass == "")
            {  return RedirectToAction("index", "Login"); }

            UserBiz.CheckUser(strUserName, strPass, out objNewUser);
            if (objNewUser.ID == 0)
            {
                return   RedirectToAction("index", "Login"); 
            }
            else
            {

                UserFunctionInstantCol objTempCol = objNewUser.UserFunctionInstantCol;
                //if (AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString("BranchCol") != null)
                //{
                //    UMSBranchBiz objBranchBiz = ((UMSBranchCol)Session["BranchCol"])[strBranchID];
                //    AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.SetString("BranchCol") = objBranchBiz;

                //}
             //   AlgorithmatENMMVCCore.WebHelpers.HttpContext.Session.GetString("CurrentUser")

                //SysData.CurrentUser = objNewUser;
                UserSimple objUserSimple = objNewUser.UserSimple;
               // objUserSimple.Branch = intBranch;




                //FacultyCol objFacultyCol = new FacultyCol(true);

                string strUser = JsonConvert.SerializeObject(objNewUser.UserSimple);
                HttpContext.Session.SetString("CurrentUser", strUser);
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, objUserSimple.Name),
                // Add additional claims as needed
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Optional: Configure additional properties
                    IsPersistent = true, // "Remember me" functionality
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

            }
            

             
                return RedirectToAction("Index", "Home");
            }

        public IActionResult ChangePasswordIndex()
        {
            return View("ChangePassword");
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("index"); 
           
        }
    }
}
