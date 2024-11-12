using System;
using System.Linq;
using Cuemon;
using Cuemon.Extensions.IO;
using Codebelt.Extensions.Xunit;
using Savvyio.Extensions.Newtonsoft.Json;
using Savvyio.Extensions.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace Codebelt.SharedKernel
{
    public class TokenTest : Test
    {
        public static TheoryData<string> WhitespaceCharacters => new(Alphanumeric.WhiteSpace.ToCharArray().Where(c => c != 6158).Select(c => c.ToString()));
        
        public TokenTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException()
        {
            var message = Assert.Throws<ArgumentNullException>(() =>
            {
                new Token(null);
            }).Message;

            Assert.Equal("Value cannot be null, empty or consist only of white-space characters. (Parameter 'value')", message);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenValueIsEmpty()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                new Token("");
            }).Message;

            Assert.Equal("Value cannot be null, empty or consist only of white-space characters. (Parameter 'value')", message);
        }

        [Theory]
        [MemberData(nameof(WhitespaceCharacters))]
        public void Constructor_ShouldThrowArgumentException_WhenValueIsWhitespace(string value)
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                new Token(value);
            }).Message;

            Assert.Equal("Value cannot be null, empty or consist only of white-space characters. (Parameter 'value')", message);
        }

        [Theory]
        [MemberData(nameof(WhitespaceCharacters))]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenValueContainsNonAsciiValues(string value)
        {
            var message = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new Token(string.Concat(Generate.RandomString(12), value, Generate.RandomString(22)));
            }).Message;

            Assert.StartsWith("White-space characters are not allowed inside value. (Parameter 'value')", message);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenValueHasLessThan32Characters()
        {
            var sut = Assert.Throws<ArgumentOutOfRangeException>(() => new Token(Generate.RandomString(31)));

            TestOutput.WriteLine(sut.Message);

            Assert.StartsWith("The minimum length of value was not meet. 32 characters are required. (Parameter 'value')", sut.Message);
            Assert.Equal("31 < 32", sut.ActualValue);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenValueHasExceeded128Characters()
        {
            var sut = Assert.Throws<ArgumentOutOfRangeException>(() => new Token(Generate.RandomString(129)));

            TestOutput.WriteLine(sut.Message);

            Assert.StartsWith("The maximum length of value was exceeded. 128 characters are allowed. (Parameter 'value')", sut.Message);
            Assert.Equal("129 > 128", sut.ActualValue);
        }

        [Fact]
        public void Constructor_ShouldNotThrowArgumentOutOfRangeException_WhenValueHasLessThan32Characters()
        {
            var sut = new Token(Generate.RandomString(20), o => o.MinimumLength = 0);

            TestOutput.WriteLine(sut);

            Assert.Equal(20, sut.Value.Length);
        }

        [Fact]
        public void Constructor_ShouldNotThrowArgumentOutOfRangeException_WhenValueHasExceededMaxCharacters()
        {
            var sut = new Token(Generate.RandomString(255), o => o.MaximumLength = 0);

            TestOutput.WriteLine(sut);

            Assert.Equal(255, sut.Value.Length);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenValueHasHighCharacterFrequency()
        {
            var sut = Assert.Throws<ArgumentOutOfRangeException>(() => new Token(Generate.RandomString(32, "a", "b", "c", "d")));

            TestOutput.WriteLine(sut.Message);

            Assert.StartsWith("Value suggest to high frequency of repeated characters. At least 4 distinct characters are required. (Parameter 'value')", sut.Message);
            Assert.Equal("a,b,c,d", sut.ActualValue);
        }

        [Fact]
        public void Marshalling_ShouldRepresentCorrectly()
        {
            var sut = new Token("1acb4e4928a64206b22b2392ffd4e605");
            var json = JsonMarshaller.Default.Serialize(sut).ToEncodedString();
            var newtonsoftJson = NewtonsoftJsonMarshaller.Default.Serialize(sut).ToEncodedString();

            TestOutput.WriteLine(json);

            Assert.Equal("\"1acb4e4928a64206b22b2392ffd4e605\"", json);
            Assert.Equal(json, newtonsoftJson);
        }
    }
}
