using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShoppingCart.Services
{
    public class CartService : IDisposable
    {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public Cart GetBySessionId(string sessionId)
        {
            var cart = _db.Carts.
                Include("CartItems").
                Where(c => c.SessionId == sessionId).
                SingleOrDefault();

            cart = CreateCartIfItDoesntExist(sessionId, cart);

            return cart;
        }

        private Cart CreateCartIfItDoesntExist(string sessionId, Cart cart)
        {
            if (null == cart)
            {
                cart = new Cart
                {
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };
                _db.Carts.Add(cart);
                _db.SaveChanges();
            }

            return cart;
        }

        public Cart GetById(int id)
        {
            var cart = _db.Carts.
                Include("CartItems").
                Include("CartItems.Book").
                Include("CartItems.Book.Author").
                Include("CartItems.Book.Category").
                Where(c => c.Id == id).
                SingleOrDefault();

            if (null == cart)
                throw new System.Data.Entity.Core.ObjectNotFoundException
                    (string.Format("Unable to find cart with id {0}", id));

            return cart;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}