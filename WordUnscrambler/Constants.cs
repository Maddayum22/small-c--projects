using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    public class Constants
    {
        public const string wordListFileName = "wordlist.txt";

        public const string optionsOnHowToEnterScrambledWords = "Enter scrambled words manually or as a file: M - Manual/F - File ";
        public const string optionsOnContinuingProgram = "Would you like to continue?: Y/N ";
        public const string enterScrambledWordsViaFile = "Enter full patch including filename: ";
        public const string enterScrambledWordsManually = "Enter words manually (seperated by commas if multiple): ";
        public const string enterScrambledWordsOptionNotRecognized = "The option was not recognized";

        public const string errorScrambledWordsCannotBeLoaded = "Scrambled words cannot be loaded.";
        public const string errorProgramWillBeTerminated = "Program will be terminated";

        public const string matchedFound = "Match found for {0}: {1}";
        public const string noMatchedWordsFound = "No matched words have been found.";

        public const string WordListNotFound = "Word list could not be found.";

    }
}
