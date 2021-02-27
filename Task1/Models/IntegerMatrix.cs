using System;
using CommonLibrary.Models;

namespace Task1.Models
{
    public class IntegerMatrix : IMatrix
    {
        private int[,] matrix;
        private int size;

        public void CreateMatrix(int size)
        {
            this.matrix = new int[size, size];
            this.size = size;
        }

        public void PopulateMatrixWithNumbers(WayOfPopulatingData wayOfPopulatingData)
        {
            Action<int[,], int, int> populate = wayOfPopulatingData switch
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

        private void PopulateByRow(int[,] matrix, int i, int j) => matrix[i, j] = i * j;
        private void PopulateByColumn(int[,] matrix, int i, int j) => matrix[j, i] = i * j;
    }
}
