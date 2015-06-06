using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using PetaPoco;

namespace MagicOrm
{

    public class EmitTest
    {
        static FieldInfo fldConverters = typeof(Database).GetField("m_Converters", BindingFlags.Static | BindingFlags.GetField | BindingFlags.NonPublic);
        static MethodInfo fnListGetItem = typeof(List<Func<object, object>>).GetProperty("Item").GetGetMethod();
        static List<Func<object, object>> m_Converters = new List<Func<object, object>>();
        static MethodInfo fnGetValue = typeof(IDataRecord).GetMethod("GetValue", new Type[] { typeof(int) });

        private static void AddConverterToStack(ILGenerator il, Func<object, object> converter)
        {
            if (converter != null)
            {
                // Add the converter
                int converterIndex = m_Converters.Count;
                m_Converters.Add(converter);

                // Generate IL to push the converter onto the stack
                il.Emit(OpCodes.Ldsfld, fldConverters);
                il.Emit(OpCodes.Ldc_I4, converterIndex);
                il.Emit(OpCodes.Callvirt, fnListGetItem);					// Converter
            }
        }

        public Dictionary<string,PropertyInfo> GetProperties<T>()
        {
            var dic = new Dictionary<string, PropertyInfo>();
            var t = typeof (T);
            foreach (var propertyInfo in t.GetProperties())
            {
                dic.Add(propertyInfo.Name,propertyInfo);
            }
            return dic;
        } 

        public IEnumerable<T> ReaderToObject<T>(IDataReader reader) where T : class, new()
        {
             MethodInfo fnIsDBNull = typeof(IDataRecord).GetMethod("IsDBNull");


            var columns = this.GetProperties<T>();
            var type = typeof (T);
            //创建一个动态方法
            var dynamicMethod = new DynamicMethod("petapoco_factory_1", type, new[] { typeof(IDataReader) }, true);
            var il = dynamicMethod.GetILGenerator();
            // var t = new T();
            il.Emit(OpCodes.Newobj, type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null));

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var srcType = reader.GetFieldType(i);
                var p = columns[reader.GetName(i)];
                var destType = p.PropertyType;

                // "if (!rdr.IsDBNull(i))"
                il.Emit(OpCodes.Ldarg_0);                   // poco,rdr
                il.Emit(OpCodes.Ldc_I4, i);                   // poco,rdr,i
                il.Emit(OpCodes.Callvirt, fnIsDBNull);              // poco,bool
                var lblNext = il.DefineLabel();
                il.Emit(OpCodes.Brtrue_S, lblNext);               // poco
                il.Emit(OpCodes.Dup);

               // Func<object, object> converter = null;

                // Setup stack for call to converter(生成converter)
              //  AddConverterToStack(il, converter);

                // "value = rdr.GetValue(i)"
                il.Emit(OpCodes.Ldarg_0);                   // *,rdr
                il.Emit(OpCodes.Ldc_I4, i);                   // *,rdr,i
                il.Emit(OpCodes.Callvirt, fnGetValue);              // *,value

                // Call the converter
//                if (converter != null)
//                    il.Emit(OpCodes.Callvirt, typeof(Func<object, object>).GetMethod("Invoke"));

                // Assign it
                il.Emit(OpCodes.Unbox_Any, destType);   // poco,poco,value
                il.Emit(OpCodes.Callvirt, p.GetSetMethod(true));    // poco
                il.MarkLabel(lblNext);

                il.Emit(OpCodes.Ret);

            }
            var del = dynamicMethod.CreateDelegate(Expression.GetFuncType(typeof(IDataReader), type)) as Func<IDataReader, T>;
            using (reader)
            {
                while (true)
                {
                    T poco;
                    if (!reader.Read())
                        yield break;
                    poco = del(reader);

                    yield return poco;
                }
            }
        }
    }
}
