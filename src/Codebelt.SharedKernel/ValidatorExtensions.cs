using System;
using System.Runtime.CompilerServices;
using Cuemon;
using Cuemon.Extensions;

namespace Codebelt.SharedKernel
{
    internal static class ValidatorExtensions
    {
        internal static void ContainsAny(this Validator _, string argument, char[] chars, string message = "One or more character matches was found.", [CallerArgumentExpression(nameof(argument))] string paramName = null)
        {
            if (argument?.ContainsAny(chars) ?? false)
            {
                throw new ArgumentOutOfRangeException(paramName, argument, message);
            }
        }
    }
}
