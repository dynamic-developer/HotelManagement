using System;
using System.Collections.Generic;
using System.Web.Services;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;
using System.Web;

namespace Workbyclock
{
    public partial class Employees : System.Web.UI.Page
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
        public static List<EmployeeViewModel> GetAllEmployees()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if (HttpContext.Current.Session["rolename"] != null && HttpContext.Current.Session["rolename"].ToString() == "System Admin")
            {
                var es = new EmployeeService();
                return es.GetAllEmployees();
            }
            else
            {
                if (HttpContext.Current.Session["companyid"] != null)
                {
                    var es = new EmployeeService();
                    return es.GetAllEmployeesByCompanyId(int.Parse(HttpContext.Current.Session["companyid"].ToString()));
                }
            }

            return null;
            

        }
    }
}