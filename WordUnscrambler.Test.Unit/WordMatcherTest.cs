using WordUnscrambler.workers;

namespace WordUnscrambler.Test.Unit
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();

        [TestMethod]
        public void ScrambledWordMatchesGivenWordInTheList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWord = { "arihc" };
            var matchedWords = _wordMatcher.Match(scrambledWord, words);

            Assert.IsTrue(matchedWords.Count() == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("arihc"));
            Assert.IsTrue(matchedWords[0].Word.Equals("chair"));
        }

        [TestMethod]
        public void ScrambledWordsMatchGivenWordsInTheList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWords = { "arihc", "act" };
            var matchedWords = _wordMatcher.Match(scrambledWords, words);   

            Assert.IsTrue(matchedWords.Count() == 2);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("arihc"));
            Assert.IsTrue(matchedWords[0].Word.Equals("chair"));
            Assert.IsTrue(matchedWords[1].ScrambledWord.Equals("act"));
            Assert.IsTrue(matchedWords[1].Word.Equals("cat"));
        }
    }
}