using System;
namespace harmonyexplorer.Harmony
{
    public class FunctionalScale
    {
        private static int[] _base = new int[] { 2, 2, 1, 2, 2, 2, 1 };
        private static int[] _baseWholeTone = new int[] { 2, 2, 2, 2, 2, 2, 2 };
        private static int[] _baseNaturalMinor = new int[] { 2, 1, 2, 2, 1, 2, 2 };
        private static int[] _baseMelodicMinor = new int[] { 2, 1, 2, 2, 2, 2, 1 };
        private static int[] _baseHarmonicMinor = new int[] { 2, 1, 2, 2, 1, 3, 1 };
        private static int[] _baseExperimental = new int[] { 1, 1, 1, 1, 1, 1, 1 };
        private static int[] getStepsSingleOctaveIncludeRoot(ModeEnum mode)
        {
            int[] result = new int[_base.Length + 1];
            switch (mode)
            {
                case ModeEnum.NaturalMinor:
                    result[0] = 0;
                    for (int i = 0; i < _baseNaturalMinor.Length; i++)
                    {
                        int offset = (i % _baseNaturalMinor.Length);
                        result[i + 1] = _baseNaturalMinor[offset];
                    }
                    break;
                case ModeEnum.HarmonicMinor:
                    result[0] = 0;
                    for (int i = 0; i < _baseHarmonicMinor.Length; i++)
                    {
                        int offset = (i % _baseHarmonicMinor.Length);
                        result[i + 1] = _baseHarmonicMinor[offset];
                    }
                    break;
                case ModeEnum.MelodicMinor:
                    result[0] = 0;
                    for (int i = 0; i < _baseMelodicMinor.Length; i++)
                    {
                        int offset = (i % _baseMelodicMinor.Length);
                        result[i + 1] = _baseMelodicMinor[offset];
                    }
                    break;
                default: //std modes...
                    {
                        result[0] = 0;
                        for (int i = 0; i < _base.Length; i++)
                        {
                            int offset = ((i + (int)mode) % _base.Length);
                            result[i + 1] = _base[offset];
                        }
                        break;
                    }
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