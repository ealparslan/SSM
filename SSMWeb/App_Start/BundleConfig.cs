﻿using System.Web;
using System.Web.Optimization;

namespace SSMWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js"));


            bundles.Add(new ScriptBundle("~/Scripts/datatables").Include(
                "~/Scripts/jquery.dataTables.js",
                "~/Scripts/dataTables.bootstrap.js",
                "~/Scripts/dataTables.colReorder.js",
                "~/Scripts/dataTables.colVis.js"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
              "~/Content/jquery.dataTables.css", 
              "~/Content/dataTables.colVis.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/spacelab.css",
                      //"~/Content/jquery-ui.css",
                      "~/Content/site.css",
                      "~/Content/select2.css",
                      "~/Content/select2-bootstrap.css"
                      ));
        }
    }
}
