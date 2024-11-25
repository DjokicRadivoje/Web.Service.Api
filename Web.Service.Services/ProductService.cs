using System.Collections.Immutable;
using System.Text.Json;
using Web.Service.DataModel.Product;
using Web.Service.Services.Interfaces;

namespace Web.Service.Services
{
    public class ProductService: IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductResponse>> GetProduct(ProductRequest request)
        { 
        var response = new List<ProductResponse>();

            var result = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            {
                var content = await result.Content.ReadAsStringAsync();
                var productResponse = JsonSerializer.Deserialize<IEnumerable<ProductResponse>>(content);
                response = productResponse.ToList();
            }
            //response.Add(new ProductResponse() { Id = 1, Name = "Kredit" });
        return response;
        }
    }
}
