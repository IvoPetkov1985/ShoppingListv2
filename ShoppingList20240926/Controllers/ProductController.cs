using Microsoft.AspNetCore.Mvc;
using ShoppingList20240926.Contracts;
using ShoppingList20240926.Models;

namespace ShoppingList20240926.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IList<ProductViewModel> model = await _service.GetAllProductsAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductViewModel model = new ProductViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _service.AddProductAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProductViewModel model = await _service.GetProductByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model, int id)
        {
            if (!ModelState.IsValid || model.Id != id)
            {
                return View(model);
            }

            await _service.UpdateProductAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
