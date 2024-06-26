﻿using System;
using Cuemon.Extensions;
using Cuemon.Text;

namespace Codebelt.SharedKernel.Security
{
    /// <summary>
    /// Represents a <see cref="Secret"/> object that can be used for storing sensitive data.
    /// </summary>
    /// <remarks>https://martinfowler.com/eaaCatalog/valueObject.html</remarks>
    /// <seealso cref="Token" />
    public record Secret : Token
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="Guid"/> to <see cref="Secret"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="Secret"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator Secret (Guid value)
        {
            return new Secret(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string"/> to <see cref="Secret"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="Secret"/> that is equivalent to <paramref name="value"/>.</returns>
        public static implicit operator Secret (string value)
        {
            return new Secret(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Secret"/> class.
        /// </summary>
        /// <param name="value">The <see cref="Guid"/> value to assign the role of <see cref="Secret"/>.</param>
        public Secret(Guid value) : this(value.ToString("N"))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Secret"/> class.
        /// </summary>
        /// <param name="value">The <see cref="string"/> value to assign the role of <see cref="Secret"/>.</param>
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
        public Secret(string value) : base(value, o => o.MaximumCharacterFrequency = 1)
        {
        }

        /// <summary>
        /// Returns a <see cref="string"/>> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string"/>> that represents this instance.</returns>
        public override string ToString()
        {
            return Value;
        }

        /// <summary>
        /// Converts this instance to its equivalent <see cref="T:byte[]"/> representation.
        /// </summary>
        /// <param name="setup">The <see cref="EncodingOptions"/> which may be configured.</param>
        /// <returns>A <see cref="T:byte[]"/> that is equivalent to this instance.</returns>
        public byte[] ToByteArray(Action<EncodingOptions> setup = null)
        {
            return ToString().ToByteArray(setup);
        }
    }
}
