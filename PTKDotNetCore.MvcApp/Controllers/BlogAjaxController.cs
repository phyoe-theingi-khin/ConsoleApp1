using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;
using System.Reflection.Metadata;

namespace PTKDotNetCore.MvcApp.Controllers;

//https://localhost:7047/Blog/Index
public class BlogAjaxController : Controller
{
    private readonly AppDbContext _db;
    public BlogAjaxController(AppDbContext context)
    {
        _db = context;
    }


    [ActionName("Index")]
    public IActionResult BlogIndex()
    {
        List<BlogModel> lst = _db.Blogs.ToList();
        return View("BlogIndex", lst);
    }

    [ActionName("Edit")]
    public IActionResult BlogEdit(int id)
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }

        // return View("Blog", item);
        return View("BlogEdit", item);
    }

    [ActionName("Create")]
    //string title,string author,string content
    public IActionResult BlogCreate()
    {
        return View("BlogCreate");
    }

    [HttpPost]
    [ActionName("Save")]
    public IActionResult BlogSave(BlogModel blog)
    {
        _db.Blogs.Add(blog);
        int result = _db.SaveChanges();
        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        BlogMessageResponseModel model = new BlogMessageResponseModel()
        {
            IsSuccess = result > 0,
            Message = message
        };
        //return Redirect("/Blog");
        return Json(model);
    }

    [HttpPost]
    [ActionName("Update")]
    public IActionResult BlogUpdate(int id, BlogModel blog)
    {
        BlogMessageResponseModel model = new BlogMessageResponseModel();
        var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            //model.IsSuccess = false;
            //model.Message = "No data found.";
            model = new BlogMessageResponseModel()
            {
                IsSuccess = false,
                Message = "No data found."
            };
            return Json(model);
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        int result = _db.SaveChanges();
        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        model = new BlogMessageResponseModel()
        {
            IsSuccess = result > 0,
            Message = message
        };
        return Json(model);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult BlogDelete(BlogModel blog)
    {
        BlogMessageResponseModel model = new BlogMessageResponseModel();
        var item = _db.Blogs.FirstOrDefault(x => x.BlogId == blog.BlogId);
        if (item is null)
        {
            model = new BlogMessageResponseModel()
            {
                IsSuccess = false,
                Message = "No data found."
            };
            return Json(model);
        }

        _db.Blogs.Remove(item);
        int result = _db.SaveChanges();
        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        model = new BlogMessageResponseModel()
        {
            IsSuccess = result > 0,
            Message = message
        };
        return Json(model);
    }
}
