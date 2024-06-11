using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PTKDotNetCore.MinimalWebApi;
using PTKDotNetCore.MinimalWebApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/PTKDotNetCore.MinimalWebApi.log", rollingInterval: RollingInterval.Hour)
    
    .CreateLogger();
try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    //builder.Services.AddSerilog();
    builder.Host.UseSerilog();
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    app.MapGet("/api/blog", (AppDbContext _db) =>
    {
        List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
        Log.Information(JsonConvert.SerializeObject(lst, Formatting.Indented));
        return Results.Ok(lst);
    })
        .WithName("GetBlog")
        .WithOpenApi();

    app.MapGet("/api/blog/{id}", (AppDbContext _db, int id) =>
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
        if (item is null)
        {
            return Results.NotFound("No data found.");
        }

        return Results.Ok(item);
    })
        .WithName("GetBlogById")
        .WithOpenApi();

    app.MapGet("/api/blog/{pageNo}/{pageSize}", (AppDbContext _db, int pageNo, int pageSize) =>
    {
        int rowCount = _db.Blogs.Count();
        int pageCount = rowCount / pageSize;
        if (rowCount % pageSize > 0)
            pageCount++;
        if (pageNo > pageCount)
        {
            return Results.BadRequest(new { Message = "Invalid pageNo!" });
        }

        List<BlogModel> lst = _db.Blogs
            .OrderByDescending(x => x.BlogId)
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        BlogResponseModel model = new();
        model.Data = lst;
        model.pageSize = pageSize;
        model.pageNo = pageNo;
        model.pageCount = pageCount;
        //model.isEndOfPage = pageNo == pageCount;
        return Results.Ok(model);
    })
        .WithName("GetBlogByPagination")
        .WithOpenApi();

    app.MapPost("/api/blog", (AppDbContext _db, BlogModel model) =>
    {
        _db.Blogs.Add(model);
        int result = _db.SaveChanges();
        string message = result > 0 ? "saving successful." : "saving failed.";
        return Results.Ok(message);

    })
        .WithName("CreateBlog")
        .WithOpenApi();

    app.MapPut("/api/blog/{id}", (AppDbContext _db, int id, BlogModel model) =>
    {
        BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
        if (item is null)
        {
            return Results.NotFound("No data found.");
        }

        item.BlogTitle = model.BlogTitle;
        item.BlogAuthor = model.BlogAuthor;
        item.BlogContent = model.BlogContent;
        //_db.Update(item);
        int result = _db.SaveChanges();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        return Results.Ok(message);

    })
        .WithName("UpdateBlog")
        .WithOpenApi();

    app.MapDelete("/api/blog/{id}", (AppDbContext _db, int id) =>
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
        if (item is null)
        {
            return Results.NotFound("No data found.");
        }

        _db.Blogs.Remove(item);
        int result = _db.SaveChanges();

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        return Results.Ok(message);
    })
        .WithName("DeleteBlog")
        .WithOpenApi();


    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
