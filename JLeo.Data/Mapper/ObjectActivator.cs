using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace JLeo.Data.Mapper
{

    public class Member
    {
        public string MemberName { get; set; }

        public MemberInfo MemberInfo { get; set; }

        public int Ordinal { get; set; }
    }

    public class ObjectActivator : IObjectActivator
    {
        public IList<T> CreateInstance<T>(IDataReader reader) where T : class, new()
        {
            var resultList = new List<T>();
            var modelType = typeof(T);
            var memberList = new List<MemberInfo>();
            var modelMembers = modelType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in modelMembers)
            {
                PropertyInfo prop = null;
                if ((prop = item as PropertyInfo) != null)
                {
                    if (prop.GetSetMethod() == null)
                        continue;//对于没有公共的 setter 直接跳过
                    memberList.Add(item);
                }
                else if (item as FieldInfo != null)
                {
                    memberList.Add(item);
                }
                else
                    continue;//只支持公共属性和字段
            }
            var mapList = new List<Member>();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var fieldName = reader.GetName(i);
                for (var j = 0; j < memberList.Count; j++)
                {
                    var memberName = memberList[j].Name;
                    if (fieldName == memberName)
                    {
                        mapList.Add(new Member { MemberName = memberName, MemberInfo = memberList[j], Ordinal = i });
                        memberList.RemoveAt(j);
                        break;
                    }
                }
            }
            while (reader.Read())
            {
                var model = new T();
                foreach (var item in mapList)
                {
                    EmitHelper.SetEntityMemberValueByExp<T>(model, item.MemberInfo, reader, item.Ordinal);
                }
                resultList.Add(model);
            }
            return resultList;
        }
    }
}
