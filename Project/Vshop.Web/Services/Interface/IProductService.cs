using Vshop.Web.Models.ViewModel;

namespace Vshop.Web.Services.Interface;

public interface IProductService
{
    Task<IEnumerable<ProductViewmodel>> GetAllProducts();
}

