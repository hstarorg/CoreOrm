using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OrmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            Console.ReadKey();
        }

        public static async void Start()
        {
            var list = await SqlTest();
            Console.WriteLine(list.Count.ToString());
        }

        public async static Task<List<TestModel>> SqlTest()
        {
            var list = new List<TestModel>();
            var connectionString = "data source=10.1.25.28,41433;database=xxx;uid=xxx;Password=xxx;connection reset=false;Connection Timeout=30;Connection Lifetime=30;min pool size=0; max pool size=50;";
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("select top 2 name as Name from sys.tables", conn))
                {
                    await conn.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        var model = BuildInstance<TestModel>(reader);
                        list.Add(model);
                    }
                    Console.WriteLine("The End");
                    return list;
                }
            }
        }

        public static T BuildInstance<T>(IDataReader reader) where T : class, new()
        {
            var model = new T();
            var fieldCount = reader.FieldCount;
            var dic = new Dictionary<string, int>();
            for (var i = 0; i < fieldCount; i++)
            {
                dic.Add(reader.GetName(i), i);
                Console.Write($"{reader.GetValue(i)}\t{reader.GetFieldType(i)}");
            }
            var memberInfo = typeof(T).GetMember("Name")[0];
            //var action = EmitHelper.SetEntityMemberValue(memberInfo);
            //action(model, reader, 0);
            EmitHelper.SetEntityMemberValueByExp<T>(model, memberInfo, reader, 0);
            return model;
        }
    }
}
