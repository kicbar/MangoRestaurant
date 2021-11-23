using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Controllers
{
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _cartService = cartService;
            _productService = productService;
        }
        public IActionResult CartIndex()
        {
            return View();
        }
    }
}
