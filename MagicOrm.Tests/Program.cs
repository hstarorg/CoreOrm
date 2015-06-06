using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.CSharp;

namespace MagicOrm.Tests
{
    class Program
    {
        static public void Main(string[] args)
        {
            var a=DateTime.Now.AddDays(-3).GetWeekOfYear();
            Console.WriteLine(a.ToString());
            Console.ReadKey();
        }

      

        private static void Emit()
        {
            //Emit
            var f = typeof(float);
            var dm = new DynamicMethod("test_func", f, new[] { f, f, f });
            var il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Ret);
            var method = dm.CreateDelegate(Expression.GetFuncType(f, f, f, f)) as Func<float, float, float, float>;
            Console.WriteLine(method(1.0f, 3, 2.0f));
            Console.ReadKey();
        }
    }

    public static class DateTimeExtension
    {
        public static int GetWeekOfYear(this DateTime dt)
        {
            GregorianCalendar calendar = new GregorianCalendar();
            return calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    }
}
