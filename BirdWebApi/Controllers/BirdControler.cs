using BirdWebApi.BirdsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace BirdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdControler : ControllerBase
    {
        private readonly string _url="https://burma-project-ideas.vercel.app/birds";

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string jsonstr = await response.Content.ReadAsStringAsync();
                List<BirdDataModel> birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(jsonstr);
                // return Ok(jsonstr);
                //List<BirdViewModel> lst = birds.Select(bird => new BirdViewModel
                //{
                //    BirdName = bird.BirdMyanmarName,
                //    BirdId = bird.Id,
                //    Desp = bird.Description,
                //    PhotoUrl = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}"

                //}).ToList();
                // List<BirdViewModel> lst = birds.Select(bird =>Change(bird)).ToList();
                List<BirdViewModel> lst = new List<BirdViewModel>();
                foreach (var bird in birds)
                {
                    BirdViewModel item = Change(bird);
                    lst.Add(item);
                }
                return Ok(lst);
            }
            else
            {
                return BadRequest();

            }
     
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HttpClient client = new HttpClient();
            var response= await client.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonstr = await response.Content.ReadAsStringAsync();
            BirdDataModel bird = JsonConvert.DeserializeObject<BirdDataModel>(jsonstr);
                // return Ok(jsonstr);
                //var item = new BirdViewModel
                //{
                //    BirdName = bird.BirdMyanmarName,
                //    BirdId = bird.Id,
                //    Desp = bird.Description,
                //    PhotoUrl = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}"
                //};
                var item = Change(bird);
                return Ok(item);
            }
            else
            {
                return BadRequest();

            }
        }
        private BirdViewModel Change(BirdDataModel bird)
        {
            var item = new BirdViewModel
            {
                BirdName = bird.BirdMyanmarName,
                BirdId = bird.Id,
                Desp = bird.Description,
                PhotoUrl = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}"
            };
            return item;

        }
    }
}
