using System.ComponentModel.DataAnnotations;

namespace WordleSolver.Server.Models {
    public class GuessHistory {
        [Required]
        public required IReadOnlyList<WordleGuess> Guesses { get; init; }
    }
}
