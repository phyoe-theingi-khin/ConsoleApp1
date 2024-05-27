using PTKDotNetCore.ConsoleApp.Models;
using Refit;

namespace PTKDotNetCore.ConsoleApp.RefitExamples;

internal interface IBlogApi
{
    [Get("/api/blog")]
    Task<List<BlogModel>> GetBlog();

    [Get("/api/blog/{id}")]
    Task<BlogModel> GetBlog(int id);

    [Post("/api/blog")]
    Task<string> CreateBlog(BlogModel blog);

    [Put("/api/blog/{id}")]
    Task<string> UpdateBlog (int id,BlogModel blog);

    [Delete("/api/blog/{id}")]
    Task<string> Deleteblog(int id);
}