using Microsoft.AspNetCore.Mvc;
using WordleSolver.Server.Filters;
using WordleSolver.Server.Models;

namespace WordleSolver.Server.Controllers {
    [ApiController]
    [Route("WordleSolver")]
    public class WordleSolverController : ControllerBase {
        private readonly ILogger<WordleSolverController> _logger;

        public WordleSolverController(ILogger<WordleSolverController> logger) {
            _logger = logger;
        }

        [HttpPost(Name = "CalculateNextGuess")]
        [ValidateModel]
        public string Post(GuessHistory Guesses) {
            return "lions";
        }
    }
}
