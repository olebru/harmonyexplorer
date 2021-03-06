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
        public static (Note[] notes, bool sharp) Notes(Note root, ModeEnum mode)
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
            var seenChar = new List<char>();
            for (int i = 0; i < result.Length - 1; i++)
            {
                var firstLetterInRoot = result[i].Name.ToCharArray()[0];
                if (seenChar.Contains(firstLetterInRoot))
                {
                    tryagain = true;
                }
                else
                {
                    seenChar.Add(firstLetterInRoot);
                }
            }
            if (tryagain)
            {
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

            var resultWithSharpFlag = (notes: result[range], sharp: sharp);

            return resultWithSharpFlag;
        }
        public static (Chord[] chords, bool sharp) Chords(Note root, ModeEnum mode)
        {
            var rootNoteSharpTuple = Notes(root, mode);
            Chord[] result = new Chord[rootNoteSharpTuple.notes.Length];
            //10 Octaves to prevent running out, if odd scales... its a magic number... kind of should be enough...
            var relativeStepsFromRoot = FunctionalScale.GetAbsouluteOffsetFromRoot(mode, octaves: 10);
            for (int i = 0; i < rootNoteSharpTuple.notes.Length; i++)
            {
                Note rootNote = rootNoteSharpTuple.notes[i];
                int stepsToThird = relativeStepsFromRoot[i + 2] - relativeStepsFromRoot[i];
                int stepsToFifth = relativeStepsFromRoot[i + 4] - relativeStepsFromRoot[i];
                int stepsToSeventh = relativeStepsFromRoot[i + 6] - relativeStepsFromRoot[i];
                int stepsToNinth = relativeStepsFromRoot[i + 8] - relativeStepsFromRoot[i];
                int stepsToEleventh = relativeStepsFromRoot[i + 10] - relativeStepsFromRoot[i];
                int stepsToThrirteenth = relativeStepsFromRoot[i + 12] - relativeStepsFromRoot[i];
                var c = new Chord(rootNote, stepsToThird, stepsToFifth, stepsToSeventh, stepsToNinth, stepsToEleventh, stepsToThrirteenth, rootNoteSharpTuple.notes);
                result[i] = c;
            }
            return (chords: result, sharp: rootNoteSharpTuple.sharp);
        }
        public static ModeWithChords GetModeWithChords(Note root, ModeEnum mode)
        {
            var chordSharpTuple = Chords(root, mode);
            var result = new ModeWithChords();
            result.Mode = mode;
            result.First = chordSharpTuple.chords[0];
            result.Second = chordSharpTuple.chords[1];
            result.Third = chordSharpTuple.chords[2];
            result.Fourth = chordSharpTuple.chords[3];
            result.Fifth = chordSharpTuple.chords[4];
            result.Sixth = chordSharpTuple.chords[5];
            result.Seventh = chordSharpTuple.chords[6];
            result.SharpAnnotation = chordSharpTuple.sharp;
            return result;
        }
        public static List<List<ModeWithChords>> GetAllModesWithChords(Note root)
        {

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