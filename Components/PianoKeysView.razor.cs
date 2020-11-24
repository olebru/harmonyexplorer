using System;
using System.Text;
using Microsoft.AspNetCore.Components;
using harmonyexplorer.Harmony;
using System.Linq;
using System.Collections.Generic;
namespace harmonyexplorer.Components
{
    public partial class PianoKeysView : ComponentBase
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
        [Parameter]
        public int[] halfsteps { get; set; }
    }
}
