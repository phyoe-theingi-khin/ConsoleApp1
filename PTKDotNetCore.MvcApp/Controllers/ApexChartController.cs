using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;

namespace PTKDotNetCore.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        private readonly AppDbContext _db;
        public ApexChartController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult PieChart()
        {
            ApexChartPieChartResponseModel model = new ApexChartPieChartResponseModel()
            {
                Lables = new List<string> { "Team A", "Team B", "Team C", "Team D", "Team E" },
                Series = new List<int> { 44, 55, 13, 43, 22 }
            };
            return View(model);

        }
        public IActionResult DashedLineChart()
        {
            
            var lst=_db.PageStatistics.ToList();
            ApexChartDashedLineResponseModel model = new ApexChartDashedLineResponseModel();
            List<ApexChartDashedLineModel>lstSeries = new List<ApexChartDashedLineModel>();

            var lstSessionDuration = lst.Select(x => x.SessionDuration).ToList();
            var lstPageViews = lst.Select(x => x.PageViews).ToList();
            var lstTotalVisits = lst.Select(x => x.TotalVisits).ToList();
            var lstDate = lst.Select(x => x.CreatedDate).ToList();

            lstSeries.Add(new ApexChartDashedLineModel { name = "Session Duration", data = lstSessionDuration });
            lstSeries.Add(new ApexChartDashedLineModel { name = "Page Views", data = lstPageViews });
            lstSeries.Add(new ApexChartDashedLineModel { name = "Total Visits", data = lstTotalVisits });
            model.Series= lstSeries;
            model.Lables = lstDate;
            return View(model) ;
        }
        public IActionResult RadarChart()
        {
           
            var lst=_db.Radars.ToList();
            ApexChartRadarResponseModel model=new ApexChartRadarResponseModel();
            model.Series=lst.Select(x => x.Series).ToList();
            model.Month=lst.Select(x => x.Month).ToList();

            return View(model);
        }

       
    }
}
