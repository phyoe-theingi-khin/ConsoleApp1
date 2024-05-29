using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;

namespace PTKDotNetCore.MvcApp.Controllers
{
    public class HighChartController : Controller
    {
        public IActionResult DonutChart()
        {
          
            return View();

        }
        public IActionResult DonutChartHomework() 
        {
            AppDbContext content = new AppDbContext();
            var lst = content.DonutChartHomework.ToList();
            DonutChartHomeworkResponseModel model = new DonutChartHomeworkResponseModel();
            model.Browsers = lst.Select(x => x.Browsers).ToList();
            model.Versions = lst.Select(x => x.Versions).ToList();
            model.Usages = lst.Select(x => x.Usages).ToList();
            return View(model);
        }
    }
}
