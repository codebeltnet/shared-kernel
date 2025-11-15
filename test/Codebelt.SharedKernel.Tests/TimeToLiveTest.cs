using System;
using Cuemon.Extensions.IO;
using Codebelt.Extensions.Xunit;
using Savvyio.Extensions.Newtonsoft.Json;
using Savvyio.Extensions.Text.Json;
using Xunit;

namespace Codebelt.SharedKernel
{
    public class TimeToLiveTest : Test
    {
        public TimeToLiveTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Comparison_LeftShouldBeGreaterThanRight()
        {
            var left = new TimeToLive(TimeSpan.FromDays(2));
            var right = new TimeToLive(TimeSpan.FromHours(1));
            Assert.True(left > right);
        }

        [Fact]
        public void Comparison_RightShouldBeGreaterThanLeft()
        {
            var left = new TimeToLive(TimeSpan.FromHours(1));
            var right = new TimeToLive(TimeSpan.FromDays(2));
            Assert.True(left < right);
        }

        [Fact]
        public void Comparison_LeftShouldBeGreaterThanOrEqualToRight()
        {
            var left = new TimeToLive(TimeSpan.FromDays(2));
            var right = new TimeToLive(TimeSpan.FromDays(2));
            Assert.True(left >= right);
        }

        [Fact]
        public void Comparison_RightShouldBeGreaterThanOrEqualToLeft()
        {
            var left = new TimeToLive(TimeSpan.FromHours(1));
            var right = new TimeToLive(TimeSpan.FromHours(2));
            Assert.True(left <= right);
        }
        
        [Fact]
        public void Comparison_ShouldBeEqual()
        {
            var left = new TimeToLive(TimeSpan.FromHours(1));
            var right = new TimeToLive(TimeSpan.FromHours(1));
            Assert.Equal(right, left);
        }

        [Fact]
        public void Comparison_ShouldBeDifferent()
        {
            var left = new TimeToLive(TimeSpan.FromTicks(1));
            var right = new TimeToLive(TimeSpan.FromHours(1));
            Assert.NotEqual(right, left);
        }

        [Fact]
        public void FromYears_ShouldHaveOneYearLifespan()
        {
            var sut = TimeToLive.FromYears(1);

            Assert.InRange(sut.Value.TotalDays, 365, 366);
        }

        [Fact]
        public void FromMonths_ShouldHaveSixMonthsLifespan()
        {
            var sut = TimeToLive.FromMonths(6);

            Assert.InRange(sut.Value.TotalDays, 181, 184);
        }

        [Fact]
        public void FromDays_ShouldHaveThirtyDaysLifespan()
        {
            var sut = TimeToLive.FromDays(30);

            Assert.Equal(30, sut.Value.TotalDays);
        }

        [Fact]
        public void FromHours_ShouldHaveTwentyFourHoursLifespan()
        {
            var sut = TimeToLive.FromHours(24);

            Assert.Equal(24, sut.Value.TotalHours);
        }

        [Fact]
        public void FromMinutes_ShouldHaveFifteenMinutesLifespan()
        {
            var sut = TimeToLive.FromMinutes(15);

            Assert.Equal(15, sut.Value.TotalMinutes);
        }

        [Fact]
        public void Marshalling_ShouldRepresentCorrectly()
        {
            var sut = TimeToLive.FromYears(1);
            var json = JsonMarshaller.Default.Serialize(sut).ToEncodedString();
            var newtonsoftJson = NewtonsoftJsonMarshaller.Default.Serialize(sut).ToEncodedString();

            TestOutput.WriteLine(json);

            Assert.Equal("\"365.00:00:00\"", json);
            Assert.Equal(json, newtonsoftJson);
        }
    }
}
