namespace WordleSolver.Server.Models {
    [WordleGuessValidation]
    public class WordleGuess {
        public required string Word { get; init; }
        public required IReadOnlyList<string> Colors { get; init; }
    }
}
