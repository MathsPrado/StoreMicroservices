using Microsoft.AspNetCore.Mvc;
using Vshop.Web.Models.ViewModel;
using Vshop.Web.Services.Interface;

namespace Vshop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var result = await _productService.GetAllProducts();
            if (result is null)
                return View("Error");

            return View(result);
        }
    }
}
