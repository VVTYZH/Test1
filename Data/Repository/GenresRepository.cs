using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GenresRepository : IRepository<Genre>
    {

        private readonly BookShopContext context;

        public GenresRepository(BookShopContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Genre entity)
        {
            context.Genres.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> AllAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task DeleteAsync(Genre entity)
        {
            context.Genres.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Genre> FindByIdAsync(int id)
        {
            return await context.Genres.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Genre entity)
        {
            context.Genres.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
