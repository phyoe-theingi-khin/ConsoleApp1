using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PTKDotNetCore.RealTimeChartApp.Hubs;
using PTKDotNetCore.RealTimeChartApp.Models;
using System.Diagnostics;

namespace PTKDotNetCore.RealTimeChartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<NotificationHub>_hubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<NotificationHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> IndexAsync(DataRequestModel requestModel)
        {
            await _hubContext.Clients.All.SendAsync("ClientReceiveEvent", requestModel.Data);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public class DataRequestModel
        {
            public string Data { get; set;}
        }
    }
}
