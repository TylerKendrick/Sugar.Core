using System;

namespace Sugar.Reflection
{
    public static class TypeFluentExpressionExtensions
    {
        public static bool SubclassOf(this IFluentExpression<Type> self, Type type)
        {
            return self.Context.IsSubclassOf(type);
        }
        public static bool SubclassOf<T>(this IFluentExpression<Type> self)
        {
            return self.SubclassOf(typeof (T));
        }

        public static bool Primitive(this IFluentExpression<Type> self)
        {
            return self.Context.IsPrimitive;
        }

        public static bool Class(this IFluentExpression<Type> self)
        {
            return self.Context.IsClass;
        }

        public static bool ValueType(this IFluentExpression<Type> self)
        {
            return self.Context.IsValueType;
        }

        public static bool Enum(this IFluentExpression<Type> self)
        {
            return self.Context.IsEnum;
        }

        public static bool Interface(this IFluentExpression<Type> self)
        {
            return self.Context.IsInterface;
        }
    }
}
