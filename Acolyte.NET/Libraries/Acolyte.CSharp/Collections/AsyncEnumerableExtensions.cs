﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acolyte.Assertions;

namespace Acolyte.Collections
{
    /// <summary>
    /// Contains useful methods to work with async enumerable items.
    /// </summary>
    public static class AsyncEnumerableExtensions
    {
        /// <summary>
        /// Transorms a <see cref="IAsyncEnumerable{T}" /> to <see cref="IEnumerable{T}" />. This
        /// method used to work with API that cannot process <see cref="IAsyncEnumerable{T}" />
        /// sequences.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the elements of <paramref name="source" />.
        /// </typeparam>
        /// <param name="source">
        /// The <see cref="IAsyncEnumerable{T}" /> to convert to <see cref="IEnumerable{T}" />.
        /// </param>
        /// <returns>
        /// A <see cref="IEnumerable{T}" /> that contains elements from the input async sequence.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <c>null</c>.
        /// </exception>
        public static async Task<IEnumerable<T>> AsEnumerable<T>(
            this IAsyncEnumerable<T> source)
        {
            source.ThrowIfNull(nameof(source));

            var result = new List<T>();
            await foreach (T entity in source)
            {
                result.Add(entity);
            }

            return result;
        }
    }
}
