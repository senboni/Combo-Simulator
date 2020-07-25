using ComboSimulator.Client.Shared;
using ComboSimulator.Client.ViewModels;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Pages.ChasePages
{
    public class ChaseEditBase : ComponentBase
    {
        [Inject]
        protected IChaseViewModel ChaseViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Chase ChaseModel { get; set; } = new Chase();

        public ChaseViewModel ChaseViewModel { get; set; } = new ChaseViewModel();
        public string stringHits { get; set; } = "1";
        public string stringRepeat { get; set; } = "1";

        public string NullOption { get; set; } = "None";
        public string BackRoute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ChaseModel = await ChaseViewModelService.GetChase(long.Parse(Id));

            BackRoute = $"chases/{Id}";

            ChaseViewModel = ChaseModel;
        }

        // validation
        protected async Task HandleValidSubmit()
        {
            if (ChaseViewModel.Attribute1 == NullOption) ChaseViewModel.Attribute1 = null;
            if (ChaseViewModel.Attribute2 == NullOption) ChaseViewModel.Attribute2 = null;
            if (ChaseViewModel.Jutsu1 == NullOption) ChaseViewModel.Jutsu1 = null;
            if (ChaseViewModel.Jutsu2 == NullOption) ChaseViewModel.Jutsu2 = null;
            if (ChaseViewModel.Causing == NullOption) ChaseViewModel.Causing = null;

            ChaseViewModel.Hits = int.Parse(stringHits);
            ChaseViewModel.Repeat = int.Parse(stringRepeat);

            ChaseModel = ChaseViewModel;

            await ChaseViewModelService.UpdateChase(long.Parse(Id), ChaseModel);

            NavigationManager.NavigateTo("chases");
        }

        protected async Task HandleInvalidSubmit()
        {
            if (ChaseViewModel.Attribute1 == NullOption && ChaseViewModel.Jutsu1 != ChaseViewModel.Jutsu2)
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
