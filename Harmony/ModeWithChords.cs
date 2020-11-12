using System;
using System.Drawing;
using System.Collections.Generic;

namespace harmonyexplorer.Harmony
{
    public class ModeWithChords
    {
        public ModeEnum Mode { get; set; }
        public Chord First { get; set; }
        public Chord Second { get; set; }
        public Chord Third { get; set; }
        public Chord Fourth { get; set; }
        public Chord Fifth { get; set; }
        public Chord Sixth { get; set; }
        public Chord Seventh { get; set; }

        public Chord[] Chords
        {
            get
            {
                var result = new List<Chord>();
                result.Add(First);
                result.Add(Second);
                result.Add(Third);
                result.Add(Fourth);
                result.Add(Fifth);
                result.Add(Sixth);
                result.Add(Seventh);
                return result.ToArray();
            }
        }
    }
}