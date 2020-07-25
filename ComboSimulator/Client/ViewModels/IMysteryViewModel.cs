using ComboSimulator.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComboSimulator.Client.ViewModels
{
    public interface IMysteryViewModel
    {
        Task<List<Mystery>> GetMysteryList();
        Task<Mystery> GetMystery(long id);
        Task CreateMystery(Mystery model);
        Task UpdateMystery(long id, Mystery model);
        Task DeleteMystery(long id);
    }
}