using System.Web.Mvc;

namespace BookArt1.Areas.Visitor
{
    public class VisitorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Visitor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Visitor_default",
                "{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                new[] { "BookArt1.Areas.Visitor.Controllers" }
            );

            context.MapRoute(
                "Visitor_default_site",
                "site/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                new[] { "BookArt1.Areas.Visitor.Controllers" }
            );
        }
    }
}