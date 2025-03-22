using System.Text.RegularExpressions;

namespace WordleSolver.Server.Solver {
    public class WordList {
        private static WordList? _instance;
        private readonly List<string> words = new List<string>();
        public static WordList GetInstance() {
            if (_instance is null) {
                _instance = new WordList();
            }
            return _instance;
        }

        private WordList() {
            var filePath = Path.Combine(Environment.CurrentDirectory, "Resources/word-list.txt");
            words = File.ReadAllLines(filePath).ToList();
        }

        public List<string> GetMatches(string regex) {
            return words.Where(words => Regex.IsMatch(words, regex)).ToList();
        }
    }
}