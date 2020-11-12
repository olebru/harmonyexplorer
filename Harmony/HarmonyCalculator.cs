﻿using System;
using System.Text;
using System.Collections.Generic;
using harmonyexplorer.Harmony;
using harmonyexplorer.Shared;
using System.Linq;


namespace harmonyexplorer.Harmony
{
    public class HarmonyCalculator
    {
        public static Note[] Notes(Note root, ModeEnum mode)
        {
            var funcRelative = FunctionalScale.GetAbsouluteOffsetFromRoot(mode, 1);
            var sharp = root.Name.Contains(Helpers.SHARPCHAR);
            if (root.Name == "C") sharp = true;
            if (root.Name == "G") sharp = true;
            if (root.Name == "D") sharp = true;
            if (root.Name == "A") sharp = true;
            if (root.Name == "E") sharp = true;
            if (root.Name.Contains(Helpers.FLATCHAR)) sharp = false;

            var names = sharp ? Helpers.Sharps : Helpers.Flats;

            var idxOfRootInNames = Array.IndexOf(names, root.Name);
            var result = new Note[funcRelative.Length];
            var range = new System.Range(0, result.Length - 1); //Remove Last element as it is the root repeated... FIXME?

            for (int i = 0; i < funcRelative.Length; i++)
            {
                var idxCurrentName = (funcRelative[i] + idxOfRootInNames) % names.Length;
                result[i] = new Note(names[idxCurrentName]);
            }

            //FIXME Dirty WET hack...
            bool tryagain = false;


            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Name.ToArray()[0] != Helpers.WhiteKeys[i].ToArray()[0])
                {
                    tryagain = true;
                }
            }

            if (tryagain && root.Name.Count() == 1)
            {
                sharp = !sharp;
                names = sharp ? Helpers.Sharps : Helpers.Flats;
                idxOfRootInNames = Array.IndexOf(names, root.Name);
                result = new Note[funcRelative.Length];
                range = new System.Range(0, result.Length - 1); //Remove Last element as it is the root repeated... FIXME? 

                for (int i = 0; i < funcRelative.Length; i++)
                {
                    var idxCurrentName = (funcRelative[i] + idxOfRootInNames) % names.Length;
                    result[i] = new Note(names[idxCurrentName]);
                }
            }

            bool tryagain2 = false;
            var seen = new List<string>();
            if (root.Name.Count() == 2)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (!seen.Contains(result[i].Name))
                    {
                        seen.Add(result[i].Name);
                    }
                    else
                    {

                        tryagain2 = true;
                    }
                }
            }


            if (tryagain2)
            {

                names = sharp ? Helpers.Sharps : Helpers.Flats;
                idxOfRootInNames = Array.IndexOf(names, root.Name);

                sharp = !sharp;
                names = sharp ? Helpers.Sharps : Helpers.Flats;


                result = new Note[funcRelative.Length];
                range = new System.Range(0, result.Length - 1); //Remove Last element as it is the root repeated... FIXME? 

                for (int i = 0; i < funcRelative.Length; i++)
                {
                    var idxCurrentName = (funcRelative[i] + idxOfRootInNames) % names.Length;
                    result[i] = new Note(names[idxCurrentName]);
                }
            }




            return result[range];
        }
        public static Chord[] Chords(Note root, ModeEnum mode)
        {
            var rootNames = Notes(root, mode);

            Chord[] result = new Chord[rootNames.Length];
            var relativeStepsFromRoot = FunctionalScale.GetAbsouluteOffsetFromRoot(mode, octaves: 3);

            for (int i = 0; i < rootNames.Length; i++)
            {
                string name = rootNames[i].Name;

                int stepsToThird = relativeStepsFromRoot[i + 2] - relativeStepsFromRoot[i];
                int stepsToFifth = relativeStepsFromRoot[i + 4] - relativeStepsFromRoot[i];
                int stepsToSeventh = relativeStepsFromRoot[i + 6] - relativeStepsFromRoot[i];
                int stepsToNinth = relativeStepsFromRoot[i + 8] - relativeStepsFromRoot[i];
                int stepsToEleventh = relativeStepsFromRoot[i + 10] - relativeStepsFromRoot[i];
                int stepsToThrirteenth = relativeStepsFromRoot[i + 12] - relativeStepsFromRoot[i];

                var c = new Chord(name, stepsToThird, stepsToFifth, stepsToSeventh, stepsToNinth, stepsToEleventh, stepsToThrirteenth);

                result[i] = c;

            }

            return result;
        }

        public static ModeWithChords GetModeWithChords(Note root, ModeEnum mode)
        {
            var chords = Chords(root, mode);
            var result = new ModeWithChords();

            result.Mode = mode;
            result.First = chords[0];
            result.Second = chords[1];
            result.Third = chords[2];
            result.Fourth = chords[3];
            result.Fifth = chords[4];
            result.Sixth = chords[5];
            result.Seventh = chords[6];

            return result;
        }
        public static List<List<ModeWithChords>> GetAllModesWithChords(Note root)
        {
            //var result = new ModeWithChords[7 * (int)extensions];
            var fullresult = new List<List<ModeWithChords>>();

            foreach (var mode in Helpers.AllModes)
            {
                var moderesult = new List<ModeWithChords>();

                moderesult.Add(GetModeWithChords(root, mode));
                fullresult.Add(moderesult);
            }
            return fullresult;
        }
    }
}