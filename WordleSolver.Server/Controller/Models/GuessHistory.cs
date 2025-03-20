using System.ComponentModel.DataAnnotations;

namespace WordleSolver.Server.Controller.Models {
    public class GuessHistory {
        [Required]
        public required IReadOnlyList<WordleGuess> Guesses { get; init; }
    }
}
