using ComboSimulator.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComboSimulator.Client.ViewModels
{
    public interface IPassiveViewModel
    {
        Task<List<Passive>> GetPassiveList();
        Task<Passive> GetPassive(long id);
        Task CreatePassive(Passive model);
        Task UpdatePassive(long id, Passive model);
        Task DeletePassive(long id);
    }
}
