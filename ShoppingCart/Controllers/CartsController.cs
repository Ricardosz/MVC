using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CartsController : Controller
    {
        private readonly CartService _cartService = new CartService();

        public CartsController()
        {
            AutoMapper.Mapper.CreateMap<Cart, CartViewModel>();
            AutoMapper.Mapper.CreateMap<CartItem, CartItemViewModel>();
            AutoMapper.Mapper.CreateMap<Book, BookViewModel>();
            AutoMapper.Mapper.CreateMap<Author, AuthorViewModel>();
            AutoMapper.Mapper.CreateMap<Category, CategoryViewModel>();
        }

        // GET: Carts
        [Authorize]
        public ActionResult Index()
        {
            var cart = _cartService.GetBySessionId(HttpContext.Session.SessionID);

            return View(
                AutoMapper.Mapper.Map<Cart, CartViewModel>(cart)
            );
        }

        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            var cart = _cartService.GetBySessionId(HttpContext.Session.SessionID);

            return PartialView(
                AutoMapper.Mapper.Map<Cart, CartViewModel>(cart)
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}