using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class EmployeeTimeCardViewModel
    {
        public int EmployeeTimeCardId { get; set; }
        public int EmployeeId { get; set; }
        public int LocationId { get; set; }
        public int? DeviceId { get; set; }
        public string LocationIp { get; set; }
        public Nullable<System.DateTime> TimeIn { get; set; }
        public string TimeInUIString { get; set; }
        public Nullable<System.DateTime> TimeOut { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string TimeOutUIString { get; set; }

        public Nullable<System.DateTime> TimeInUtc { get; set; }
        public Nullable<System.DateTime> TimeOutUtc { get; set; }
        public int? DeviceIdOut { get; set; }

        public string Reason { get; set; }
        public string TimeInSt => GetDateFormatted(this.TimeIn);
        public string TimeOutSt => GetDateFormatted(this.TimeOut);

        public string GetDateFormatted(DateTime? value)
        {
            if(value == null)
            {
                return "";
            }
            //value = value.Value.AddHours(2);
            return value.Value.ToString("MM/dd/yyyy h:mm tt");
        }
       

        public double Hours => GetHours(this.TimeInUtc, this.TimeOutUtc);

        public double GetHours(DateTime? ti, DateTime? to)
        {
            double result = 0;
            if (ti != null && to != null)
            {
                result = (to.Value - ti.Value).TotalHours;
            }
            return Math.Round(result, 2);
        }



    }
}
