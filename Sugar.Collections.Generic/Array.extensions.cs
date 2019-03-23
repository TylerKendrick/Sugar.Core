namespace System.Collections.Generic
{
    using ObjectModel;

    /// <summary>
    /// Exposes static methods from the <see cref="Array"/> type as extension methods.
    /// Also provides common operations with an instance of <see cref="Array"/> as extension methods.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Copies the value of an index from an instance of <see cref="Array"/> into another contained index.
        /// </summary>
        /// <param name="self">The target <see cref="Array"/>.</param>
        /// <param name="from">The index of the value to copy from the specified <see cref="Array"/>.</param>
        /// <param name="to">The index of the value to override in the specified <see cref="Array"/>.</param>
        public static void CopyIndex<T>(this T[] self, int from, int to)
        {
            var item = self.GetValue(from);
            self.SetValue(item, to);
        }

        /// <summary>
        /// Copies the value of an index from an instance of <see cref="Array"/> into other contained indices.
        /// </summary>
        /// <param name="self">The target <see cref="Array"/>.</param>
        /// <param name="from">The index of the value to copy from the specified <see cref="Array"/>.</param>
        /// <param name="to">The indices of the value to override in the specified <see cref="Array"/>.</param>
        public static void CopyIndex<T>(this T[] self, int from, params int[] to)
        {
            void partial(int x) => CopyIndex(self, from, x);
            to.ForEach(partial);
        }

        /// <summary>
        /// Swaps the values of two indices in an <see cref="Array"/>.
        /// </summary>
        /// <param name="self">The target <see cref="Array"/>.</param>
        /// <param name="left">The index of the first value to copy from the specified <see cref="Array"/>.</param>
        /// <param name="right">The index of the second value to copy from the specified <see cref="Array"/>.</param>
        public static void Swap<T>(this T[] self, int left, int right)
        {
            var leftItem = self.GetValue(left);
            var rightItem = self.GetValue(right);
            self.SetValue(leftItem, right);
            self.SetValue(rightItem, left);
        }

        /// <summary>
        /// Sets a range of elements in the <see cref="T:System.Array"/> to zero, to false, or to null, depending on the element type.
        /// </summary>
        /// <param name="self">The <see cref="T:System.Array"/> whose elements need to be cleared.</param>
        /// <param name="index">The starting index of the range of elements to clear.</param>
        /// <param name="length">The number of elements to clear.</param>
        public static void Clear<T>(this T[] self, int index, int length) => Array.Clear(self, index, length);

        /// <summary>
        /// Sets a range of elements in the <see cref="T:System.Array"/> to zero, to false, or to null, depending on the element type.
        /// </summary>
        /// <param name="self">The <see cref="T:System.Array"/> whose elements need to be cleared.</param>
        /// <param name="index">The starting index of the range of elements to clear.</param>
        public static void Clear<T>(this T[] self, int index) => Clear(self, index, self.Length);

        /// <summary>
        /// Sets a range of elements in the <see cref="T:System.Array"/> to zero, to false, or to null, depending on the element type.
        /// </summary>
        /// <param name="self">The <see cref="T:System.Array"/> whose elements need to be cleared.</param>
        public static void Clear<T>(this T[] self) => Clear(self, 0);

        /// <summary>
        /// Searches a range of elements in a one-dimensional sorted <see cref="T:System.Array"/> 
        /// for a value, using the specified <see cref="T:System.Collections.IComparer"/> interface.
        /// </summary>
        /// 
        /// <returns>
        /// The index of the specified <paramref name="value"/> in the specified <paramref name="self"/>, 
        /// if <paramref name="value"/> is found. 
        /// If <paramref name="value"/> is not found 
        /// and <paramref name="value"/> is less than one or more elements in <paramref name="self"/>, 
        /// a negative number which is the bitwise complement of the index of the first element 
        /// that is larger than <paramref name="value"/>. 
        /// If <paramref name="value"/> is not found 
        /// and <paramref name="value"/> is greater than any of the elements in <paramref name="self"/>, 
        /// a negative number which is the bitwise complement of (the index of the last element plus 1).
        /// </returns>
        /// <param name="self">The sorted one-dimensional <see cref="T:System.Array"/> to search.</param>
        /// <param name="index">The starting index of the range to search.</param>
        /// <param name="length">The length of the range to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparer">The <see cref="T:System.Collections.IComparer"/> implementation to use when comparing elements.
        /// -or- null to use the <see cref="T:System.IComparable"/> implementation of each element.</param>
        public static int BinarySearch<T>(this T[] self, int index, int length, T value, IComparer<T> comparer)
            => Array.BinarySearch(self, index, length, value, comparer);

        /// <summary>
        /// Searches a range of elements in a one-dimensional sorted <see cref="T:System.Array"/> 
        /// for a value, using the specified <see cref="T:System.Collections.IComparer"/> interface.
        /// </summary>
        /// 
        /// <returns>
        /// The index of the specified <paramref name="value"/> in the specified <paramref name="self"/>, 
        /// if <paramref name="value"/> is found. 
        /// If <paramref name="value"/> is not found 
        /// and <paramref name="value"/> is less than one or more elements in <paramref name="self"/>, 
        /// a negative number which is the bitwise complement of the index of the first element 
        /// that is larger than <paramref name="value"/>. 
        /// If <paramref name="value"/> is not found 
        /// and <paramref name="value"/> is greater than any of the elements in <paramref name="self"/>, 
        /// a negative number which is the bitwise complement of (the index of the last element plus 1).
        /// </returns>
        /// <param name="self">The sorted one-dimensional <see cref="T:System.Array"/> to search.</param>
        /// <param name="index">The starting index of the range to search.</param>
        /// <param name="length">The length of the range to search.</param>
        /// <param name="value">The object to search for.</param>
        public static int BinarySearch<T>(this T[] self, int index, int length, T value)
            => Array.BinarySearch(self, index, length, value);

        /// <summary>
        /// Searches a range of elements in a one-dimensional sorted <see cref="T:System.Array"/> 
        /// for a value, using the specified <see cref="T:System.Collections.IComparer"/> interface.
        /// </summary>
        /// 
        /// <returns>
        /// The index of the specified <paramref name="value"/> in the specified <paramref name="self"/>, 
        /// if <paramref name="value"/> is found. 
        /// If <paramref name="value"/> is not found 
        /// and <paramref name="value"/> is less than one or more elements in <paramref name="self"/>, 
        /// a negative number which is the bitwise complement of the index of the first element 
        /// that is larger than <paramref name="value"/>. 
        /// If <paramref name="value"/> is not found 
        /// and <paramref name="value"/> is greater than any of the elements in <paramref name="self"/>, 
        /// a negative number which is the bitwise complement of (the index of the last element plus 1).
        /// </returns>
        /// <param name="self">The sorted one-dimensional <see cref="T:System.Array"/> to search.</param>
        /// <param name="index">The starting index of the range to search.</param>
        /// <param name="value">The object to search for.</param>
        public static int BinarySearch<T>(this T[] self, int index, T value)
            => Array.BinarySearch(self, index, self.Length, value);

        /// <summary>
        /// Searches a range of elements in a one-dimensional sorted <see cref="T:System.Array"/> 
        /// for a value, using the specified <see cref="T:System.Collections.IComparer"/> interface.
        /// </summary>
        /// 
        /// <returns>
        /// The index of the specified <paramref name="value"/> in the specified <paramref name="self"/>, 
        /// if <paramref name="value"/> is found. 
        /// If <paramref name="value"/> is not found 
        /// and <paramref name="value"/> is less than one or more elements in <paramref name="self"/>, 
        /// a negative number which is the bitwise complement of the index of the first element 
        /// that is larger than <paramref name="value"/>. 
        /// If <paramref name="value"/> is not found 
        /// and <paramref name="value"/> is greater than any of the elements in <paramref name="self"/>, 
        /// a negative number which is the bitwise complement of (the index of the last element plus 1).
        /// </returns>
        /// <param name="self">The sorted one-dimensional <see cref="T:System.Array"/> to search.</param>
        /// <param name="value">The object to search for.</param>
        public static int BinarySearch<T>(this T[] self, T value)
            => Array.BinarySearch(self, value);

        /// <summary>
        /// Sorts the elements in a range of elements in a one-dimensional <see cref="T:System.Array"/> using the specified <see cref="T:System.Collections.IComparer"/>.
        /// </summary>
        public static void Sort<T>(this T[] self, int index, int length, IComparer<T> comparer)
            => Array.Sort(self, index, length, comparer);

        /// <summary>
        /// Sorts the elements in a range of elements in a one-dimensional <see cref="T:System.Array"/> using the specified <see cref="T:System.Collections.IComparer"/>.
        /// </summary>
        public static void Sort<T>(this T[] self, int index, int length)
            => Array.Sort(self, index, length);

        /// <summary>
        /// Sorts the elements in a range of elements in a one-dimensional <see cref="T:System.Array"/> using the specified <see cref="T:System.Collections.IComparer"/>.
        /// </summary>
        public static void Sort<T>(this T[] self, int index)
            => Array.Sort(self, index, self.Length);

        /// <summary>
        /// Sorts the elements in a range of elements in a one-dimensional <see cref="T:System.Array"/> using the specified <see cref="T:System.Collections.IComparer"/>.
        /// </summary>
        public static void Sort<T>(this T[] self) => Array.Sort(self);

        /// <summary>
        /// Performs the specified action on each element of the specified array.
        /// </summary>
        public static void ForEach<T>(this T[] self, Action<T> action)
            => Array.ForEach(self, action);

        /// <summary>
        /// Changes the number of elements in the array to the new size.
        /// </summary>
        public static void Resize<T>(this T[] self, int size)
            => Array.Resize(ref self, size);

        /// <summary>
        /// Returns a read-only wrapper for the specified array.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only <see cref="System.Collections.ObjectModel.ReadOnlyCollection{T}"/> wrapper for the specified array.
        /// </returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] self)
            => Array.AsReadOnly(self);
    }
}