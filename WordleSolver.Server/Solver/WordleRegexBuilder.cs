namespace WordleSolver.Server.Solver {
    public class WordleRegexBuilder {
        // Sets a letter slot to the given letter
        public WordleRegexBuilder SetLetter(char letter, int position) {
            return this;
        }

        // Removes the letter as a potential option from all slots
        public WordleRegexBuilder ExcludeLetter(char letter) {
            return this;
        }

        // Restricts the letter from the letter slot, but adds a requirement that the letter exists somewhere 
        public WordleRegexBuilder RestrictLetter(char letter, int position) {
            return this;
        }

        public string Build() {
            return "";
        }
    }
}
