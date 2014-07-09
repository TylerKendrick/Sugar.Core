using System;
using System.Collections.Generic;

namespace Sugar
{
    public class EnumerableIt<TItem, TCollection, TConditional> :
        It<TCollection, EnumerableIsComparableExpression<TItem, TCollection, TConditional>, TConditional> 
        where TCollection : IEnumerable<TItem> 
        where TConditional : IConditionalExpression<TCollection>
    {
        public EnumerableIt(Func<EnumerableIsComparableExpression<TItem, TCollection, TConditional>> factoryMethod) 
            : base(factoryMethod)
        {
        }
    }

    public class EnumerableIt<TItem, TCollection> :
        It<TCollection, EnumerableIsComparableExpression<TItem, TCollection>>
        where TCollection : IEnumerable<TItem>
    {
        public EnumerableIt(Func<EnumerableIsComparableExpression<TItem, TCollection>> factoryMethod) 
            : base(factoryMethod)
        {
        }
    }

    public class EnumerableIt<TItem> :
        EnumerableIt<TItem, IEnumerable<TItem>>
    {
        public EnumerableIt(Func<EnumerableIsComparableExpression<TItem, IEnumerable<TItem>>> factoryMethod) 
            : base(factoryMethod)
        {
        }
    }
}