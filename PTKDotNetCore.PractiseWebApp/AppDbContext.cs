using Microsoft.EntityFrameworkCore;
using PTKDotNetCore.PractiseWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTKDotNetCore.PractiseWebApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".\\MSSQLSERVER1",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "phyo@123",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);

        }
      public DbSet<ProductModels> Products { get; set; }
    }
}
