using Newtonsoft.Json;
using PTKDotNetCore.ConsoleApp.Models;
using RestSharp;

namespace PTKDotNetCore.ConsoleApp.RestClientExamples;

public class RestClientExample
{
    private readonly string _apiUrl = "https://localhost:7131/api/Blog";
    public async Task Run()
    {
        //await Read();
        //await Edit(1);
        //await Edit(33);
        //await Update(23, "string", "string", "string");
        //await Delete(23);
        //await Delete(17);
        //await Delete(18);
        //await Delete(19);
        await Create("title","author","content");

    }
    private async Task Read()
    {
        RestRequest request = new RestRequest(_apiUrl,Method.Get);    
        RestClient restClient = new RestClient();
        RestResponse response= await restClient.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonstr = response.Content;
            List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonstr);
            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }

        }
        else
        {
            Console.WriteLine(response.Content);
        }

    }
    public async Task Edit(int id)
    {
        string url = $"{_apiUrl}/{id}";
        RestRequest request = new RestRequest(url, Method.Get);
        RestClient restClient = new RestClient();
        RestResponse response = await restClient.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonstr = response.Content;
            BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonstr);
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
        else
        {
            Console.WriteLine(response.Content);
        }
    }
    public async Task Create(string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogAuthor = author,
            BlogContent = content,
            BlogTitle = title
        };
        RestRequest request = new RestRequest(_apiUrl, Method.Post);
        request.AddBody(blog);  
        RestClient restClient = new RestClient();
        RestResponse response = await restClient.ExecuteAsync(request);
            
        if (response.IsSuccessStatusCode)
        {
            string jsonstr = response.Content;
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine(response.Content);
        }
        // Your HTTP request code here
    }

    public async Task Update(int id, string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogAuthor = author,
            BlogContent = content,
            BlogTitle = title
        };
        string url = $"{_apiUrl}/{id}";
        RestRequest request = new RestRequest(url, Method.Put);
        request.AddBody(blog);
        RestClient restClient = new RestClient();
        RestResponse response = await restClient.ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string jsonstr = response.Content;
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine(response.Content);
        }
    }
    private async Task Delete(int id)
    {
        string url = $"{_apiUrl}/{id}";
        RestRequest request = new RestRequest(url, Method.Delete);
        RestClient restClient = new RestClient();
        RestResponse response = await restClient.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonstr = response.Content;
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine(response.Content);
        }
    }
}