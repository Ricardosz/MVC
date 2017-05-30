using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Services
{
    public class BookService : IDisposable
    {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public List<Book> GetByCategoryId(int categoryId)
        {
            return _db.Books.
                Include("Author").
                Where(b => b.CategoryId == categoryId).
                OrderByDescending(b => b.Featured).
                ToList();
        }

        public List<Book> GetFeatured()
        {
            return _db.Books.
                Include("Author").
                Where(b => b.Featured).
                ToList();
        }

        public Book GetById(int id)
        {
            var book = _db.Books.
                Include("Author").
                Where(b => b.Id == id).
                SingleOrDefault();

            if (null == book)
                throw new System.Data.Entity.Core.ObjectNotFoundException
                    (string.Format("Unable to find book with id {0}", id));

            return book;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}