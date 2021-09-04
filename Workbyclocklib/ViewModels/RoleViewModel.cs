using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleDescription { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}
