using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.MvcApp.Models;
using PTKDotNetCore.Shared;

namespace PTKDotNetCore.MvcApp.Controllers
{
    public class BlogDapperController : Controller
    {
        private readonly DapperService _dapperService;
        public BlogDapperController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public IActionResult Index()
        {
            var lst = _dapperService.Query<BlogModel>("select * from tbl_blog");
            return View(lst);
            
        }
    }
}
