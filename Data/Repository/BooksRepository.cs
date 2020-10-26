using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BooksRepository : IRepository<Book>
    {
        private readonly BookShopContext context;

        public BooksRepository(BookShopContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Book entity)
        {
            context.Books.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> AllAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task DeleteAsync(Book entity)
        {
            context.Books.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Book> FindByIdAsync(int id)
        {
            return await context.Books.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Book entity)
        {
            context.Books.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
