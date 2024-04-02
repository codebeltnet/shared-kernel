using System;
using Cuemon.Extensions.IO;
using Cuemon.Extensions.Xunit;
using Savvyio.Extensions.Newtonsoft.Json;
using Savvyio.Extensions.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace Codebelt.SharedKernel
{
    public class CoordinatedUniversalTimeTest : Test
    {
        public static TheoryData<string> UtcCompliantDates => new()
        {
            "2020-01-01T00:00:00Z",
            "2024-03-17T15:27:30.0000000+08:00",
            "2024-02-29T10:15:30+02:00",
            CoordinatedUniversalTime.MaxValue.ToString(),
            CoordinatedUniversalTime.MinValue.ToString()
        };

        public CoordinatedUniversalTimeTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [MemberData(nameof(UtcCompliantDates))]
        public void FromString_ShouldBeExpressedAsCoordinatedUniversalTime(string value)
        {
            var sut = CoordinatedUniversalTime.FromString(value);
            Assert.Equal(DateTimeKind.Utc, sut.Value.Kind);
        }

        [Fact]
        public void FromString_ShouldThrowArgumentException_SinceNoLocalTimezoneOrCoordinatedUniversalTimeWasSpecified()
        {

            var message = Assert.Throws<ArgumentException>(() =>
            {
                CoordinatedUniversalTime.FromString("2020-01-01T00:00:00");
            }).Message;

            Assert.Equal("Value is not in a valid state. (Expression 'value.Kind != DateTimeKind.Utc') (Parameter 'value')", message);
        }

        [Fact]
        public void Comparison_LeftShouldBeGreaterThanRight()
        {
            var left = new CoordinatedUniversalTime(CoordinatedUniversalTime.MaxValue);
            var right = new CoordinatedUniversalTime(CoordinatedUniversalTime.MinValue);
            Assert.True(left > right);
        }

        [Fact]
        public void Comparison_RightShouldBeGreaterThanLeft()
        {
            var left = new CoordinatedUniversalTime(CoordinatedUniversalTime.MinValue);
            var right = new CoordinatedUniversalTime(CoordinatedUniversalTime.MaxValue);
            Assert.True(left < right);
        }

        [Fact]
        public void Comparison_LeftShouldBeGreaterThanOrEqualToRight()
        {
            var left = new CoordinatedUniversalTime(DateTime.UtcNow.Date);
            var right = new CoordinatedUniversalTime(DateTime.UtcNow.Date);
            Assert.True(left >= right);
        }

        [Fact]
        public void Comparison_RightShouldBeGreaterThanOrEqualToLeft()
        {
            var left = new CoordinatedUniversalTime(DateTime.UtcNow.Date);
            var right = new CoordinatedUniversalTime(DateTime.UtcNow.Date);
            Assert.True(left <= right);
        }
        
        [Fact]
        public void Comparison_ShouldBeEqual()
        {
            var left = new CoordinatedUniversalTime(DateTime.UtcNow.Date);
            var right = new CoordinatedUniversalTime(DateTime.UtcNow.Date);
            Assert.Equal(right, left);
        }

        [Fact]
        public void Comparison_ShouldBeDifferent()
        {
            var left = new CoordinatedUniversalTime(DateTime.UtcNow);
            var right = new CoordinatedUniversalTime(DateTime.UtcNow.AddHours(1));
            Assert.NotEqual(right, left);
        }

        [Fact]
        public void DateTime_ShouldConvertFromCoordinatedUniversalTime()
        {
            var sut = CoordinatedUniversalTime.FromString("2024-03-17T15:27:30.0000000+08:00");

            DateTime equivalent = sut.Value;

            Assert.Equal(sut.Value, equivalent);
        }

        [Fact]
        public void ImplicitConversion_ShouldConvertFromDateTimeOffset()
        {
            var expected = DateTimeOffset.Parse("2024-03-17T15:27:30.0000000+08:00");

            CoordinatedUniversalTime sut = expected;

            Assert.Equal(expected, sut);
        }

        [Fact]
        public void ImplicitConversion_ShouldConvertFromDateTime()
        {
            var expected = DateTime.UtcNow;

            CoordinatedUniversalTime sut = expected;

            Assert.Equal(expected, sut);
        }

        [Fact]
        public void Marshalling_ShouldRepresentCorrectly()
        {
            var sut = CoordinatedUniversalTime.FromString("2024-03-17T15:27:30.0000000+08:00");
            var json = JsonMarshaller.Default.Serialize(sut).ToEncodedString();
            var newtonsoftJson = NewtonsoftJsonMarshaller.Default.Serialize(sut).ToEncodedString();

            TestOutput.WriteLine(json);

            Assert.Equal("\"2024-03-17T07:27:30.0000000Z\"", json);
            Assert.Equal(json, newtonsoftJson);
        }
    }
}
