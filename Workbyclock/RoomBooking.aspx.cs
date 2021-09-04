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
    public partial class RoomBooking : System.Web.UI.Page
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
        public static List<RoomBookingViewModel> GetAllRoomBooking()
        {
            var es = new RoomBookingService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetAllRoomBooking();
        }
       

        [WebMethod]
        public static RoomBookingViewModel GetRoomBookingByRoomBookingId(int RoomBookingId)
        {
            var es = new RoomBookingService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetRoomBookingByRoomBookingId(RoomBookingId);
        }

        [WebMethod]
        public static int SaveRoomBooking(int RoomBookingId,
            int RoomId,
            int GuestId,
            decimal Price,
            DateTime? FromDate,
            DateTime? ToDate,
             int BookingTypeId,
            DateTime BookingDate,
            int CompanyId,
            int LocationId,
            int RoomBookingStatusId)
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

            var es = new RoomBookingService();
            var model = new RoomBookingViewModel();
            model.RoomBookingId = RoomBookingId;
            model.RoomId = RoomId;
            model.GuestId = GuestId;
            model.Price = Price;
            model.FromDate = FromDate;
            model.ToDate = ToDate;
            model.BookingTypeId = BookingTypeId;
            model.BookingDate = DateTime.UtcNow;
            model.CreateDate = DateTime.UtcNow;
            model.CompanyId = companyId;
            model.LocationId = LocationId;
            model.RoomBookingStatusId = RoomBookingStatusId;
            return es.SaveRoomBooking(model);
        }

        [WebMethod]
        public static int DeleteRoomBooking(int RoomBookingId)
        {
            var es = new RoomBookingService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            return es.DeleteRoomBooking(RoomBookingId);
        }

        [WebMethod]
        public static List<BookingTypeViewModel> GetAllBookingType()
        {
            var es = new RoomBookingService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetAllBookingType();
        }

        [WebMethod]
        public static List<RoomBookingStatusMasterViewModel> GetAllRoomBookingStatusMaster()
        {
            var es = new RoomBookingService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetAllRoomBookingStatusMaster();
        }

        [WebMethod]
        public static List<RoomViewModel> CheckRoomAvailability(DateTime FromDate, DateTime ToDate)
        {
            var es = new RoomBookingService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.CheckRoomAvailability(FromDate, ToDate);
        }


    }
}