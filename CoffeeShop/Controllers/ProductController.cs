using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models.Interface;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public ActionResult Shop() 
        {
            return View(productRepository.GetAllProducts());
        }
    }
}
