using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class RoomBookingViewModel
    {
        public int RoomBookingId { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public decimal Price { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public int BookingTypeId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CompanyId { get; set; }
        public int LocationId { get; set; }

        public string RoomName { get; set; }
        public string GuestName { get; set; }
        public string BookingTypeName { get; set; }
        public string CompanyName { get; set; }
        public string LocationName { get; set; }
        public string GuestPhone { get; set; }
        public Nullable<int> RoomBookingStatusId { get; set; }
        public string RoomBookingStatusName { get; set; }

        public int? BookingPaymentId { get; set; }
        public decimal? PaymentAmount { get; set; }
    }
}
