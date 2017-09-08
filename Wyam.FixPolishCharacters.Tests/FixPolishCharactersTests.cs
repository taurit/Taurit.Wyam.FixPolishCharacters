using Xunit;

namespace Wyam.FixPolishCharacters.Tests
{
    public class FixPolishCharactersTests
    {
        [Fact]
        public void PolishCharacterShouldBeReplaced_ę()
        {
            // Arrange
            FixPolishCharacters sut = new FixPolishCharacters();

            // Act
            var fixedString = sut.FixPolishUtfCharacters("Jak odzwyczajam si&#x119; od Youtube - Zakasane r&#x119;kawy");

            // Assert
            Assert.Equal("Jak odzwyczajam się od Youtube - Zakasane rękawy", fixedString);
        }
        [Fact]
        public void PolishCharacterShouldBeReplaced_ś()
        {
            // Arrange
            FixPolishCharacters sut = new FixPolishCharacters();

            // Act
            var fixedString = sut.FixPolishUtfCharacters("wtorek, 5 wrze&#x15B;nia 2017 r.");

            // Assert
            Assert.Equal("wtorek, 5 września 2017 r.", fixedString);
        }

        [Fact]
        public void PolishCharacterShouldBeReplaced_WhenUtfCharactersUseCapitalLetters()
        {
            // Arrange
            FixPolishCharacters sut = new FixPolishCharacters();

            // Act
            var fixedString = sut.FixPolishUtfCharacters("wtorek, 5 wrze&#X15B;nia 2017 r.");

            // Assert
            Assert.Equal("wtorek, 5 września 2017 r.", fixedString);
        }

        [Fact]
        public void ReplaceCaseInsensitive_ShouldWorkWithSpecialCharacters()
        {
            // Arrange
            string input = "&#x15B; &#X15B; &#x15b;";

            // Act
            var output = input.ReplaceCaseInsensitive("&#x15B;", "ś");

            // Assert 
            Assert.Equal("ś ś ś", output);
        }

    }
}