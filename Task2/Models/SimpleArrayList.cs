using System;
using System.Collections;
using CommonLibrary.Models;

namespace Task2.Models
{
    public class SimpleArrayList : IMatrix
    {
        ArrayList arrayList;

        public void CreateMatrix(int size)
        {
            this.arrayList = new ArrayList();

            for (int i = 0; i < size; i++)
                this.arrayList.Add(i);

            double sum = 0;
            for (int i = 0; i < size; i++)
                sum += (double)this.arrayList[i];
        }

        public void PopulateMatrixWithNumbers(WayOfPopulatingData wayOfPopulatingData)
        {
            throw new NotImplementedException();
        }
    }
}
