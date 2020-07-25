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
    public class AttackCreateBase : ComponentBase
    {
        [Inject]
        protected IAttackViewModel AttackViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Attack AttackModel { get; set; } = new Attack();
        public AttackViewModel AttackViewModel { get; set; } = new AttackViewModel();

        public string NullOption { get; set; } = "None";

        // validation
        protected async Task HandleValidCreate()
        {
            if (AttackViewModel.Attribute1 == NullOption) AttackViewModel.Attribute1 = null;
            if (AttackViewModel.Attribute2 == NullOption) AttackViewModel.Attribute2 = null;
            if (AttackViewModel.Jutsu1 == NullOption) AttackViewModel.Jutsu1 = null;
            if (AttackViewModel.Jutsu2 == NullOption) AttackViewModel.Jutsu2 = null;
            if (AttackViewModel.Causing == NullOption) AttackViewModel.Causing = null;

            AttackModel = AttackViewModel;

            await AttackViewModelService.CreateAttack(AttackModel);

            Back_Click();
        }

        protected async Task HandleInvalidCreate()
        {
            if (AttackViewModel.Attribute1 == NullOption && AttackViewModel.Jutsu1 != AttackViewModel.Jutsu2)
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
            NavigationManager.NavigateTo("attacks");
        }

        // validation alert
        public AlertBase AlertDisplay { get; set; }
    }
}
