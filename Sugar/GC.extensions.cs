using System;

namespace Sugar
{
    public static class GCExtensions
    {
        public static int GetGeneration(this WeakReference self)
        {
            return GC.GetGeneration(self);
        }

        public static void KeepAlive(this object self)
        {
            GC.KeepAlive(self);
        }

        public static void ReRegisterForFinalize(this object self)
        {
            GC.ReRegisterForFinalize(self);
        }
        public static void SuppressFinalize(this object self)
        {
            GC.SuppressFinalize(self);
        }
    }
}