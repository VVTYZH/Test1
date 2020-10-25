using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class AgeCategoryRepository : IRepository<AgeCategory>
    {
        private readonly BookShopContext context;

        public IEnumerable<AgeCategory> All => context.AgeCategories.ToList();

        public AgeCategoryRepository(BookShopContext context)
        {
            this.context = context;
        }

        public void Add(AgeCategory entity)
        {
            context.AgeCategories.Add(entity);
            context.SaveChanges();
        }

        public void Delete(AgeCategory entity)
        {
            context.AgeCategories.Remove(entity);
            context.SaveChanges();
        }

        public AgeCategory FindById(int id)
        {
            return context.AgeCategories.FirstOrDefault(e => e.Id == id);
        }

        public AgeCategory FindById(string id)
        {
            throw new NotImplementedException();
        }

        public AgeCategory FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(AgeCategory entity)
        {
            context.AgeCategories.Update(entity);
            context.SaveChanges();
        }
    }
}
