using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
   public class GuestViewModel
    {
        public int GuestId { get; set; }
        public string GuestFullName { get; set; }
        public string GuestPhone { get; set; }
        public string GuestEmail { get; set; }
        public bool IsDNR { get; set; }
        public string GuestAddress { get; set; }
        public string GuestDriverLicenseId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
