using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using PTKDotNetCore.WebApp.Models;
using Newtonsoft.Json;

namespace PTKDotNetCore.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
	private readonly ILogger _logger;
	private readonly AppDbContext _db;
	public BlogController(ILogger<BlogController> logger)
	{
		_db = new AppDbContext();
		_logger = logger;
	}


	[HttpGet]
	public IActionResult GetBlogs()
	{
		List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
		_logger.LogInformation("Count is " + lst.Count.ToString());
		_logger.LogInformation(JsonConvert.SerializeObject(lst, Formatting.Indented));
		return Ok(lst);
	}

	[HttpGet("{pageNo}/{pageSize}")]
	//[HttpGet("pageNo/{pageNo}/pageSize/{pageSize}")]

	public IActionResult GetBlogs(int pageNo, int pageSize)
	{
		int rowCount = _db.Blogs.Count();
		int pageCount = rowCount / pageSize;
		if (rowCount % pageSize > 0)
			pageCount++;
		if (pageNo > pageCount)
		{
			return BadRequest(new { Message = "Invalid pageNo!" });
		}
			 
		List<BlogModel> lst = _db.Blogs
			.OrderByDescending(x => x.BlogId)
			.Skip((pageNo - 1) * pageSize)
			.Take(pageSize)
			.ToList();
		
		BlogResponseModel model = new();
		model.Data = lst;
		model.pageSize = pageSize;
		model.pageNo = pageNo;
		model.pageCount = pageCount;
		//model.isEndOfPage = pageNo == pageCount;
		return Ok(model);
	}

	[HttpGet("{id}")]
	public IActionResult GetBlog(int id)
	{
		BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
		if (item is null)
		{
			return NotFound("No data found.");
		}

		return Ok(item);
	}

	[HttpPost]
	public IActionResult CreateBlogs(BlogModel blog)
	{
		_db.Blogs.Add(blog);
		int result = _db.SaveChanges();
		string message = result > 0 ? "saving successful." : "saving failed.";
		return Ok(message);
	}

	[HttpPut("{id}")]
	public IActionResult UpdateBlogs(int id, BlogModel blog)
	{
		//var item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
		BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
		if (item is null)
		{
			return NotFound("No data found.");
		}

		item.BlogTitle = blog.BlogTitle;
		item.BlogAuthor = blog.BlogAuthor;
		item.BlogContent = blog.BlogContent;
		//_db.Update(item);
		int result = _db.SaveChanges();

		string message = result > 0 ? "Updating Successful." : "Updating Failed.";
		return Ok(message);
	}

	[HttpDelete("{id}")]
	public IActionResult DeleteBlogs(int id)
	{
		BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
		if (item is null)
		{
			return NotFound("No data found.");
		}

		_db.Blogs.Remove(item);
		int result = _db.SaveChanges();

		string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
		return Ok(message);
	}
}