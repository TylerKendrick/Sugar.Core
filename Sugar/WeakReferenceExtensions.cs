using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class WeakReferenceExtensions
    {
        public static bool IsAlive<TValue>(this WeakReference<TValue> self)
            where TValue : class
        {
            self.TryGetTarget(out var target);
            return target != null;
        }
    }
}