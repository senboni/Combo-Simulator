using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public class NinjaRepository : INinjaRepository
    {
        private readonly NinjaContext ninjaContext;

        public NinjaRepository(NinjaContext ninjaContext)
        {
            this.ninjaContext = ninjaContext;
        }
        public async Task<Ninja> AddNinja(Ninja ninja)
        {
            var result = await ninjaContext.Ninjas.AddAsync(ninja);
            await ninjaContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Ninja> DeleteNinja(long ninjaId)
        {
            var result = await ninjaContext.Ninjas
                .FirstOrDefaultAsync(n => n.Id == ninjaId);
            if (result != null)
            {
                ninjaContext.Ninjas.Remove(result);
                await ninjaContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Ninja>> GetNinjas()
        {
            return await ninjaContext.Ninjas
                //.Include(n => n.Attacks)
                .ToListAsync();
        }

        public async Task<Ninja> GetNinja(long ninjaId)
        {
            return await ninjaContext.Ninjas
                .FirstOrDefaultAsync(n => n.Id == ninjaId);
        }

        public async Task<IEnumerable<Ninja>> Search(string name)
        {
            IQueryable<Ninja> query = ninjaContext.Ninjas;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(n => n.Name.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Ninja> UpdateNinja(Ninja ninja)
        {
            var result = await ninjaContext.Ninjas
                .FirstOrDefaultAsync(n => n.Id == ninja.Id);

            if (result != null)
            {
                result.Name = ninja.Name;
                result.MysteryId = ninja.MysteryId;
                result.AttackId = ninja.AttackId;
                result.ChaseId1 = ninja.ChaseId1;
                result.ChaseId2 = ninja.ChaseId2;
                result.ChaseId3 = ninja.ChaseId3;
                result.PassiveId1 = ninja.PassiveId1;
                result.PassiveId2 = ninja.PassiveId2;
                result.PassiveId3 = ninja.PassiveId3;
                result.ImagePath = ninja.ImagePath;
                result.Attribute = ninja.Attribute;
                result.Type = ninja.Type;
                result.Stars = ninja.Stars;

                await ninjaContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
