using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class BooksRepository : IRepository<Book>
    {
        private readonly BookShopContext context;

        public IEnumerable<Book> All => context.Books.ToList();

        public BooksRepository(BookShopContext context)
        {
            this.context = context;
        }

        public void Add(Book entity)
        {
            context.Books.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Book entity)
        {
            context.Books.Remove(entity);
            context.SaveChanges();
        }

        public Book FindById(int id)
        {
            return context.Books.FirstOrDefault(e => e.Id == id);
        }

        public Book FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Book FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            context.Books.Update(entity);
            context.SaveChanges();
        }
    }
}
