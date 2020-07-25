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
    public class AttackViewModel : IAttackViewModel
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

        public AttackViewModel()
        {
            ImagePath = "noimage.png";
        }

        public AttackViewModel(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public static implicit operator AttackViewModel(Attack i)
        {
            return new AttackViewModel
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
                ImagePath = i.ImagePath
            };
        }
        public static implicit operator Attack(AttackViewModel i)
        {
            return new Attack
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
                ImagePath = i.ImagePath
            };
        }

        public async Task<List<Attack>> GetAttackList()
        {
            return await HttpClient.GetFromJsonAsync<List<Attack>>("Attack");
        }
        public async Task<Attack> GetAttack(long id)
        {
            return await HttpClient.GetFromJsonAsync<Attack>($"Attack/{id}");
        }
        public async Task CreateAttack(Attack model)
        {
            await HttpClient.PostAsJsonAsync("Attack", model);
        }
        public async Task UpdateAttack(long id, Attack model)
        {
            await HttpClient.PutAsJsonAsync($"Attack/{id}", model);
        }
        public async Task DeleteAttack(long id)
        {
            await HttpClient.DeleteAsync($"Attack/{Id}");
        }
    }
}
