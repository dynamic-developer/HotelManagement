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
    public partial class ManageTimeSheet : System.Web.UI.Page
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
        public static string SaveTimesheetByEmployeeId(
                int EmployeeTimeCardId,
              int EmployeeId,
              int LocationId,
              string LocationIp,
             DateTime? TimeIn,
            DateTime? TimeOut,
            string TimeInString,
            string TimeOutString,
            string Reason)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return "Not a valid user";
            }
            var es = new EmployeeService();

            bool isValidCompany = false;
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
                        if (!es.IsValidCompanyForEmployee(EmployeeId, int.Parse(HttpContext.Current.Session["companyid"].ToString())))
                        {
                            return "Not a valid user";
                        }
                        isValidCompany = es.IsValidCompanyForUser(HttpContext.Current.Session["id"].ToString(), int.Parse(HttpContext.Current.Session["companyid"].ToString()));

                    }
                }
            }

            if (!isValidCompany)
            {
                return "Not a valid user";
            }
            var em = new EmployeeTimeCardViewModel();
            em.EmployeeId = EmployeeId;
            em.LocationId = LocationId;
            em.LocationIp = LocationIp;
            em.TimeIn = TimeIn;
            em.TimeOut = TimeOut;
            em.EmployeeTimeCardId = EmployeeTimeCardId;
            em.Reason = Reason;
            em.TimeInUIString = TimeInString;
            em.TimeOutUIString = TimeOutString;
            return es.SaveEmployeeTimeCard(em, HttpContext.Current.Session["id"].ToString());
        }

        [WebMethod]
        public static string DeleteTimesheetByEmployeeId(
                int EmployeeTimeCardId,
             string Reason)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return "Not a valid user";
            }
            var es = new EmployeeService();

            bool isValidCompany = false;
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
                return "Not a valid user";
            }
            return es.DeleteTimeCard(EmployeeTimeCardId, HttpContext.Current.Session["id"].ToString(),Reason);
        }

        [WebMethod]
        public static EmployeeTimeCardViewModel GetTimesheetByEmployeeId(int TimeCardId, int EmployeeId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var es = new EmployeeService();

            bool isValidCompany = false;
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
                        if (!es.IsValidCompanyForEmployee(EmployeeId, int.Parse(HttpContext.Current.Session["companyid"].ToString())))
                        {
                            return null;
                        }
                        isValidCompany = es.IsValidCompanyForUser(HttpContext.Current.Session["id"].ToString(), int.Parse(HttpContext.Current.Session["companyid"].ToString()));

                    }
                }
            }

            if (!isValidCompany)
            {
                return null;
            }

            return es.GetEmployeeTimeCard(TimeCardId);
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
               


                return loc;
            }
            else
            {
                if (HttpContext.Current.Session["companyid"] != null)
                {
                    var es = new EmployeeService();
                    var loc = es.GetAllLocationsByCompanyId(int.Parse(HttpContext.Current.Session["companyid"].ToString()));
                    


                    return loc;
                }
            }

            return null;
        }

    }
}