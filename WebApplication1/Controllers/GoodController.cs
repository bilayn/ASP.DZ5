using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class GoodController : Controller
    {
        private readonly GoodRepository _goods = new GoodRepository();
        private readonly CategoryRepository _categories = new CategoryRepository();
        private readonly ManufacturerRepository _manufacturers = new ManufacturerRepository();

        public GoodController()
        {
            ViewBag.Categories = _categories.GetAll()
                .ToList()
                .Select(x => new SelectListItem()
                {
                    Value =  x.CategoryId.ToString(),
                    Text = x.CategoryName
                }).ToList();

            ViewBag.Manufacturers = _manufacturers.GetAll()
                .ToList()
                .Select(uc => new SelectListItem()
                {
                    Value = uc.ManufacturerId.ToString(),
                    Text = uc.ManufacturerName
                })
                .ToList();
        }


        // GET: Manufacturer
        public ActionResult Index()
        {
            return View(_goods.GetAll());
        }

        public ActionResult Edit(int id)
        {
            
            return View(_goods.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Good good)
        {
            if (ModelState.IsValid)
            {
                _goods.UpdateOrCreate(good);
            }

            return View();
        }

        public ActionResult Create(Good good)
        {
            if (ModelState.IsValid)
            {
                _goods.UpdateOrCreate(good);
            }

            return View();
        }
    }
}