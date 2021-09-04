using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace Workbyclock
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("/Account/Login");
        }

        [WebMethod]
        public static void LogOut()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.User = null;
            System.Web.Security.FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("/Account/Login");
        }
    }
}