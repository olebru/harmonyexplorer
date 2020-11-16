using System;
using System.Text;
using System.Collections.Generic;
using harmonyexplorer.Shared;
namespace harmonyexplorer.Harmony
{
    public class Chord
    {
        public Chord(Note Root, int StepsToThird, int StepsToFifth, int StepsToSeventh, int StepsToNinth, int StepsToEleventh, int StepsToThrirteenth, Note[] NoteNamesInOriginScale)
        {
            this.Root = Root;
            this.StepsToThird = StepsToThird;
            this.StepsToFifth = StepsToFifth;
            this.StepsToSeventh = StepsToSeventh;
            this.StepsToNinth = StepsToNinth;
            this.StepsToEleventh = StepsToEleventh;
            this.StepsToThirteenth = StepsToThrirteenth;
            this.NoteNamesInOriginScale = NoteNamesInOriginScale;
        }
        public UpperExtensionEnum IncludedExtensions { get; set; }
        public Note[] NoteNamesInOriginScale { get; set; }
        public bool ShowDetails { get; set; } = false;
        public int StepsToThird { get; set; }
        public int StepsToFifth { get; set; }
        public int StepsToSeventh { get; set; }
        public int StepsToNinth { get; set; }
        public int StepsToEleventh { get; set; }
        public int StepsToThirteenth { get; set; }
        public Note Root { get; set; }
        public bool Sus2 { get { return StepsToThird == 2; } }
        public bool Minor { get { return StepsToThird == 3; } }
        public bool Perfect3 { get { return StepsToThird == 4; } }
        public bool Sus4 { get { return StepsToThird == 5; } }
        public bool Flat5 { get { return StepsToFifth == 6; } }
        public bool Perfect5 { get { return StepsToFifth == 7; } }
        public bool Sharp5 { get { return StepsToFifth == 8; } }
        public bool DoubleFlat7LetsCallIt6 { get { return StepsToSeventh == 9; } }
        public bool Dominant7 { get { return StepsToSeventh == 10; } }
        public bool Maj7 { get { return StepsToSeventh == 11; } }
        //12 would be octave of root
        public bool Flat9 { get { return StepsToNinth == 13; } }
        public bool Perfect9 { get { return StepsToNinth == 14; } }
        public bool Sharp9 { get { return StepsToNinth == 15; } }
        public bool Flat11 { get { return StepsToEleventh == 16; } }
        public bool Perfect11 { get { return StepsToEleventh == 17; } }
        public bool Sharp11 { get { return StepsToEleventh == 18; } }
        public bool Flat13 { get { return StepsToThirteenth == 20; } }
        public bool Perfect13 { get { return StepsToThirteenth == 21; } }
        public bool Sharp13 { get { return StepsToThirteenth == 22; } }
        public int FunctionInOriginalScale
        {
            get
            {
                var function = Array.IndexOf(NoteNamesInOriginScale, Root) + 1;
                return function;
            }
        }
        public Note GetRelativeChromaticNote(int halfstepsabove, bool sharpAnnotation)
        {
            var chromaticScale = sharpAnnotation ? Helpers.Sharps : Helpers.Flats;
            var idxOfSelf = Array.IndexOf(chromaticScale, Root.Name);
            var resultIdx = (idxOfSelf + halfstepsabove) % chromaticScale.Length;
            return new Note(chromaticScale[resultIdx]);
        }
        public List<Note> GetNotesInChord()
        {
            var result = new List<Note>();
            foreach (var ext in Helpers.AllExtensions)
            {
                int rootOffset = Array.IndexOf(NoteNamesInOriginScale, Root);
                if ((int)ext <= (int)IncludedExtensions)
                {
                    switch (ext)
                    {
                        case UpperExtensionEnum.Triads:
                            result.Add(NoteNamesInOriginScale[(1 + rootOffset - 1) % (NoteNamesInOriginScale.Length)]);
                            result.Add(NoteNamesInOriginScale[(3 + rootOffset - 1) % (NoteNamesInOriginScale.Length)]);
                            result.Add(NoteNamesInOriginScale[(5 + rootOffset - 1) % (NoteNamesInOriginScale.Length)]);
                            break;
                        case UpperExtensionEnum.Sevenths:
                            result.Add(NoteNamesInOriginScale[(7 + rootOffset - 1) % (NoteNamesInOriginScale.Length)]);
                            break;
                        case UpperExtensionEnum.Ninths:
                            result.Add(NoteNamesInOriginScale[(9 + rootOffset - 1) % (NoteNamesInOriginScale.Length)]);
                            break;
                        case UpperExtensionEnum.Ellevenths:
                            result.Add(NoteNamesInOriginScale[(11 + rootOffset - 1) % (NoteNamesInOriginScale.Length)]);
                            break;
                        case UpperExtensionEnum.Thirteenths:
                            result.Add(NoteNamesInOriginScale[(13 + rootOffset - 1) % (NoteNamesInOriginScale.Length)]);
                            break;
                    }
                }
            }
            return result;
        }
        public bool Diminished
        {
            get
            {
                return false;
            }
        }
        public string UnknownBaseStep
        {
            get
            {
                var unknown = new StringBuilder();
                if (StepsToThird < 2 || StepsToThird > 5) unknown.Append("error3=" + StepsToThird);
                if (StepsToFifth < 6 || StepsToFifth > 8) unknown.Append("error5=" + StepsToThird);
                return unknown.ToString();
            }
        }
        public string Unknown7Step
        {
            get
            {
                var unknown = new StringBuilder();
                if (StepsToSeventh < 9 || StepsToSeventh > 11) unknown.Append("error7=" + StepsToSeventh);
                return unknown.ToString();
            }
        }
        public string Unknown9Step
        {
            get
            {
                var unknown = new StringBuilder();
                if (StepsToNinth < 13 || StepsToNinth > 15) unknown.Append("error9=" + StepsToNinth);
                return unknown.ToString();
            }
        }
        public string Unknown11Step
        {
            get
            {
                var unknown = new StringBuilder();
                if (StepsToEleventh < 16 || StepsToEleventh > 18) unknown.Append("error11=" + StepsToEleventh);
                return unknown.ToString();
            }
        }
        public string Unknown13Step
        {
            get
            {
                var unknown = new StringBuilder();
                if (StepsToThirteenth < 20 || StepsToThirteenth > 22) unknown.Append("error13=" + StepsToThirteenth);
                return unknown.ToString();
            }
        }
        public string BasicTriadStringBase
        {
            get
            {
                var sb = new StringBuilder();
                RootAndMinorSusModifiers(sb);
                return sb.ToString();
            }
        }
        public string BasicTriadStringModifiers
        {
            get
            {
                var sb = new StringBuilder();
                FlatSharpModifiers5(sb);
                return sb.ToString();
            }
        }
        public string SeventhStringBase
        {
            get
            {
                var sb = new StringBuilder();
                RootAndMinorSusModifiers(sb);
                MajModifier(sb);
                sb.Append("7");
                return sb.ToString();
            }
        }
        public string SeventhStringModifiers
        {
            get
            {
                var sb = new StringBuilder();
                FlatSharpModifiers5(sb);
                return sb.ToString();
            }
        }
        public string NinthStringBase
        {
            get
            {
                var sb = new StringBuilder();
                RootAndMinorSusModifiers(sb);
                MajModifier(sb);
                if (Perfect9)
                {
                    sb.Append("9");
                }
                else
                {
                    sb.Append("7");
                }
                return sb.ToString();
            }
        }
        public string NinthStringModifiers
        {
            get
            {
                var sb = new StringBuilder();
                FlatSharpModifiers9(sb);
                return sb.ToString();
            }
        }
        public string EleventhStringBase
        {
            get
            {
                var sb = new StringBuilder();
                RootAndMinorSusModifiers(sb);
                MajModifier(sb);
                if (Perfect11) sb.Append("11");
                if (!Perfect11 && Perfect9) sb.Append("9");
                if (!Perfect11 && !Perfect11 && !Perfect9) sb.Append("7");
                return sb.ToString();
            }
        }
        public string EleventhStringModifiers
        {
            get
            {
                var sb = new StringBuilder();
                FlatSharpModifiers11(sb);
                return sb.ToString();
            }
        }
        public string ThirteenthStringBase
        {
            get
            {
                var sb = new StringBuilder();
                RootAndMinorSusModifiers(sb);
                MajModifier(sb);
                if (Perfect13) sb.Append("13");
                if (!Perfect13 && Perfect11) sb.Append("11");
                if (!Perfect13 && !Perfect11 && Perfect9) sb.Append("9");
                if (!Perfect13 && !Perfect11 && !Perfect9) sb.Append("7");
                return sb.ToString();
            }
        }
        public string ThirteenthStringModifiers
        {
            get
            {
                var sb = new StringBuilder();
                FlatSharpModifiers13(sb);
                return sb.ToString();
            }
        }
        private void RootAndMinorSusModifiers(StringBuilder sb)
        {
            sb.Append(Root.Name);
            if (Minor && !Diminished) sb.Append(Helpers.MINORCHAR);
            if (Sus2) sb.Append(Helpers.SUS2STRING);
            if (Sus4) sb.Append(Helpers.SUS4STRING);
        }
        private void MajModifier(StringBuilder sb)
        {
            if (Maj7) sb.Append(Helpers.MAJCHAR);
        }
        private void FlatSharpModifiers13(StringBuilder sb)
        {
            if (Flat13) sb.Append(Helpers.FLATCHAR + "13");
            if (Sharp13) sb.Append(Helpers.SHARPCHAR + "13");
            FlatSharpModifiers11(sb);
        }
        private void FlatSharpModifiers11(StringBuilder sb)
        {
            if (Flat11) sb.Append(Helpers.FLATCHAR + "11");
            if (Sharp11) sb.Append(Helpers.SHARPCHAR + "11");
            FlatSharpModifiers9(sb);
        }
        private void FlatSharpModifiers9(StringBuilder sb)
        {
            if (Flat9) sb.Append(Helpers.FLATCHAR + "9");
            if (Sharp9) sb.Append(Helpers.SHARPCHAR + "9");
            FlatSharpModifiers5(sb);
        }
        private void FlatSharpModifiers5(StringBuilder sb)
        {
            if (Flat5) sb.Append(Helpers.FLATCHAR + "5");
            if (Sharp5) sb.Append(Helpers.SHARPCHAR + "5");
        }
        public string PlainTextChordWithOutModifiers(UpperExtensionEnum extension)
        {
            if (UnknownBaseStep + Unknown7Step + Unknown9Step + Unknown11Step + Unknown13Step != string.Empty)
                return UnknownBaseStep + Unknown7Step + Unknown9Step + Unknown11Step + Unknown13Step;
            switch (extension)
            {
                case UpperExtensionEnum.Triads:
                    return BasicTriadStringBase;
                case UpperExtensionEnum.Sevenths:
                    return SeventhStringBase;
                case UpperExtensionEnum.Ninths:
                    return NinthStringBase;
                case UpperExtensionEnum.Ellevenths:
                    return EleventhStringBase;
                case UpperExtensionEnum.Thirteenths:
                    return ThirteenthStringBase;
                default:
                    return string.Empty;
            }
        }
        public string Modifiers(UpperExtensionEnum extension)
        {
            if (UnknownBaseStep + Unknown7Step + Unknown9Step + Unknown11Step + Unknown13Step != string.Empty)
                return UnknownBaseStep + Unknown7Step + Unknown9Step + Unknown11Step + Unknown13Step;
            switch (extension)
            {
                case UpperExtensionEnum.Triads:
                    return BasicTriadStringModifiers;
                case UpperExtensionEnum.Sevenths:
                    return SeventhStringModifiers;
                case UpperExtensionEnum.Ninths:
                    return NinthStringModifiers;
                case UpperExtensionEnum.Ellevenths:
                    return EleventhStringModifiers;
                case UpperExtensionEnum.Thirteenths:
                    return ThirteenthStringModifiers;
                default:
                    return string.Empty;
            }
        }
    }
}