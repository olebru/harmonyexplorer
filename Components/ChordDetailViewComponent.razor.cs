using System;
using System.Text;
using Microsoft.AspNetCore.Components;
using harmonyexplorer.Harmony;
namespace harmonyexplorer.Components
{
    public partial class ChordDetailViewComponent : ComponentBase
    {
        protected override void OnParametersSet()
        {
            chord.IncludedExtensions = extension;
            base.OnParametersSet();
        }
        void Close()
        {
            chord.ShowDetails = false;
        }
        string ChordComponentsAsText
        {
            get
            {
                var sep = " ";
                var sbResult = new StringBuilder();
                foreach (var part in chord.GetNotesInChord())
                {
                    sbResult.Append(part.Name);
                    sbResult.Append(sep);
                }
                var result = sbResult.ToString();
                result = result.Substring(0, result.Length - 1);
                return result;
            }
        }
        [Parameter]
        public UpperExtensionEnum extension { get; set; }
        [Parameter]
        public Chord chord { get; set; }
        [Parameter]
        public ModeWithChords modeWithChords { get; set; }
    }
}