using PTKDotNetCore.PractiseExamples.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTKDotNetCore.PractiseExamples.RefitExample
{
    public class RefitExample
    {
        private readonly RefitApi refitApi = RestService.For<RefitApi>("https://localhost:7031");
        public async Task Run()
        {
            await ReadAsync();
        }
        private async Task ReadAsync()
        {
            var lst = await refitApi.GetProduct();
            foreach (ProductModels item in lst)
            {
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductCategory);
                Console.WriteLine(item.ProductPrice);
            }
        }
        private async Task CreateAsync(string name, string category, int price)
        {
            List<ProductModels> lst = await refitApi.PostProduct();
            
        }
    }
}
