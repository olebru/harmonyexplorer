using Microsoft.AspNetCore.Components;
using harmonyexplorer.Harmony;


namespace harmonyexplorer.Components
{

    public partial class PianoVoicingView : ComponentBase
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        [Parameter]
        public Chord chord { get; set; }


    }
}