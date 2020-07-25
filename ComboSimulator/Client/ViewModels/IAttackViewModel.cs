using ComboSimulator.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComboSimulator.Client.ViewModels
{
    public interface IAttackViewModel
    {
        Task<List<Attack>> GetAttackList();
        Task<Attack> GetAttack(long id);
        Task CreateAttack(Attack model);
        Task UpdateAttack(long id, Attack model);
        Task DeleteAttack(long id);
    }
}
