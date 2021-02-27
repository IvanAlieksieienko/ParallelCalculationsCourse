using System;
using CommonLibrary.Models;
using Task2.Models;

namespace Task2.Services
{
    public class PerformanceService : CommonLibrary.Services.PerformanceService
    {
        public override void ProcessMatrix(Settings settings)
        {
            IMatrix matrix = settings.MatrixType.GetType() == typeof(SimpleArray) ? new SimpleArray() :
                             settings.MatrixType.GetType() == typeof(SimpleArrayList) ? new SimpleArrayList() :
                             new SimpleLinkedList();
            matrix.CreateMatrix(settings.MatrixSize);
        }
    }
}
