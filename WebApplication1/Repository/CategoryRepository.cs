using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private ShopEntities _context = new ShopEntities();

        public void UpdateOrCreate(Category entity)
        {
            _context.Category.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public Category Get(int Id)
        {
            return _context.Category.FirstOrDefault(x => x.CategoryId == Id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category;
        }

        public void Remove(int Id)
        {
            var entity = _context.Category.FirstOrDefault(x => x.CategoryId == Id);
            _context.Category.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        ~CategoryRepository()
        {
            _context.Dispose();
        }
    }
}