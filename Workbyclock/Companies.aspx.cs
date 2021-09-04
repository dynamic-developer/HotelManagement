using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;

namespace Workbyclock
{
    public partial class Companies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated || HttpContext.Current.Session["rolename"] == null || HttpContext.Current.Session["rolename"].ToString() != "System Admin")
                {
                    Response.Redirect("/Account/Login");
                }
            }
        }

        [WebMethod]
        public static List<CompanyViewModel> GetAllCompanies()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated || HttpContext.Current.Session["rolename"] == null || HttpContext.Current.Session["rolename"].ToString() != "System Admin")
            {
                return null;
            }
            var es = new EmployeeService();
            return es.GetAllCompanies();

        }

        [WebMethod]
        public static bool SetCurrentCompany(int CompanyId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated || HttpContext.Current.Session["rolename"] == null || HttpContext.Current.Session["rolename"].ToString() != "System Admin")
            {
                return false;
            }
            HttpContext.Current.Session["companyid"] = CompanyId;
            return true;

        }
    }
}