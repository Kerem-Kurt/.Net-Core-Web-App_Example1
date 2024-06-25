using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Crewin_Task.Services;
using System.Collections.Generic;
using Crewin_Task.Models;

namespace Crewin_Task.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _productService.GetCategoriesAsync();
            return View(categories);
        }

        public async Task<IActionResult> Category(string name)
        {
            var products = await _productService.GetProductsByCategoryAsync(name);
            return View(products);
        }
    }
}
