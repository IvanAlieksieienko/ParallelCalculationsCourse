using System;
using CommonLibrary.Models;

namespace Task1.Models
{
    public class FloatMatrix : IMatrix
    {
        private float[,] matrix;
        private int size;

        public void CreateMatrix(int size)
        {
            this.matrix = new float[size, size];
            this.size = size;
        }

        public void PopulateMatrixWithNumbers(WayOfPopulatingData wayOfPopulatingData)
        {
            Action<float[,], int, int> populate = wayOfPopulatingData switch
            {
                WayOfPopulatingData.Column => this.PopulateByColumn,
                _ => this.PopulateByRow
            };
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    populate.Invoke(this.matrix, i, j);
                }
            }
        }

        private void PopulateByRow(float[,] matrix, int i, int j) => matrix[i, j] = i * j;
        private void PopulateByColumn(float[,] matrix, int i, int j) => matrix[j, i] = i * j;
    }
}
