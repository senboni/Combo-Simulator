using ComboSimulator.Client.Pages.NinjaPages;
using ComboSimulator.Client.ViewModels;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Pages.SimulatorPages
{
    public class SimulatorBase : ComponentBase
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        private INinjaViewModel NinjaViewModel { get; set; }

        public List<Ninja> NinjaList { get; set; } = new List<Ninja>();
        public List<Ninja> FilteredList { get; set; } = new List<Ninja>();

        protected NinjaFilter filterNinjas;

        protected ElementReference ninRef;

        protected string[] BackgroundImages = new string[] { "finalvalley.webp", "canyon.webp", "konohacenter.webp", "firetemple.webp", "tanzaku.webp",
                                                                "forestofdeath.webp", "sand.webp", "mist.webp", "forestbridge.webp", "konohagate.webp" };
        protected int randomNumber;

        protected override async Task OnInitializedAsync()
        {
            Random random = new Random();
            randomNumber = random.Next(0, BackgroundImages.Length);

            NinjaList = await NinjaViewModel.GetNinjaList();

            foreach (Ninja i in NinjaList)
            {
                i.Mystery = await NinjaViewModel.GetMystery(i.MysteryId);
                i.Attack = await NinjaViewModel.GetAttack(i.AttackId);

                if (i.ChaseId1 != null) i.Chases[0] = await NinjaViewModel.GetChase((long)i.ChaseId1);
                if (i.ChaseId2 != null) i.Chases[1] = await NinjaViewModel.GetChase((long)i.ChaseId2);
                if (i.ChaseId3 != null) i.Chases[2] = await NinjaViewModel.GetChase((long)i.ChaseId3);

                if (i.PassiveId1 != null) i.Passives[0] = await NinjaViewModel.GetPassive((long)i.PassiveId1);
                if (i.PassiveId2 != null) i.Passives[1] = await NinjaViewModel.GetPassive((long)i.PassiveId2);
                if (i.PassiveId3 != null) i.Passives[2] = await NinjaViewModel.GetPassive((long)i.PassiveId3);
            }

            FilteredList = NinjaList;
        }

        protected void UpdateFilterList(string filterTerm)
        {
            FilteredList = NinjaList.Where(i =>
                    i.Name.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Attribute.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Attack.Name.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Mystery.Name.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Type.ToLower().Contains(filterTerm.ToLower())
                ).ToList();

            filterNinjas.RefreshTable();
        }

        protected async Task MouseDown(Ninja ninja, MouseEventArgs e)
        {
            await JSRuntime.InvokeAsync<Ninja>("nClicked", ninja, e, ninja.Chases, ninja.Passives);
        }

        protected async Task MouseOver(Ninja ninja)
        {
            await JSRuntime.InvokeAsync<Ninja>("nHovered", ninja, ninja.Chases, ninja.Passives);
        }

        protected async Task MouseOut()
        {
            await JSRuntime.InvokeVoidAsync("notHovered", ninRef);
        }
    }
}
