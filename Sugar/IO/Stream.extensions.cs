using System;
using System.IO;
using Sugar.Observables;

namespace Sugar.IO
{
    /// <summary>
    /// Simplifies common Stream operations.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="StreamReader"/> class 
        /// and invokes the specified action within a disposable block.
        /// </summary>
        /// <param name="self">The target stream to read.</param>
        /// <param name="action">The action to execute on the reader.</param>
        public static void Read(this Stream self, Action<StreamReader> action)
        {
            new StreamReader(self).Using(action);
            using (var reader = new StreamReader(self))
            {
                action(reader);
            }
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="StreamReader"/> class 
        /// and invokes the specified Func within a disposable block.
        /// </summary>
        /// <param name="self">The target stream to read.</param>
        /// <param name="action">The action to execute on the reader.</param>
        public static T Read<T>(this Stream self, Func<StreamReader, T> action)
        {
            using (var reader = new StreamReader(self))
            {
                return action(reader);
            }
        }
        
        /// <summary>
        /// Initialize a new instance of the <see cref="StreamWriter"/> class 
        /// and invokes the specified action within a disposable block.
        /// </summary>
        /// <param name="self">The target stream to read.</param>
        /// <param name="action">The action to execute on the reader.</param>
        public static void Write(this Stream self, Action<StreamWriter> action)
        {
            using (var reader = new StreamWriter(self))
            {
                action(reader);
            }
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="StreamWriter"/> class 
        /// and invokes the specified Func within a disposable block.
        /// </summary>
        /// <param name="self">The target stream to read.</param>
        /// <param name="action">The action to execute on the reader.</param>
        public static T Write<T>(this Stream self, Func<StreamWriter, T> action)
        {
            using (var reader = new StreamWriter(self))
            {
                return action(reader);
            }
        }
        
        /// <summary>
        /// Reads a stream until the end, and returns the results as a string.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string AsString(this Stream self)
        {
            return self.Read(x => x.ReadToEnd());
        }
    }
}