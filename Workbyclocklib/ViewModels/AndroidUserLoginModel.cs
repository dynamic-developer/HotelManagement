using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class AndroidUserLoginModel
    {
        public int UserId { get; set; }
        public int UserPin { get; set; }
        public string UserPhone { get; set; }
        public string startDateString { get;set;}
        public string endDateString { get; set; }
    }
}
