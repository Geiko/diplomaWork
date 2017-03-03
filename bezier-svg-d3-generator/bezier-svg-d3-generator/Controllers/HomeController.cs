using System.Web;
using System.Web.Mvc;

namespace bezier_svg_d3_generator.Controllers
{
    public class HomeController : Controller
    {
        private const string VISIT_COUNTER_URL = @"~/Content/Counters/visitCounter.txt";


        // GET: Home
        public ActionResult Index()
        {
            try
            {
                string textVisitCounter = System.IO.File.ReadAllText(Server.MapPath(VISIT_COUNTER_URL));
                int visitCounter = int.Parse(textVisitCounter);
                visitCounter++;
                System.IO.File.WriteAllText(Server.MapPath(VISIT_COUNTER_URL), visitCounter.ToString());
            }
            catch (System.Exception)
            {
            }

            return View();
        }        
    }
}
