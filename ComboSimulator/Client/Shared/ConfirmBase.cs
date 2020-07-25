using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Shared
{
    public class ConfirmBase : ComponentBase
    {
        [Parameter]
        public string ConfirmTitle { get; set; } = "Confirmation";
        [Parameter]
        public string ConfirmMessage { get; set; } = "Are you sure?";
        [Parameter]
        public string ConfirmYes { get; set; } = "Yes";
        [Parameter]
        public string ConfirmNo { get; set; } = "No";
        public bool ShowConfirm { get; set; }

        public void Show()
        {
            ShowConfirm = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirm = false;
            await ConfirmChanged.InvokeAsync(value);
        }
    }
}
