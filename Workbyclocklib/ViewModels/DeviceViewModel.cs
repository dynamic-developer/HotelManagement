using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class DeviceViewModel
    {
        public int DeviceId { get; set; }
        public int LocationId { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceDescription { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        public bool IsUsed { get; set; }


    }
}
