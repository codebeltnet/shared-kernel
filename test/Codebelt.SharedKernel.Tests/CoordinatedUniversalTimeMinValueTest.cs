using System;
using Codebelt.Extensions.Xunit;
using Xunit;

namespace Codebelt.SharedKernel;

public class CoordinatedUniversalTimeMinValueTest : Test
{
    public CoordinatedUniversalTimeMinValueTest(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void MinValue_ShouldBeEarliestUtcInstant()
    {
        var sut = CoordinatedUniversalTime.MinValue;

        Assert.Equal(DateTime.MinValue.Ticks, sut.Value.Ticks);
        Assert.Equal(DateTimeKind.Utc, sut.Value.Kind);
        Assert.Equal("0001-01-01T00:00:00.0000000Z", sut.ToString());
    }
}
