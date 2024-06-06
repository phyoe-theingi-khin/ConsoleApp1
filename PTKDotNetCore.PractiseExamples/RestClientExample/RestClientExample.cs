using Newtonsoft.Json;
using PTKDotNetCore.PractiseExamples.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTKDotNetCore.PractiseExamples.RestClientExample
{
    public class RestClientExample
    {
        private readonly string _apiUrl = "http://localhost:5272/api/Product";
        private readonly RestClient _restClient = new RestClient();
        public async Task Run()
        {
            //await ReadAsync();
            //await EditAsync(2);
            //await EditAsync(20);
            await CreateAsync("Name11","Category11",90);
            //await UpdateAsync(20, "Name11", "Category11", 90);
            //await UpdateAsync(5, "Name11", "Category11", 90);
            //await DeleteAsync(8);



        }
        private async Task ReadAsync()
        {
            RestRequest request = new RestRequest(_apiUrl, Method.Get);
            RestResponse response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;
                List<ProductModels> lst = JsonConvert.DeserializeObject<List<ProductModels>>(json)!;
                foreach (ProductModels item in lst)
                {
                    Console.WriteLine(item.ProductId);
                    Console.WriteLine(item.ProductName);
                    Console.WriteLine(item.ProductPrice);
                    Console.WriteLine(item.ProductCategory);
                }

            }
            else
            {
                Console.WriteLine(response.Content);
            }

        }
        private async Task EditAsync(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;
                ProductModels item = JsonConvert.DeserializeObject<ProductModels>(json)!;
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductPrice);
                Console.WriteLine(item.ProductCategory);
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }
        private async Task CreateAsync(string name, string category, int price)
        {

            ProductModels model = new ProductModels()
            {
                ProductCategory = category,
                ProductName = name,
                ProductPrice = price
            };
            RestRequest request = new RestRequest(_apiUrl, Method.Post);
            request.AddJsonBody(model);
            RestResponse response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }

        }
        private async Task UpdateAsync(int id, string name, string category, int price)
        {
            string url = $"{_apiUrl}/{id}";
            ProductModels model = new ProductModels()
            {
                ProductCategory = category,
                ProductName = name,
                ProductPrice = price
            };
            RestRequest request =new RestRequest(url, Method.Put);
            request.AddJsonBody(model);
            RestResponse response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }

        }
        private async Task DeleteAsync(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url);
            RestResponse response = await _restClient.ExecuteAsync(request, Method.Delete);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }
    }
}
