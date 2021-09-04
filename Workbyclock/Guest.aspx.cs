using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workbyclocklib.Models;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;


namespace Workbyclock
{
    public partial class Guest : System.Web.UI.Page
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
        public static GuestViewModel GetGuestByGuestId(int GuestId)
        {
            var es = new GuestService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetGuestByGuestId(GuestId);
        }

        [WebMethod]
        public static int SaveGuest(int GuestId,
            string GuestFullName,
            string GuestPhone,
            string GuestEmail,
            bool IsDNR,
            string GuestAddress,
            string GuestDriverLicenseId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            int companyId = 0;
            if (HttpContext.Current.Session["companyid"] != null)
            {
                companyId = int.Parse(HttpContext.Current.Session["companyid"].ToString());
            }
            var es = new GuestService();
            var model = new GuestViewModel();
            model.GuestId = GuestId;
            model.GuestFullName = GuestFullName;
            model.GuestPhone = GuestPhone;
            model.GuestEmail = GuestEmail;
            model.IsDNR = IsDNR;
            model.GuestAddress = GuestAddress;
            model.GuestDriverLicenseId = GuestDriverLicenseId;
            model.CompanyId = companyId;
            return es.SaveGuest(model);
        }
       
        [WebMethod]
        public static int DeleteGuest(int guestId)
        {
            var es = new GuestService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            return es.DeleteGuest(guestId);
        }

        [WebMethod]
        public static List<CompanyViewModel> GetAllCompanies()
        {
            var es = new EmployeeService();
            return es.GetAllCompanies();
        }
    }
}