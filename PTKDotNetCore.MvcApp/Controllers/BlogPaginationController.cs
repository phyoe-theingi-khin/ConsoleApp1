using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;

namespace PTKDotNetCore.MvcApp.Controllers
{
	public class BlogPaginationController : Controller
	{
		private readonly AppDbContext _db;
		public BlogPaginationController(AppDbContext db)
		{
			_db = db;
		}
		[ActionName("Index")]
		public IActionResult BlogIndex(int pageNo=1, int pageSize=10)
		{
		
			
			int rowCount = _db.Blogs.Count();
			int pageCount = rowCount / pageSize;
			if (rowCount % pageSize > 0)
				pageCount++;
			if (pageNo > pageCount)
			{
				return View();
			}

			List<BlogModel> lst = _db.Blogs
				//.OrderByDescending(x => x.BlogId)
				.Skip((pageNo - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			BlogResponseModel model = new();
			model.Data = lst;
			model.pageSize = pageSize;
			model.pageNo = pageNo;
			model.pageCount = pageCount;
            //model.isEndOfPage = pageNo == pageCount;
            return View("BlogIndex", model);
		}
	}
}
