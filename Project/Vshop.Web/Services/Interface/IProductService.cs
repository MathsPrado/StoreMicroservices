using Vshop.Web.Models.ViewModel;

namespace Vshop.Web.Services.Interface;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();
    Task<ProductViewModel> FindProductById(int id);
    Task<ProductViewModel> CreateProduct (ProductViewModel productVM);
    Task<ProductViewModel> UpdateProduct (ProductViewModel productVM);
    Task<bool> DeleteProduct (int id);
}

  