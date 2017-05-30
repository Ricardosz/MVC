using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Services
{
    public class CategoryService : IDisposable
    {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public List<Category> Get()
        {
            return _db.Categories.OrderBy(c => c.Name).ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}