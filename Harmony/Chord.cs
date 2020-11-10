using System.Text;

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
                return Minor && Flat5;
            }
        }
        public string BasicTriadString
        {
            get
            {
                if (Diminished) return Root + "º";
                if (Minor) return Root + "m";
                return Root;
            }
        }
        public string SeventhString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(Root);
                if (Maj7) sb.Append("△");
                if (Diminished) sb.Append("º");
                if (Minor && !Diminished) sb.Append("m");
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
                if (Maj7) sb.Append("△");
                if (Minor) sb.Append("m");
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
                if (Maj7) sb.Append("△");
                if (Minor) sb.Append("m");
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
                if (Maj7) sb.Append("△");
                if (Minor) sb.Append("m");
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
            if (Flat13) sb.Append("♭13");
            if (Sharp13) sb.Append("♯13");
            FlatSharpModifiers11(sb);
        }
        private void FlatSharpModifiers11(StringBuilder sb)
        {
            if (Flat11) sb.Append("♭11");
            if (Sharp11) sb.Append("♯11");
            FlatSharpModifiers9(sb);
        }
        private void FlatSharpModifiers9(StringBuilder sb)
        {
            if (Flat9) sb.Append("♭9");
            if (Sharp9) sb.Append("♯9");
            FlatSharpModifiers5(sb);
        }
        private void FlatSharpModifiers5(StringBuilder sb)
        {
            if (Flat5) sb.Append("♭5");
            if (Sharp5) sb.Append("♯5");
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