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
    public partial class BookingPayment : System.Web.UI.Page
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
        public static List<BookingPaymentViewModel> GetAllBookingPayments(int bookingId=0)
        {
            var es = new BookingPaymentService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if (bookingId == 0)
            {
                return es.GetAllBookingPayments();
            }
            else
            {
                return es.GetAllBookingPayments().Where(x=>x.BookingId == bookingId).ToList();
            }
            
        }
        [WebMethod]
        public static BookingPaymentViewModel GetBookingPaymentsById(int bookingPaymentId)
        {
            var es = new BookingPaymentService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetBookingPaymentsById(bookingPaymentId);
        }

        [WebMethod]
        public static int SaveBookingPayments(int BookingPaymentId,
            int BookingId,
            int PaymentTypeId,
            decimal PaymentAmount,
            string PaymentAcceptedBy)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            var es = new BookingPaymentService();
            var model = new BookingPaymentViewModel();
            model.BookingPaymentId = BookingPaymentId;
            model.BookingId = BookingId;
            model.PaymentTypeId = PaymentTypeId;
            model.PaymentAmount = PaymentAmount;
            model.PaymentDate = DateTime.UtcNow;
            model.PaymentAcceptedBy = PaymentAcceptedBy;
            return es.SaveBookingPayments(model);
        }

        [WebMethod]
        public static int DeleteBookingPayment(int BookingPaymentId)
        {
            var es = new BookingPaymentService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            return es.DeleteBookingPayment(BookingPaymentId);
        }

        [WebMethod]
        public static List<PaymentTypesViewModel> GetAllPaymentTypes()
        {
            var es = new BookingPaymentService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetAllPaymentTypes();
        }

    }
}