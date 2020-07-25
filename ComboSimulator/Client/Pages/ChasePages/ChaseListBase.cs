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

namespace ComboSimulator.Client.Pages.ChasePages
{
    public class ChaseListBase : ComponentBase
    {
        [Inject]
        protected IChaseViewModel ChaseViewModel { get; set; }

        protected string Coords { get; set; }

        public List<Chase> ChaseList { get; set; } = new List<Chase>();
        public List<Chase> FilteredList { get; set; } = new List<Chase>();

        protected ChaseFilter filterChases;

        protected override async Task OnInitializedAsync()
        {
            ChaseList = await ChaseViewModel.GetChaseList();

            FilteredList = ChaseList;
        }

        protected void UpdateFilterList(string filterTerm)
        {
            FilteredList = ChaseList.Where(i =>
                    i.Name.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Chasing.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Description.ToLower().Contains(filterTerm.ToLower()) ||
                    i.Effects.ToLower().Contains(filterTerm.ToLower())
                ).ToList();

            filterChases.RefreshTable();
        }

        protected void mouseMove(MouseEventArgs e)
        {
            Coords = $"X = {e.ClientX}, Y = {e.ClientY}";
        }

        protected void mouseOut()
        {
            Coords = "";
        }
    }
}
