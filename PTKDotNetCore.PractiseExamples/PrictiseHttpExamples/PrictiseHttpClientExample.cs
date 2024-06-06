using Newtonsoft.Json;
using PTKDotNetCore.PractiseExamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace PTKDotNetCore.PractiseExamples.PrictiseHttpExamples
{
    public class PrictiseHttpClientExample
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task Run()
        {
            await ReadAsync();
            //await EditAsync(4);
            //await EditAsync(20);
        }
        private async Task ReadAsync()
        {
            _client.Timeout = TimeSpan.FromSeconds(200);
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await _client.GetAsync("https://localhost:7031/api/Product");
            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://localhost:7031/api/Product");
                //HttpResponseMessage response = await _client.GetAsync("http://localhost:5272/api/Product");
                if (response.IsSuccessStatusCode)
                {
                    string jsonStr = await response.Content.ReadAsStringAsync();
                    List<ProductModels> lst = JsonConvert.DeserializeObject<List<ProductModels>>(jsonStr)!;
                    foreach (ProductModels model in lst)
                    {
                        Console.WriteLine(model.ProductId);
                        Console.WriteLine(model.ProductName);
                        Console.WriteLine(model.ProductPrice);
                        Console.WriteLine(model.ProductCategory);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Request timed out. Please try again later.");
            }

        }
        private async Task EditAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:7031/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                ProductModels item = JsonConvert.DeserializeObject<ProductModels>(jsonStr)!;
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductPrice);
                Console.WriteLine(item.ProductCategory);
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errorResponse);
            }


        }
        private async Task CreateAsync(string name, string category, int price)
        {
            string url = "https://localhost:7031/api/Product";
            ProductModels model = new ProductModels()
            {
                ProductCategory = category,
                ProductPrice = price,
                ProductName = name
            };
            string jsonStr = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(content: JsonConvert.SerializeObject(jsonStr), Encoding.UTF8, Application.Json);
            await _client.PostAsync("api/blog", content);
            HttpResponseMessage response = await _client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            
        }

        private async void UpdateAsync(int id, string name, string category, int price)
        {
            ProductModels model = new ProductModels()
            {
                ProductCategory = category,
                ProductPrice = price,
                ProductName = name
            };
            string jsonStr = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);

            string url = $"https://localhost:7031/api/Product/{id}";

            HttpResponseMessage response = await _client.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
           

        }
        private async Task DeleteAsync(int id)
        {
            string url = $"https://localhost:7031/api/Product/{id}";
            HttpResponseMessage response = await _client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            
        }

    }
}
