using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordleSolver.Server.Solver;

namespace WordleSolver.Tests.Solver {
    public class WordleRegexBuilderTests {
        [Fact]
        public void SetLetter_ShouldGivePatternThatMatchesWordWithLetter() {
            // Arrange
            var builder = new WordleRegexBuilder();

            // Act
            builder.SetLetter('a', 0);
            string pattern = builder.Build();

            // Assert
            Assert.Matches(pattern, "apple");
            Assert.DoesNotMatch(pattern, "lions");
        }
    }
}
