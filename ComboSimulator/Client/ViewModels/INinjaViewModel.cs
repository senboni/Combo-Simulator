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
    }
}