using PTKDotNetCore.ConsoleApp.Models;
using Refit;

namespace PTKDotNetCore.ConsoleApp.RefitExamples;

internal class RefitExample
{
    // private readonly string _url = "https://localhost:7131";
    private readonly IBlogApi refitApi = RestService.For<IBlogApi>("https://localhost:7131");

    public async Task Run()
    {
        //await Read();
        await Edit(1);
        await Edit(0);
    }
    private async Task Read()
    {
        var lst = await refitApi.GetBlog();
        foreach (BlogModel item in lst)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
    }
    private async Task Edit(int id)
    {
        try {
            var item = await refitApi.GetBlog(id);
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
        catch (Refit.ApiException ex) {
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
    }
    private async Task Create(string title, string author, string content)
    {
        BlogModel model = new BlogModel()
        {
            BlogAuthor = author,
            BlogTitle = title,
            BlogContent = content
        };
        try
        {
            string message = await refitApi.CreateBlog(model);
            Console.WriteLine(message);
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    private async Task Update(int id, string title, string author, string content)
    {
        BlogModel model = new BlogModel()
        {
            BlogAuthor = author,
            BlogTitle = title,
            BlogContent = content
        };
        try
        {
            string message = await refitApi.UpdateBlog(id, model);
            Console.WriteLine(message);
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    private async Task Delete(int id)
    {
        try
        {
            string message = await refitApi.Deleteblog(id);
            Console.WriteLine(message);
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}