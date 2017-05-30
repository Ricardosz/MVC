using ShoppingCart.DAL;
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
    public class BooksController : Controller
    {
        private readonly BookService _bookService = new BookService();
        


        public BooksController()
        {
            AutoMapper.Mapper.CreateMap<Book, BookViewModel>();
            AutoMapper.Mapper.CreateMap<Author, AuthorViewModel>();
            AutoMapper.Mapper.CreateMap<Category, CategoryViewModel>();
        }

        // GET: Books
        public ActionResult Index(int categoryId)
        {
            var books = _bookService.GetByCategoryId(categoryId);

            ViewBag.SelectedCategoryId = categoryId;

            return View(
                AutoMapper.Mapper.Map<List<Book>, List<BookViewModel>>(books)
            );
        }
        
        public ActionResult Details(int id)
        {
            var book = _bookService.GetById(id);

            return View(
                AutoMapper.Mapper.Map<Book, BookViewModel>(book)
            );
        }

        [ChildActionOnly]
        public PartialViewResult Featured()
        {
            var books = _bookService.GetFeatured();

            return PartialView(
                AutoMapper.Mapper.Map<List<Book>, List<BookViewModel>>(books)
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}