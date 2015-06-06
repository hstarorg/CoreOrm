using System.Configuration;

namespace HstarSyncForQiniu
{
    public static class GlobalObject
    {
        static GlobalObject()
        {
            AccessKey = ConfigurationManager.AppSettings["Qiniu_Access_Key"];
            SecretKey = ConfigurationManager.AppSettings["Qiniu_Secret_Key"];
        }

        public static string AccessKey { get; set; }

        public static string SecretKey { get; set; }
    }
}
