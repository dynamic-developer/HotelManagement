using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Workbyclock
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });



            Bundle cs = new Bundle("~/bundles/cssv1", new CssMinify());
            cs.Include("~/datas/bootstrap/css/bootstrap.css",
                       "~/css/animate.css",
                       "~/css/magnific-popup.css",
                       "~/css/font-awesome.min.css",
                       "~/css/hover-min.css",
                       "~/plugins/payonline-icon/style.css",
                       "~/plugins/bands-icon/style.css",
                       "~/css/owl.carousel.css",
                       "~/css/owl.theme.default.min.css",
                       "~/css/bootstrap-select.min.css",
                       "~/css/jquery.bxslider.min.css",
                       "~/css/style.css",
                       "~/css/responsive.css");
            bundles.Add(cs);

            bundles.Add(new ScriptBundle("~/bundles/jsv1").Include(

                "~/js/jquery.js",
                "~/js/bootstrap.bundle.min.js",
                "~/js/jquery.magnific-popup.min.js",
                "~/js/owl.carousel.min.js",
                "~/js/bootstrap-select.min.js",
                "~/js/isotope.js",
                "~/js/jquery.bxslider.min.js",
                "~/js/theme.js"));

            BundleTable.EnableOptimizations = true;

        }
    }
}