using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Shared
{
    public class AlertBase : ComponentBase
    {
        [Parameter]
        public string AlertMessage { get; set; } = "This is an alert—check it out!";
        [Parameter]
        public string AlertType { get; set; } = "danger";

        public bool ShowAlert { get; set; }

        public void Show(bool state)
        {
            ShowAlert = state;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> AlertChanged { get; set; }

        protected async Task OnAlertChange(bool value)
        {
            ShowAlert = false;
            await AlertChanged.InvokeAsync(value);
        }
    }
}
