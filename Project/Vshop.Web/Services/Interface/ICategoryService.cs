using Vshop.Web.Models.ViewModel;

namespace Vshop.Web.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
    }
}
