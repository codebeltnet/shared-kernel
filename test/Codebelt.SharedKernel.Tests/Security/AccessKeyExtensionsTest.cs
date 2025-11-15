using System;
using Codebelt.Extensions.Xunit;
using Xunit;

namespace Codebelt.SharedKernel.Security
{
    public class AccessKeyExtensionsTest : Test
    {
        public AccessKeyExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void IsValid_ShouldReturnTrue_WhenAccessKeyIsValid()
        {
            var sut = AccessKey.Issue(Guid.NewGuid().ToString("N"));

            Assert.True(sut.IsValid());
        }

        [Fact]
        public void IsValid_ShouldReturnFalse_WhenAccessKeyIsInvalidDueToEitherExpiryOrValidFrom()
        {
            var utc1 = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1));
            var sut1 = AccessKey.Issue(Guid.NewGuid(), TimeToLive.MinValue);
            var sut2 = new AccessKey(Guid.NewGuid(), o => o.ValidFrom = DateTime.UtcNow);

            Assert.False(sut1.IsValid(utc1));
            Assert.False(sut2.IsValid(utc1));
        }

        [Fact]
        public void IsValid_ShouldReturnTrue_WhenAccessKeyHasLargeDesiredClockSkew()
        {
            var utc = DateTime.UtcNow.Subtract(TimeSpan.FromHours(1));
            var sut = new AccessKey(Guid.NewGuid(), o =>
            {
                o.ValidFrom = CoordinatedUniversalTime.MinValue;
                o.Expires = new CoordinatedUniversalTime(utc);
                o.DesiredTolerance = TimeSpan.FromHours(2);
            });

            Assert.True(sut.IsValid());
        }
    }
}
