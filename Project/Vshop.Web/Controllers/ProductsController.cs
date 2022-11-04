using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vshop.Web.Models.ViewModel;
using Vshop.Web.Roles;
using Vshop.Web.Services.Interface;

namespace Vshop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService,
                                  ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var result = await _productService.GetAllProducts();
            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreateProduct()
        {
            //ViewBag is an object Dynamic with property created in controller with have access in View
            ViewBag.CategoryId = new SelectList(await
                 _categoryService.GetAllCategories(), "CategoryId", "Name");

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.CreateProduct(productVM);

                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await
                                     _categoryService.GetAllCategories(), "CategoryId", "Name");
            }
            return View(productVM);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.CategoryId = new SelectList(await
                               _categoryService.GetAllCategories(), "CategoryId", "Name");

            var result = await _productService.FindProductById(id);

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateProduct(productVM);

                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProductViewModel>> DeleteProduct(int id)
        {
            var result = await _productService.FindProductById(id);

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost(), ActionName("DeleteProduct")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (!result)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
