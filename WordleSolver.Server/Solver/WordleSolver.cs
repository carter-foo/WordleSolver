using WordleSolver.Server.Controller.Models;

namespace WordleSolver.Server.Solver {
    public class WordleSolver {
        public static WordleSolverResponse GenerateSuggestions(GuessHistory guessHistory) {
            var builder = new WordleRegexBuilder();
            
            foreach (var guess in guessHistory.Guesses) {
                
            }

            return new WordleSolverResponse {
                Suggestions = new List<string> { "apple", "banana", "cherry" }
            };
        }
    }
}
