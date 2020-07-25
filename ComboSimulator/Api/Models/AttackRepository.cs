using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public class AttackRepository : IAttackRepository
    {
        private readonly AttackContext attackContext;

        public AttackRepository(AttackContext attackContext)
        {
            this.attackContext = attackContext;
        }

        public async Task<Attack> AddAttack(Attack attack)
        {
            var result = await attackContext.Attacks.AddAsync(attack);
            await attackContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Attack> DeleteAttack(long attackId)
        {
            var result = await attackContext.Attacks
                .FirstOrDefaultAsync(a => a.Id == attackId);
            if (result != null)
            {
                attackContext.Attacks.Remove(result);
                await attackContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Attack> GetAttack(long attackId)
        {
            return await attackContext
                .Attacks.FirstOrDefaultAsync(a => a.Id == attackId);
        }

        public async Task<IEnumerable<Attack>> GetAttacks()
        {
            return await attackContext.Attacks.ToListAsync();
        }

        public async Task<IEnumerable<Attack>> Search(string name)
        {
            IQueryable<Attack> query = attackContext.Attacks;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Attack> UpdateAttack(Attack attack)
        {
            var result = await attackContext.Attacks
                .FirstOrDefaultAsync(a => a.Id == attack.Id);

            if (result != null)
            {
                result.Name = attack.Name;
                result.Attribute1 = attack.Attribute1;
                result.Attribute2 = attack.Attribute2;
                result.Jutsu1 = attack.Jutsu1;
                result.Jutsu2 = attack.Jutsu2;
                result.Causing = attack.Causing;
                result.Effects = attack.Effects;
                result.Description = attack.Description;
                result.ImagePath = attack.ImagePath;

                await attackContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
