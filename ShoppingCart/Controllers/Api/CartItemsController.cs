using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCart.Controllers.Api
{
    public class CartItemsController : ApiController
    {
        private readonly CartItemService _cartItemService = new CartItemService();

        public CartItemsController()
        {
            AutoMapper.Mapper.CreateMap<Cart, CartViewModel>();
            AutoMapper.Mapper.CreateMap<CartItem, CartItemViewModel>();
            AutoMapper.Mapper.CreateMap<Book, BookViewModel>();

            AutoMapper.Mapper.CreateMap<CartItemViewModel, CartItem>();
            AutoMapper.Mapper.CreateMap<BookViewModel, Book>();
            AutoMapper.Mapper.CreateMap<AuthorViewModel, Author>();
            AutoMapper.Mapper.CreateMap<CategoryViewModel, Category>();
        }
        
        public CartItemViewModel Post(CartItemViewModel cartItem)
        {
            var newCartItem = _cartItemService.AddToCart(AutoMapper.Mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return AutoMapper.Mapper.Map<CartItem, CartItemViewModel>(newCartItem);
        }
        
        public CartItemViewModel Put(CartItemViewModel cartItem)
        {
            _cartItemService.UpdateCartItem(AutoMapper.Mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return cartItem;
        }

        public CartItemViewModel Delete(CartItemViewModel cartItem)
        {
            _cartItemService.DeleteCartItem(AutoMapper.Mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return cartItem;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartItemService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
