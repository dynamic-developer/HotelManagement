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
    public partial class ViewEmployeeTimesheet : System.Web.UI.Page
    {
        public bool IsAllowedRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("/Account/Login");
                }
                if (HttpContext.Current.Session["rolename"] != null && (HttpContext.Current.Session["rolename"].ToString() == "System Admin" || HttpContext.Current.Session["rolename"].ToString() == "Company Admin"))
                {
                    IsAllowedRole = true;

                }
                else
                {
                    IsAllowedRole = false;
                }
            }
        }

        [WebMethod]
        public static List<EmployeeTimeCardViewModel> GetAllTimesheetForEmployee(DateTime startDate, DateTime endDate, int employeeId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if (employeeId == 0)
            {
                return null;
            }
            var es = new EmployeeService();
            return es.GetEmployeeTime(employeeId, startDate, endDate);
        }
    }
}