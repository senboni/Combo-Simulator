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

namespace ComboSimulator.Client.Pages.NinjaPages
{
    public class NinjaInfoBase : ComponentBase
    {
        [Inject]
        private INinjaViewModel NinjaViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public long Id { get; set; }

        public Ninja NinjaModel { get; set; } = new Ninja();

        public string EditRoute { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EditRoute = $"ninjas/edit/{Id}";

            NinjaModel = await NinjaViewModel.GetNinja(Id);

            NinjaModel.Mystery = await NinjaViewModel.GetMystery(NinjaModel.MysteryId);
            NinjaModel.Attack = await NinjaViewModel.GetAttack(NinjaModel.AttackId);

            if (NinjaModel.ChaseId1 != null) NinjaModel.Chases[0] = await NinjaViewModel.GetChase(NinjaModel.ChaseId1);
            if (NinjaModel.ChaseId2 != null) NinjaModel.Chases[1] = await NinjaViewModel.GetChase(NinjaModel.ChaseId2);
            if (NinjaModel.ChaseId3 != null) NinjaModel.Chases[2] = await NinjaViewModel.GetChase(NinjaModel.ChaseId3);

            if (NinjaModel.PassiveId1 != null) NinjaModel.Passives[0] = await NinjaViewModel.GetPassive(NinjaModel.PassiveId1);
            if (NinjaModel.PassiveId2 != null) NinjaModel.Passives[1] = await NinjaViewModel.GetPassive(NinjaModel.PassiveId2);
            if (NinjaModel.PassiveId3 != null) NinjaModel.Passives[2] = await NinjaViewModel.GetPassive(NinjaModel.PassiveId3);
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
                await NinjaViewModel.DeleteNinja(Id);

                NavigationManager.NavigateTo("ninjas");
            }
        }
    }
}
