using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using harmonyexplorer.Harmony;
using harmonyexplorer.Shared;
using harmonyexplorer.Components;
using System.Linq;
namespace harmonyexplorer.Pages
{
    public partial class ModeExplorer : ComponentBase
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            // upperExtensions = UpperExtensionEnum.Triads;
            currentRoot = Helpers.AllNotes[0];
            ModesToShow = new List<ModeEnum>();
            ModesToShow.Add(ModeEnum.Ionian);
            UpperExtensionsToShow = new List<UpperExtensionEnum>();
            UpperExtensionsToShow.Add(UpperExtensionEnum.Triads);
            updateData();
        }
        private bool showMenu = true;
        public bool ShowMenu { get { return showMenu; } }
        public void ToggleMenu()
        {
            showMenu = !showMenu;
        }
        // public UpperExtensionEnum upperExtensions { get; set; }
        List<List<ModeWithChords>> data;
        List<ModeEnum> ModesToShow { get; set; }
        List<UpperExtensionEnum> UpperExtensionsToShow { get; set; }
        Note currentRoot;
        private void updateData()
        {
            var all = HarmonyCalculator.GetAllModesWithChords(currentRoot);
            var temp = new List<List<ModeWithChords>>();
            foreach (var modeList in all)
            {
                if (ModesToShow.Contains(modeList[0].Mode))
                {
                    temp.Add(modeList);
                }
            }
            //sort extensions...
            var tempExtensions = new List<UpperExtensionEnum>();
            foreach (var ext in Helpers.AllExtensions)
            {
                if (UpperExtensionsToShow.Contains(ext)) tempExtensions.Add(ext);
            }
            UpperExtensionsToShow = tempExtensions;
            data = temp;
        }
        public void ChangeKey(Note root)
        {
            var temp = root;
            if (temp.Name.Contains('/'))
            {
                var parts = temp.Name.Split('/');
                temp = parts[0] != currentRoot.Name ? new Note(parts[0]) : new Note(parts[1]);
            }
            currentRoot = temp;
            updateData();
        }
        public bool IsThisTheCurrentRoot(Note note)
        {
            return note.Name == currentRoot.Name;
        }
        public void ToggleMode(ModeEnum mode)
        {
            if (ModesToShow.Contains(mode))
            {
                ModesToShow.Remove(mode);
            }
            else
            {
                ModesToShow.Add(mode);
            }
            updateData();
        }
        public void ToggleExtension(UpperExtensionEnum extension)
        {
            if (UpperExtensionsToShow.Contains(extension))
            {
                UpperExtensionsToShow.Remove(extension);
            }
            else
            {
                UpperExtensionsToShow.Add(extension);
            }
            updateData();
        }
        public void ToggleUseFulFilter()
        {
            HideLessUsefulChords = !HideLessUsefulChords;
        }
        public bool HideLessUsefulChords = false;
    }
}
