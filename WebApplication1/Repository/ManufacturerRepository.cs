using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private ShopEntities _context = new ShopEntities();

        public void Dispose()
        {
            _context.Dispose();
        }

        public Manufacturer Get(int Id)
        {
            return _context.Manufacturer.FirstOrDefault(x => x.ManufacturerId == Id);
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return _context.Manufacturer;
        }

        public void Remove(int Id)
        {
            var entity = _context.Manufacturer.FirstOrDefault(x => x.ManufacturerId == Id);
            _context.Manufacturer.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateOrCreate(Manufacturer entity)
        {
            _context.Manufacturer.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        ~ManufacturerRepository()
        {
            _context.Dispose();
        }
    }
}