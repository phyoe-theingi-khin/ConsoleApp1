//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using PTKDotNetCore.MVCApp2.Models;
//using System.Text;
//using System.Diagnostics.Eventing.Reader;
//using System.Text.Json.Serialization;
//using static System.Net.Mime.MediaTypeNames;
//using System.Net.Http;
//using System.Reflection;

//namespace PTKDotNetCore.MvcApp.Controllers;

//public class BlogController : Controller
//{
//    private readonly HttpClient _httpClient;
//    public BlogController(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//    }
//    [ActionName("Index")]
//    public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
//    {
//        BlogResponseModel model = new BlogResponseModel();
//        var response = await _httpClient.GetAsync($"api/blog/{pageNo}/{pageSize}");
//        if (response.IsSuccessStatusCode)
//        {
//            var jsonStr = await response.Content.ReadAsStringAsync();
//            model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr)!;

//        }
//        return View("BlogIndex", model);

//    }
//    [ActionName("Create")]
//    public IActionResult BlogCreate()
//    {
//        return View("BlogCreate");
//    }

//    [HttpPost]
//    [ActionName("Save")]
//    public async Task<IActionResult> BlogSave(BlogModel blog)
//    {
//        HttpContent content = new StringContent(content: JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
//        await _httpClient.PostAsync("api/blog", content);
//        return Redirect("/Blog");
//    }
//    [ActionName("Edit")]
//    public async Task<IActionResult> BlogEdit(int id)
//    {
//        var response = await _httpClient.GetAsync($"api/blog/{id}");
//        if (!response.IsSuccessStatusCode)
//        {
//            return Redirect("/Blog");
//        }
//        var jsonStr = await response.Content.ReadAsStringAsync();
//        BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
//        return View("BlogEdit", model);
//    }

//    //[HttpPut("{id}")]
//    [ActionName("Update")]
//    public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
//    {
//        HttpContent content = new StringContent(content: JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
//        var response = await _httpClient.PutAsync($"api/blog/{id}", content);
//        if (!response.IsSuccessStatusCode)
//        {
//            return Redirect("/Blog/");
//        }
//        return Redirect("/Blog");

//    }

//    [ActionName("Delete")]
//    public async Task<IActionResult> BlogDelete(int id)
//    {
//        await _httpClient.DeleteAsync($"api/blog/{id}");
//        return Redirect("/Blog");
//    }
//}

