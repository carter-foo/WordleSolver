using Microsoft.AspNetCore.Mvc;
using WordleSolver.Server.Controller.Filters;
using WordleSolver.Server.Controller.Models;

namespace WordleSolver.Server.Controller {
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
