using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTKDotNetCore.MinimalWebApi.Models;

namespace PTKDotNetCore.MinimalWebApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BlogModel> Blogs { get; set; }
}