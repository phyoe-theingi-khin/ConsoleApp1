using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTKDotNetCore.MvcApp.Models;

namespace PTKDotNetCore.MvcApp;

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

        //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        //{
        //    DataSource = ".",
        //    InitialCatalog = "TestDb",
        //    UserID = "sa",
        //    Password = "sasa@123",
        //    TrustServerCertificate = true
        //};
        optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
    
    public DbSet<PageStatisticsModel> PageStatistics { get; set; }
    public DbSet<RadarModel> Radars { get; set; }    
}