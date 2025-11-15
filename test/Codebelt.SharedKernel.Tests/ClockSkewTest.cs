using System;
using Cuemon.Extensions.IO;
using Codebelt.Extensions.Xunit;
using Savvyio.Extensions.Newtonsoft.Json;
using Savvyio.Extensions.Text.Json;
using Xunit;

namespace Codebelt.SharedKernel
{
    public class ClockSkewTest : Test
    {
        public ClockSkewTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Comparison_LeftShouldBeGreaterThanRight()
        {
            var left = ClockSkew.MaxValue;
            var right = ClockSkew.MinValue;
            Assert.True(left > right);
        }

        [Fact]
        public void Comparison_RightShouldBeGreaterThanLeft()
        {
            var left = ClockSkew.MinValue;
            var right = ClockSkew.MaxValue;
            Assert.True(left < right);
        }

        [Fact]
        public void Comparison_LeftShouldBeGreaterThanOrEqualToRight()
        {
            var left = new ClockSkew(TimeSpan.FromHours(1));
            var right = new ClockSkew(TimeSpan.FromHours(1));
            Assert.True(left >= right);
        }

        [Fact]
        public void Comparison_RightShouldBeGreaterThanOrEqualToLeft()
        {
            var left = new ClockSkew(TimeSpan.FromHours(1));
            var right = new ClockSkew(TimeSpan.FromHours(2));
            Assert.True(left <= right);
        }
        
        [Fact]
        public void Comparison_ShouldBeEqual()
        {
            var left = new ClockSkew(TimeSpan.FromHours(1));
            var right = new ClockSkew(TimeSpan.FromHours(1));
            Assert.Equal(right, left);
        }

        [Fact]
        public void Comparison_ShouldBeDifferent()
        {
            var left = new ClockSkew(TimeSpan.FromTicks(1));
            var right = new ClockSkew(TimeSpan.FromHours(1));
            Assert.NotEqual(right, left);
        }

        [Fact]
        public void FromMinutes_ShouldHaveFifteenMinutesSkew()
        {
            var sut = ClockSkew.FromMinutes(15);

            Assert.Equal(15, sut.Value.TotalMinutes);
        }

        [Fact]
        public void FromSeconds_ShouldHaveThirtySecondsSkew()
        {
            var sut = ClockSkew.FromSeconds(30);

            Assert.Equal(30, sut.Value.TotalSeconds);
        }

        [Fact]
        public void Marshalling_ShouldRepresentCorrectly()
        {
            var sut = ClockSkew.FromSeconds(30);
            var json = JsonMarshaller.Default.Serialize(sut).ToEncodedString();
            var newtonsoftJson = NewtonsoftJsonMarshaller.Default.Serialize(sut).ToEncodedString();

            TestOutput.WriteLine(json);

            Assert.Equal("\"00:00:30\"", json);
            Assert.Equal(json, newtonsoftJson);
        }
    }
}
