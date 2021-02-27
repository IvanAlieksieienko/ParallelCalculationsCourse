using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLibrary.Models;

namespace CommonLibrary.Services
{
    public abstract class PerformanceService
    {
        public static PerformanceInfo MeasurePerformance(Task task)
        {
            var initialBytes = GC.GetTotalMemory(false);
            var startTime = DateTime.Now;
            task.RunSynchronously();
            var endTime = DateTime.Now;
            var eventualBytes = GC.GetTotalMemory(false);
            return new PerformanceInfo
            {
                KBytesSpent = eventualBytes - initialBytes,
                TimeSpent = endTime - startTime
            };
        }

        public IList<PerformanceInfo> Manage(Settings settings, int[] sizes)
        {
            IList<PerformanceInfo> performanceInfos = new List<PerformanceInfo>();
            foreach (var size in sizes)
            {
                settings.MatrixSize = size;
                Task newTask = new Task(() => this.ProcessMatrix(settings));
                var performanceInfo = PerformanceService.MeasurePerformance(newTask);
                performanceInfo.Settings = settings;
                performanceInfo.MatrixSize = size;
                performanceInfos.Add(performanceInfo);
            }
            return performanceInfos;
        }

        public abstract void ProcessMatrix(Settings settings);
    }
}
