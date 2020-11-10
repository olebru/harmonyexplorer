using System.Text;
using harmonyexplorer.Shared;

namespace harmonyexplorer.Harmony
{
    public class Chord
    {
        public string Root { get; set; }
        public bool Minor { get; set; }
        public bool Flat5 { get; set; }
        public bool Sharp5 { get; set; }
        public bool Maj7 { get; set; }
        public bool Flat9 { get; set; }
        public bool Sharp9 { get; set; }
        public bool Flat11 { get; set; }
        public bool Sharp11 { get; set; }
        public bool Flat13 { get; set; }
        public bool Sharp13 { get; set; }
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
                sb.Append(Root);
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
                sb.Append(Root);
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
                sb.Append(Root);
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
                sb.Append(Root);
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
                sb.Append(Root);
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