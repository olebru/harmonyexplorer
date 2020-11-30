using System;
namespace harmonyexplorer.Harmony
{
    public class FunctionalScale
    {
        private static int[] _baseIonian = new int[] { 2, 2, 1, 2, 2, 2, 1 };
        private static int[] _baseDorian = new int[] { 2, 1, 2, 2, 2, 1, 2 };
        private static int[] _basePhrygian = new int[] { 1, 2, 2, 2, 1, 2, 2 };
        private static int[] _baseLydian = new int[] { 2, 2, 2, 1, 2, 2, 1 };
        private static int[] _baseMixolydion = new int[] { 2, 2, 1, 2, 2, 1, 2 };
        private static int[] _baseAeolian = new int[] { 2, 1, 2, 2, 1, 2, 2 };
        private static int[] _baseLocrian = new int[] { 1, 2, 2, 1, 2, 2, 2 };
        private static int[] _baseWholeTone = new int[] { 2, 2, 2, 2, 2, 2, 2 };
        private static int[] _baseNaturalMinor = new int[] { 2, 1, 2, 2, 1, 2, 2 };
        private static int[] _baseMelodicMinor = new int[] { 2, 1, 2, 2, 2, 2, 1 };
        private static int[] _baseHarmonicMinor = new int[] { 2, 1, 2, 2, 1, 3, 1 };
        private static int[] _baseExperimental = new int[] { 1, 1, 1, 1, 1, 1, 1 };

        private static int[] _baseMelodicMinorI = new int[] { 2, 1, 2, 2, 2, 2, 1 };
        private static int[] _baseMelodicMinorII = new int[] { 1, 2, 2, 2, 2, 1, 2 };
        private static int[] _baseMelodicMinorIII = new int[] { 2, 2, 2, 2, 1, 2, 1 };
        private static int[] _baseMelodicMinorIV = new int[] { 2, 2, 2, 1, 2, 1, 2 };
        private static int[] _baseMelodicMinorV = new int[] { 2, 2, 1, 2, 1, 2, 2 };
        private static int[] _baseMelodicMinorVI = new int[] { 2, 1, 2, 1, 2, 2, 2 };
        private static int[] _baseMelodicMinorVII = new int[] { 1, 2, 1, 2, 2, 2, 2, };


        private static int[] getStepsSingleOctaveIncludeRoot(ModeEnum mode)
        {
            switch (mode)
            {
                case ModeEnum.Ionian: return OffsetBaseAndAddRoot(_baseIonian);
                case ModeEnum.Dorian: return OffsetBaseAndAddRoot(_baseDorian);
                case ModeEnum.Phrygian: return OffsetBaseAndAddRoot(_basePhrygian);
                case ModeEnum.Lydian: return OffsetBaseAndAddRoot(_baseLydian);
                case ModeEnum.Mixolydian: return OffsetBaseAndAddRoot(_baseMixolydion);
                case ModeEnum.Aeolian: return OffsetBaseAndAddRoot(_baseAeolian);
                case ModeEnum.Locrian: return OffsetBaseAndAddRoot(_baseLocrian);

                case ModeEnum.MelodicMinorI: return OffsetBaseAndAddRoot(_baseMelodicMinorI);
                case ModeEnum.MelodicMinorII: return OffsetBaseAndAddRoot(_baseMelodicMinorII);
                case ModeEnum.MelodicMinorIII: return OffsetBaseAndAddRoot(_baseMelodicMinorIII);
                case ModeEnum.MelodicMinorIV: return OffsetBaseAndAddRoot(_baseMelodicMinorIV);
                case ModeEnum.MelodicMinorV: return OffsetBaseAndAddRoot(_baseMelodicMinorV);
                case ModeEnum.MelodicMinorVI: return OffsetBaseAndAddRoot(_baseMelodicMinorVI);
                case ModeEnum.MelodicMinorVII: return OffsetBaseAndAddRoot(_baseMelodicMinorVII);





                //case ModeEnum.NaturalMinor: return OffsetBaseAndAddRoot(_baseNaturalMinor);
                case ModeEnum.HarmonicMinor: return OffsetBaseAndAddRoot(_baseHarmonicMinor);
                //case ModeEnum.MelodicMinor: return OffsetBaseAndAddRoot(_baseHarmonicMinor);
                default: throw new Exception("Unknown mode " + mode);
            }
        }
        private static int[] OffsetBaseAndAddRoot(int[] _base)
        {
            int[] result = new int[8];
            result[0] = 0;
            for (int i = 0; i < _base.Length; i++)
            {
                int offset = (i % _base.Length);
                result[i + 1] = _base[offset];
            }
            return result;
        }
        public static int[] GetAbsouluteOffsetFromRoot(ModeEnum mode, int octaves)
        {
            var steps = GetSteps(mode, octaves);
            var result = new int[steps.Length];
            for (int i = 0; i < steps.Length; i++)
            {
                if (i == 0)
                {
                    result[i] = steps[i];
                }
                else
                {
                    result[i] = steps[i] + result[i - 1];
                }
            }
            return result;
        }
        public static int[] GetSteps(ModeEnum mode, int octaves)
        {
            var singleOctave = getStepsSingleOctaveIncludeRoot(mode);
            int[] result = new int[((singleOctave.Length - 1) * octaves) + 1];
            for (int i = 0; i < singleOctave.Length; i++)
            {
                result[i] = singleOctave[i];
            }
            int resultIDX = singleOctave.Length;
            while (resultIDX < result.Length)
            {
                int lookupidx = ((resultIDX - 1) % (singleOctave.Length - 1) + 1);
                result[resultIDX] = singleOctave[lookupidx];
                resultIDX++;
            }
            return result;
        }
    }
}