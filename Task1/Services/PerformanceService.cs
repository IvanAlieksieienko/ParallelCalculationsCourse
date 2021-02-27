using System;
using CommonLibrary.Models;
using Task1.Models;

namespace Task1.Services
{
    public class PerformanceService : CommonLibrary.Services.PerformanceService
    {
        public override void ProcessMatrix(Settings settings)
        {
            IMatrix matrix = settings.MatrixType.GetType() == typeof(int) ? new IntegerMatrix() : new FloatMatrix();
            matrix.CreateMatrix(settings.MatrixSize);
            matrix.PopulateMatrixWithNumbers(settings.WayOfPopulatingData);
        }
    }
}
