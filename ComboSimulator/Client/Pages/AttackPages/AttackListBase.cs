using ComboSimulator.Client.ViewModels;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Pages.AttackPages
{
    public class AttackListBase : ComponentBase
    {
        [Inject]
        protected IAttackViewModel AttackViewModel { get; set; }

        public List<Attack> AttackList { get; set; } = new List<Attack>();
        public List<Attack> FilteredList { get; set; } = new List<Attack>();

        protected AttackFilter filterAttacks;

        protected override async Task OnInitializedAsync()
        {
            AttackList = await AttackViewModel.GetAttackList();

            FilteredList = AttackList;
        }

        protected void UpdateFilterList(string filterTerm)
        {
            FilteredList = AttackList.Where(i =>
                    i.Name.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Causing.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Description.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Effects.ToLower().Contains(filterTerm.ToLower())
                ).ToList();

            filterAttacks.RefreshTable();
        }
    }
}
