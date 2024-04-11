using Codebelt.SharedKernel.Security;
using Savvyio.Domain;
using System;
using System.Linq;
using Cuemon;
using Cuemon.Extensions;

namespace Codebelt.SharedKernel
{
    /// <summary>
    /// Represents a <see cref="Token"/> object that encapsulates an immutable value used for identification or access control.
    /// </summary>
    /// <remarks>https://martinfowler.com/eaaCatalog/valueObject.html</remarks>
    /// <seealso cref="SingleValueObject{T}" />
    public record Token : SingleValueObject<string>
    {
        private static readonly char[] WhiteSpaceChars = Alphanumeric.WhiteSpace.ToCharArray();

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="value">The <see cref="string"/> value to assign the role of <see cref="Secret"/>.</param>
        /// <param name="setup">The <see cref="TokenOptions"/> which may be configured.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> cannot be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="value"/> cannot be empty or consist only of white-space characters.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> contained one or more white-space characters -or-
        /// <paramref name="value"/> was less than <see cref="TokenOptions.MinimumLength"/> characters -or-
        /// <paramref name="value"/> was greater than <see cref="TokenOptions.MaximumLength"/> characters -or-
        /// <paramref name="value"/> had a character frequency greater than <see cref="TokenOptions.MaximumCharacterFrequency"/>.
        /// </exception>
        public Token(string value, Action<TokenOptions> setup = null) : base(Validator.CheckParameter(value, () =>
        {
            Validator.ThrowIfInvalidConfigurator(setup, out var options);
            Validator.ThrowIfNullOrWhitespace(value, message: "Value cannot be null, empty or consist only of white-space characters.");
            Validator.ThrowIfLowerThan(value.Length, options.MinimumLength == 0 ? int.MinValue: options.MinimumLength, nameof(value), $"The minimum length of {nameof(value)} was not meet. {options.MinimumLength} characters are required.");
            Validator.ThrowIfGreaterThan(value.Length, options.MaximumLength == 0 ? int.MaxValue: options.MaximumLength, nameof(value), $"The maximum length of {nameof(value)} was exceeded. {options.MaximumLength} characters are allowed.");
            Validator.ThrowIf.ContainsAny(value, WhiteSpaceChars, message: $"White-space characters are not allowed inside {nameof(value)}.");
            Validator.ThrowWhen(condition => condition.IsTrue((out string frequency) =>
            {
                frequency = value.Distinct().Order().FromChars();
                return options.MaximumCharacterFrequency > 0 && frequency.Length <= options.MaximumCharacterFrequency;
            }).Create(frequency => new ArgumentOutOfRangeException(nameof(value), DelimitedString.Create(frequency), $"Value suggest to high frequency of repeated characters. At least {options.MaximumCharacterFrequency} distinct characters are required.")).TryThrow());
        }))
        {
        }
    }
}
