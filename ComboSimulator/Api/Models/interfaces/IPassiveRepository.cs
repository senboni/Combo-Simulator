using ComboSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public interface IPassiveRepository
    {
        Task<IEnumerable<Passive>> Search(string name);
        Task<IEnumerable<Passive>> GetPassives();
        Task<Passive> GetPassive(long chaseId);
        Task<Passive> AddPassive(Passive chase);
        Task<Passive> UpdatePassive(Passive chase);
        Task<Passive> DeletePassive(long chaseId);
    }
}
