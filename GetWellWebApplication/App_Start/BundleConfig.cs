using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GetWellWebApplication.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/index scripts.js",
                        "~/Scripts/Index script.js",
                        "~/Scripts/from1 scripts.js",
                        "~/Scripts/fontawesome-free-5.15.2-web/js/all.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                        "~/Scripts/calendar script.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/materializer").Include(
                      "~/Scripts/materialize.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Style.css",
                      "~/Content/fontawesome-free-5.15.2-web/css/all.css",
                      "~/Content/Poppins/Poppins-ExtraLight.ttf"));

            bundles.Add(new StyleBundle("~/Accueil/css").Include(
                      "~/Content/Stylehome.css"
                ));

            bundles.Add(new StyleBundle("~/Information_doc/css").Include(
                      "~/Content/style-info-doc.css"
                ));

            bundles.Add(new StyleBundle("~/Content/materializer").Include(
               "~/Content/materialize.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                "~/Scripts/jquery-ui.min.js",
                "~/Scripts/jquery-ui.js"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                "~/Content/jquery-ui.min.css"));
        }
    }
}