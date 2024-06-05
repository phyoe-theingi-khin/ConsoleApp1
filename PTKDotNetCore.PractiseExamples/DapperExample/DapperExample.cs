using Dapper;
using PTKDotNetCore.PractiseExamples.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTKDotNetCore.PractiseExamples.DapperExample
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".\\MSSQLSERVER1",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "phyo@123",
            TrustServerCertificate = true
        };
        public void Read()
        {

            string query = @"Select [ProductId]
                            ,[ProductName]
                            ,[ProductCategory]
                            ,[ProductPrice] 
                            From [dbo].[Tbl_Product]";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<ProductModels> lst = db.Query<ProductModels>(query).ToList();
            foreach (ProductModels model in lst)
            {
                Console.WriteLine(model.ProductId);
                Console.WriteLine(model.ProductName);
                Console.WriteLine(model.ProductCategory);
                Console.WriteLine(model.ProductPrice);
            }
        }
        public void Edit(int id)
        {
            string query = @"Select [ProductId]
                            ,[ProductName]
                            ,[ProductCategory]
                            ,[ProductPrice] 
                            From [dbo].[Tbl_Product] 
                            Where ProductId=@ProductId";
            ProductModels products = new ProductModels()
            {
                ProductId = id,
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<ProductModels>(query, products).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine(item.ProductId);
            Console.WriteLine(item.ProductName);
            Console.WriteLine(item.ProductCategory);
            Console.WriteLine(item.ProductPrice);

        }
        public void Create(string name, string category, int price)
        {
            string query = @"Insert Into [dbo].Tbl_Product 
                            ([ProductName],[ProductCategory],[ProductPrice]) 
                            Values(@ProductName,@ProductCategory,@ProductPrice)";
            ProductModels products = new ProductModels()
            {
                ProductName = name,
                ProductCategory = category,
                ProductPrice = price
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, products);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }
        public void Update(int id, string name, string category, int price)
        {
            string query = @"Update [dbo].Tbl_Product 
                            Set 
                                [ProductName]=@ProductName,
                                [ProductCategory]=@ProductCategory,
                                [ProductPrice]=@ProductPrice
                            Where ProductId=@ProductId";
            ProductModels products = new ProductModels()
            {
                ProductId = id,
                ProductName = name,
                ProductCategory = category,
                ProductPrice = price
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, products);
            string message = result > 0 ? "Update Successful" : "Update Failed";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            string query = @"Delete 
                            From [dbo].[Tbl_Product] 
                            Where ProductId=@ProductId";
            ProductModels products = new ProductModels()
            {
                ProductId = id,
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, products);
            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            Console.WriteLine(message);
        }

    }
}
