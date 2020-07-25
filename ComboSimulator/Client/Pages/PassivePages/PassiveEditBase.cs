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
    public class PassiveEditBase : ComponentBase
    {
        [Inject]
        protected IPassiveViewModel PassiveViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Passive PassiveModel { get; set; } = new Passive();
        public PassiveViewModel PassiveViewModel { get; set; } = new PassiveViewModel();
        public string NullOption { get; set; } = "None";
        public string BackRoute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BackRoute = $"passives/{Id}";

            PassiveModel = await PassiveViewModelService.GetPassive(long.Parse(Id));

            PassiveViewModel = PassiveModel;
        }

        // validation
        protected async Task HandleValidSubmit()
        {
            if (PassiveViewModel.Attribute1 == NullOption) PassiveViewModel.Attribute1 = null;
            if (PassiveViewModel.Attribute2 == NullOption) PassiveViewModel.Attribute2 = null;
            if (PassiveViewModel.Jutsu1 == NullOption) PassiveViewModel.Jutsu1 = null;
            if (PassiveViewModel.Jutsu2 == NullOption) PassiveViewModel.Jutsu2 = null;

            PassiveModel = PassiveViewModel;

            await PassiveViewModelService.UpdatePassive(long.Parse(Id), PassiveModel);

            NavigationManager.NavigateTo("passives");
        }

        protected async Task HandleInvalidSubmit()
        {
            if (PassiveViewModel.Attribute1 == NullOption && PassiveViewModel.Jutsu1 != PassiveViewModel.Jutsu2)
            {
                await HandleValidSubmit();
            }
            else
            {
                AlertDisplay.Show(true);
            }
        }

        // edit confirmation popup
        public ConfirmBase EditConfirmation { get; set; }

        protected void Edit_Click()
        {
            AlertDisplay.Show(false);
            EditConfirmation.Show();
        }

        protected async Task ConfirmEdit_Click(bool editConfirmed)
        {
            if (editConfirmed == true)
            {
                await HandleValidSubmit();
            }
        }

        // validation alert
        public AlertBase AlertDisplay { get; set; }
    }
}
