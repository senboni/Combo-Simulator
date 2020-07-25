using ComboSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Server.Models
{
    public interface INinjaRepository
    {
        Task<IEnumerable<Ninja>> Search(string name);
        Task<IEnumerable<Ninja>> GetNinjas();
        Task<Ninja> GetNinja(long ninjaId);
        Task<Ninja> AddNinja(Ninja ninja);
        Task<Ninja> UpdateNinja(Ninja ninja);
        Task<Ninja> DeleteNinja(long ninjaId);
    }
}
