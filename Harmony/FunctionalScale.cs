using System;

namespace harmonyexplorer.Harmony
{
    public class FunctionalScale
    {
        private static int[] _base = new int[] { 2, 2, 1, 2, 2, 2, 1 };

        public static String ModeNameMuke(XXScaleDegreeEnum degree)
        {
            return ((ModeEnum)degree).ToString();
        }
        private static int[] getStepsSingleOctaveIncludeRoot(ModeEnum degree)
        {

            int[] result = new int[_base.Length + 1];
            result[0] = 0; //root tests
            for (int i = 0; i < _base.Length; i++)
            {
                int offset = ((i + (int)degree) % _base.Length);
                result[i + 1] = _base[offset];
            }

            return result;
        }
        public static int[] GetAbsouluteOffsetFromRoot(ModeEnum degree, int octaves)
        {
            var steps = GetSteps(degree, octaves);
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
        public static int[] GetSteps(ModeEnum degree, int octaves)
        {

            var singleOctave = getStepsSingleOctaveIncludeRoot(degree);

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