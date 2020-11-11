using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using harmonyexplorer.Harmony;
using harmonyexplorer.Shared;

using System.Linq;

namespace harmonyexplorer.Pages
{
    public partial class ModeExplorer : ComponentBase
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            upperExtensions = UpperExtensionEnum.Triads;
            currentRoot = Helpers.AllNotes[0];
            ModesToShow = new List<ModeEnum>();
            ModesToShow.Add(ModeEnum.Ionian);
            headerValues = tempHeaderFFS;

            updateData();

        }

        private bool showMenu = true;
        public bool ShowMenu { get { return showMenu; } }
        public void ToggleMenu()
        {

            showMenu = !showMenu;
        }
        public UpperExtensionEnum upperExtensions { get; set; }

        private Chord drillDownToChord;
        private UpperExtensionEnum drillDownToChordExtension;
        public void DrillDownChord(Chord chord)
        {
            // drillDownToChord = chord;
            //  drillDownToChordExtension = extension;

        }
        List<List<ModeWithChords>> data;

        List<ModeEnum> ModesToShow { get; set; }
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

        public void ChangeExtensions(UpperExtensionEnum value)
        {
            upperExtensions = value;
            updateData();
        }

        public void ToggleMode(ModeEnum degree)
        {
            if (ModesToShow.Contains(degree))
            {
                ModesToShow.Remove(degree);
            }
            else
            {
                ModesToShow.Add(degree);
            }
            updateData();
        }

        public string[] headerValues;
        public void NextHeaderText()
        {
            currentHeaderIdx++;
            if (currentHeaderIdx == 3) currentHeaderIdx = 0;

            headerValues = tempHeaderFFS;
        }

        private int currentHeaderIdx = 0;
        public string[] tempHeaderFFS
        {
            get
            {
                var allHeaderValues = new List<List<string>>();

                var romanNumerals = new List<string>()
                {
                    "I",
                    "II",
                    "III",
                    "IV",
                    "V",
                    "VI",
                    "VII"
                };


                var integers = new List<string>()
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7"

                };


                var names = new List<string>()
                {
                    "Tonic",
                    "Supertonic",
                    "Mediant",
                    "Subdominant",
                    "Dominant",
                    "Submediant",
                    "Leading tone"

                };


                allHeaderValues.Add(romanNumerals);
                allHeaderValues.Add(integers);
                allHeaderValues.Add(names);


                return allHeaderValues[currentHeaderIdx].ToArray();


            }

        }

    }
}


