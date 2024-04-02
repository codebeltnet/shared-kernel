using System;
using Cuemon;

namespace Codebelt.SharedKernel.Security
{
    /// <summary>
    /// Extension methods for the <see cref="AccessKey"/> record.
    /// </summary>
    public static class AccessKeyExtensions
    {
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="accessKey">The <see cref="AccessKey"/> to extend.</param>
        /// <param name="utc">The optional <see cref="CoordinatedUniversalTime"/> to use instead of <see cref="CoordinatedUniversalTime.Now"/>.</param>
        /// <returns><c>true</c> if the specified <paramref name="accessKey"/> is valid; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="accessKey"/> cannot be null.
        /// </exception>
        public static bool IsValid(this AccessKey accessKey, CoordinatedUniversalTime utc = null)
        {
            Validator.ThrowIfNull(accessKey);
            utc ??= CoordinatedUniversalTime.Now();
            var start = accessKey.ValidFrom;
            var expires = accessKey.Expires.Add(accessKey.DesiredTolerance);
            return utc >= start && utc <= expires;
        }
    }
}
