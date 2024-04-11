using System;

namespace Codebelt.SharedKernel
{
    /// <summary>
    /// Represents a <see cref="CorrelationId"/> object that can be used as unique identifier that help you trace requests across multiple services in a distributed system.
    /// </summary>
    /// <remarks>https://martinfowler.com/eaaCatalog/valueObject.html</remarks>
    /// <seealso cref="Token" />
    public record CorrelationId : Token
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="Guid"/> to <see cref="CorrelationId"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="CorrelationId"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator CorrelationId (Guid value)
        {
            return new CorrelationId(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string"/> to <see cref="CorrelationId"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="CorrelationId"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator CorrelationId (string value)
        {
            return new CorrelationId(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationId"/> class.
        /// </summary>
        /// <param name="value">The <see cref="Guid"/> value to assign the role of <see cref="CorrelationId"/>.</param>
        public CorrelationId(Guid value) : this(value.ToString("N"))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationId"/> class.
        /// </summary>
        /// <param name="value">The <see cref="string"/> value to assign the role of <see cref="CorrelationId"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> cannot be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="value"/> cannot be empty or consist only of white-space characters.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> contained one or more white-space characters -or-
        /// <paramref name="value"/> was less than 32 characters -or-
        /// <paramref name="value"/> was greater than 128 characters -or-
        /// <paramref name="value"/> consist only of same repeated character.
        /// </exception>
        public CorrelationId(string value) : base(value, o => o.MaximumCharacterFrequency = 1)
        {
        }
    }
}
