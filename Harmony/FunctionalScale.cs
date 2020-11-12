using System;

namespace harmonyexplorer.Harmony
{
    public class FunctionalScale
    {
        private static int[] _base = new int[] { 2, 2, 1, 2, 2, 2, 1 };

        private static int[] _baseWholeTone = new int[] { 2, 2, 2, 2, 2, 2, 2 };

        private static int[] getStepsSingleOctaveIncludeRoot(ModeEnum mode)
        {
            int[] result = new int[_base.Length + 1];
            switch (mode)
            {
                case ModeEnum.WholeTone:
                    result[0] = 0;
                    for (int i = 0; i < _baseWholeTone.Length; i++)
                    {
                        int offset = (i % _baseWholeTone.Length);
                        result[i + 1] = _baseWholeTone[offset];
                    }
                    break;

                default:
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