using PTKDotNetCore.PractiseExamples.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTKDotNetCore.PractiseExamples.RefitExample
{
    public interface RefitApi
    {
        [Get("/api/product")]
        Task<List<ProductModels>> GetProduct(); 

        [Get("/api/product/{id}")]
        Task<ProductModels> GetProduct(int id);
        
        [Get("/api/product/{id}")]
        Task<ProductModels> PostProduct(int id);
        

    }
}
