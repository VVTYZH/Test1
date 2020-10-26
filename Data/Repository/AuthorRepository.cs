using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly BookShopContext context;

        public AuthorRepository(BookShopContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Author entity)
        {
            context.Authors.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> AllAsync()
        {
            return await context.Authors.ToListAsync();
        }

        public async Task DeleteAsync(Author entity)
        {
            context.Authors.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Author> FindByIdAsync(int id)
        {
            return await context.Authors.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Author entity)
        {
            context.Authors.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
