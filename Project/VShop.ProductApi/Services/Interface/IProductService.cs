﻿using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(ProductDTO productDTO);
        Task DeleteProduct(int id);
    }
}
