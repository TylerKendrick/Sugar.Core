using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Sugar.Dynamic
{
    /// <summary>
    /// Allows for properties of dynamic objects to be indexed as a dictionary.
    /// </summary>
    public class DynamicDictionary : DynamicObject
    {
        private readonly IDictionary<string, Lazy<DynamicDictionary>> _dictionary = new Dictionary<string, Lazy<DynamicDictionary>>();

        /// <summary>
        /// Provides string literal index on dynamic objects.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns>Returns a new dictionary as a lazy object.</returns>
        public Lazy<DynamicDictionary> this[string name]
        {
            get { return _dictionary[name]; }
            set { _dictionary[name] = SetValue(value); }
        }

        /// <summary>
        /// Wraps the construction of an object as a <see cref="Lazy{DynamicDictionary}"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static Lazy<DynamicDictionary> SetValue(object value)
        {
            return new Lazy<DynamicDictionary>(() => new DynamicDictionary(value));
        }

        /// <summary>
        /// Returns the number of properties in the <see cref="Dynamic"/> object.
        /// </summary>
        public int Count
        {
            get { return _dictionary.Count; }
        }
        
        /// <summary>
        /// Inspects properties of an <see cref="Object"/> and creates a dictionary with them.
        /// </summary>
        /// <param name="wrapper">The target object to wrap.</param>
        public DynamicDictionary(object wrapper)
        {
            dynamic dynamo = wrapper;
            IDictionary<string, object> dynamoDic = dynamo;

            foreach (var member in dynamoDic)
            {
                var closure = member;
                _dictionary.Add(closure.Key, new Lazy<DynamicDictionary>(() => new DynamicDictionary(closure.Value)));
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Lazy<DynamicDictionary> lazyDictionary;
            var success = _dictionary.TryGetValue(binder.Name, out lazyDictionary);

            result = lazyDictionary;
            return success;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this[binder.Name] = SetValue(value);
            return true;
        }
    }
}