using PTKDotNetCore.PractiseExamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTKDotNetCore.PractiseExamples.EFCoreExample
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<ProductModels> lst = db.Products.ToList();
            foreach (ProductModels item in lst)
            {
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductCategory);
                Console.WriteLine(item.ProductPrice);
            }
        }
        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Products.FirstOrDefault(item => item.ProductId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.ProductId);
            Console.WriteLine(item.ProductName);
            Console.WriteLine(item.ProductCategory);
            Console.WriteLine(item.ProductPrice);
        }
        public void Create(string name, string category, int price)
        {
            ProductModels products = new ProductModels()
            {
                ProductName = name,
                ProductCategory = category,
                ProductPrice = price
            };
            AppDbContext db = new AppDbContext();
            db.Products.Add(products);
            int result=db.SaveChanges();
            string message = result > 0 ? "Saving Successful!" : "Saving Failed!";
            Console.WriteLine(message);
        }
        public void Update (int id, string name, string category, int price)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Products.FirstOrDefault(item => item.ProductId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            item.ProductName= name;
            item.ProductCategory= category;
            item.ProductPrice= price;
            int result=db.SaveChanges();
            string message = result > 0 ? "Updating Successful!" : "Updating Failed! ";
            Console.WriteLine(message); 
        }
        public void Delete (int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Products.FirstOrDefault(item => item.ProductId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Products.Remove(item);
            int result=db.SaveChanges();
            string message = result > 0 ? "Deleting Successful!" : "Deleting Failed!";
            Console.WriteLine(message);
        }
    }
}
