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
        void ShowDetails()
        {
            chord.ShowDetails = true;
        }
        [Parameter]
        public Chord chord { get; set; }
        [Parameter]
        public ModeWithChords modeWithChords { get; set; }
        [Parameter]
        public bool hidden { get; set; }
        [Parameter]
        public UpperExtensionEnum extension { get; set; }
    }
}