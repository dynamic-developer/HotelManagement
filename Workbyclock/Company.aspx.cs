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
    public partial class Company : System.Web.UI.Page
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
        public static int SaveCompany(int CompanyId,
        string CompanyName,
        string CompanyDescription,
        string CompanyPhone,
        string CompanyEmail,
        string CompanyWebsite,
        string CompanyAddress1,
        string CompanyAddress2,
        string CompanyCity,
        string CompanyState,
        string CompanyZip,
        string CompanyCountry,
        byte[] CompanyLogo,
        bool Active,
        int CompanyNumberOfUsers,
        int CompanyNumberOfLocation)
        {
            var es = new EmployeeService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
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
                return 0;
            }
            var companyObj = new CompanyViewModel();
            companyObj.CompanyId = CompanyId;
            companyObj.CompanyName = CompanyName;
            companyObj.CompanyDescription = CompanyDescription;
            companyObj.CompanyPhone = CompanyPhone;
            companyObj.CompanyEmail = CompanyEmail;
            companyObj.CompanyWebsite = CompanyWebsite;
            companyObj.CompanyAddress1 = CompanyAddress1;
            companyObj.CompanyAddress2 = CompanyAddress2;
            companyObj.CompanyCity = CompanyCity;
            companyObj.CompanyState = CompanyState;
            companyObj.CompanyZip = CompanyZip;
            companyObj.CompanyCountry = CompanyCountry;
            companyObj.CompanyLogo = CompanyLogo;
            companyObj.Active = Active;
            companyObj.CompanyNumberOfUsers = CompanyNumberOfUsers;
            companyObj.CompanyNumberOfLocation = CompanyNumberOfLocation;
            return es.SaveCompany(companyObj);

        }

        [WebMethod]
        public static CompanyViewModel GetCompanyByCompanyId(int CompanyId)
        {
            var es = new EmployeeService();
           if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            bool isValidCompany = false;
            if (HttpContext.Current.Session["rolename"] != null && HttpContext.Current.Session["rolename"].ToString() == "System Admin")
            {
                isValidCompany = true;

            }
            
            if (!isValidCompany)
            {
                return null;
            }
            return es.GetCompanyByCompanyId(CompanyId);

        }
    }
}