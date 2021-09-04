using System;
using System.Web;
using System.Web.Services;

using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;

namespace Workbyclock
{
    public partial class Location : System.Web.UI.Page
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
        public static int SaveLocation(int LocationId, int CompanyId,
         string LocationName,
         string LocationDescription,
         string LocationPhone,
         string LocationEmail,
         string LocationAddress1,
         string LocationAddress2,
         string LocationCity,
         string LocationState,
         string LocationZip,
         string LocationCountry,
         bool Active)
        {
            var es = new EmployeeService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            bool isValidCompany = false;
            int currentCompany = 0;
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
                        currentCompany = int.Parse(HttpContext.Current.Session["companyid"].ToString());
                        isValidCompany = es.IsValidCompanyForUser(HttpContext.Current.Session["id"].ToString(), int.Parse(HttpContext.Current.Session["companyid"].ToString()));

                    }
                }
            }

            if (!isValidCompany)
            {
                return 0;
            }
            var LocationObj = new LocationViewModel();
            LocationObj.LocationId = LocationId;
            LocationObj.CompanyId = CompanyId == 0 ? currentCompany : CompanyId;
            LocationObj.LocationName = LocationName;
            LocationObj.LocationDescription = LocationDescription;
            if (!string.IsNullOrEmpty(LocationPhone))
            {
                LocationPhone = LocationPhone.Replace("-", string.Empty);
                LocationPhone = LocationPhone.Replace("(", string.Empty);
                LocationPhone = LocationPhone.Replace(")", string.Empty);
                LocationPhone = LocationPhone.Replace(" ", string.Empty);
            }
            
            LocationObj.LocationPhone = LocationPhone;
            LocationObj.LocationEmail = LocationEmail;
            LocationObj.LocationAddress1 = LocationAddress1;
            LocationObj.LocationAddress2 = LocationAddress2;
            LocationObj.LocationCity = LocationCity;
            LocationObj.LocationState = LocationState;
            LocationObj.LocationZip = LocationZip;
            LocationObj.LocationCountry = LocationCountry;
            LocationObj.Active = Active;
            return es.SaveLocation(LocationObj);
           
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