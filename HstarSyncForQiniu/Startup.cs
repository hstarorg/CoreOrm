using Qiniu.Conf;

namespace HstarSyncForQiniu
{
    public static class Startup
    {
        public static void Init()
        {
            InitQiniu();
        }

        /// <summary>
        /// 初始化七牛的配置
        /// <param name="accessKey">访问密钥</param>
        /// <param name="secretKey">安全验证密钥</param>
        /// </summary>
        private static void InitQiniu(string accessKey = null, string secretKey = null)
        {
            GlobalObject.AccessKey = accessKey ?? GlobalObject.AccessKey;
            GlobalObject.SecretKey = secretKey ?? GlobalObject.SecretKey;
            Config.ACCESS_KEY = GlobalObject.AccessKey;
            Config.SECRET_KEY = GlobalObject.SecretKey;
            Config.Init();
        }
    }
}
