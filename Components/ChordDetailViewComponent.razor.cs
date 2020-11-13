using Microsoft.AspNetCore.Components;
using harmonyexplorer.Harmony;


namespace harmonyexplorer.Components
{

    public partial class ChordDetailViewComponent : ComponentBase
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        void Close()
        {
            chord.ShowDetails = false;

        }


        [Parameter]
        public UpperExtensionEnum extension { get; set; }


        [Parameter]
        public Chord chord { get; set; }



    }
}