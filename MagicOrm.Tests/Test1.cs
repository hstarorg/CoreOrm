using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace MagicOrm.Tests
{
    public class Test1
    {
        public void Test()
        {
            // this.RunTaskWithThread();
            //  this.RunDelegateWithAsync();
           // this.RunTaskWithBackgroundWorker();
            this.RunTaskWithAsyncAndAwait();
            // this.RunTaskBySync();

            // this.RunTaskWithThread();

            //this.RunTaskWithThreadPool();

            // this.RunTaskWithBackgroundWorker();

            // this.RunTaskWithAsyncTask();

            //  this.RunTaskWithAsyncAndAwait();
        }

        /// <summary>
        /// 同步执行任务
        /// </summary>
        private void RunTaskBySync()
        {
            Console.WriteLine("同步方式执行6 tasks 开始：");
            var tt = new TestTasks();
            CodeActuator.RunCode(() =>
            {
                tt.Task1();
                tt.Task2(1000);
            });
            Console.WriteLine("同步方式执行6 tasks 结束。\n\n");
        }

        /// <summary>
        /// 多线程方式执行任务
        /// </summary>
        private void RunTaskWithThread()
        {
            var tt = new TestTasks();
            new Thread(tt.Task1).Start();
            new Thread(x => tt.Task2((int)x)).Start((object)1000);
        }

        private delegate int AsyncCaller(int x);

        private void RunDelegateWithAsync()
        {
            var tt = new TestTasks();

            Action ac = tt.Task1;
            Action<int> ac2 = tt.Task2;
            ac.BeginInvoke(null, null);
            ac2.BeginInvoke(1000, null, null);
        }

        /// <summary>
        /// 线程池方式执行任务
        /// </summary>
        private void RunTaskWithThreadPool()
        {
            var tt = new TestTasks();

            ThreadPool.QueueUserWorkItem(o => tt.Task1());
            ThreadPool.QueueUserWorkItem(o => tt.Task2(1000));
        }

        /// <summary>
        /// 后台线程方式执行任务
        /// </summary>
        private void RunTaskWithBackgroundWorker()
        {
            var tt = new TestTasks();

            var bw = new BackgroundWorker();
            bw.DoWork += (sender, e) => tt.Task1();
            bw.DoWork += (sender, e) => tt.Task2(1000);
            bw.DoWork += (sender, e) => e.Result = tt.Task3(1000);
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += (sender, e) => Console.WriteLine(e.Result);
        }

        /// <summary>
        /// 异步Task方式执行任务
        /// </summary>
        private void RunTaskWithAsyncTask()
        {
            var tt = new TestTasks();

            var t1 = Task.Factory.StartNew(tt.Task1);
            var t2 = Task.Factory.StartNew(() => tt.Task2(1000));
            var t3 =Task.Factory.StartNew(() => tt.Task3(1000));
            Task.WaitAll(t1,t2,t3);
            Console.WriteLine(t3.Result);
        }

        /// <summary>
        /// 后台线程方式执行任务
        /// </summary>
        private void RunTaskWithAsyncAndAwait()
        {
            AsyncRunTask();
            Console.WriteLine("不用等待，我先执行了。");
        }

        private async void AsyncRunTask()
        {
            var tt = new TestTasks();
            await Task.Factory.StartNew(tt.Task1);
            await Task.Factory.StartNew(() => tt.Task2(1000));
            var result = await Task.Factory.StartNew(() => tt.Task3(1000));
            Console.WriteLine(result);
        }
    }
}
