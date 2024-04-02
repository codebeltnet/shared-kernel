using System;
using System.Globalization;
using Cuemon;

namespace Codebelt.SharedKernel
{
    /// <summary>
    /// Represents a <see cref="ClockSkew"/> object that can be used to warrant for clock skew related scenarios such as authentication.
    /// </summary>
    /// <remarks>https://martinfowler.com/eaaCatalog/valueObject.html</remarks>
    /// <seealso cref="ComparableValueObject{T}" />
    public record ClockSkew : ComparableValueObject<TimeSpan>
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="ClockSkew"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="TimeSpan"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator ClockSkew (TimeSpan value)
        {
            return new ClockSkew(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="TimeSpan"/> to <see cref="ClockSkew"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="TimeToLive"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator TimeSpan (ClockSkew value)
        {
            return value.Value;
        }

        /// <summary>
        /// Denotes the largest possible value of <see cref="ClockSkew"/>.
        /// </summary>
        public static readonly TimeSpan MaxValue = TimeSpan.FromHours(4);

        /// <summary>
        /// Denotes the smallest possible value of <see cref="ClockSkew"/>.
        /// </summary>
        public static readonly TimeSpan MinValue = TimeSpan.Zero;

        /// <summary>
        /// Returns a <see cref="ClockSkew"/> that represents a specified number of minutes.
        /// </summary>
        /// <param name="value">A number of minutes.</param>
        /// <returns>A new instance of <see cref="ClockSkew"/> that represents <paramref name="value"/>.</returns>
        public static ClockSkew FromMinutes(byte value)
        {
            var utcNow = DateTime.UtcNow;
            return utcNow.AddMinutes(value) - utcNow;
        }

        /// <summary>
        /// Returns a <see cref="ClockSkew"/> that represents a specified number of seconds.
        /// </summary>
        /// <param name="value">A number of seconds.</param>
        /// <returns>A new instance of <see cref="ClockSkew"/> that represents <paramref name="value"/>.</returns>
        public static ClockSkew FromSeconds(ushort value)
        {
            var utcNow = DateTime.UtcNow;
            return utcNow.AddSeconds(value) - utcNow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClockSkew"/> class.
        /// </summary>
        /// <param name="value">The <see cref="TimeSpan"/> value to assign the role of <see cref="ClockSkew"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> cannot be less than <see cref="MinValue"/> -or-
        /// <paramref name="value"/> cannot exceed <see cref="MaxValue"/>.
        /// </exception>
        public ClockSkew(TimeSpan value) : base(Validator.CheckParameter(value, () =>
        {
            Validator.ThrowIfLowerThan(value.Ticks, MinValue.Ticks, nameof(value), "Value for clock skew cannot be negative.");
            Validator.ThrowIfGreaterThan(value.Ticks, MaxValue.Ticks, nameof(value), "Value for clock skew was exceeded.");
        }))
        {
        }

        /// <summary>
        /// Returns a <see cref="string"/>> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string"/>> that represents this instance.</returns>
        public override string ToString()
        {
            return Value.ToString("c", CultureInfo.InvariantCulture);
        }
    }
}
