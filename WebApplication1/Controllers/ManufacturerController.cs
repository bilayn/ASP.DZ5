using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ManufacturerController : Controller
    {
        private ManufacturerRepository _manufacturers = new ManufacturerRepository();
        // GET: Manufacturer
        public ActionResult Index()
        {
            return View(_manufacturers.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(_manufacturers.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
                _manufacturers.UpdateOrCreate(manufacturer);

            return View();
        }

        public ActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
                _manufacturers.UpdateOrCreate(manufacturer);
            return View();
        }
    }
}