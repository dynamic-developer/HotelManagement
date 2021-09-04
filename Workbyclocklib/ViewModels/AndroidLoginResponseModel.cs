using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class AndroidLoginResponseModel
    {
        public EmployeeViewModel EmployeeViewModel { get; set; }
        public List<EmployeeTimeCardViewModel> TimeCards { get; set; }
    }
}
