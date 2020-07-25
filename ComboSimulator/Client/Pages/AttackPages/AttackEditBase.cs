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

namespace ComboSimulator.Client.Pages.AttackPages
{
    public class AttackEditBase : ComponentBase
    {
        [Inject]
        protected IAttackViewModel AttackViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Attack AttackModel { get; set; } = new Attack();

        public AttackViewModel AttackViewModel { get; set; } = new AttackViewModel();

        public string NullOption { get; set; } = "None";
        public string BackRoute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BackRoute = $"attacks/{Id}";

            AttackModel = await AttackViewModelService.GetAttack(long.Parse(Id));

            AttackViewModel = AttackModel;
        }

        // validation
        protected async Task HandleValidSubmit()
        {
            if (AttackViewModel.Attribute1 == NullOption) AttackViewModel.Attribute1 = null;
            if (AttackViewModel.Attribute2 == NullOption) AttackViewModel.Attribute2 = null;
            if (AttackViewModel.Jutsu1 == NullOption) AttackViewModel.Jutsu1 = null;
            if (AttackViewModel.Jutsu2 == NullOption) AttackViewModel.Jutsu2 = null;
            if (AttackViewModel.Causing == NullOption) AttackViewModel.Causing = null;

            AttackModel = AttackViewModel;

            await AttackViewModelService.UpdateAttack(long.Parse(Id), AttackModel);

            NavigationManager.NavigateTo("attacks");
        }

        protected async Task HandleInvalidSubmit()
        {
            if (AttackViewModel.Attribute1 == NullOption && AttackViewModel.Jutsu1 != AttackViewModel.Jutsu2)
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
