using Microsoft.AspNetCore.Components;
using harmonyexplorer.Harmony;
using System.Collections.Generic;


namespace harmonyexplorer.Components
{

    public partial class ChordTableViewComponent : ComponentBase
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();



        }

        [Parameter]
        public List<UpperExtensionEnum> upperExtensions { get; set; }

        [Parameter]
        public string[] headerValues { get; set; }

        [Parameter]
        public List<List<ModeWithChords>> data { get; set; }

    }
}