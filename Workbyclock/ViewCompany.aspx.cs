using System;
using System.Web;
using System.Web.Services;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;

namespace Workbyclock
{
    public partial class ViewCompany : System.Web.UI.Page
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
        public static CompanyViewModel GetCompanyByCompanyId()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if(HttpContext.Current.Session["companyid"] != null)
            {
                var es = new EmployeeService();
                return es.GetCompanyByCompanyId(int.Parse(HttpContext.Current.Session["companyid"].ToString()));
            }

            return null;
        }
    }
}