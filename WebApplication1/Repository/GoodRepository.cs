using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class GoodRepository : IRepository<Good>
    {
        private ShopEntities _context = new ShopEntities();

        public void Dispose()
        {
            _context.Dispose();
        }

        public Good Get(int Id)
        {
            return _context.Good.FirstOrDefault(x => x.GoodId == Id);
        }

        public IEnumerable<Good> GetAll()
        {
            return _context.Good;
        }

        public void Remove(int Id)
        {
            var entity = _context.Good.FirstOrDefault(x => x.GoodId == Id);
            _context.Good.Remove(entity);
            _context.SaveChanges();
        }


        public void UpdateOrCreate(Good entity)
        {
            _context.Good.AddOrUpdate(entity);
            _context.SaveChanges();
        }
    }
}