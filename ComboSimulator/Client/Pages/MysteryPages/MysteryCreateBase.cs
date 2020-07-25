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
    public class MysteryCreateBase : ComponentBase
    {
        [Inject]
        private IMysteryViewModel MysteryViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Mystery MysteryModel { get; set; } = new Mystery();
        public MysteryViewModel MysteryViewModel { get; set; } = new MysteryViewModel();

        public string stringBFC { get; set; } = "1";
        public string stringCD { get; set; } = "2";
        public string stringChakra { get; set; } = "40";

        public string NullOption { get; set; } = "None";

        // validation
        protected async Task HandleValidCreate()
        {
            if (MysteryViewModel.Attribute1 == NullOption) MysteryViewModel.Attribute1 = null;
            if (MysteryViewModel.Attribute2 == NullOption) MysteryViewModel.Attribute2 = null;
            if (MysteryViewModel.Jutsu1 == NullOption) MysteryViewModel.Jutsu1 = null;
            if (MysteryViewModel.Jutsu2 == NullOption) MysteryViewModel.Jutsu2 = null;
            if (MysteryViewModel.Causing == NullOption) MysteryViewModel.Causing = null;

            MysteryViewModel.BfCooldown = int.Parse(stringBFC);
            MysteryViewModel.Cooldown = int.Parse(stringCD);
            MysteryViewModel.Chakra = int.Parse(stringChakra);

            MysteryModel = MysteryViewModel;

            await MysteryViewModelService.CreateMystery(MysteryModel);

            Back_Click();
        }

        protected async Task HandleInvalidCreate()
        {
            if (MysteryViewModel.Attribute1 == NullOption && MysteryViewModel.Jutsu1 != MysteryViewModel.Jutsu2)
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
            NavigationManager.NavigateTo("mysteries");
        }

        // validation alert
        public AlertBase AlertDisplay { get; set; }
    }
}
