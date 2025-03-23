namespace WordleSolver.Server.Solver {
    public class LetterTracker {
        private Dictionary<char, (int min, int max)> _Letters;
        public LetterTracker() {
            _Letters = [];
        }

        public int GetMin(char letter) {
            return _Letters.TryGetValue(letter, out (int min, int max) value) ? value.min : 0;
        }

        public int GetMax(char letter) {
            return _Letters.TryGetValue(letter, out (int min, int max) value) ? value.max : 5;
        }

        public List<char> GetTrackedLetters() {
            return _Letters.Keys.ToList();
        }

        private void SetMax(char letter, int max) {
            if (!_Letters.ContainsKey(letter)) {
                _Letters[letter] = (0, max);
            } else {
                _Letters[letter] = (_Letters[letter].min, max);
            }
        }

        private void SetMin(char letter, int min) {
            if (!_Letters.ContainsKey(letter)) {
                _Letters[letter] = (min, 5);
            } else {
                _Letters[letter] = (min, _Letters[letter].max);
            }
        }

        /* Suggests a new minimum that is ignored if the minimum is already greater than the one provided */
        public void SuggestMin(char letter, int min) {
            if (min > GetMax(letter)) {
                throw new ArgumentException("Minimum cannot be greater than current maximum.");
            }
            SetMin(letter, Math.Max(min, GetMin(letter)));
        }

        /* Sets the maximum to the minimum */
        public void MaxOut(char letter) {
            SetMax(letter, GetMin(letter));
        }
    }
}
