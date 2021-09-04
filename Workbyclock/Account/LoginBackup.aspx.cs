using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workbyclock.Models;

namespace Workbyclock.Account
{
    public partial class LoginBackup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
            //ResendButton.Visible = false;
            // Enable this once you have account confirmation enabled for password reset functionality
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                // RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();


                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                //var result = signinManager.PasswordSignIn(Email.Text, Password.Text, false, shouldLockout: false);

                //switch (result)
                //{
                //    case SignInStatus.Success:
                //        IdentityHelper.RedirectToReturnUrl("~/Dashboard.aspx", Response);
                //        //Response.Redirect("/Dashboard.aspx");
                //        break;
                //    case SignInStatus.LockedOut:
                //        Response.Redirect("/Account/Lockout");
                //        break;
                //    case SignInStatus.RequiresVerification:
                //        //Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                //        //                                Request.QueryString["ReturnUrl"],
                //        //                                RememberMe.Checked),
                //        // true);
                //        break;
                //    case SignInStatus.Failure:
                //    default:
                //        FailureText.Text = "Invalid login attempt";
                //        ErrorMessage.Visible = true;
                //        break;
                //}
            }
        }

    }
}