using ComboSimulator.Client.ViewModels;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Pages.MysteryPages
{
    public class MysteryListBase : ComponentBase
    {
        [Inject]
        private IMysteryViewModel MysteryViewModel { get; set; }

        public List<Mystery> MysteryList { get; set; } = new List<Mystery>();
        public List<Mystery> FilteredList { get; set; } = new List<Mystery>();

        protected MysteryFilter filterMysteries;

        protected override async Task OnInitializedAsync()
        {
            MysteryList = await MysteryViewModel.GetMysteryList();

            FilteredList = MysteryList;
        }

        protected void UpdateFilterList(string filterTerm)
        {
            FilteredList = MysteryList.Where(i =>
                    i.Name.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Description.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Effects.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Chakra.ToString().ToLower().Contains(filterTerm.ToLower())
                ).ToList();

            filterMysteries.RefreshTable();
        }
    }
}
