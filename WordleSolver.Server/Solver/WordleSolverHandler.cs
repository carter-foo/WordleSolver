using WordleSolver.Server.Controller.Models;

namespace WordleSolver.Server.Solver {
    public class WordleSolverHandler {
        public static WordleSolverResponse GenerateSuggestions(GuessHistory guessHistory) {
            var builder = new WordleRegexBuilder();
            var wordList = WordList.GetInstance();
            
            foreach (var guess in guessHistory.Guesses) {
                builder.AddGuess(guess);
            }
            string regex = builder.Build();
            var matches = wordList.GetMatches(regex);

            return new WordleSolverResponse {
                Suggestions = matches
            };
        }
    }
}
