using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class BookingPaymentViewModel
    {
        public int BookingPaymentId { get; set; }
        public int BookingId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentAcceptedBy { get; set; }
        public string PaymentTypeName { get; set; }

        public string GuestName { get; set; }
        public string RoomName { get; set; }
        public string GuestPhone { get; set; }

        public int BookingTypeId { get; set; }
        public decimal? RoomPrice { get; set; }

    }
}
