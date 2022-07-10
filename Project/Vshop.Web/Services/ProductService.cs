using System.Text;
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
        private ProductViewModel productVm;
        private IEnumerable<ProductViewModel> productsVm;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productsVm = await JsonSerializer
                                .DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _opt);
                }
                else
                {
                    return null;
                }
            }
            return productsVm;
        }

        public async Task<ProductViewModel> FindProductById(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productVm = await JsonSerializer
                              .DeserializeAsync<ProductViewModel>(apiResponse, _opt);
                }
                else
                {
                    return null;
                }
            }
            return productVm;

        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productVM)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            StringContent content = new StringContent(JsonSerializer.Serialize(productVM),
                                    Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productVm = await JsonSerializer
                                .DeserializeAsync<ProductViewModel>(apiResponse, _opt);
                }
                else
                {
                    return null;
                }
            }
            return productVm;
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel productVM)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            ProductViewModel productUpdated = new ProductViewModel();

            using (var response = await client.PutAsJsonAsync(apiEndpoint, productVM))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productUpdated = await JsonSerializer
                                .DeserializeAsync<ProductViewModel>(apiResponse, _opt);
                }
                else
                {
                    return null;
                }
            }
            return productUpdated;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
