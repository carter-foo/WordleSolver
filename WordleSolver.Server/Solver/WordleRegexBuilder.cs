namespace WordleSolver.Server.Solver {
    public class WordleRegexBuilder {
        private Dictionary<int, char> _knownLetters;
        private Dictionary<int, char> _restrictedLetters;
        private List<char> excludedLetters;

        public WordleRegexBuilder() {
            _knownLetters = [];
            _restrictedLetters = [];
            excludedLetters = [];
        }

        // Sets a letter slot to the given letter
        public WordleRegexBuilder SetLetter(char letter, int position) {
            _knownLetters[position] = letter;
            return this;
        }

        // Removes the letter as a potential option from all slots
        public WordleRegexBuilder ExcludeLetter(char letter) {
            excludedLetters.Add(letter);
            return this;
        }

        // Restricts the letter from the letter slot, but adds a requirement that the letter exists somewhere 
        public WordleRegexBuilder RestrictLetter(char letter, int position) {
            _restrictedLetters[position] = letter;
            return this;
        }

        public string Build() {
            /*
             * For each position:
             * 1. If the position is known, add the letter and move to the next
             * 2. If there are particular restrictions for the position, add the restriction to the pattern
             * 3. Add restrictions for each excluded letter
             * 
             * At the end, add a lookahead for each restricted letter
             */

            bool needsLookahead = _restrictedLetters.Count > 0;

            string result = "^";

            if (needsLookahead) {
                result += "(?=";
            }

            for (int i = 0; i < 5; i++) { 
                if(_knownLetters.ContainsKey(i)) {
                    result += _knownLetters[i];
                    continue;
                }

                var restrictions = new List<char>();
                if (_restrictedLetters.ContainsKey(i)) {
                    restrictions.Add(_restrictedLetters[i]);
                }
                restrictions.AddRange(excludedLetters);

                if (restrictions.Count > 0) {
                    string addition = "[^";
                    foreach (char restriction in restrictions) {
                        addition += $"{restriction}";
                    }
                    addition += "]";
                    result += addition;
                } else {
                    result += ".";
                }
                
            }

            result += "$";

            if (needsLookahead) {
                result += ")";
            }

            foreach(var restriction in _restrictedLetters) {
                result += $"(?=.*{restriction.Value})";
            }
            result += ".*";

            return result;
        }
    }
}
