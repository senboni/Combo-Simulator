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
    public class AttackInfoBase : ComponentBase
    {
        [Inject]
        protected IAttackViewModel AttackViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public long Id { get; set; }

        public Attack AttackModel { get; set; } = new Attack();
        public string EditRoute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EditRoute = $"attacks/edit/{Id}";

            AttackModel = await AttackViewModel.GetAttack(Id);
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
                await AttackViewModel.DeleteAttack(Id);
                NavigationManager.NavigateTo("attacks");
            }
        }
    }
}
