using System;

namespace Sugar
{
    public class It<T> : It<T, IsComparableExpression<T>>
    {
        public It(T handle)
            : base(() => new IsComparableExpression<T>(handle))
        {
        }
    }

    public class It<T, TIs>
        where TIs : IsComparableExpression<T>
    {
        private readonly Lazy<TIs> _is;
        public TIs Is { get { return _is.Value; } }

        public It(Func<TIs> factoryMethod)
        {
            _is = new Lazy<TIs>(factoryMethod);
        }
    }
}