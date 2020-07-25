using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public class ChaseRepository : IChaseRepository
    {
        private readonly ChaseContext chaseContext;

        public ChaseRepository(ChaseContext chaseContext)
        {
            this.chaseContext = chaseContext;
        }

        public async Task<Chase> AddChase(Chase chase)
        {
            var result = await chaseContext.Chases.AddAsync(chase);
            await chaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Chase> DeleteChase(long chaseId)
        {
            var result = await chaseContext.Chases
                .FirstOrDefaultAsync(c => c.Id == chaseId);
            if (result != null)
            {
                chaseContext.Chases.Remove(result);
                await chaseContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Chase> GetChase(long chaseId)
        {
            return await chaseContext
                .Chases.FirstOrDefaultAsync(c => c.Id == chaseId);
        }

        public async Task<IEnumerable<Chase>> GetChases()
        {
            return await chaseContext.Chases.ToListAsync();
        }

        public async Task<IEnumerable<Chase>> Search(string name)
        {
            IQueryable<Chase> query = chaseContext.Chases;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Chase> UpdateChase(Chase chase)
        {
            var result = await chaseContext.Chases
                .FirstOrDefaultAsync(c => c.Id == chase.Id);

            if (result != null)
            {
                result.Name = chase.Name;
                result.Attribute1 = chase.Attribute1;
                result.Attribute2 = chase.Attribute2;
                result.Jutsu1 = chase.Jutsu1;
                result.Jutsu2 = chase.Jutsu2;
                result.Chasing = chase.Chasing;
                result.Causing = chase.Causing;
                result.Effects = chase.Effects;
                result.Description = chase.Description;
                result.ImagePath = chase.ImagePath;
                result.Hits = chase.Hits;
                result.Repeat = chase.Repeat;

                await chaseContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
