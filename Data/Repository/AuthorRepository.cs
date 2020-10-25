using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly BookShopContext context;

        public IEnumerable<Author> All => context.Authors.ToList();

        public AuthorRepository(BookShopContext context)
        {
            this.context = context;
        }

        public void Add(Author entity)
        {
            context.Authors.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Author entity)
        {
            context.Authors.Remove(entity);
            context.SaveChanges();
        }

        public Author FindById(int id)
        {
            return context.Authors.FirstOrDefault(e => e.Id == id);
        }

        public Author FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Author FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Author entity)
        {
            context.Authors.Update(entity);
            context.SaveChanges();
        }
    }
}
