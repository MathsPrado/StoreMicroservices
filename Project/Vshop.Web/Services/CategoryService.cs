﻿using System.Text.Json;
using Vshop.Web.Models.ViewModel;
using Vshop.Web.Services.Interface;

namespace Vshop.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _options;
        private const string apiEndpoint = "/api/categories/";

        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var client = _clientFactory.CreateClient("ProductApi");

            IEnumerable<CategoryViewModel> categories;

            using (var response = await client.GetAsync(apiEndpoint))
            {

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    categories = await JsonSerializer
                        .DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);

                }
                else
                {
                    return null;
                }
            }
                return categories;
        }
    }
}
