using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Pentotris
{
    internal class ThreadManager : IDisposable
    {
        private readonly BlockingCollection<Action> taskQueue = new BlockingCollection<Action>();
        private readonly Thread[] workers;

        public ThreadManager(int workerCount)
        {
            workers = new Thread[workerCount];
            for (int i = 0; i < workerCount; i++)
            {
                workers[i] = new Thread(Work);
                workers[i].Start();
            }   
        }

        public void QueueTask(Action task)
        {
            taskQueue.Add(task);
        }

        public void Work()
        {
            foreach (var task in taskQueue.GetConsumingEnumerable())
            {
                try
                {
                    task();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public void Dispose()
        {
            taskQueue.CompleteAdding();
            foreach (var worker in workers)
            {
                worker.Join();
            }
        }
    }
}
