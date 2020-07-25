using ComboSimulator.Client.Shared;
using ComboSimulator.Client.ViewModels;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Pages.MysteryPages
{
    public class MysteryEditBase : ComponentBase
    {
        [Inject]
        private IMysteryViewModel MysteryViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Mystery MysteryModel { get; set; } = new Mystery();

        public MysteryViewModel MysteryViewModel { get; set; } = new MysteryViewModel();

        public string stringBFC { get; set; }
        public string stringCD { get; set; }
        public string stringChakra { get; set; }

        public string NullOption { get; set; } = "None";
        public string BackRoute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MysteryModel = await MysteryViewModelService.GetMystery(long.Parse(Id));

            stringBFC = Convert.ToString(MysteryViewModel.BfCooldown);
            stringCD = Convert.ToString(MysteryViewModel.Cooldown);
            stringChakra = Convert.ToString(MysteryViewModel.Chakra);

            BackRoute = $"mysteries/{Id}";

            MysteryViewModel = MysteryModel;
        }

        // validation
        protected async Task HandleValidSubmit()
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

            await MysteryViewModelService.UpdateMystery(long.Parse(Id), MysteryModel);

            NavigationManager.NavigateTo("mysteries");
        }

        protected async Task HandleInvalidSubmit()
        {
            if (MysteryViewModel.Attribute1 == NullOption && MysteryViewModel.Jutsu1 != MysteryViewModel.Jutsu2)
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
