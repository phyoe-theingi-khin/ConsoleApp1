using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTKDotNetCore.MVCApp2.Models;
using System.Text;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using System.Reflection;
using PTKDotNetCore.MVCApp2;

namespace PTKDotNetCore.MvcApp.Controllers;

public class BlogController : Controller
{
    private readonly IBlogApi _blogApi;
    public BlogController(IBlogApi blogApi)
    {
        _blogApi = blogApi;
    }

    [ActionName("Index")]
    public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
    {
       
        var model = await _blogApi.GetBlog(pageNo, pageSize);
        return View("BlogIndex", model);

    }
    [ActionName("Create")]
    public IActionResult BlogCreate()
    {
        return View("BlogCreate");
    }

    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult> BlogSave(BlogModel blog)
    {
        var model = await _blogApi.CreateBlog(blog);
        return Redirect("/Blog");
    }
    [ActionName("Edit")]
    public async Task<IActionResult> BlogEdit(int id)
    {
        var model=await _blogApi.GetBlog(id);
        return View("BlogEdit", model);
    }

    //[HttpPut("{id}")]
    [ActionName("Update")]
    public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
    {
       var model= await _blogApi.UpdateBlog(id, blog);
        return Redirect("/Blog");

    }

    [ActionName("Delete")]
    public async Task<IActionResult> BlogDelete(int id)
    {
       var model=await _blogApi.Deleteblog(id);
        return Redirect("/Blog");
    }
}

