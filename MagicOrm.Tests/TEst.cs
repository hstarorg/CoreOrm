using System;
using System.Dynamic;
namespace MagicOrm.Tests
{
    public class Test2
    {
        public string parse(object obj)
        {
            dynamic d = obj;
            var s = "Hello," + d.Name;
            return s;
        }
    }
}
