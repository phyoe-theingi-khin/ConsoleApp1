using Microsoft.AspNetCore.Mvc;

namespace PTKDotNetCore.MvcApp.Controllers
{
    public class CanvasChart : Controller
    {
        public IActionResult BarChart()
        {
            return View();
        }
    }
}
