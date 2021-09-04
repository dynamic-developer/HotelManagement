using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class DesktopEmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeePin { get; set; }

        public DateTime? EmployeeStart { get; set; }
        public string EmployeeStartString { get; set; }

        public DateTime? EmployeeEnd { get; set; }
        public string EmployeeEndString { get; set; }
        public string DeviceCode { get; set; }
        public int LocationId { get; set; }
        public string LocationIp { get; set; }
    }
}
