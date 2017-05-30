using ShoppingCart.Behaviors;
using ShoppingCart.DAL;
using ShoppingCart.Models;
using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace ShoppingCart.Services
{
    public class AuthorService : IDisposable
    {
        private ShoppingCartContext _db = new ShoppingCartContext();
        public List<Author> Get(QueryOptions queryOptions)
        {
            var start = QueryOptionsCalculator.CalculateStart(queryOptions);

            var authors = _db.Authors.
                OrderBy(queryOptions.Sort).
                Skip(start).
                Take(queryOptions.PageSize);

            queryOptions.TotalPages = QueryOptionsCalculator.CaclulateTotalPages(
                _db.Authors.Count(), queryOptions.PageSize);

            return authors.ToList();
        }

        public Author GetById(long id)
        {
            Author author = _db.Authors.Find(id);
            if (author == null)
            {
                throw new System.Data.Entity.Core.ObjectNotFoundException
                    (string.Format("Unable to find author with id {0}", id));
            }

            return author;
        }

        public Author GetByName(string name)
        {
            Author author = _db.Authors
                .Where(a => a.FirstName + ' ' + a.LastName == name)
                .SingleOrDefault();
            if (author == null)
            {
                throw new System.Data.Entity.Core.ObjectNotFoundException
                    (string.Format("Unable to find author with name {0}", name));
            }

            return author;
        }

        public void Insert(Author author)
        {
            _db.Authors.Add(author);

            _db.SaveChanges();
        }

        public void Update(Author author)
        {
            _db.Entry(author).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(Author author)
        {
            _db.Authors.Remove(author);

            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}