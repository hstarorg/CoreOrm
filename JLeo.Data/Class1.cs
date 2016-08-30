using System;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace JLeo.Data
{
    public static class EmitHelper
    {
        /// <summary>
        /// Set property/field value
        /// </summary>
        /// <param name="il"></param>
        /// <param name="memberInfo">Member info</param>
        public static void SetValue(ILGenerator il, MemberInfo memberInfo)
        {
            var memberType = memberInfo.MemberType;
            if (memberType == MemberTypes.Property)
            {
                var setter = (memberInfo as PropertyInfo).GetSetMethod();
                il.EmitCall(OpCodes.Callvirt, setter, null);
            }
            else if (memberType == MemberTypes.Field)
            {
                il.Emit(OpCodes.Stfld, memberInfo as FieldInfo);
            }
            else
            {
                throw new NotSupportedException("Only set value to property and field.");
            }
        }

        public static Action<object, IDataReader, int> SetEntityMemberValue(MemberInfo memberInfo)
        {
            DynamicMethod dm = new DynamicMethod($"SetObjectMemberFromReader_{Guid.NewGuid().ToString("N")}", null, new Type[] { typeof(object), typeof(IDataReader), typeof(int) }, true);
            // Build method body
            ILGenerator il = dm.GetILGenerator();

            il.Emit(OpCodes.Ldarg_S, 0);
            il.Emit(OpCodes.Castclass, memberInfo.DeclaringType); //强类型

            var readerMethod = typeof(EmitHelper).GetMethod("GetString");

            il.Emit(OpCodes.Ldarg_S, 1);
            il.Emit(OpCodes.Ldarg_S, 2);
            il.EmitCall(OpCodes.Call, readerMethod, null);

            SetValue(il, memberInfo);

            il.Emit(OpCodes.Ret);

            var action = dm.CreateDelegate(typeof(Action<object, IDataReader, int>)) as Action<object, IDataReader, int>;
            return action;
        }

        public static void SetEntityMemberValueByExp<T>(T entity, MemberInfo memberInfo, IDataReader reader, int ordinal)
        {
            var param1 = Expression.Parameter(typeof(Object), "obj");
            var param2 = Expression.Parameter(typeof(IDataReader), "reader");
            var param3 = Expression.Parameter(typeof(int), "ordinal");

            var readerMethod = typeof(EmitHelper).GetMethod("GetString");
            var value = readerMethod.Invoke(null, new[] { reader as object, ordinal as object });

            var pType = (memberInfo as PropertyInfo);

            var setMethodInfo = pType.GetSetMethod();
            var invokeObjExpr = Expression.Parameter(typeof(T), "source");//source
            ParameterExpression propValExpr = Expression.Parameter(pType.PropertyType, "value");//value
            MethodCallExpression setMethodExpr = Expression.Call(invokeObjExpr, setMethodInfo, propValExpr);//source.setXXX(value)

            var lambdaBodyExp = Expression.Call(null, readerMethod, param2, param3);

            var dynamicDelegateExp = Expression.Lambda(setMethodExpr, invokeObjExpr, propValExpr);
            var dynamicDelegate = dynamicDelegateExp.Compile();
            dynamicDelegate.DynamicInvoke(entity, value);
        }

        public static string GetString(this IDataReader reader, int ordinal)
        {
            return reader.GetString(ordinal);
        }
    }
}
