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

namespace ComboSimulator.Client.Pages.ChasePages
{
    public class ChaseInfoBase : ComponentBase
    {
        [Inject]
        protected IChaseViewModel ChaseViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Chase ChaseModel { get; set; } = new Chase();
        public string EditRoute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EditRoute = $"chases/edit/{Id}";

            ChaseModel = await ChaseViewModel.GetChase(long.Parse(Id));
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
                await ChaseViewModel.DeleteChase(long.Parse(Id));
                NavigationManager.NavigateTo("chases");
            }
        }
    }
}
