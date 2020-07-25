using ComboSimulator.Client.Shared;
using ComboSimulator.Client.ViewModels;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Pages.MysteryPages
{
    public class MysteryInfoBase : ComponentBase
    {
        [Inject]
        private IMysteryViewModel MysteryViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Mystery MysteryModel { get; set; } = new Mystery();
        public string EditRoute { get; set; }

        protected async override Task OnInitializedAsync()
        {
            EditRoute = $"mysteries/edit/{Id}";

            MysteryModel = await MysteryViewModel.GetMystery(long.Parse(Id));
        }

        // delete button

        public ConfirmBase DeleteConfirmation { get; set; }
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed == true)
            {
                await MysteryViewModel.DeleteMystery(long.Parse(Id));
                NavigationManager.NavigateTo("mysteries");
            }
        }
    }
}
