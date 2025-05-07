using WordleSolver.Server.Controller.Models;

namespace WordleSolver.Server.Solver {
    public class WordleSolverHandler {
        private static readonly int _maxSuggestions = 15;
        public static WordleSolverResponse GenerateSuggestions(GuessHistory guessHistory) {
            var builder = new WordleRegexBuilder();
            var wordList = WordList.GetInstance();
            
            foreach (var guess in guessHistory.Guesses) {
                builder.AddGuess(guess);
            }
            string regex = builder.Build();
            var matches = wordList.GetTopMatches(regex, _maxSuggestions);

            return new WordleSolverResponse {
                Suggestions = matches
            };
        }
    }
}
