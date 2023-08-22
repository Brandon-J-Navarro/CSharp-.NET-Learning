using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string OptionOnHowToEnterScrambledWords = "Enter scrambled word(s) manually or as a file: M - Manual / F - File";
        public const string OptionOnContinuingTheProgam = "Do you want to continue? Y/N";        
        
        public const string EnterScrambledWordsViaFile = "Enter full path including file name: ";
        public const string EnterScrambledWordsManually = "Enter word(s) manually (separated by commas if multiple): ";
        public const string EnterScrambledWordsOptionNotReconized = "The option was not recognized.";

        public const string Yes = "Y";
        public const string No = "N";

        public const string File = "F";
        public const string Manual = "M";


        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because there was an error.";
        public const string ErrorProgramWillBeTerminated = "The progam will be terminated.";

        public const string MatchFound = "Match found for '{0}': {1}";
        public const string MatchNotFound = "No Matches have been found.";

        public const string WordListFileName = "Resources\\MITs10000-wordlist.txt";
    }
}
