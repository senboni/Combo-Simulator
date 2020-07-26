using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.ViewModels
{
    public class NinjaViewModel : INinjaViewModel
    {
        private HttpClient HttpClient { get; set; }

        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public long MysteryId { get; set; }
        [Required]
        public long AttackId { get; set; }
        public long? ChaseId1 { get; set; }
        public long? ChaseId2 { get; set; }
        public long? ChaseId3 { get; set; }
        public long? PassiveId1 { get; set; }
        public long? PassiveId2 { get; set; }
        public long? PassiveId3 { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }
        [Required]
        [MaxLength(10)]
        public string Attribute { get; set; }
        [MaxLength(100)]
        public string Type { get; set; }
        [Required]
        public int Stars { get; set; }

        //other table
        public Mystery Mystery { get; set; } = new Mystery();
        public Attack Attack { get; set; } = new Attack();

        public Chase[] Chases = new Chase[3];

        public Passive[] Passives = new Passive[3];

        public NinjaViewModel()
        {
            AttackId = 1;
            MysteryId = 1;
            ImagePath = "noimage.png";
            Attribute = "Fire";
            Stars = 1;
        }

        public NinjaViewModel(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public static implicit operator NinjaViewModel(Ninja i)
        {
            return new NinjaViewModel
            {
                Id = i.Id,
                Name = i.Name,
                MysteryId = i.MysteryId,
                AttackId = i.AttackId,
                ChaseId1 = i.ChaseId1,
                ChaseId2 = i.ChaseId2,
                ChaseId3 = i.ChaseId3,
                PassiveId1 = i.PassiveId1,
                PassiveId2 = i.PassiveId2,
                PassiveId3 = i.PassiveId3,
                ImagePath = i.ImagePath,
                Attribute = i.Attribute,
                Type = i.Type,
                Stars = i.Stars,
                Mystery = i.Mystery,
                Attack = i.Attack,
                Chases = i.Chases,
                Passives = i.Passives
            };
        }
        public static implicit operator Ninja(NinjaViewModel i)
        {
            return new Ninja
            {
                Id = i.Id,
                Name = i.Name,
                MysteryId = i.MysteryId,
                AttackId = i.AttackId,
                ChaseId1 = i.ChaseId1,
                ChaseId2 = i.ChaseId2,
                ChaseId3 = i.ChaseId3,
                PassiveId1 = i.PassiveId1,
                PassiveId2 = i.PassiveId2,
                PassiveId3 = i.PassiveId3,
                ImagePath = i.ImagePath,
                Attribute = i.Attribute,
                Type = i.Type,
                Stars = i.Stars
            };
        }

        public async Task<List<Ninja>> GetNinjaList()
        {
            return await HttpClient.GetFromJsonAsync<List<Ninja>>("Ninja");
        }
        public async Task<Ninja> GetNinja(long id)
        {
            return await HttpClient.GetFromJsonAsync<Ninja>($"Ninja/{id}");
        }
        public async Task CreateNinja(Ninja model)
        {
            await HttpClient.PostAsJsonAsync("Ninja", model);
        }
        public async Task UpdateNinja(long id, Ninja model)
        {
            await HttpClient.PutAsJsonAsync($"Ninja/{id}", model);
        }
        public async Task DeleteNinja(long id)
        {
            await HttpClient.DeleteAsync($"Ninja/{Id}");
        }
    }
}
