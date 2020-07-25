using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ComboSimulator.Server.Models;
using ComboSimulator.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ComboSimulator.Client.ViewModels
{
    public class PassiveViewModel : IPassiveViewModel
    {
        private HttpClient HttpClient { get; set; }

        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [UnlikeExceptNull("Attribute2", ErrorMessage = "Attribute 1 & 2 must not equal")]
        [MaxLength(10)]
        public string Attribute1 { get; set; }
        [UnlikeExceptNull("Attribute1", ErrorMessage = "Attribute 1 & 2 must not equal")]
        [MaxLength(10)]
        public string Attribute2 { get; set; }
        [UnlikeExceptNull("Jutsu2", ErrorMessage = "Jutsu 1 & 2 must not equal")]
        [MaxLength(10)]
        public string Jutsu1 { get; set; }
        [UnlikeExceptNull("Jutsu1", ErrorMessage = "Jutsu 1 & 2 must not equal")]
        [MaxLength(10)]
        public string Jutsu2 { get; set; }
        [MaxLength(50)]
        public string Effects { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }

        public PassiveViewModel()
        {
            ImagePath = "noimage.png";
        }

        public PassiveViewModel(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public static implicit operator PassiveViewModel(Passive i)
        {
            return new PassiveViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Attribute1 = i.Attribute1,
                Attribute2 = i.Attribute2,
                Jutsu1 = i.Jutsu1,
                Jutsu2 = i.Jutsu2,
                Effects = i.Effects,
                Description = i.Description,
                ImagePath = i.ImagePath
            };
        }
        public static implicit operator Passive(PassiveViewModel i)
        {
            return new Passive
            {
                Id = i.Id,
                Name = i.Name,
                Attribute1 = i.Attribute1,
                Attribute2 = i.Attribute2,
                Jutsu1 = i.Jutsu1,
                Jutsu2 = i.Jutsu2,
                Effects = i.Effects,
                Description = i.Description,
                ImagePath = i.ImagePath
            };
        }

        public async Task<List<Passive>> GetPassiveList()
        {
            return await HttpClient.GetFromJsonAsync<List<Passive>>("Passive");
        }

        public async Task<Passive> GetPassive(long id)
        {
            return await HttpClient.GetFromJsonAsync<Passive>($"Passive/{id}");
        }

        public async Task CreatePassive(Passive model)
        {
            await HttpClient.PostAsJsonAsync("Passive", model);
        }

        public async Task UpdatePassive(long id, Passive model)
        {
            await HttpClient.PutAsJsonAsync($"Passive/{id}", model);
        }

        public async Task DeletePassive(long id)
        {
            await HttpClient.DeleteAsync($"Passive/{Id}");
        }
    }
}
