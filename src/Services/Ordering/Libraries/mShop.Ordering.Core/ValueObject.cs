using System;
using System.Collections.Generic;
using System.Linq;

namespace mShop.Ordering.Core
{
    /// <summary>
    /// Defines the <see cref="ValueObject" />.
    /// Learn more: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// The EqualOperator.
        /// </summary>
        /// <param name="left">The left<see cref="ValueObject"/>.</param>
        /// <param name="right">The right<see cref="ValueObject"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left?.Equals(right) != false;
        }

        /// <summary>
        /// The NotEqualOperator.
        /// </summary>
        /// <param name="left">The left<see cref="ValueObject"/>.</param>
        /// <param name="right">The right<see cref="ValueObject"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        /// <summary>
        /// The GetEqualityComponents.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{object}"/>.</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();

        /// <summary>
        /// The Equals.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// The GetHashCode.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
