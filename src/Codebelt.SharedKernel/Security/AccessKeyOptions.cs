using System;
using Cuemon;
using Cuemon.Configuration;

namespace Codebelt.SharedKernel.Security
{
    /// <summary>
    /// Provides options to be used with <see cref="AccessKey"/>>.
    /// </summary>
    /// <seealso cref="IValidatableParameterObject" />
    public class AccessKeyOptions : IValidatableParameterObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessKeyOptions"/> class.
        /// </summary>
        public AccessKeyOptions()
        {
            ValidFrom = CoordinatedUniversalTime.MinValue;
            Expires = CoordinatedUniversalTime.MaxValue;
            DesiredTolerance = ClockSkew.FromSeconds(30);
        }

        /// <summary>
        /// Gets or sets the date and time from which the access key is valid. Default is <see cref="CoordinatedUniversalTime.MinValue"/> (e.g., always valid).
        /// </summary>
        /// <value>The date and time from which the access key is valid.</value>
        public CoordinatedUniversalTime ValidFrom { get; set; }

        /// <summary>
        /// Gets or sets the expiry date and time of the access key. Default is <see cref="CoordinatedUniversalTime.MaxValue"/> (e.g., no expiration).
        /// </summary>
        /// <value>The expiry date and time of the access key.</value>
        public CoordinatedUniversalTime Expires { get; set; }

        /// <summary>
        /// Gets or sets the desired tolerance for potential clock skew variations. Default is 30 seconds.
        /// </summary>
        /// <value>The desired tolerance for potential clock skew variations.</value>
        public ClockSkew DesiredTolerance { get; set; }

        /// <summary>
        /// Determines whether the public read-write properties of this instance are in a valid state.
        /// </summary>
        /// <remarks>This method is expected to throw exceptions when one or more conditions fails to be in a valid state.</remarks>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ValidFrom"/> is null -or-
        /// <see cref="Expires"/> is null -or-
        /// <see cref="DesiredTolerance"/> is null -or-
        /// <see cref="ValidFrom"/> is greater than <see cref="Expires"/>.
        /// </exception>
        public void ValidateOptions()
        {
            Validator.ThrowIfInvalidState(ValidFrom == null);
            Validator.ThrowIfInvalidState(Expires == null);
            Validator.ThrowIfInvalidState(DesiredTolerance == null);
            Validator.ThrowIfInvalidState(ValidFrom > Expires);
        }
    }
}
