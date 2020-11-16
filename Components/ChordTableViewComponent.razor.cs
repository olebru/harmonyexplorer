using Microsoft.AspNetCore.Components;
using harmonyexplorer.Harmony;
using System.Collections.Generic;
using harmonyexplorer.Shared;


namespace harmonyexplorer.Components
{

    public partial class ChordTableViewComponent : ComponentBase
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            headerValues = Helpers.AllChordFunctionNamingConventions[currentHeaderIdx];
        }


        [Parameter]
        public List<UpperExtensionEnum> upperExtensions { get; set; }


        public List<string> headerValues;
        public void NextHeaderText()
        {
            currentHeaderIdx++;
            if (currentHeaderIdx == 3) currentHeaderIdx = 0;

            headerValues = Helpers.AllChordFunctionNamingConventions[currentHeaderIdx]; ;
        }

        private int currentHeaderIdx = 1;

        [Parameter]
        public List<List<ModeWithChords>> data { get; set; }

    }
}