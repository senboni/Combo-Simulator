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

namespace ComboSimulator.Client.Pages.PassivePages
{
    public class PassiveInfoBase : ComponentBase
    {
        [Inject]
        protected IPassiveViewModel PassiveViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string Id { get; set; }

        public Passive Passive { get; set; } = new Passive();
        public string EditRoute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EditRoute = $"passives/edit/{Id}";

            Passive = await PassiveViewModel.GetPassive(long.Parse(Id));
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
                await PassiveViewModel.DeletePassive(long.Parse(Id));
                NavigationManager.NavigateTo("passives");
            }
        }
    }
}
