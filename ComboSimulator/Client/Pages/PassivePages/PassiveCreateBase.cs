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
    public class PassiveCreateBase : ComponentBase
    {
        [Inject]
        protected IPassiveViewModel PassiveViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Passive PassiveModel { get; set; } = new Passive();
        public PassiveViewModel PassiveViewModel { get; set; } = new PassiveViewModel();

        public string NullOption { get; set; } = "None";

        // validation
        protected async Task HandleValidCreate()
        {
            if (PassiveViewModel.Attribute1 == NullOption) PassiveViewModel.Attribute1 = null;
            if (PassiveViewModel.Attribute2 == NullOption) PassiveViewModel.Attribute2 = null;
            if (PassiveViewModel.Jutsu1 == NullOption) PassiveViewModel.Jutsu1 = null;
            if (PassiveViewModel.Jutsu2 == NullOption) PassiveViewModel.Jutsu2 = null;

            PassiveModel = PassiveViewModel;

            await PassiveViewModelService.CreatePassive(PassiveModel);

            Back_Click();
        }

        protected async Task HandleInvalidCreate()
        {
            if (PassiveViewModel.Attribute1 == NullOption && PassiveViewModel.Jutsu1 != PassiveViewModel.Jutsu2)
            {
                await HandleValidCreate();
            }
            else
            {
                AlertDisplay.Show(true);
            }
        }

        // edit confirmation popup
        public ConfirmBase CreateConfirmation { get; set; }

        protected void Create_Click()
        {
            AlertDisplay.Show(false);
            CreateConfirmation.Show();
        }

        protected async Task ConfirmCreate_Click(bool createConfirmed)
        {
            if (createConfirmed == true)
            {
                await HandleValidCreate();
            }
        }

        protected void Back_Click()
        {
            NavigationManager.NavigateTo("passives");
        }

        // validation alert
        public AlertBase AlertDisplay { get; set; }
    }
}
