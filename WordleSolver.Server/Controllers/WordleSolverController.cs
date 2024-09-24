using Microsoft.AspNetCore.Mvc;
using WordleSolver.Server.Models;

namespace WordleSolver.Server.Controllers
{
    [ApiController]
    [Route("wordlesolver")]
    public class WordleSolverController : ControllerBase
    {
        private readonly ILogger<WordleSolverController> _logger;

        public WordleSolverController(ILogger<WordleSolverController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name="CalculateNextGuess")]
        public string Post (GuessHistory Guesses)
        {
            foreach (WordleGuess Guess in Guesses.Guesses)
            {
                _logger.Log(LogLevel.Information, Guess.StringRepresentation);
            }
            return "lions";
        }
    }
}
