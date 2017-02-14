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
                      "~/Content/site7.css",
                      "~/Content/CSS/style_home5.css",
                      "~/Content/CSS/style_about_yourself3.css",
                      "~/Content/CSS/style_projects4.css",
                      "~/Content/CSS/style_paginator.css",                      
                      "~/Content/CSS/animate.min.css",
                      "~/Content/CSS/turn.css",
                      "~/Content/CSS/style_admin.css",
                      "~/Content/CSS/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/d3js").Include(
                      "~/Scripts/d3/d3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/turnjs").Include(
                      "~/Scripts/turnjs4/lib/turn.js",
                      "~/Scripts/turnjs4/myTurnTune.js"));

            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                      "~/Scripts/Home/deleteMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/menuActive").Include(
                      "~/Scripts/Home/menuActive1.js"));

            bundles.Add(new ScriptBundle("~/bundles/feedbackscripts").Include(
                      "~/Scripts/Feedback/GetSendResult1.js", 
                      "~/Scripts/Feedback/BackButton.js"));
            

            bundles.Add(new ScriptBundle("~/bundles/animate").Include(
                      "~/Scripts/Home/magicAnimation.js",
                      "~/Scripts/Home/animateChar1.js",
                      "~/Scripts/Home/slide.js",
                      "~/Scripts/Home/appearText5.js"));

            bundles.Add(new ScriptBundle("~/bundles/pageEnlarge").Include(
                      "~/Scripts/Projects/pageEnlarge.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminSection").Include(
                      "~/Scripts/Admin/AddUrl.js",
                      "~/Scripts/Admin/CreateNewObj.js",
                      "~/Scripts/Admin/SubmitOnSelect1.js",
                      "~/Scripts/Admin/SubmitOnSelect1.js",
                      "~/Scripts/Admin/menuActiveAdmin.js"));

            bundles.Add(new ScriptBundle("~/bundles/backButton").Include(
                      "~/Scripts/Feedback/BackButton.js"));
        }
    }
}
