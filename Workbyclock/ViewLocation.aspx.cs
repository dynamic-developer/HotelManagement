using System;
using System.Web;
using System.Web.Services;

using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;


namespace Workbyclock
{
    public partial class ViewLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static LocationViewModel GetLocationByLocationId(int LocationId)
        {
            var es = new EmployeeService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            bool isValidLocation = false;
            if (HttpContext.Current.Session["rolename"] != null && HttpContext.Current.Session["rolename"].ToString() == "System Admin")
            {
                isValidLocation = true;

            }
            else
            {
                if (HttpContext.Current.Session["rolename"] != null)
                {
                    if (HttpContext.Current.Session["id"] != null && HttpContext.Current.Session["companyid"] != null)
                    {
                        isValidLocation = es.IsValidLocationForUser(HttpContext.Current.Session["id"].ToString(), int.Parse(HttpContext.Current.Session["companyid"].ToString()), LocationId);

                    }
                }
            }

            if (!isValidLocation)
            {
                return null;
            }

            return es.GetLocationsByLocationId(LocationId);

        }
    }
}