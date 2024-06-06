using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTKDotNetCore.PrictiseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTKDotNetCore.PrictiseTest.EFCoreTest
{

    public class EFCoreTest
    {
        private readonly AppDbContext _db = new AppDbContext();
        public void Read()
        {
            List<ProductModel> lst = _db.Products.ToList();
            foreach (ProductModel item in lst)
            {
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductPrice);
                Console.WriteLine(item.ProductCategory);
            }
        }
        public void Edit(int id)
        {
            ProductModel item = _db.Products.FirstOrDefault(item => item.ProductId == id)!;
            if (item is null)
            {
                Console.WriteLine("No dadta found");
                return;
            }
            Console.WriteLine(item.ProductId);
            Console.WriteLine(item.ProductName);
            Console.WriteLine(item.ProductCategory);
            Console.WriteLine(item.ProductPrice);
        }
        public void Create(string name, string category, int price)
        {
            ProductModel model = new ProductModel()
            {
                ProductName = name,
                ProductCategory = category,
                ProductPrice = price
            };
            _db.Products.Add(model);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving successful" : " Saving Failed";
            Console.WriteLine(message);
        }
        public void Update(int id, string name, string category, int price)
        {
            ProductModel item = _db.Products.FirstOrDefault(item => item.ProductId == id)!;
            if (item is null)
            {
                Console.WriteLine("No dadta found");
                return;
            }
            item.ProductName = name;
            item.ProductCategory = category;
            item.ProductPrice = price;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating successful" : " Updating Failed";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            ProductModel item = _db.Products.FirstOrDefault(item => item.ProductId == id)!;
            if (item is null)
            {
                Console.WriteLine("No dadta found");
                return;
            }
            _db.Products.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting successful" : " Deleting Failed";
            Console.WriteLine(message);

        }
    }
}
