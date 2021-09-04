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
    public partial class Timesheet : System.Web.UI.Page
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
        public static List<EmployeeViewModel> GetAllTimesheet(string startDateString, string endDateString, int locationId, string employeeType )
        {
            DateTime startDate = DateTime.Now; 
            DateTime endDate = DateTime.Now;
            if (!string.IsNullOrEmpty(startDateString) && !string.IsNullOrEmpty(endDateString))
            {
                startDate = DateTime.Parse(startDateString);
                endDate = DateTime.Parse(endDateString);
            }else if (string.IsNullOrEmpty(startDateString) && !string.IsNullOrEmpty(endDateString))
            {

                endDate = DateTime.Parse(endDateString);
                startDate = endDate.AddDays(-14);
            }
            else if(!string.IsNullOrEmpty(startDateString) && string.IsNullOrEmpty(endDateString))
            {
                startDate = DateTime.Parse(startDateString);
                endDate = startDate.AddDays(14);

            }
            else
            {

            }
                
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var es = new EmployeeService();

            if (HttpContext.Current.Session["rolename"] != null && HttpContext.Current.Session["rolename"].ToString() == "System Admin")
            {

                if (HttpContext.Current.Session["companyid"] != null)
                {
                    return es.GetEmployeesTime(startDate, endDate, int.Parse(HttpContext.Current.Session["companyid"].ToString()), locationId, employeeType);
                }
                else
                {
                    return es.GetEmployeesTime(startDate, endDate, 0, locationId, employeeType);
                }
            }
            else
            {
                if (HttpContext.Current.Session["companyid"] != null)
                {
                    return es.GetEmployeesTime(startDate, endDate, int.Parse(HttpContext.Current.Session["companyid"].ToString()), locationId, employeeType);
                }
            }

            return null;
        }

        [WebMethod]
        public static List<LocationViewModel> GetAllLocations()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if (HttpContext.Current.Session["rolename"] != null && HttpContext.Current.Session["rolename"].ToString() == "System Admin")
            {
                var es = new EmployeeService();
                var loc = es.GetAllLocations();
                if (loc == null)
                {
                    loc = new List<LocationViewModel>();
                }
                var lv = new LocationViewModel()
                {
                    LocationId = 0,
                    LocationName = "All"
                };
                loc.Insert(0, lv);


                return loc;
            }
            else
            {
                if (HttpContext.Current.Session["companyid"] != null)
                {
                    var es = new EmployeeService();
                    var loc = es.GetAllLocationsByCompanyId(int.Parse(HttpContext.Current.Session["companyid"].ToString()));
                    if (loc == null)
                    {
                        loc = new List<LocationViewModel>();
                    }
                    var lv = new LocationViewModel()
                    {
                        LocationId = 0,
                        LocationName = "All"
                    };
                    loc.Insert(0, lv);


                    return loc;
                }
            }

            return null;
        }
    }
}