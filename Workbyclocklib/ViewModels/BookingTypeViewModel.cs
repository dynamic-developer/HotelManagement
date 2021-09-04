using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class BookingTypeViewModel
    {
        public int BookingTypeId { get; set; }
        public string BookingTypeName { get; set; }
        public string BookingTypeDesc { get; set; }
        public bool IsTaxable { get; set; }
        public Nullable<int> TaxInfoId { get; set; }
        public int CompanyId { get; set; }
        public int LocationId { get; set; }
    }
}
