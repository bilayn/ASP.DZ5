using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryRepository _categories = new CategoryRepository();
        // GET: Category
        public ActionResult Index()
        {
            return View(_categories.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(_categories.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
                _categories.UpdateOrCreate(category);

            return View();
        }

        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
                _categories.UpdateOrCreate(category);
            return View();
        }
    }
}