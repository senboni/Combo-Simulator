using ComboSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public interface IMysteryRepository
    {
        Task<IEnumerable<Mystery>> Search(string name);
        Task<IEnumerable<Mystery>> GetMysteries();
        Task<Mystery> GetMystery(long mysteryId);
        Task<Mystery> AddMystery(Mystery mystery);
        Task<Mystery> UpdateMystery(Mystery mystery);
        Task<Mystery> DeleteMystery(long mysteryId);
    }
}
