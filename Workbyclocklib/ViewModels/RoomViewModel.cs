using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomDesc { get; set; }
        public int RoomBeds { get; set; }
        public int RoomStatusId { get; set; }
        public int CompanyId { get; set; }
        public int Locationid { get; set; }
        public Nullable<decimal> RoomPrice { get; set; }
        public string RoomStatusName { get; set; }
        public string CompanyName { get; set; }
        public string LocationName { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? Todate { get; set; }

        public int? RoomBookingStatusId { get; set; }

    }
}
