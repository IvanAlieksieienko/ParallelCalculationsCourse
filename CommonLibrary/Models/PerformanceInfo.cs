using System;
namespace CommonLibrary.Models
{
    public class PerformanceInfo
    {
        public TimeSpan TimeSpent { get; set; }
        public double KBytesSpent { get; set; }
        public Settings Settings { get; set; }
        public int MatrixSize { get; set; }
    }
}
