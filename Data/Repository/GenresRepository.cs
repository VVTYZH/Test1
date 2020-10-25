using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class GenresRepository : IRepository<Genre>
    {
        private readonly BookShopContext context;

        public IEnumerable<Genre> All => context.Genres.ToList();

        public GenresRepository(BookShopContext context)
        {
            this.context = context;
        }

        public void Add(Genre entity)
        {
            context.Genres.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Genre entity)
        {
            context.Genres.Remove(entity);
            context.SaveChanges();
        }

        public Genre FindById(int id)
        {
            return context.Genres.FirstOrDefault(e => e.Id == id);
        }

        public Genre FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Genre FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Genre entity)
        {
            context.Genres.Update(entity);
            context.SaveChanges();
        }
    }
}
