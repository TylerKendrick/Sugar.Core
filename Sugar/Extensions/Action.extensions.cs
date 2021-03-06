﻿namespace System
{
    /// <summary>
    /// Simplifies action invocation and operations.
    /// </summary>
    public static partial class ActionExtensions
    {
        /// <summary>
        /// Provides an object for conditional invocation.
        /// </summary>
        public static When When(this Action self, Func<bool> predicate)
        {
            return new When(self, predicate);
        }

        /// <summary>
        /// Provides a new <see cref="Looper"/> instances that wraps a specified <see cref="Action"/>.
        /// </summary>
        public static Looper Loop(this Action self)
        {
            return new Looper(self);
        }

        /// <summary>
        /// Wraps proceeding Catch/Finally blocks to allow passing control of blocks to other areas.
        /// </summary>
        public static ITryBlock Try(this Action self)
        {
            return TryBlock.Configuration.Default(self).Configure();
        }

        /// <summary>
        /// Wraps proceeding Catch/Finally blocks to allow passing control of blocks to other areas.
        /// </summary>
        public static ITryBlock Try(this Action self, ITryConfiguration configuration)
        {
            return TryBlock.Create(self, configuration);
        }
    }
}