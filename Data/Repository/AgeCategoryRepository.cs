using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AgeCategoryRepository : IRepository<AgeCategory>
    {
        private readonly BookShopContext context;

        public AgeCategoryRepository(BookShopContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(AgeCategory entity)
        {
            context.AgeCategories.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AgeCategory>> AllAsync()
        {
            return await context.AgeCategories.ToListAsync();
        }

        public async Task DeleteAsync(AgeCategory entity)
        {
            context.AgeCategories.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<AgeCategory> FindByIdAsync(int id)
        {
            return await context.AgeCategories.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(AgeCategory entity)
        {
            context.AgeCategories.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
