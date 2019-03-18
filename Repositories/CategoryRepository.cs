using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApp.Models;

namespace Core_WebApp.Repositories
{
    public class CategoryRepository : IRepository<Category, int>
    {
        AppDbContext context;
        /// <summary>
        /// Injecting the Dependency for AppDbContext class
        /// </summary>
        /// <param name="context"></param>
        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Category Create(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            var cat = context.Categories.Find(id);
            if (cat != null)
            {
                context.Categories.Remove(cat);
                context.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public IEnumerable<Category> Get()
        {
            return context.Categories.ToList();
        }

        public Category Get(int id)
        {
            var cat = context.Categories.Find(id);
            return cat;
        }

        public bool Update(int id, Category entity)
        {
            bool isUpdated = false;
            var cat = context.Categories.Find(id);
            if (cat != null)
            {
                cat.CategoryName = entity.CategoryName;
                cat.BasePrice = entity.BasePrice;
                context.SaveChanges();
                isUpdated = true;
            }
            return isUpdated;
        }
    }
}
