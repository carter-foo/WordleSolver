using System.ComponentModel.DataAnnotations;

namespace WordleSolver.Server.Controller.Models.Validation {
    public class WordleGuessValidationAttribute : ValidationAttribute {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value == null) {
                return new ValidationResult("Guess cannot be null");
            }
            var guess = (WordleGuess)value;
            if (guess.Word.Length != 5) {
                return new ValidationResult("Word must be 5 characters long");
            }
            if (guess.Colors.Count != 5) {
                return new ValidationResult("Must supply 5 colors");
            }
            return ValidationResult.Success;
        }
    }
}
