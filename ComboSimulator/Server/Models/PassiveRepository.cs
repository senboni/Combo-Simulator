using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Server.Models
{
    public class PassiveRepository : IPassiveRepository
    {
        private readonly PassiveContext passiveContext;

        public PassiveRepository(PassiveContext passiveContext)
        {
            this.passiveContext = passiveContext;
        }

        public async Task<Passive> AddPassive(Passive passive)
        {
            var result = await passiveContext.Passives.AddAsync(passive);
            await passiveContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Passive> DeletePassive(long passiveId)
        {
            var result = await passiveContext.Passives
                .FirstOrDefaultAsync(c => c.Id == passiveId);
            if (result != null)
            {
                passiveContext.Passives.Remove(result);
                await passiveContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Passive> GetPassive(long passiveId)
        {
            return await passiveContext
                .Passives.FirstOrDefaultAsync(p => p.Id == passiveId);
        }

        public async Task<IEnumerable<Passive>> GetPassives()
        {
            return await passiveContext.Passives.ToListAsync();
        }

        public async Task<IEnumerable<Passive>> Search(string name)
        {
            IQueryable<Passive> query = passiveContext.Passives;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Passive> UpdatePassive(Passive passive)
        {
            var result = await passiveContext.Passives
                .FirstOrDefaultAsync(p => p.Id == passive.Id);

            if (result != null)
            {
                result.Name = passive.Name;
                result.Attribute1 = passive.Attribute1;
                result.Attribute2 = passive.Attribute2;
                result.Jutsu1 = passive.Jutsu1;
                result.Jutsu2 = passive.Jutsu2;
                result.Description = passive.Description;
                result.ImagePath = passive.ImagePath;

                await passiveContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
