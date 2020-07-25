using ComboSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Server.Models
{
    public interface IPassiveRepository
    {
        Task<IEnumerable<Passive>> Search(string name);
        Task<IEnumerable<Passive>> GetPassives();
        Task<Passive> GetPassive(long passiveId);
        Task<Passive> AddPassive(Passive passive);
        Task<Passive> UpdatePassive(Passive passive);
        Task<Passive> DeletePassive(long passiveId);
    }
}
