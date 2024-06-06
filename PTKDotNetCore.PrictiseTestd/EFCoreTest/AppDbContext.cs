using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTKDotNetCore.PrictiseTest.Models;

namespace PTKDotNetCore.PrictiseTest.EFCoreTest
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder OptionBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".\\MSSQLSERVER1",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "phyo@123",
                TrustServerCertificate = true
            };
            OptionBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<ProductModel> Products { get; set; }
    }
    
}
