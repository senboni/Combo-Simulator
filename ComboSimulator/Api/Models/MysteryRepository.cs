using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public class MysteryRepository : IMysteryRepository
    {
        private readonly MysteryContext mysteryContext;

        public MysteryRepository(MysteryContext mysteryContext)
        {
            this.mysteryContext = mysteryContext;
        }
        public async Task<Mystery> AddMystery(Mystery mystery)
        {
            var result = await mysteryContext.Mysteries.AddAsync(mystery);
            await mysteryContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Mystery> DeleteMystery(long mysteryId)
        {
            var result = await mysteryContext.Mysteries
                .FirstOrDefaultAsync(a => a.Id == mysteryId);
            if (result != null)
            {
                mysteryContext.Mysteries.Remove(result);
                await mysteryContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Mystery>> GetMysteries()
        {
            return await mysteryContext.Mysteries.ToListAsync();
        }

        public async Task<Mystery> GetMystery(long mysteryId)
        {
            return await mysteryContext
                .Mysteries.FirstOrDefaultAsync(m => m.Id == mysteryId);
        }

        public async Task<IEnumerable<Mystery>> Search(string name)
        {
            IQueryable<Mystery> query = mysteryContext.Mysteries;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Mystery> UpdateMystery(Mystery mystery)
        {
            var result = await mysteryContext.Mysteries
                .FirstOrDefaultAsync(m => m.Id == mystery.Id);

            if (result != null)
            {
                result.Name = mystery.Name;
                result.Attribute1 = mystery.Attribute1;
                result.Attribute2 = mystery.Attribute2;
                result.Jutsu1 = mystery.Jutsu1;
                result.Jutsu2 = mystery.Jutsu2;
                result.Causing = mystery.Causing;
                result.Effects = mystery.Effects;
                result.Description = mystery.Description;
                result.ImagePath = mystery.ImagePath;
                result.Prompt = mystery.Prompt;
                result.BfCooldown = mystery.BfCooldown;
                result.Cooldown = mystery.Cooldown;
                result.Chakra = mystery.Chakra;

                await mysteryContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
