using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PTKDotNetCore.MvcApp;
using PTKDotNetCore.Shared;
using System.Data.Common;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(
    opt=>{opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddDbContext<AppDbContext>(
    opt =>{
        //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        //{
        //    DataSource = ".\\MSSQLSERVER1",
        //    InitialCatalog = "TestDb",
        //    UserID = "sa",
        //    Password = "phyo@123",
        //    TrustServerCertificate = true
        //};
        //opt.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));

    }, 
    ServiceLifetime.Transient,
    ServiceLifetime.Transient);
//builder.Services.AddScoped<AdoDotNetService>();
builder.Services.AddScoped(n => new AdoDotNetService(builder.Configuration.GetConnectionString("DbConnection")!));
builder.Services.AddScoped(n => new DapperService(builder.Configuration.GetConnectionString("DbConnection")!));
builder.Services.AddSingleton<CommonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
