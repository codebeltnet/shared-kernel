using System;
using Cuemon.Extensions.IO;
using Cuemon.Extensions.Xunit;
using Savvyio.Extensions.Newtonsoft.Json;
using Savvyio.Extensions.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace Codebelt.SharedKernel.Security
{
    public class AccessKeyTest : Test
    {
        public AccessKeyTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void DesiredTolereance_ShouldBe_ThirtySeconds()
        {
            var sut = new AccessKey(Guid.NewGuid());
            Assert.Equal(TimeSpan.FromSeconds(30), sut.DesiredTolerance);
        }

        [Fact]
        public void Expires_ShouldBe_MaxValue()
        {
            var sut = new AccessKey(Guid.NewGuid());
            Assert.Equal(CoordinatedUniversalTime.MaxValue, sut.Expires);
        }

        [Fact]
        public void Secret_ShouldBe_UuidInNumberFormat()
        {
            var uuid = Guid.NewGuid();
            var sut = new AccessKey(uuid);
            Assert.Equal(uuid.ToString("N"), sut.Secret);
        }

        [Fact]
        public void Secret_ShouldBe_AsSpecified()
        {
            var secret = "mysecretthatisatleastthirtytwocharacterslong";
            var sut = new AccessKey(secret);
            Assert.Equal(secret, sut.Secret);
        }

        [Fact]
        public void Expires_ShouldBeOneYearFromUtcNow()
        {
            var utc = DateTime.UtcNow;
            var sut = AccessKey.Issue("bae9d2e09c9b5f65f9a7a3c5a55748b180ee65c1", TimeToLive.FromYears(1));
            var lifespan = sut.Expires - sut.ValidFrom;

            Assert.Equal("bae9d2e09c9b5f65f9a7a3c5a55748b180ee65c1", sut.Secret);
            Assert.Equal(lifespan.Ticks, (utc.AddYears(1) - utc).Ticks);
        }

        [Fact]
        public void Marshalling_ShouldRepresentCorrectly()
        {
            var sut = new AccessKey("1acb4e4928a64206b22b2392ffd4e605");
            var json = JsonMarshaller.Default.Serialize(sut).ToEncodedString();
            var newtonsoftJson = NewtonsoftJsonMarshaller.Default.Serialize(sut).ToEncodedString();

            TestOutput.WriteLine(json);

            Assert.Equal("""{"secret":"1acb4e4928a64206b22b2392ffd4e605","validFrom":"0001-01-01T00:00:00.0000000Z","expires":"9999-12-31T22:59:59.9999999Z","desiredTolerance":"00:00:30"}""", json);
            Assert.Equal(json, newtonsoftJson);
        }
    }
}
