using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class CoverTypesRepository : IRepository<CoverType>
    {
        private readonly BookShopContext context;

        public IEnumerable<CoverType> All => context.CoverTypes.ToList();

        public CoverTypesRepository(BookShopContext context)
        {
            this.context = context;
        }

        public void Add(CoverType entity)
        {
            context.CoverTypes.Add(entity);
            context.SaveChanges();
        }

        public void Delete(CoverType entity)
        {
            context.CoverTypes.Remove(entity);
            context.SaveChanges();
        }

        public CoverType FindById(int id)
        {
            return context.CoverTypes.FirstOrDefault(e => e.Id == id);
        }

        public CoverType FindById(string id)
        {
            throw new NotImplementedException();
        }

        public CoverType FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CoverType entity)
        {
            context.CoverTypes.Update(entity);
            context.SaveChanges();
        }
    }
}
