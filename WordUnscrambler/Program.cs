using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.workers;
using WordUnscrambler.data;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;

            do
            {
                Console.WriteLine(Constants.optionsOnHowToEnterScrambledWords);
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "F":
                        Console.Write(Constants.enterScrambledWordsViaFile);
                        ExecuteFileScenario();
                        break;
                    case "M":
                        Console.Write(Constants.enterScrambledWordsManually);
                        ExecuteManualScenario();
                        break;
                    default:
                        Console.Write(Constants.enterScrambledWordsOptionNotRecognized);
                        break;
                }

                var continueDecision = string.Empty;

                do
                {

                    Console.WriteLine("Do you want to continue? (Y or N)");
                    continueDecision = Console.ReadLine() ?? string.Empty;

                } while (!continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) 
                && !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);
        }

        private static void ExecuteManualScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayScrambledUnmatchedWords(scrambledWords);

        }

        private static void ExecuteFileScenario()
        {
            var filename = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayScrambledUnmatchedWords(scrambledWords);
        }

        private static void DisplayScrambledUnmatchedWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.matchedFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            } else
            {
                Console.WriteLine(Constants.noMatchedWordsFound);
            }
        }
    }
}
