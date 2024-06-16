using Microsoft.EntityFrameworkCore;
using PTKDotNetCore.BlazorServerApp.Models;

namespace PTKDotNetCore.BlazorServerApp;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
    {

    }
    public DbSet<BlogModel> Blogs { get; set; }

  
}