using System;
using System.Collections.Generic;
using CommonLibrary.Models;

namespace Task2.Models
{
    public class SimpleLinkedList : IMatrix
    {
        LinkedList<double> linkedList;

        public void CreateMatrix(int size)
        {
            this.linkedList = new LinkedList<double>();

            for (int i = 0; i < size; i++)
                this.linkedList.AddLast(new LinkedListNode<double>(i));

            double sum = 0;
            for (int i = 0; i < size; i++)
                sum += this.linkedList.Find(i).Value;
        }

        public void PopulateMatrixWithNumbers(WayOfPopulatingData wayOfPopulatingData)
        {
            throw new NotImplementedException();
        }
    }
}
