
using Xunit;
using static Json.JsonNumber;

namespace Json
{
    public class JsonNumberFacts
    {
        [Fact]
        public void IsJsonNumber_CanBeZero_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("0"));
        }

        [Fact]
        public void IsJsonNumber_DoesNotContainLetters_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("a"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveASingleDigit_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("7"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveMultipleDigits_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("70"));
        }

        [Fact]
        public void IsJsonNumber_IsNotNull_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber(null));
        }

        [Fact]
        public void IsJsonNumber_IsNotAnEmptyString_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber(string.Empty));
        }

        [Fact]
        public void IsJsonNumber_DoesNotStartWithZero_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("07"));
        }

        [Fact]
        public void IsJsonNumber_CanBeNegative_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("-26"));
        }

        [Fact]
        public void IsJsonNumber_CanBeMinusZero_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("-0"));
        }

        [Fact]
        public void IsJsonNumber_CanBeFractional_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12.34"));
        }

        [Fact]
        public void IsJsonNumber_TheFractionCanHaveLeadingZeros_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("0.00000001") && IsJsonNumber("10.00000001"));
        }

        [Fact]
        public void IsJsonNumber_DoesNotEndWithADot_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("12."));
        }

        [Fact]
        public void IsJsonNumber_DoesNotHaveTwoFractionParts_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("12.34.56"));
        }

        [Fact]
        public void IsJsonNumber_TheDecimalPartDoesNotAllowLetters_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("12.3x"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveAnExponent_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12e3"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanStartWithCapitalE_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12E3"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanHavePositive_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12e+3"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeNegative_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("61e-9"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveFractionAndExponent_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12.34E3"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentDoesNotAllowLetters_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22e3x3"));
        }

        [Fact]
        public void IsJsonNumber_DoesNotHaveTwoExponents_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22e323e33"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentIsAlwaysComplete_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22e") && IsJsonNumber("22e+") && IsJsonNumber("23E-"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentIsAfterTheFraction_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22e3.3"));
        }

        [Fact]
        public void IsJsonNumber_ContainMultipleSameOperators_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("88e-3-2"));
        }

        [Fact]
        public void IsJsonNumber_StartsWithExponent_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("E23"));
        }

        [Fact]
        public void IsJsonNumber_ContainTwoOrMoreOperatorsInRow_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("1024-+"));
        }

        [Fact]
        public void IsJsonNumber_ContainOperatorAfterDigit_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("44+"));
        }

        [Fact]
        public void IsJsonNumber_ContainExponentAndFraction_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12.3E-2"));
        }

        [Fact]
        public void IsJsonNumber_IsZeroAndContainExponent_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("0e2"));
        }

        [Fact]
        public void IsJsonNumber_IsZerotAndContainFraction_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("0.2e-1"));
        }

        [Fact]
        public void IsJsonNumber_IsNegativeZeroAndContainExponent_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("-0e5"));
        }

        [Fact]
        public void IsJsonNumber_IsNegativeContainExponentAndFraction_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("-10.e+5"));
        }
    }
}
