namespace WordleSolver.Server.Controller.Models {
    public class WordleSolverResponse {
        public required IReadOnlyList<string> Suggestions { get; init; }
    }
}
