using ComboSimulator.Client.ViewModels;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Pages.NinjaPages
{
    public class NinjaListBase : ComponentBase
    {
        [Inject]
        private INinjaViewModel NinjaViewModel { get; set; }
        [Inject]
        private IMysteryViewModel MysteryViewModel { get; set; }
        [Inject]
        private IAttackViewModel AttackViewModel { get; set; }
        [Inject]
        private IChaseViewModel ChaseViewModel { get; set; }
        [Inject]
        private IPassiveViewModel PassiveViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Ninja> NinjaList { get; set; } = new List<Ninja>();
        public List<Ninja> FilteredList { get; set; } = new List<Ninja>();

        protected NinjaFilter filterNinjas;

        protected override async Task OnInitializedAsync()
        {
            NinjaList = await NinjaViewModel.GetNinjaList();

            foreach (Ninja i in NinjaList)
            {
                i.Mystery = await MysteryViewModel.GetMystery(i.MysteryId);
                i.Attack = await AttackViewModel.GetAttack(i.AttackId);

                if (i.ChaseId1 != null) i.Chases[0] = await ChaseViewModel.GetChase((long)i.ChaseId1);
                if (i.ChaseId2 != null) i.Chases[1] = await ChaseViewModel.GetChase((long)i.ChaseId2);
                if (i.ChaseId3 != null) i.Chases[2] = await ChaseViewModel.GetChase((long)i.ChaseId3);

                if (i.PassiveId1 != null) i.Passives[0] = await PassiveViewModel.GetPassive((long)i.PassiveId1);
                if (i.PassiveId2 != null) i.Passives[1] = await PassiveViewModel.GetPassive((long)i.PassiveId2);
                if (i.PassiveId3 != null) i.Passives[2] = await PassiveViewModel.GetPassive((long)i.PassiveId3);
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
    }
}
