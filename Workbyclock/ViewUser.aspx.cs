using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;

namespace Workbyclock
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("/Account/Login");
                }
            }
        }

        [WebMethod]
        public static UserViewModel GetUserInfo(string UserId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var es = new EmployeeService();
            return es.GetUserInfo(UserId);
        }
    }
}