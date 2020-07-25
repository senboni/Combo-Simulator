using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using ComboSimulator.Client.ViewModels;

namespace ComboSimulator.Client.Pages.PassivePages
{
    public class PassiveListBase : ComponentBase
    {
        [Inject]
        protected IPassiveViewModel PassiveViewModel { get; set; }

        protected List<Passive> PassiveList { get; set; }
        protected List<Passive> FilteredList { get; set; }

        protected PassiveFilter filterPassives;

        protected override async Task OnInitializedAsync()
        {
            PassiveList = await PassiveViewModel.GetPassiveList();

            FilteredList = PassiveList;
        }

        protected void UpdateFilterList(string filterTerm)
        {
            FilteredList = PassiveList.Where(i =>
                    i.Name.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Description.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Effects.ToLower().Contains(filterTerm.ToLower())
                ).ToList();

            filterPassives.RefreshTable();
        }
    }
}
