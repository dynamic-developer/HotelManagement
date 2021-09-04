using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workbyclocklib.Services;

namespace Workbyclock
{
    public partial class Authenticated : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var es = new EmployeeService();
                    var currentUserInfo = es.GetUserInfoByUsername(HttpContext.Current.User.Identity.Name);
                    if (currentUserInfo != null && currentUserInfo.Active)
                    {
                        HttpContext.Current.Session["id"] = currentUserInfo.Id;
                        HttpContext.Current.Session["name"] = currentUserInfo.UserFullName;
                        HttpContext.Current.Session["email"] = currentUserInfo.Email;
                        HttpContext.Current.Session["rolename"] = currentUserInfo.RoleName;
                       
                        if (currentUserInfo.RoleName == "System Admin")
                        {
                            dvCompanies.Visible = true;
                            dvCompany.Visible = false;
                        }
                        else
                        {
                            dvCompanies.Visible = false;
                            dvCompany.Visible = true;
                            var currentUserCompany = es.GetCompanyByUserId(currentUserInfo.Id);
                            if (currentUserCompany != null && currentUserCompany.Active)
                            {
                                HttpContext.Current.Session["companyid"] = currentUserCompany.CompanyId;
                            }

                        }

                    }
                }
            }
            
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }


    }
}