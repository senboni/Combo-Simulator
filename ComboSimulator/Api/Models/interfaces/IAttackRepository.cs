using ComboSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public interface IAttackRepository
    {
        Task<IEnumerable<Attack>> Search(string name);
        Task<IEnumerable<Attack>> GetAttacks();
        Task<Attack> GetAttack(long attackId);
        Task<Attack> AddAttack(Attack attack);
        Task<Attack> UpdateAttack(Attack attack);
        Task<Attack> DeleteAttack(long attackId);
    }
}
