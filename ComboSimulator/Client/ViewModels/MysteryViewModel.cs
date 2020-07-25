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
    public class MysteryViewModel : IMysteryViewModel
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
        [MaxLength(20)]
        public string Causing { get; set; }
        [MaxLength(50)]
        public string Effects { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }
        public bool Prompt { get; set; }
        public int BfCooldown { get; set; }
        public int Cooldown { get; set; }
        public int Chakra { get; set; }

        public MysteryViewModel()
        {
            ImagePath = "noimage.png";
            Prompt = true;
            BfCooldown = 1;
            Cooldown = 2;
            Chakra = 40;
        }

        public MysteryViewModel(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public static implicit operator MysteryViewModel(Mystery i)
        {
            return new MysteryViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Attribute1 = i.Attribute1,
                Attribute2 = i.Attribute2,
                Jutsu1 = i.Jutsu1,
                Jutsu2 = i.Jutsu2,
                Causing = i.Causing,
                Effects = i.Effects,
                Description = i.Description,
                ImagePath = i.ImagePath,
                Prompt = i.Prompt,
                BfCooldown = i.BfCooldown,
                Cooldown = i.Cooldown,
                Chakra = i.Chakra
            };
        }
        public static implicit operator Mystery(MysteryViewModel i)
        {
            return new Mystery
            {
                Id = i.Id,
                Name = i.Name,
                Attribute1 = i.Attribute1,
                Attribute2 = i.Attribute2,
                Jutsu1 = i.Jutsu1,
                Jutsu2 = i.Jutsu2,
                Causing = i.Causing,
                Effects = i.Effects,
                Description = i.Description,
                ImagePath = i.ImagePath,
                Prompt = i.Prompt,
                BfCooldown = i.BfCooldown,
                Cooldown = i.Cooldown,
                Chakra = i.Chakra
            };
        }

        public async Task<List<Mystery>> GetMysteryList()
        {
            return await HttpClient.GetFromJsonAsync<List<Mystery>>("Mystery");
        }
        public async Task<Mystery> GetMystery(long id)
        {
            return await HttpClient.GetFromJsonAsync<Mystery>($"Mystery/{id}");
        }
        public async Task CreateMystery(Mystery model)
        {
            await HttpClient.PostAsJsonAsync("Mystery", model);
        }
        public async Task UpdateMystery(long id, Mystery model)
        {
            await HttpClient.PutAsJsonAsync($"Mystery/{id}", model);
        }
        public async Task DeleteMystery(long id)
        {
            await HttpClient.DeleteAsync($"Mystery/{Id}");
        }
    }
}
