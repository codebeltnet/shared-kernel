using System;
using System.Globalization;
using Cuemon;

namespace Codebelt.SharedKernel
{
    /// <summary>
    /// Represents a <see cref="TimeToLive"/> (TTL) object that can be used when issuing authentication tokens or similar.
    /// </summary>
    /// <remarks>https://martinfowler.com/eaaCatalog/valueObject.html</remarks>
    /// <seealso cref="ComparableValueObject{T}" />
    public record TimeToLive : ComparableValueObject<TimeSpan>
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="TimeToLive"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="TimeSpan"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator TimeSpan(TimeToLive value)
        {
            return value.Value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="TimeSpan"/> to <see cref="TimeToLive"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="TimeToLive"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator TimeToLive(TimeSpan value)
        {
            return new TimeToLive(value);
        }

        /// <summary>
        /// Denotes the largest possible value of <see cref="TimeToLive"/>.
        /// </summary>
        public static readonly TimeSpan MaxValue = TimeSpan.MaxValue;

        /// <summary>
        /// Denotes the smallest possible value of <see cref="TimeToLive"/>.
        /// </summary>
        public static readonly TimeSpan MinValue = TimeSpan.Zero;

        /// <summary>
        /// Returns a <see cref="TimeToLive"/> that represents a specified number of minutes.
        /// </summary>
        /// <param name="value">A number of minutes.</param>
        /// <returns>A new instance of <see cref="TimeToLive"/> that represents <paramref name="value"/>.</returns>
        public static TimeToLive FromMinutes(double value)
        {
            var utcNow = DateTime.UtcNow;
            return utcNow.AddMinutes(value) - utcNow;
        }

        /// <summary>
        /// Returns a <see cref="TimeToLive"/> that represents a specified number of hours.
        /// </summary>
        /// <param name="value">A number of hours.</param>
        /// <returns>A new instance of <see cref="TimeToLive"/> that represents <paramref name="value"/>.</returns>
        public static TimeToLive FromHours(double value)
        {
            var utcNow = DateTime.UtcNow;
            return utcNow.AddHours(value) - utcNow;
        }

        /// <summary>
        /// Returns a <see cref="TimeToLive"/> that represents a specified number of days.
        /// </summary>
        /// <param name="value">A number of days.</param>
        /// <returns>A new instance of <see cref="TimeToLive"/> that represents <paramref name="value"/>.</returns>
        public static TimeToLive FromDays(double value)
        {
            var utcNow = DateTime.UtcNow;
            return utcNow.AddDays(value) - utcNow;
        }

        /// <summary>
        /// Returns a <see cref="TimeToLive"/> that represents a specified number of months.
        /// </summary>
        /// <param name="value">A number of months.</param>
        /// <returns>A new instance of <see cref="TimeToLive"/> that represents <paramref name="value"/>.</returns>
        public static TimeToLive FromMonths(int value)
        {
            var utcNow = DateTime.UtcNow;
            return utcNow.AddMonths(value) - utcNow;
        }

        /// <summary>
        /// Returns a <see cref="TimeToLive"/> that represents a specified number of years.
        /// </summary>
        /// <param name="value">A number of years.</param>
        /// <returns>A new instance of <see cref="TimeToLive"/> that represents <paramref name="value"/>.</returns>
        public static TimeToLive FromYears(int value)
        {
            var utcNow = DateTime.UtcNow;
            return utcNow.AddYears(value) - utcNow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeToLive"/> class.
        /// </summary>
        /// <param name="value">The <see cref="TimeSpan"/> value to assign the role of <see cref="TimeToLive"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> cannot be less than <see cref="MinValue"/> -or-
        /// <paramref name="value"/> cannot exceed <see cref="MaxValue"/>.
        /// </exception>
        public TimeToLive(TimeSpan value) : base(Validator.CheckParameter(value, () =>
        {
            Validator.ThrowIfLowerThan(value.Ticks, MinValue.Ticks, nameof(value), "Value for lifespan cannot be negative.");
            Validator.ThrowIfGreaterThan(value.Ticks, MaxValue.Ticks, nameof(value), "Value for lifespan was exceeded.");
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
