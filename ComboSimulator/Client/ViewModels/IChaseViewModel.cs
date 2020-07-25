using ComboSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Client.ViewModels
{
    public interface IChaseViewModel
    {
        Task<List<Chase>> GetChaseList();
        Task<Chase> GetChase(long id);
        Task CreateChase(Chase model);
        Task UpdateChase(long id, Chase model);
        Task DeleteChase(long id);
    }
}
