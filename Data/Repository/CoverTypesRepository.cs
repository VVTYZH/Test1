using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CoverTypesRepository : IRepository<CoverType>
    {

        private readonly BookShopContext context;

        public CoverTypesRepository(BookShopContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(CoverType entity)
        {
            context.CoverTypes.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CoverType>> AllAsync()
        {
            return await context.CoverTypes.ToListAsync();
        }

        public async Task DeleteAsync(CoverType entity)
        {
            context.CoverTypes.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<CoverType> FindByIdAsync(int id)
        {
            return await context.CoverTypes.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(CoverType entity)
        {
            context.CoverTypes.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
