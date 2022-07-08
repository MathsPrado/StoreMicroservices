using Vshop.Web.Models.ViewModel;

namespace Vshop.Web.Services.Interface;

public interface IProductService
{
    Task<IEnumerable<ProductViewmodel>> GetAllProducts();
    Task<ProductViewmodel> FindProductById(int id);
    Task<ProductViewmodel> CreateProduct (ProductViewmodel productVM);
    Task<ProductViewmodel> UpdateProduct (ProductViewmodel productVM);
    Task<bool> DeleteProduct (int id);
}

  