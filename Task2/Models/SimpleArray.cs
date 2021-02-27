using System;
using CommonLibrary.Models;

namespace Task2.Models
{
    public class SimpleArray : IMatrix
    {
        public double[] array;

        public void CreateMatrix(int size)
        {
            this.array = new double[size];

            for (int i = 0; i < size; i++)
                this.array[i] = i;

            double sum = 0;
            for (int i = 0; i < size; i++)
                sum += this.array[i];
        }

        public void PopulateMatrixWithNumbers(WayOfPopulatingData wayOfPopulatingData)
        {
            throw new NotImplementedException();
        }
    }
}
