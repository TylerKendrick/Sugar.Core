using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System
{
    public static class ArrayExtensions
    {
        public static void CopyIndex(this Array self, int from, int to)
        {
            var item = self.GetValue(from);
            self.SetValue(item, to);
        }

        public static void CopyIndex(this Array self, int from, params int[] to)
        {
            Action<int> partial = x => CopyIndex(self, from, x);
            to.ForEach(partial);
        }

        public static void Swap(this Array self, int left, int right)
        {
            var leftItem = self.GetValue(left);
            var rightItem = self.GetValue(right);
            self.SetValue(leftItem, right);
            self.SetValue(rightItem, left);
        }

        public static void Clear(this Array self, int index, int length)
        {
            Array.Clear(self, index, length);
        }
        public static void Clear(this Array self, int index)
        {
            Array.Clear(self, index, self.Length);
        }
        public static void Clear(this Array self)
        {
            Array.Clear(self, 0, self.Length);
        }

        public static int BinarySearch(this Array self, int index, int length, object value, IComparer comparer)
        {
            return Array.BinarySearch(self, index, length, value, comparer);
        }
        public static int BinarySearch(this Array self, int index, int length, object value)
        {
            return Array.BinarySearch(self, index, length, value);
        }
        public static int BinarySearch(this Array self, int index, object value)
        {
            return Array.BinarySearch(self, index, self.Length, value);
        }
        public static int BinarySearch(this Array self, object value)
        {
            return Array.BinarySearch(self, value);
        }


        public static int BinarySearch<T>(this T[] self, int index, int length, T value, IComparer<T> comparer)
        {
            return Array.BinarySearch(self, index, length, value, comparer);
        }
        public static int BinarySearch<T>(this T[] self, int index, int length, T value)
        {
            return Array.BinarySearch(self, index, length, value);
        }
        public static int BinarySearch<T>(this T[] self, int index, T value)
        {
            return Array.BinarySearch(self, index, self.Length, value);
        }
        public static int BinarySearch<T>(this T[] self, T value)
        {
            return Array.BinarySearch(self, value);
        }
        
        public static void Sort(this Array self, int index, int length, IComparer comparer)
        {
            Array.Sort(self, index, length, comparer);
        }
        public static void Sort(this Array self, int index, int length)
        {
            Array.Sort(self, index, length);
        }
        public static void Sort(this Array self, int index)
        {
            Array.Sort(self, index, self.Length);
        }
        public static void Sort(this Array self)
        {
            Array.Sort(self);
        }


        public static void Sort<T>(this T[] self, int index, int length, IComparer<T> comparer)
        {
            Array.Sort(self, index, length, comparer);
        }
        public static void Sort<T>(this T[] self, int index, int length)
        {
            Array.Sort(self, index, length);
        }
        public static void Sort<T>(this T[] self, int index)
        {
            Array.Sort(self, index, self.Length);
        }
        public static void Sort<T>(this T[] self)
        {
            Array.Sort(self);
        }

        public static void ForEach<T>(this T[] self, Action<T> action)
        {
            Array.ForEach(self, action);
        }

        public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] self)
        {
            return Array.AsReadOnly(self);
        }
    }
}