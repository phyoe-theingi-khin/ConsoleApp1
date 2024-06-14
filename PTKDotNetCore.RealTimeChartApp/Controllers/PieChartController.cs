using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PTKDotNetCore.RealTimeChartApp.Hubs;
using System.Text.Json.Serialization;

namespace PTKDotNetCore.RealTimeChartApp.Controllers
{

    public class PieChartController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        public static List<PieChartModel> Data = new List<PieChartModel>();

        public PieChartController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(PieChartModel requestModel)
        {
            Data.Add(requestModel);
            PieChartResponseModel model = new PieChartResponseModel()
            {
                Label = Data.Select(x => x.Label).ToList(),
                Series = Data.Select(x => x.Series).ToList(),

            };
            string jsonStr = JsonConvert.SerializeObject(model);
            await _hubContext.Clients.All.SendAsync("ClientReceiveEvent", jsonStr);
            return View();
        }
        public IActionResult Watch()
        {
            return View();
        }

        public class PieChartModel
        {
            public string Label { get; set; }
            public int Series { get; set; }
        }
        public class PieChartResponseModel
        {
            public List<string> Label { get; set; }
            public List<int> Series { get; set; }
        }
    }

}
