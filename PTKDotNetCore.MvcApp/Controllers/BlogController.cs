using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;

namespace PTKDotNetCore.MvcApp.Controllers;

//https://localhost:7047/Blog/Index
public class BlogController : Controller
{
    private readonly AppDbContext _db;
    public BlogController(AppDbContext db)
    {
        _db = db;
    }
    [ActionName("Index")]
    [HttpGet]
    public IActionResult BlogIndex()
    {
        List<BlogModel> lst = _db.Blogs.ToList();
        return View("BlogIndex",lst);
    }
    [ActionName ("Edit")]
    public IActionResult BlogEdit(int id)
    {
        BlogModel? item= _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if(item is null) 
        {
            return Redirect("/Blog");
        }
        return View("BlogEdit",item);
    }
    [ActionName ("Create")]
    //string title,string author,string content
    public IActionResult BlogCreate()
    {
        return View("BlogCreate");

    }
    [HttpPost]
    [ActionName ("Save")]
    public IActionResult BlogSave(BlogModel blog)
    {
        _db.Blogs.Add(blog);
        _db.SaveChanges();
        return Redirect("/Blog");
    }
    [HttpPost]
    [ActionName("Update")]
    public IActionResult BlogUpdate(int id,BlogModel blog)
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }
        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor= blog.BlogAuthor;   
        item.BlogContent= blog.BlogContent;
        _db.SaveChanges();
        return Redirect("/Blog");
    }
    [ActionName("Delete")]
    public IActionResult BlogDelete(int id)
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }
        _db.Blogs.Remove(item);
        _db.SaveChanges();
        return Redirect("/Blog");
    }
}