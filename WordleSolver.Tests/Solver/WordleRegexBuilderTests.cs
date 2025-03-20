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
        public void SetLetter_ShouldMatchWordWithLetter() {
            // Arrange
            var builder = new WordleRegexBuilder();

            // Act
            builder.SetLetter('a', 0);
            string pattern = builder.Build();

            // Assert
            Assert.Matches(pattern, "apple");
            Assert.DoesNotMatch(pattern, "lions");
        }

        [Fact]
        public void ExcludeLetter_ShouldNotMatchWordWithLetter() {
            // Arrange
            var builder = new WordleRegexBuilder();
            
            // Act
            builder.ExcludeLetter('a');
            string pattern = builder.Build();

            // Assert
            Assert.DoesNotMatch(pattern, "apple");
            Assert.Matches(pattern, "lions");
        }

        [Fact]
        public void RestrictLetter_ShouldMatchWordWithLetterInAnyOtherPosition() {
            // Arrange
            var builder = new WordleRegexBuilder();
            
            // Act
            builder.RestrictLetter('a', 0);
            string pattern = builder.Build();
            
            // Assert
            Assert.DoesNotMatch(pattern, "apple");
            Assert.DoesNotMatch(pattern, "lions");
            Assert.Matches(pattern, "place");
        }

        [Fact]
        public void SetLetterAndRestrictSameLetter_ShouldNotMatchWordWithOnlySetLetter() {
            // Arrange
            var builder = new WordleRegexBuilder();

            // Act
            builder.SetLetter('p', 1);
            builder.RestrictLetter('p', 0);
            string pattern = builder.Build();

            // Assert
            Assert.DoesNotMatch(pattern, "spend");
        }
    }
}
