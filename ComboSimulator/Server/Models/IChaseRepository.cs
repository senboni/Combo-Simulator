using ComboSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Server.Models
{
    public interface IChaseRepository
    {
        Task<IEnumerable<Chase>> Search(string name);
        Task<IEnumerable<Chase>> GetChases();
        Task<Chase> GetChase(long chaseId);
        Task<Chase> AddChase(Chase chase);
        Task<Chase> UpdateChase(Chase chase);
        Task<Chase> DeleteChase(long chaseId);
    }
}
