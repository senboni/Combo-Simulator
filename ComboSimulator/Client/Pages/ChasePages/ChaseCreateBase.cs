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
    public class ChaseCreateBase : ComponentBase
    {
        [Inject]
        protected IChaseViewModel ChaseViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Chase ChaseModel { get; set; } = new Chase();
        public ChaseViewModel ChaseViewModel { get; set; } = new ChaseViewModel { Chasing = "LowFloat" };

        public string stringHits { get; set; } = "1";
        public string stringRepeat { get; set; } = "1";

        public string NullOption { get; set; } = "None";

        // validation
        protected async Task HandleValidCreate()
        {
            if (ChaseViewModel.Attribute1 == NullOption) ChaseViewModel.Attribute1 = null;
            if (ChaseViewModel.Attribute2 == NullOption) ChaseViewModel.Attribute2 = null;
            if (ChaseViewModel.Jutsu1 == NullOption) ChaseViewModel.Jutsu1 = null;
            if (ChaseViewModel.Jutsu2 == NullOption) ChaseViewModel.Jutsu2 = null;
            if (ChaseViewModel.Causing == NullOption) ChaseViewModel.Causing = null;

            ChaseViewModel.Hits = int.Parse(stringHits);
            ChaseViewModel.Repeat = int.Parse(stringRepeat);

            ChaseModel = ChaseViewModel;

            await ChaseViewModelService.CreateChase(ChaseModel);

            Back_Click();
        }

        protected async Task HandleInvalidCreate()
        {
            if (ChaseViewModel.Attribute1 == NullOption && ChaseViewModel.Jutsu1 != ChaseViewModel.Jutsu2)
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
            NavigationManager.NavigateTo("chases");
        }

        // validation alert
        public AlertBase AlertDisplay { get; set; }
    }
}
