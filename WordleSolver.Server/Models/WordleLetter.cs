namespace WordleSolver.Server.Models
{
    public enum Hint
    {
        NotPresent,
        WrongPlace,
        RightPlace
    }

    public class WordleLetter
    {
        public char Letter { get; set; }
        public Hint LetterHint { get; set; }
    }
}
