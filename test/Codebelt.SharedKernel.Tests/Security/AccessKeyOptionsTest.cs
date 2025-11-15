using System;
using Codebelt.Extensions.Xunit;
using Xunit;

namespace Codebelt.SharedKernel.Security
{
    public class AccessKeyOptionsTest : Test
    {
        public AccessKeyOptionsTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ValidateOptions_ShouldThrownInvalidOperationException_WhenValidFromIsNull()
        {
            var sut = new AccessKeyOptions
            {
                ValidFrom = null
            };

            var ex = Assert.Throws<InvalidOperationException>(() => sut.ValidateOptions());

            Assert.Equal("Operation is not valid due to the current state of the object. (Expression 'ValidFrom == null')", ex.Message);
        }

        [Fact]
        public void ValidateOptions_ShouldThrownInvalidOperationException_WhenExpiresIsNull()
        {
            var sut = new AccessKeyOptions
            {
                Expires = null
            };

            var ex = Assert.Throws<InvalidOperationException>(() => sut.ValidateOptions());

            Assert.Equal("Operation is not valid due to the current state of the object. (Expression 'Expires == null')", ex.Message);
        }

        [Fact]
        public void ValidateOptions_ShouldThrownInvalidOperationException_WhenToleranceIsNull()
        {
            var sut = new AccessKeyOptions
            {
                DesiredTolerance = null
            };

            var ex = Assert.Throws<InvalidOperationException>(() => sut.ValidateOptions());

            Assert.Equal("Operation is not valid due to the current state of the object. (Expression 'DesiredTolerance == null')", ex.Message);
        }

        [Fact]
        public void ValidateOptions_ShouldThrownInvalidOperationException_WhenValidFromIsGreaterThanExpires()
        {
            var sut = new AccessKeyOptions
            {
                Expires = CoordinatedUniversalTime.MinValue,
                ValidFrom = CoordinatedUniversalTime.MaxValue
            };

            var ex = Assert.Throws<InvalidOperationException>(() => sut.ValidateOptions());

            Assert.Equal("Operation is not valid due to the current state of the object. (Expression 'ValidFrom > Expires')", ex.Message);
        }

        [Fact]
        public void ValidFrom_ShouldDefaultTo_CoordinatedUniversalTimeMinValue()
        {
            var sut = new AccessKeyOptions();

            Assert.Equal(CoordinatedUniversalTime.MinValue, sut.ValidFrom);
        }

        [Fact]
        public void Expires_ShouldDefaultTo_CoordinatedUniversalTimeMaxValue()
        {
            var sut = new AccessKeyOptions();

            Assert.Equal(CoordinatedUniversalTime.MaxValue, sut.Expires);
        }

        [Fact]
        public void DesiredTolerance_ShouldDefaultTo_ClockSkewFromSecondsThirty()
        {
            var sut = new AccessKeyOptions();

            Assert.Equal(ClockSkew.FromSeconds(30), sut.DesiredTolerance);
        }
    }
}
