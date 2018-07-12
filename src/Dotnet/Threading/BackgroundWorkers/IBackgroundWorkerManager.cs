﻿namespace Dotnet.Threading.BackgroundWorkers
{
    public interface IBackgroundWorkerManager : IRunnable
    {
        void Add(IBackgroundWorker worker);
 
    }
}
