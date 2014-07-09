using System;
using System.Collections.Generic;
using System.Linq;
using Sugar.Linq;

namespace Sugar.Threading
{
    /// <summary>
    /// Leverages Parallel libraries to provide parallelized factory methods.
    /// </summary>
    public class Parallel<T>
    {
        /// <summary>
        /// Executes each of the functions, possibly in parallel.
        /// </summary>
        /// <param name="generators">A collection of <see cref="Func{T}"/> to execute.</param>
        /// <returns>The results of execution from the specified paramater.</returns>
        public static IEnumerable<T> Invoke(params Func<T>[] generators)
        {
            generators.Require();
            generators.ForEach(x => x.Require());

            return generators.AsParallel().Select(x => x());
        }
    }
}
