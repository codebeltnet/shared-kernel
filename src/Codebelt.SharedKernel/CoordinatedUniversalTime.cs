using System;
using System.Globalization;
using Cuemon;

namespace Codebelt.SharedKernel
{
    /// <summary>
    /// Represents a <see cref="CoordinatedUniversalTime"/> (UTC) object that can be used when you need a timestamp that is based on an absolute time.
    /// </summary>
    /// <remarks>https://martinfowler.com/eaaCatalog/valueObject.html</remarks>
    /// <seealso cref="ComparableValueObject{T}" />
    public record CoordinatedUniversalTime : ComparableValueObject<DateTime>
    {
        /// <summary>
        /// Denotes the largest possible value of <see cref="CoordinatedUniversalTime"/>.
        /// </summary>
        public static readonly CoordinatedUniversalTime MaxValue = DateTime.ParseExact("9999-12-31T22:59:59.9999999Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal); // Cannot use DateTime.MaxValue.ToUniversalTime() as it becomes 9999-12-31T23:59:59.9999999Z on Ubuntu 22.04 (but weirdly enough works on WSL with same distro).

        /// <summary>
        /// Denotes the smallest possible value of <see cref="CoordinatedUniversalTime"/>.
        /// </summary>
        public static readonly CoordinatedUniversalTime MinValue = new(DateTime.MinValue.ToUniversalTime());

        /// <summary>
        /// Performs an implicit conversion from <see cref="CoordinatedUniversalTime"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="DateTime"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator DateTime (CoordinatedUniversalTime value)
        {
            return value.Value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="DateTime"/> to <see cref="CoordinatedUniversalTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="CoordinatedUniversalTime"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator CoordinatedUniversalTime (DateTime value)
        {
            return new CoordinatedUniversalTime(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="DateTimeOffset"/> to <see cref="CoordinatedUniversalTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="CoordinatedUniversalTime"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator CoordinatedUniversalTime (DateTimeOffset value)
        {
            return new CoordinatedUniversalTime(value.UtcDateTime);
        }

        /// <summary>
        /// Converts the string representation of a date and time to its <see cref="CoordinatedUniversalTime"/>> equivalent.
        /// </summary>
        /// <param name="value">A string that contains a date and time to convert.</param>
        /// <returns>A new instance of <see cref="CoordinatedUniversalTime"/> that represents <paramref name="value"/>.</returns>
        public static CoordinatedUniversalTime FromString(string value)
        {
            return new CoordinatedUniversalTime(DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal));
        }

        /// <summary>
        /// Returns a <see cref="CoordinatedUniversalTime"/> whose value is the current UTC date and time.
        /// </summary>
        /// <returns>A new instance of <see cref="CoordinatedUniversalTime"/> set to the current date and time on this computer.</returns>
        public static CoordinatedUniversalTime Now()
        {
            return new CoordinatedUniversalTime(DateTime.UtcNow);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoordinatedUniversalTime"/> class.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to assign the role of <see cref="CoordinatedUniversalTime"/>.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="value"/> is not in a valid state, e.g., it's different from <see cref="DateTimeKind.Utc"/>.
        /// </exception>
        public CoordinatedUniversalTime(DateTime value) : base(Validator.CheckParameter(value, () =>
        {
            Validator.ThrowIfTrue(value.Kind != DateTimeKind.Utc, nameof(value));
        }))
        {
        }

        /// <summary>
        /// Returns a <see cref="string"/>> that represents this instance and complies with ISO 8601.
        /// </summary>
        /// <returns>A <see cref="string"/>> that represents this instance and complies with ISO 8601.</returns>
        public override string ToString()
        {
            return Value.ToString("O", CultureInfo.InvariantCulture);
        }
    }
}
