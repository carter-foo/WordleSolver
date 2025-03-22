using WordleSolver.Server.Controller.Models;

namespace WordleSolver.Server.Solver {
    public class WordleRegexBuilder {

        private readonly Dictionary<int, char> foundLetters = [];
        private readonly LetterTracker letterTracker = new();

        public WordleRegexBuilder AddGuess(WordleGuess guess) {
            var wordMins = new Dictionary<char, int>();
            var wordMaxes = new Dictionary<char, int>();
            for (int i = 0; i < guess.Word.Length; i++) {
                var letter = guess.Word[i];
                var color = guess.Colors[i];
                if (color == "green") {
                    // In the correct position
                    foundLetters[i] = letter;
                    // Increase the min for this letter because we found one
                    if (wordMins.TryGetValue(letter, out int min)) {
                        wordMins[letter] = min + 1;
                    } else {
                        wordMins[letter] = 1;
                    }
                } else if (color == "yellow") {
                    // There exists one more of this letter in the word
                    if (wordMins.TryGetValue(letter, out int min)) {
                        wordMins[letter] = min + 1;
                    } else {
                        wordMins[letter] = 1;
                    }
                } else if (color == "grey") {
                    // There exists no more of this letter in the word
                    if (wordMins.TryGetValue(letter, out int min)) {
                        wordMaxes[letter] = min;
                    } else {
                        wordMaxes[letter] = 0;
                    }
                } else {
                    throw new ArgumentException($"Invalid color: {color}");
                }
            }

            try {
                foreach (var letter in wordMins.Keys) {
                    letterTracker.SuggestMin(letter, wordMins[letter]);
                }
                foreach (var letter in wordMaxes.Keys) {
                    letterTracker.SuggestMax(letter, wordMaxes[letter]);
                }
            } catch (ArgumentException) {
                throw new ArgumentException($"Guess \"{guess.Word}\" contradicts another guess.");
            }

            return this;
        }

        public string Build() {
            string pattern = "";

            // Add min/max amounts for each letter via lookaheads
            foreach(var letter in letterTracker.GetTrackedLetters()) {
                int min = letterTracker.GetMin(letter);
                int max = letterTracker.GetMax(letter);
                if (min > 0) {
                    pattern += $"(?=(?:.*{letter}.*){{{min}}})";
                }
                if (max < 5) {
                    pattern += $"(?!(?:.*{letter}.*){{{max + 1}}})";
                }
            }

            // Add the found letters to the pattern, or an [a-z] if not found
            for (int i = 0; i < 5; i++) {
                if (foundLetters.TryGetValue(i, out char value)) {
                    pattern += value;
                } else {
                    pattern += "[a-z]";
                }
            }

            return pattern;
        }
    }
}
