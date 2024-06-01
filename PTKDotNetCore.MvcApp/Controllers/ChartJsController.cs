using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;

namespace PTKDotNetCore.MvcApp.Controllers
{
    public class ChartJsController : Controller
    {
        private readonly AppDbContext _db;
        public ChartJsController(AppDbContext db)
        {
        _db = db;   
        }

        public IActionResult BarChart()
        {
            
            var lst = _db.BarChart.ToList();
            ChartJsBarChartResponseModel model = new ChartJsBarChartResponseModel();
            model.Color = lst.Select(x => x.Color).ToList();
            model.Votes = lst.Select(x => x.Votes).ToList();

            return View(model);
        }
       
    }
}
