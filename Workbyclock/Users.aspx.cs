using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;

namespace Workbyclock
{
    public partial class Users : System.Web.UI.Page
    {
        public bool IsAllowedRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsAllowedRole = false;
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("/Account/Login");
                }
                if (HttpContext.Current.Session["rolename"] != null && ( HttpContext.Current.Session["rolename"].ToString() == "System Admin" || HttpContext.Current.Session["rolename"].ToString() == "Company Admin"))
                {
                    btnAddUser.Visible = true;
                    IsAllowedRole = true;

                }
                else
                {
                    btnAddUser.Visible = false;
                    IsAllowedRole = false;
                }
            }
        }

        [WebMethod]
        public static List<UserViewModel> GetAllUsers()
        {
            var es = new EmployeeService();

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
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
                return null;
            }
            if (HttpContext.Current.Session["companyid"] != null)
            {
                companyId = int.Parse(HttpContext.Current.Session["companyid"].ToString());
            }
            else
            {
                return null;
               
            }
            return es.GetUserInfoForCompany(companyId);

        }
    }
}