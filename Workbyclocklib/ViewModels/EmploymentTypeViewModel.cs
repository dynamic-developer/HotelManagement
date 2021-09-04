using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class EmploymentTypeViewModel
    {
        public int EmploymentTypeId { get; set; }
        public string EmploymentTypeName { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}
