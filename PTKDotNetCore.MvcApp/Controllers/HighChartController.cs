using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;

namespace PTKDotNetCore.MvcApp.Controllers
{
    public class HighChartController : Controller
    {
        private readonly AppDbContext _db;
        public HighChartController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult DonutChart()
        {
            return View();
        }
        public IActionResult DonutChartHomework()
        {

            var lst = _db.DonutChartHomework.ToList();
            DonutChartHomeworkResponseModel model = new DonutChartHomeworkResponseModel();
            model.Browsers = lst.Select(x => x.Browsers).Distinct().ToList();
            model.Versions = lst.Select(x => x.Versions).ToList();
            model.Usages = lst.Select(x => x.Usages).ToList();
            return View(model);
        }
    }
}
