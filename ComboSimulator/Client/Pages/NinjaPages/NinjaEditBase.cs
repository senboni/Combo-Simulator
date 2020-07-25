using ComboSimulator.Client.Shared;
using ComboSimulator.Client.ViewModels;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Pages.NinjaPages
{
    public class NinjaEditBase : ComponentBase
    {
        [Inject]
        private INinjaViewModel NinjaViewModelService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public string NullOption { get; set; }
        public string BackRoute { get; set; }

        public Ninja NinjaModel { get; set; } = new Ninja();
        public NinjaViewModel NinjaViewModel { get; set; } = new NinjaViewModel();

        public List<Mystery> Mysteries { get; set; } = new List<Mystery>();
        public List<Attack> Attacks { get; set; } = new List<Attack>();
        public List<Chase> Chases { get; set; } = new List<Chase>();
        public List<Passive> Passives { get; set; } = new List<Passive>();
        [Required]
        public string MysIdString { get; set; }
        [Required]
        public string AttIdString { get; set; }
        public string ChaseId1S { get; set; }
        public string ChaseId2S { get; set; }
        public string ChaseId3S { get; set; }
        public string PassiveId1S { get; set; }
        public string PassiveId2S { get; set; }
        public string PassiveId3S { get; set; }
        public List<int> StarsList { get; set; }
        [Required]
        public string StarsString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            StarsList = new List<int> { 1, 2, 3, 4, 5 };

            NullOption = "None";

            BackRoute = $"ninjas/{Id}";

            NinjaModel = await NinjaViewModelService.GetNinja(long.Parse(Id));
            Mysteries = await NinjaViewModelService.GetMysteryList();
            Attacks = await NinjaViewModelService.GetAttackList();
            Chases = await NinjaViewModelService.GetChaseList();
            Passives = await NinjaViewModelService.GetPassiveList();

            MysIdString = NinjaModel.MysteryId.ToString();
            AttIdString = NinjaModel.AttackId.ToString();

            if (NinjaModel.ChaseId1 != null) ChaseId1S = NinjaModel.ChaseId1.ToString(); else ChaseId1S = NullOption;
            if (NinjaModel.ChaseId2 != null) ChaseId2S = NinjaModel.ChaseId2.ToString(); else ChaseId2S = NullOption;
            if (NinjaModel.ChaseId3 != null) ChaseId3S = NinjaModel.ChaseId3.ToString(); else ChaseId3S = NullOption;
            if (NinjaModel.PassiveId1 != null) PassiveId1S = NinjaModel.PassiveId1.ToString(); else PassiveId1S = NullOption;
            if (NinjaModel.PassiveId2 != null) PassiveId2S = NinjaModel.PassiveId2.ToString(); else PassiveId2S = NullOption;
            if (NinjaModel.PassiveId3 != null) PassiveId3S = NinjaModel.PassiveId3.ToString(); else PassiveId3S = NullOption;

            StarsString = NinjaModel.Stars.ToString();

            NinjaViewModel = NinjaModel;
        }

        // validation
        protected async Task HandleValidSubmit()
        {
            // string convert
            NinjaViewModel.MysteryId = int.Parse(MysIdString);
            NinjaViewModel.AttackId = int.Parse(AttIdString);
            NinjaViewModel.Stars = int.Parse(StarsString);

            // null checks
            if (ChaseId1S == NullOption) NinjaViewModel.ChaseId1 = null;
            else NinjaViewModel.ChaseId1 = int.Parse(ChaseId1S);

            if (ChaseId2S == NullOption) NinjaViewModel.ChaseId2 = null;
            else NinjaViewModel.ChaseId2 = int.Parse(ChaseId2S);

            if (ChaseId3S == NullOption) NinjaViewModel.ChaseId3 = null;
            else NinjaViewModel.ChaseId3 = int.Parse(ChaseId3S);

            if (PassiveId1S == NullOption) NinjaViewModel.PassiveId1 = null;
            else NinjaViewModel.PassiveId1 = int.Parse(PassiveId1S);

            if (PassiveId2S == NullOption) NinjaViewModel.PassiveId2 = null;
            else NinjaViewModel.PassiveId2 = int.Parse(PassiveId2S);

            if (PassiveId3S == NullOption) NinjaViewModel.PassiveId3 = null;
            else NinjaViewModel.PassiveId3 = int.Parse(PassiveId3S);

            NinjaModel = NinjaViewModel;

            await NinjaViewModelService.UpdateNinja(long.Parse(Id), NinjaModel);

            NavigationManager.NavigateTo("ninjas");
        }

        protected void HandleInvalidSubmit()
        {
            AlertDisplay.Show(true);
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
