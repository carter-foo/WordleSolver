namespace WordleSolver.Server.Models
{
    public class WordleGuess
    {
        public WordleLetter[] Letters { get; set; }

        public string StringRepresentation => String.Concat(Enumerable.Range(0, Letters.Length).Select(Index => Letters[Index].Letter));
    }
}
