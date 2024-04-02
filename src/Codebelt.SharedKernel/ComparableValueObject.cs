using System;
using System.Numerics;
using Savvyio.Domain;

namespace Codebelt.SharedKernel
{
    /// <summary>
    /// Provides an implementation of <see cref="SingleValueObject{T}"/> tailored for handling a single value that implements the <see cref="IComparable{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the object that implements the <see cref="IComparable{T}"/> interface.</typeparam>
    public abstract record ComparableValueObject<T> : SingleValueObject<T>, IComparisonOperators<ComparableValueObject<T>, ComparableValueObject<T>, bool> where T : IComparable<T>
    {
        /// <summary>
        /// Compares two values to determine which is greater.
        /// </summary>
        /// <param name="left">The value to compare with <paramref name="right"/>.</param>
        /// <param name="right">The value to compare with <paramref name="left"/>.</param>
        /// <returns><c>true</c> if <paramref name="left"/>> is greater than <paramref name="right"/>>; otherwise, <c>false</c>.</returns>
        public static bool operator >(ComparableValueObject<T> left, ComparableValueObject<T> right) => left.Value.CompareTo(right.Value) > 0;

        /// <summary>
        /// Compares two values to determine which is less or equal.
        /// </summary>
        /// <param name="left">The value to compare with <paramref name="right"/>.</param>
        /// <param name="right">The value to compare with <paramref name="left"/>.</param>
        /// <returns><c>true</c> if <paramref name="left"/>> is greater than or equal to <paramref name="right"/>>; otherwise, <c>false</c>.</returns>
        public static bool operator >=(ComparableValueObject<T> left, ComparableValueObject<T> right) => left.Value.CompareTo(right.Value) >= 0;

        /// <summary>
        /// Compares two values to determine which is less.
        /// </summary>
        /// <param name="left">The value to compare with <paramref name="right"/>.</param>
        /// <param name="right">The value to compare with <paramref name="left"/>.</param>
        /// <returns><c>true</c> if <paramref name="left"/>> is less than <paramref name="right"/>>; otherwise, <c>false</c>.</returns>
        public static bool operator <(ComparableValueObject<T> left, ComparableValueObject<T> right) => left.Value.CompareTo(right.Value) < 0;

        /// <summary>
        /// Compares two values to determine which is less or equal.
        /// </summary>
        /// <param name="left">The value to compare with <paramref name="right"/>.</param>
        /// <param name="right">The value to compare with <paramref name="left"/>.</param>
        /// <returns><c>true</c> if <paramref name="left"/>> is less than or equal to <paramref name="right"/>>; otherwise, <c>false</c>.</returns>
        public static bool operator <=(ComparableValueObject<T> left, ComparableValueObject<T> right) => left.Value.CompareTo(right.Value) <= 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableValueObject{T}"/> class.
        /// </summary>
        /// <param name="value">The value to associate to <see cref="SingleValueObject{T}.Value"/>.</param>
        protected ComparableValueObject(T value) : base(value)
        {
        }
    }
}
