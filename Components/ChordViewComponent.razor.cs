using Microsoft.AspNetCore.Components;
using harmonyexplorer.Harmony;


namespace harmonyexplorer.Components
{

    public partial class ChordViewComponent : ComponentBase
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();



        }

        [Parameter]
        public UpperExtensionEnum extension { get; set; }


        [Parameter]
        public Chord chord { get; set; }



    }
}