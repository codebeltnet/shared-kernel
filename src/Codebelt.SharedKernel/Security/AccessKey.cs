using System;
using Cuemon;
using Savvyio.Domain;

namespace Codebelt.SharedKernel.Security
{
    /// <summary>
    /// Represents an <see cref="AccessKey"/> object that can be used for API key-based authentication and similar.
    /// </summary>
    /// <remarks>https://martinfowler.com/eaaCatalog/valueObject.html</remarks>
    /// <seealso cref="ValueObject" />
    public record AccessKey : ValueObject
    {
        /// <summary>
        /// Issues a new instance of <see cref="AccessKey"/> with an optional <paramref name="lifespan"/>.
        /// </summary>
        /// <param name="secret">The secret used to generate the access key.</param>
        /// <param name="lifespan">The lifespan of the <see cref="AccessKey"/>. If <c>null</c>, the access key will not expire.</param>
        /// <returns>Returns a new <see cref="AccessKey"/>> instance with the specified secret and lifespan.</returns>
        public static AccessKey Issue(Secret secret, TimeToLive lifespan = null)
        {
            return lifespan == null
                ? new AccessKey(secret)
                : new AccessKey(secret, o =>
            {
                var utcNow = DateTime.UtcNow;
                o.ValidFrom = utcNow;
                o.Expires = utcNow.Add(lifespan.Value);
            });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessKey"/> class.
        /// </summary>
        /// <param name="secret">The <see cref="Secret"/> of the access key.</param>
        /// <param name="setup">The <see cref="AccessKeyOptions"/> which may be configured.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="setup"/> failed to configure an instance of <see cref="AccessKeyOptions"/> in a valid state.
        /// </exception>
        public AccessKey(Secret secret, Action<AccessKeyOptions> setup = null)
        {
            Validator.ThrowIfInvalidConfigurator(setup, out var options);
            Secret = secret;
            ValidFrom = options.ValidFrom;
            Expires = options.Expires;
            DesiredTolerance = options.DesiredTolerance;
        }

        /// <summary>
        /// Gets the secret of the access key.
        /// </summary>
        /// <value>The secret of the access key.</value>
        public string Secret { get; }

        /// <summary>
        /// Gets the date and time,expressed as Coordinated Universal Time (UTC), from which the access key is valid.
        /// </summary>
        /// <value>The date and time, expressed as Coordinated Universal Time (UTC), from which the access key is valid.</value>
        public DateTime ValidFrom { get; }

        /// <summary>
        /// Gets the expiry date and time of the access key expressed as Coordinated Universal Time (UTC).
        /// </summary>
        /// <value>The expiry date and time of the access key expressed as Coordinated Universal Time (UTC).</value>
        public DateTime Expires { get; }

        /// <summary>
        /// Gets the desired tolerance for potential clock skew variations.
        /// </summary>
        /// <value>The desired tolerance for potential clock skew variations.</value>
        public TimeSpan DesiredTolerance { get; }
    }
}
