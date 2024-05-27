﻿using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTKDotNetCore.ConsoleApp.Models;

namespace PTKDotNetCore.ConsoleApp.EFCoreExamples;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {

            DataSource = "DESKTOP-4FNB1J3\\MSSQLSERVER1",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "phyo@123",
            TrustServerCertificate = true
        };
        optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}