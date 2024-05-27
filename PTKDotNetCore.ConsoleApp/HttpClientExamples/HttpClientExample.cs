using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(33);
            //await Update(23, "string", "string", "string");
            await Delete(23);
            await Delete(22);
            await Delete(21);
            await Delete(20);

        }
        private async Task Read()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage respone = await httpClient.GetAsync("https://localhost:7131/api/Blog/");
            if (respone.IsSuccessStatusCode)
            {
                string jsonstr = await respone.Content.ReadAsStringAsync();
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
                Console.WriteLine(await respone.Content.ReadAsStringAsync());
            }

        }
        public async Task Edit(int id)
        {
            string url = $"https://localhost:7131/api/Blog/{id}";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage respone = await httpClient.GetAsync(url);
            if (respone.IsSuccessStatusCode)
            {
                string jsonstr = await respone.Content.ReadAsStringAsync();
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonstr);
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.WriteLine(await respone.Content.ReadAsStringAsync());
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
            string jsonBlog = JsonConvert.SerializeObject(blog);// convert to json
            HttpContent httpcontent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7131/api/Blog/";
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(200); // Set timeout to 200 seconds
            try
            {
                HttpResponseMessage respone = await client.PostAsync(url, httpcontent);
                if (respone.IsSuccessStatusCode)
                {
                    string jsonstr = await respone.Content.ReadAsStringAsync();
                    Console.WriteLine(await respone.Content.ReadAsStringAsync());
                }
                else
                {
                    Console.WriteLine(await respone.Content.ReadAsStringAsync());
                }
                // Your HTTP request code here
            }
            catch (TaskCanceledException ex)
            {
                // Handle the timeout exception
                Console.WriteLine("Request timed out. Please try again later.");
            }


        }

        public async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogAuthor = author,
                BlogContent = content,
                BlogTitle = title
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);// convert to json
            HttpContent httpcontent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7131/api/Blog/{id}";
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(200); // Set timeout to 200 seconds
            try
            {
                HttpResponseMessage respone = await client.PutAsync(url, httpcontent);
                if (respone.IsSuccessStatusCode)
                {
                    string jsonstr = await respone.Content.ReadAsStringAsync();
                    Console.WriteLine(await respone.Content.ReadAsStringAsync());
                }
                else
                {
                    Console.WriteLine(await respone.Content.ReadAsStringAsync());
                }
                // Your HTTP request code here
            }
            catch (TaskCanceledException ex)
            {
                // Handle the timeout exception
                Console.WriteLine("Request timed out. Please try again later.");
            }


        }
        private async Task Delete(int id)
        {
            string url = $"https://localhost:7131/api/Blog/{id}";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage respone = await httpClient.DeleteAsync(url);
            if (respone.IsSuccessStatusCode)
            {
                string jsonstr = await respone.Content.ReadAsStringAsync();
                Console.WriteLine(await respone.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await respone.Content.ReadAsStringAsync());
            }
        }
    }
}

