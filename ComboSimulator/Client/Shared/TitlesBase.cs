using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Client.Shared
{
    public class TitlesBase : ComponentBase
    {
        [Parameter]
        public string Text { get; set; } = "#";

        [Parameter]
        public bool BackButton { get; set; } = false;
        [Parameter]
        public string BackRoute { get; set; } = "#";

        [Parameter]
        public bool NewButton { get; set; } = false;
        [Parameter]
        public string NewRoute { get; set; } = "#";

        [Parameter]
        public bool EditButton { get; set; } = false;
        [Parameter]
        public string EditRoute { get; set; } = "#";

        [Parameter]
        public bool DeleteButton { get; set; } = false;
        [Parameter]
        public EventCallback DeleteMethod { get; set; }

        [Parameter]
        public bool SearchInput { get; set; } = false;
        [Parameter]
        public EventCallback<string> SearchMethod { get; set; }

        // Search Filter
        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnSearchMethod();
            }
        }
        protected void OnSearchMethod()
        {
            SearchMethod.InvokeAsync(SearchTerm);
        }
    }
}
