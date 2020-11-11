using System.Text;
using harmonyexplorer.Shared;

namespace harmonyexplorer.Harmony
{
    public class Chord
    {




        public Chord(string RootName, int StepsToThird, int StepsToFifth, int StepsToSeventh, int StepsToNinth, int StepsToEleventh, int StepsToThrirteenth)
        {
            this.RootName = RootName;
            this.StepsToThird = StepsToThird;
            this.StepsToFifth = StepsToFifth;
            this.StepsToSeventh = StepsToSeventh;
            this.StepsToNinth = StepsToNinth;
            this.StepsToEleventh = StepsToEleventh;
            this.StepsToThrirteenth = StepsToThrirteenth;
        }

        public int StepsToThird { get; set; }
        public int StepsToFifth { get; set; }
        public int StepsToSeventh { get; set; }
        public int StepsToNinth { get; set; }
        public int StepsToEleventh { get; set; }
        public int StepsToThrirteenth { get; set; }

        public string RootName { get; set; }
        public bool Minor { get { return StepsToThird == 3; } }
        public bool Flat5 { get { return StepsToFifth == 6; } }
        public bool Sharp5 { get { return StepsToFifth == 8; } }
        public bool Maj7 { get { return StepsToSeventh == 11; } }
        public bool Flat9 { get { return StepsToNinth == 13; } }
        public bool Sharp9 { get { return StepsToNinth == 15; } }
        public bool Flat11 { get { return StepsToEleventh == 16; } }
        public bool Sharp11 { get { return StepsToEleventh == 18; } }
        public bool Flat13 { get { return StepsToThrirteenth == 20; } }
        public bool Sharp13 { get { return StepsToThrirteenth == 22; } }
        public bool Diminished
        {
            get
            {
                return false;
            }
        }
        public string BasicTriadString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(RootName);
                if (Diminished) sb.Append(Helpers.DIMMINISHEDCHAR);
                if (Minor) sb.Append(Helpers.MINORCHAR);
                FlatSharpModifiers5(sb);
                return sb.ToString();
            }
        }
        public string SeventhString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(RootName);
                if (Maj7) sb.Append(Helpers.MAJCHAR);
                if (Diminished) sb.Append(Helpers.DIMMINISHEDCHAR);
                if (Minor && !Diminished) sb.Append(Helpers.MINORCHAR);
                sb.Append("7");
                if (!Diminished) FlatSharpModifiers5(sb);
                return sb.ToString();
            }
        }
        public string NinthString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(RootName);
                if (Maj7) sb.Append(Helpers.MAJCHAR);//Helpers.MAJCHAR);
                if (Minor) sb.Append(Helpers.MINORCHAR);
                if (Flat9 || Sharp9)
                {
                    sb.Append("7");
                }
                else
                {
                    sb.Append("9");
                }
                FlatSharpModifiers9(sb);

                return sb.ToString();
            }
        }
        public string EleventhString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(RootName);
                if (Maj7) sb.Append(Helpers.MAJCHAR);
                if (Minor) sb.Append(Helpers.MINORCHAR);
                if (!Sharp11 && !Flat11) sb.Append("11");
                if ((Sharp11 || Flat11) && (!Sharp9 || !Flat9)) sb.Append("9");
                if ((Sharp11 || Flat11) && (Sharp9 || Flat9)) sb.Append("7");


                FlatSharpModifiers11(sb);

                return sb.ToString();
            }
        }
        public string ThirteenthString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(RootName);
                if (Maj7) sb.Append(Helpers.MAJCHAR);
                if (Minor) sb.Append(Helpers.MINORCHAR);
                if (!Sharp13 && !Flat13) sb.Append("13");

                if (!Sharp11 && !Flat11 && (Sharp13 || Flat13)) sb.Append("11");
                if ((Sharp11 || Flat11) && (!Sharp9 || !Flat9) && (Sharp13 || Flat13)) sb.Append("9");
                if ((Sharp11 || Flat11) && (Sharp9 || Flat9) && (Sharp13 || Flat13)) sb.Append("7");

                FlatSharpModifiers13(sb);

                return sb.ToString();
            }
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
        public string PlainTextChord(UpperExtensionEnum extension)
        {
            switch (extension)
            {
                case UpperExtensionEnum.Triads:
                    return BasicTriadString;
                case UpperExtensionEnum.Sevenths:
                    return SeventhString;
                case UpperExtensionEnum.Ninths:
                    return NinthString;
                case UpperExtensionEnum.Ellevenths:
                    return EleventhString;
                case UpperExtensionEnum.Thirteenths:
                    return ThirteenthString;
                default:
                    return string.Empty;
            }
        }
    }
}