using JLeo.Data.DemoApp.Models;
using JLeo.Data.Mapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace JLeo.Data.DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Console.ReadKey();
        }

        static async void Test1()
        {
            var connectionString = "data source=**;database=**;uid=**;Password=**;connection reset=false;Connection Timeout=30;Connection Lifetime=30;min pool size=0; max pool size=50;";
            ObjectActivator oa = new ObjectActivator();
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT TOP 20 [ApiId],[InUser],[InDate] FROM [dbo].[ApiFamily]", conn))
                {
                    await conn.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    var list = oa.CreateInstance<ApiFamilyEntity>(reader).ToList();
                    Console.WriteLine($"The End!!! List Count = {list.Count}");
                    foreach (var item in list)
                    {
                        Console.WriteLine($"ApiId={item.ApiId}, InUser={item.InUser}, InDate={item.InDate}");
                    }
                }
            }
        }
    }
}
