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
    public class ChaseViewModel : IChaseViewModel
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
        [MaxLength(20), Required]
        public string Chasing { get; set; }
        [MaxLength(20)]
        public string Causing { get; set; }
        [MaxLength(50)]
        public string Effects { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }
        [Required]
        public int Hits { get; set; }
        [Required]
        public int Repeat { get; set; }

        public ChaseViewModel()
        {
            ImagePath = "noimage.png";
            Chasing = "LowFloat";
            Hits = 1;
            Repeat = 1;
        }

        public ChaseViewModel(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public static implicit operator ChaseViewModel(Chase i)
        {
            return new ChaseViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Attribute1 = i.Attribute1,
                Attribute2 = i.Attribute2,
                Jutsu1 = i.Jutsu1,
                Jutsu2 = i.Jutsu2,
                Chasing = i.Chasing,
                Causing = i.Causing,
                Effects = i.Effects,
                Description = i.Description,
                ImagePath = i.ImagePath,
                Hits = i.Hits,
                Repeat = i.Repeat
            };
        }
        public static implicit operator Chase(ChaseViewModel i)
        {
            return new Chase
            {
                Id = i.Id,
                Name = i.Name,
                Attribute1 = i.Attribute1,
                Attribute2 = i.Attribute2,
                Jutsu1 = i.Jutsu1,
                Jutsu2 = i.Jutsu2,
                Chasing = i.Chasing,
                Causing = i.Causing,
                Effects = i.Effects,
                Description = i.Description,
                ImagePath = i.ImagePath,
                Hits = i.Hits,
                Repeat = i.Repeat
            };
        }

        public async Task<List<Chase>> GetChaseList()
        {
            return await HttpClient.GetFromJsonAsync<List<Chase>>("Chase");
        }
        public async Task<Chase> GetChase(long id)
        {
            return await HttpClient.GetFromJsonAsync<Chase>($"Chase/{id}");
        }
        public async Task CreateChase(Chase model)
        {
            await HttpClient.PostAsJsonAsync("Chase", model);
        }
        public async Task UpdateChase(long id, Chase model)
        {
            await HttpClient.PutAsJsonAsync($"Chase/{id}", model);
        }
        public async Task DeleteChase(long id)
        {
            await HttpClient.DeleteAsync($"Chase/{Id}");
        }
    }
}
