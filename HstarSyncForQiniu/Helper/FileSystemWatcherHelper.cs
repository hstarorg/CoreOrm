using System;
using System.IO;
using System.Threading.Tasks;

namespace HstarSyncForQiniu.Helper
{
    public static class FileSystemWatcherHelper
    {
        /// <summary>
        /// 监视指定目录
        /// </summary>
        /// <param name="path"></param>
        /// <param name="createdFunc"></param>
        /// <param name="renamedFunc"></param>
        /// <param name="changedFunc"></param>
        /// <param name="deletedFunc"></param>
        /// <param name="watchAttributes"></param>
        /// <param name="useTask"></param>
        public static void StartNewWatcher(string path,
            Action<object, FileSystemEventArgs> createdFunc,
            Action<object, FileSystemEventArgs> renamedFunc,
            Action<object, FileSystemEventArgs> changedFunc,
            Action<object, FileSystemEventArgs> deletedFunc,
            bool watchAttributes = false,
            bool useTask = true)
        {
            if (!Directory.Exists(path))
            {
                throw new FileNotFoundException("Can't find path.");
            }
            /**
             * 创建文件-默认名称：Created
             * 创建文件-自定义名称：Created->Renamed
             * 复制文件：Changed->Changed (修改NotifyFilters的值，可变为一次Changed)
             * 删除文件：Deleted
             * 重命名文件：Renamed
             */
            Action watcher = () =>
            {
                var fsWatcher = new FileSystemWatcher(path);
                if (!watchAttributes)
                {
                    fsWatcher.NotifyFilter = NotifyFilters.Size | NotifyFilters.FileName;
                }

                if (createdFunc != null)
                {
                    fsWatcher.Created += (s1, e1) => createdFunc(s1, e1);
                }
                if (renamedFunc != null)
                {
                    fsWatcher.Renamed += (s2, e2) => changedFunc(s2, e2);
                }
                if (changedFunc != null)
                {
                    fsWatcher.Changed += (s3, e3) => changedFunc(s3, e3);
                }
                if (deletedFunc != null)
                {
                    fsWatcher.Deleted += (s4, e4) => deletedFunc(s4, e4);
                }
                fsWatcher.EnableRaisingEvents = true; //开始监视
            };
            if (useTask)
            {
                Task.Factory.StartNew(watcher);
            }
            else
            {
                watcher();
            }
        }
    }
}
