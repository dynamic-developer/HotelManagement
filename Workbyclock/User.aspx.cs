using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;
using Microsoft.AspNet.Identity;
using Workbyclock.Models;

namespace Workbyclock
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("/Account/Login");
                }
            }
        }

        [WebMethod]
        public static int SaveUser(string Id,
       string UserName,
       string Email,
       int RoleId,
       string UserFullName,
       string UserAddress1,
       string UserCity,
       string UserState,
       string UserZip,
       string UserCountry,
       bool Active,
       string UserPhone,
       bool IsEmailModified)
        {
            var es = new EmployeeService();

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            if (RoleId == 1000)
            {
                return 0;
            }
            bool isValidCompany = false;
            int companyId = 0;
            if (HttpContext.Current.Session["rolename"] != null && HttpContext.Current.Session["rolename"].ToString() == "System Admin")
            {
                isValidCompany = true;

            }
            else
            {
                if (HttpContext.Current.Session["rolename"] != null)
                {
                    if (HttpContext.Current.Session["id"] != null && HttpContext.Current.Session["companyid"] != null)
                    {
                        
                        isValidCompany = es.IsValidCompanyForUser(HttpContext.Current.Session["id"].ToString(), int.Parse(HttpContext.Current.Session["companyid"].ToString()));

                    }
                }
            }

            if (!isValidCompany)
            {
                return 0;
            }
            if (HttpContext.Current.Session["companyid"] != null)
            {
                companyId = int.Parse(HttpContext.Current.Session["companyid"].ToString());
            }
            else
            {
                return 0;
                //if (HttpContext.Current.Session["rolename"] != null && HttpContext.Current.Session["rolename"].ToString() == "System Admin")
                //{
                    

                //}
                //else
                //{

                //}
            }

           
            if (!string.IsNullOrEmpty(Email))
            {
                if (es.GetValidEmail(Email) && string.IsNullOrEmpty(Id))
                {
                    var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
                    var user = new ApplicationUser() { UserName = Email, Email = Email };
                    string pass = UppercaseFirst(GetFirstName(UserFullName).ToLower() + "-" + (!string.IsNullOrEmpty(UserZip) ? UserZip.ToString() : "12345"));
                    IdentityResult result = manager.Create(user, pass);
                    //IdentityResult result = manager.Create(user, GetRandomPass());
                    if (result.Succeeded)
                    {
                        var signUp = new SignupService();
                        var userId = es.GetUserId(Email);
                        signUp.SaveUser(userId, UserName,Email,RoleId,UserFullName,UserAddress1,UserCity,UserState,UserZip,UserCountry,Active,UserPhone,IsEmailModified, companyId);
                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        string code = manager.GenerateEmailConfirmationToken(userId);
                        string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, userId, HttpContext.Current.Request);
                        WbcEmailService dal = new WbcEmailService();
                        string msg = String.Format(dal.EmailRegisterBody, Email, pass, callbackUrl);
                        dal.SendHtmlEmail(Email, dal.EmailRegisterSubject, msg);
                        //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                        //signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                        //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        //HttpContext.Current.Response.Redirect("~/Account/RegisterConfirmation");
                        return 1;
                    }
                }
                else
                {
                    var signup = new SignupService();
                    if (!string.IsNullOrEmpty(UserPhone))
                    {
                        UserPhone = UserPhone.Replace("-", string.Empty);
                        UserPhone = UserPhone.Replace("(", string.Empty);
                        UserPhone = UserPhone.Replace(")", string.Empty);
                        UserPhone = UserPhone.Replace(" ", string.Empty);
                    }
                    
                    signup.SaveUser(Id, UserName, Email, RoleId, UserFullName, UserAddress1, UserCity, UserState, UserZip, UserCountry, Active, UserPhone, IsEmailModified, companyId);
                    return 1;
                }
            }

            return 0;
        }

        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string GetFirstName(string fullName)
        {
            if (!string.IsNullOrEmpty(fullName))
            {
                string[] coll = fullName.Split(' ');
                if (coll != null && coll.Length > 0)
                {
                    return coll[0];
                }
            }
            return "";
        }

        [WebMethod]
        public static List<RoleViewModel> GetAllRoleType()
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var es = new EmployeeService();
            return es.GetAllRoles();

        }

        [WebMethod]
        public static bool CheckValidEmail(string Email)
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var es = new EmployeeService();
            return es.GetValidEmail(Email);

        }

        [WebMethod]
        public static string GetValidEmail(string UserId)
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return string.Empty;
            }

            var es = new EmployeeService();
            return es.GetEmail(UserId);

        }

        [WebMethod]
        public static UserViewModel GetUserInfo(string UserId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var es = new EmployeeService();
            return es.GetUserInfo(UserId);
        }
    }
}