using Microsoft.AspNetCore.Mvc;

namespace PTKDotNetCore.MvcApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult BarChart()
        {
            return View();
        }
    }
}
