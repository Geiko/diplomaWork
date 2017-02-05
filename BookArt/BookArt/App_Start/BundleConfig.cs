using System.Web;
using System.Web.Optimization;

namespace BookArt
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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
                      "~/Content/site3.css",
                      "~/Content/CSS/style_home5.css",
                      "~/Content/CSS/style_about_yourself3.css",
                      "~/Content/CSS/style_projects5.css",
                      "~/Content/CSS/style_paginator.css",                      
                      "~/Content/CSS/animate.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/d3js").Include(
                      "~/Scripts/d3/d3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                      "~/Scripts/Home/deleteMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/menuActive").Include(
                      "~/Scripts/Home/menuActive1.js"));

            bundles.Add(new ScriptBundle("~/bundles/feedbackscripts").Include(
                      "~/Scripts/Feedback/RecaptchaVerification1.js",
                      "~/Scripts/Feedback/GetSendResult.js", 
                      "~/Scripts/Feedback/BackButton.js"));
            

            bundles.Add(new ScriptBundle("~/bundles/animate").Include(
                      "~/Scripts/Home/magicAnimation.js",
                      "~/Scripts/Home/animateChar1.js",
                      "~/Scripts/Home/appearText4.js"));

            bundles.Add(new ScriptBundle("~/bundles/paginator").Include(
                      "~/Scripts/Projects/paginator.js"));
        }
    }
}
