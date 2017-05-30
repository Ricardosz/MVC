using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService = new CategoryService();

        [ChildActionOnly]
        public PartialViewResult Menu(int selectedCategoryId)
        {
            var categories = _categoryService.Get();

            AutoMapper.Mapper.CreateMap<Category, CategoryViewModel>();

            ViewBag.SelectedCategoryId = selectedCategoryId;

            return PartialView(
                AutoMapper.Mapper.Map<List<Category>, List<CategoryViewModel>>(categories)
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}