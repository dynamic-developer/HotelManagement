using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;

namespace Workbyclock
{
    public partial class Locations : System.Web.UI.Page
    {
        public bool IsAllowedRole;
        public bool IsSystemAdmin;
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
                    if (HttpContext.Current.Session["rolename"].ToString() == "System Admin")
                    {
                        IsSystemAdmin = true;
                    }
                    else
                    {
                        IsSystemAdmin = false ;
                    }
                    btnAddLocation.Visible = true;
                    IsAllowedRole = true;

                }
                else
                {
                    IsSystemAdmin = false;
                    btnAddLocation.Visible = false;
                    IsAllowedRole = false;
                }
            }
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
                    return es.GetAllLocations();
            }
            else
            {
                if (HttpContext.Current.Session["companyid"] != null)
                {
                    var es = new EmployeeService();
                    return es.GetAllLocationsByCompanyId(int.Parse(HttpContext.Current.Session["companyid"].ToString()));
                }
            }
           
            return null;

        }
    }
}