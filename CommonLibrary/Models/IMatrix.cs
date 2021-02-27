using System;

namespace CommonLibrary.Models
{
    public interface IMatrix
    {
        public void CreateMatrix(int size);
        public void PopulateMatrixWithNumbers(WayOfPopulatingData wayOfPopulatingData);
    }
}
