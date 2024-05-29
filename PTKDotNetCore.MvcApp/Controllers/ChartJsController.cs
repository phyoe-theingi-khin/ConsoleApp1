using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;

namespace PTKDotNetCore.MvcApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult BarChart()
        {
            AppDbContext content = new AppDbContext();
            var lst = content.BarChart.ToList();
            ChartJsBarChartResponseModel model = new ChartJsBarChartResponseModel();
            model.Color = lst.Select(x => x.Color).ToList();
            model.Votes = lst.Select(x => x.Votes).ToList();

            return View(model);
        }
       
    }
}
