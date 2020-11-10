using System;
using System.Collections.Generic;
using harmonyexplorer.Harmony;

namespace harmonyexplorer.Shared
{
    public static class Helpers
    {


        public static string[] WhiteKeys
        {
            get
            {
                return new string[] { "C", "D", "E", "F", "G", "A", "B", "C" };
            }
        }
        public static string[] Flats
        {
            get
            {
                return new string[] { "C", "D♭", "D", "E♭", "E", "F", "G♭", "G", "A♭", "A", "B♭", "B" };
            }
        }
        public static string[] Sharps
        {
            get
            {
                return new string[] { "C", "C♯", "D", "D♯", "E", "F", "F♯", "G", "G♯", "A", "A♯", "B" };
            }
        }
        public static List<ModeEnum> AllModes
        {
            get
            {
                var result = new List<ModeEnum>();
                result.Add(ModeEnum.Ionian);
                result.Add(ModeEnum.Dorian);
                result.Add(ModeEnum.Phrygian);
                result.Add(ModeEnum.Lydian);
                result.Add(ModeEnum.Mixolydian);
                result.Add(ModeEnum.Aeolian);
                result.Add(ModeEnum.Locrian);

                return result;
            }
        }
        public static List<UpperExtensionEnum> AllExtensions
        {
            get
            {
                var result = new List<UpperExtensionEnum>();
                result.Add(UpperExtensionEnum.Triads);
                result.Add(UpperExtensionEnum.Sevenths);
                result.Add(UpperExtensionEnum.Ninths);
                result.Add(UpperExtensionEnum.Ellevenths);
                result.Add(UpperExtensionEnum.Thirteenths);

                return result;
            }
        }

        public static List<Note> AllNotes
        {
            get
            {
                var result = new List<Note>();

                result.Add(new Note("C"));
                result.Add(new Note("C♯"));
                result.Add(new Note("D♭"));
                result.Add(new Note("D"));
                result.Add(new Note("D♯"));
                result.Add(new Note("E♭"));
                result.Add(new Note("E"));
                result.Add(new Note("F"));
                result.Add(new Note("F♯"));
                result.Add(new Note("G♭"));
                result.Add(new Note("G"));
                result.Add(new Note("G♯"));
                result.Add(new Note("A♭"));
                result.Add(new Note("A"));
                result.Add(new Note("A♯"));
                result.Add(new Note("B♭"));
                result.Add(new Note("B"));
                return result;

            }
        }
        public static List<Note> AllRealNotes
        {
            get
            {
                var result = new List<Note>();

                result.Add(new Note("C"));
                result.Add(new Note("C♯/D♭"));
                result.Add(new Note("D"));
                result.Add(new Note("D♯/E♭"));
                result.Add(new Note("E"));
                result.Add(new Note("F"));
                result.Add(new Note("F♯/G♭"));
                result.Add(new Note("G"));
                result.Add(new Note("G♯/A♭"));
                result.Add(new Note("A"));
                result.Add(new Note("A♯/B♭"));
                result.Add(new Note("B"));
                return result;

            }
        }
    }
}