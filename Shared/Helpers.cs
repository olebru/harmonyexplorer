using System;
using System.Collections.Generic;
using harmonyexplorer.Harmony;

namespace harmonyexplorer.Shared
{
    public static class Helpers
    {

        public const char MAJCHAR = '△';

        public const char MINORCHAR = 'm';

        public const char FLATCHAR = '♭';

        public const char SHARPCHAR = '♯';
        public const char DIMMINISHEDCHAR = 'º';
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
                return new string[] { "C", "D" + Helpers.FLATCHAR, "D", "E" + Helpers.FLATCHAR, "E", "F", "G" + Helpers.FLATCHAR, "G", "A" + Helpers.FLATCHAR, "A", "B" + Helpers.FLATCHAR, "B" };
            }
        }
        public static string[] Sharps
        {
            get
            {
                return new string[] { "C", "C" + Helpers.SHARPCHAR, "D", "D" + Helpers.SHARPCHAR, "E", "F", "F" + Helpers.SHARPCHAR, "G", "G" + Helpers.SHARPCHAR, "A", "A" + Helpers.SHARPCHAR, "B" };
            }
        }
        public static List<ModeEnum> AllModes
        {
            get
            {
                var result = new List<ModeEnum>();

                foreach (ModeEnum mode in (ModeEnum[])Enum.GetValues(typeof(ModeEnum)))
                {
                    result.Add(mode);
                }

                return result;
            }
        }
        public static List<UpperExtensionEnum> AllExtensions
        {
            get
            {
                var result = new List<UpperExtensionEnum>();

                foreach (UpperExtensionEnum extensionEnum in (UpperExtensionEnum[])Enum.GetValues(typeof(UpperExtensionEnum)))
                {
                    result.Add(extensionEnum);
                }

                return result;
            }
        }

        public static List<Note> AllNotes
        {
            get
            {
                var result = new List<Note>();

                result.Add(new Note("C"));
                result.Add(new Note("C" + Helpers.SHARPCHAR));
                result.Add(new Note("D" + Helpers.FLATCHAR));
                result.Add(new Note("D"));
                result.Add(new Note("D" + Helpers.SHARPCHAR));
                result.Add(new Note("E" + Helpers.FLATCHAR));
                result.Add(new Note("E"));
                result.Add(new Note("F"));
                result.Add(new Note("F" + Helpers.SHARPCHAR));
                result.Add(new Note("G" + Helpers.FLATCHAR));
                result.Add(new Note("G"));
                result.Add(new Note("G" + Helpers.SHARPCHAR));
                result.Add(new Note("A" + Helpers.FLATCHAR));
                result.Add(new Note("A"));
                result.Add(new Note("A" + Helpers.SHARPCHAR));
                result.Add(new Note("B" + Helpers.FLATCHAR));
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
                result.Add(new Note("C♯/D" + Helpers.FLATCHAR));
                result.Add(new Note("D"));
                result.Add(new Note("D♯/E" + Helpers.FLATCHAR));
                result.Add(new Note("E"));
                result.Add(new Note("F"));
                result.Add(new Note("F♯/G" + Helpers.FLATCHAR));
                result.Add(new Note("G"));
                result.Add(new Note("G♯/A" + Helpers.FLATCHAR));
                result.Add(new Note("A"));
                result.Add(new Note("A♯/B" + Helpers.FLATCHAR));
                result.Add(new Note("B"));
                return result;

            }
        }
    }
}