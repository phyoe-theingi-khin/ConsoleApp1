using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTKDotNetCore.PractiseWebApp.Models;
using System.Linq;


namespace PTKDotNetCore.PractiseWebApp.Controllers
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult ReadProduct()
        {
            List <ProductModels> lst= _db.Products.OrderByDescending(x => x.ProductId).ToList();

            return Ok(lst);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModels model)
        {
            _db.Products.Add(model);
            int result= _db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : " Saving Failed";
            return Ok(message);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductModels model)
        {
            ProductModels? item = _db.Products.FirstOrDefault(item => item.ProductId == id);
            if(item is null)
            {
                return NotFound("No data found!");
            }
            item.ProductId = model.ProductId ;
            item.ProductName = model.ProductName ;
            item.ProductPrice = model.ProductPrice ;
            int result = _db.SaveChanges();
            string message = result > 0 ? " Updating successful!" : " Updating Failed!";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id, ProductModels model)
        {
            ProductModels? item = _db.Products.FirstOrDefault(item => item.ProductId == id);
            if (item is null)
            {
                return NotFound("No data found!");
            }
            _db.Products.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? " Deleting successful!" : " Deleting Failed!";
            return Ok(message);
        }


    }
}
