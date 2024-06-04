using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTKDotNetCore.MVCAppPrictise.Models;

namespace PTKDotNetCore.MVCAppPrictise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : Controller
{
    private readonly HttpClient _httpClient;

    public BlogController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [ActionName("Index")]
    public  async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
    {
        BlogResponseModel model = new BlogResponseModel();
        var response = await _httpClient.GetAsync($"api/blog/{pageNo}/{pageSize}");
        if (response.IsSuccessStatusCode)
        {
            var jsonStr= await response.Content.ReadAsStringAsync();
            model= JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr)!;
        }
        return View("BlogIndex", model);
    }
    [HttpGet]
    [ActionName("Edit")]
    public void BlogEdit()
    {

    }

}