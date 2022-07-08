using System.Text.Json;
using Vshop.Web.Models.ViewModel;
using Vshop.Web.Services.Interface;

namespace Vshop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string apiEndpoint = "api/products/";
        private readonly JsonSerializerOptions _opt;
        private ProductViewmodel productVm;
        private IEnumerable<ProductViewmodel> productsVm;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<IEnumerable<ProductViewmodel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewmodel> FindProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewmodel> CreateProduct(ProductViewmodel productVM)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewmodel> UpdateProduct(ProductViewmodel productVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

    }
}
