using Xunit;
using static Json.Classes.JsonString;

namespace JsonFacts.Classes
{
    public class JsonStringFacts
    {
        [Fact]
        public void IsJsonString_IsWrappedInDoubleQuotes_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted("abc")));
        }

        [Fact]
        public void IsJsonString_AlwaysStartsWithQuotes_ShouldReturnFalse()
        {
            Assert.False(IsJsonString("abc\""));
        }

        [Fact]
        public void IsJsonString_AlwaysEndsWithQuotes_ShouldReturnTrue()
        {
            Assert.False(IsJsonString("\"abc"));
        }

        [Fact]
        public void IsJsonString_IsNotNull_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(null));
        }

        [Fact]
        public void IsJsonString_IsNotAnEmptyString_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(string.Empty));
        }

        [Fact]
        public void IsJsonString_IsAnEmptyDoubleQuotedString_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(string.Empty)));
        }

        [Fact]
        public void IsJsonString_HasStartAndEndQuotes_ShouldReturnFalse()
        {
            Assert.False(IsJsonString("\""));
        }

        [Fact]
        public void IsJsonString_DoesNotContainControlCharacters_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(Quoted("a\nb\rc")));
        }

        [Fact]
        public void IsJsonString_CanContainLargeUnicodeCharacters_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted("⛅⚾")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedQuotationMark_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"\""a\"" b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedReverseSolidus_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \\ b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedSolidus_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \/ b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedBackspace_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \b b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedFormFeed_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \f b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedLineFeed_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \n b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedCarrigeReturn_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \r b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedHorizontalTab_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \t b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedUnicodeCharacters_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \u26Be b")));
        }

        [Fact]
        public void IsJsonString_DoesNotContainUnrecognizedEscapedCharacters_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(Quoted(@"a\x")));
        }

        [Fact]
        public void IsJsonString_DoesNotEndWithReverseSolidus_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a\")));
        }

        [Fact]
        public void IsJsonString_DoesNotEndWithAnUnfinishedHexNumber_ShouldReturnTrue()
        {
            Assert.False(IsJsonString(Quoted(@"a\u")) && IsJsonString(Quoted(@"a\u123")));
        }

        [Fact]
        public void IsJsonString_ContainOnlyWhiteSpace_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted("       ")));
        }

        [Fact]
        public void IsJsonString_ContainOnlyEscapedReverseSolidus_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"\\")));
        }

        [Fact]
        public void IsJsonString_BeginAndEndsWithEscapedReverseSolidus_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"\\ abcd \\")));
        }

        [Fact]
        public void IsJsonString_ContainValidUnicodeAndUnrecognizedEscapedCharacter_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(Quoted(@"abc \u005B \q def")));
        }

        [Fact]
        public static void IsJsonString_ContainValidUnicodeAndEscapedCharacters_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"1Ec \u007C \r qwe \r \t \\")));
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
