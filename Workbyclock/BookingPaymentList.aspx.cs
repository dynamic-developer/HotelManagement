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
    public partial class BookingPaymentList : System.Web.UI.Page
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
        public static List<BookingPaymentViewModel> GetAllBookingPaymentByFilter(string FromDate, string ToDate)
        {
            var es = new BookingPaymentService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            if (!string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
            {
                startDate = DateTime.Parse(FromDate);
                endDate = DateTime.Parse(ToDate);
            }
            else if (string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
            {

                endDate = DateTime.Parse(ToDate);
                startDate = endDate.AddDays(-14);
            }
            else if (!string.IsNullOrEmpty(FromDate) && string.IsNullOrEmpty(ToDate))
            {
                startDate = DateTime.Parse(FromDate);
                endDate = startDate.AddDays(14);
            }
            return es.GetAllBookingPayments().Where(x => x.PaymentDate > startDate && x.PaymentDate < endDate && (x.PaymentDate == null || x.PaymentDate < endDate)).ToList();
        }
    }
}