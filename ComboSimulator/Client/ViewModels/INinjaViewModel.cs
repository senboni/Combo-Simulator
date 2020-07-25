using ComboSimulator.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComboSimulator.Client.ViewModels
{
    public interface INinjaViewModel
    {
        Task<List<Ninja>> GetNinjaList();
        Task<Ninja> GetNinja(long id);
        Task CreateNinja(Ninja model);
        Task UpdateNinja(long id, Ninja model);
        Task DeleteNinja(long id);

        Task<List<Mystery>> GetMysteryList();
        Task<Mystery> GetMystery(long id);

        Task<List<Attack>> GetAttackList();
        Task<Attack> GetAttack(long id);

        Task<List<Chase>> GetChaseList();
        Task<Chase> GetChase(long? id);

        Task<List<Passive>> GetPassiveList();
        Task<Passive> GetPassive(long? id);
    }
}