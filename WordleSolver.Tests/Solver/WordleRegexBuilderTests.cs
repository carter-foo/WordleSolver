using System.Text.RegularExpressions;
using WordleSolver.Server.Controller.Models;
using WordleSolver.Server.Solver;

namespace WordleSolver.Tests.Solver {
    public class WordleRegexBuilderTests {
        [Fact]
        public void Regex_ShouldMatchWord_WhenWordFits() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "words", Colors = ["grey", "green", "yellow", "yellow", "grey",] });
            var regex = builder.Build();

            Assert.Matches(regex, "rodeo");
        }

        [Fact]
        public void Regex_ShouldNotMatchWord_WhenWordDoesNotFit() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "words", Colors = ["grey", "green", "yellow", "yellow", "grey",] });
            var regex = builder.Build();

            Assert.DoesNotMatch(regex, "horse");
        }

        [Fact]
        public void Regex_ShouldNotMatchWord_WhenGuessExcludesLetterInWord() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "waves", Colors = ["grey", "grey", "grey", "grey", "grey"] });
            var regex = builder.Build();

            Assert.DoesNotMatch(regex, "wbbbb");
        }

        [Fact]
        public void Regex_ShouldNotMatchWord_WhenGuessHasYellowLetterInSamePlace() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "waves", Colors = ["yellow", "grey", "grey", "grey", "grey"] });
            var regex = builder.Build();

            Assert.DoesNotMatch(regex, "wbbbb");
        }

        [Fact]
        public void Regex_ShouldNotMatchWord_WhenGuessIncludesLetterNotInWord() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "words", Colors = ["grey", "green", "grey", "grey", "grey"] });
            var regex = builder.Build();

            Assert.DoesNotMatch(regex, "aaaaa");
        }

        [Fact]
        public void Regex_ShouldNotMatchWord_WhenGuessHasYellowLetterNotInWord() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "words", Colors = ["grey", "green", "yellow", "grey", "grey"] });
            var regex = builder.Build();

            Assert.DoesNotMatch(regex, "aaaaa");
        }

        [Fact]
        public void Regex_ShouldNotMatchWord_WhenGuessHasYellowAndGreyOfLetterButWordHasTwoOfThatLetter() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "goose", Colors = ["grey", "yellow", "grey", "grey", "grey"] });
            var regex = builder.Build();

            Assert.DoesNotMatch(regex, "oaaao");
        }

        [Fact]
        public void Regex_ShouldMatchWord_WhenGuessHasYellowAndGreyOfLetterAndWordHasOneOfThatLetter() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "goose", Colors = ["grey", "yellow", "grey", "grey", "grey"] });
            var regex = builder.Build();

            Assert.Matches(regex, "oaaaa");
        }

        [Fact]
        public void Regex_ShouldNotMatchWord_WhenGuessHasYellowAndGreyOfLetterButWordDoesNotHaveThatLetter() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "goose", Colors = ["grey", "yellow", "grey", "grey", "grey"] });
            var regex = builder.Build();

            Assert.DoesNotMatch(regex, "aaaaa");
        }

        [Fact]
        public void Regex_ShouldMatchWord_WhenMultipleGuessesWithRepeatingLettersProvided() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "words", Colors = ["grey", "green", "yellow", "yellow", "grey",] })
                .AddGuess(new WordleGuess { Word = "goose", Colors = ["grey", "green", "yellow", "grey", "yellow",] });
            var regex = builder.Build();

            Assert.Matches(regex, "rodeo");
        }

        [Fact]
        public void Regex_ShouldMatchWord_WhenGreyLetterAppearsBeforeGreenSameLetterInGuess() {
            var builder = new WordleRegexBuilder();
            builder.AddGuess(new WordleGuess { Word = "lions", Colors = ["yellow", "grey", "grey", "grey", "grey",] })
                .AddGuess(new WordleGuess { Word = "abele", Colors = ["green", "yellow", "grey", "green", "green",] });
            var regex = builder.Build();
            Assert.Matches(regex, "amble");
        }
        
        [Fact]
        public void AddGuess_ShouldThrowException_WhenInvalidColor() {
            var builder = new WordleRegexBuilder();
            Assert.Throws<ArgumentException>(() => builder.AddGuess(new WordleGuess { Word = "words", Colors = ["grey", "green", "yellow", "yellow", "blue",] }));
        }
    }
}