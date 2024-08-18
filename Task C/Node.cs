using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    class Node<T> where T : IComparable
    {
        private T data;
        public Node<T> Left, Right;
        private int balanceFactor = 0;

        public Node(T item)//Constructor
        {
            data = item;
            Left = null;
            Right = null;
        }
        public T Data //Property for data
        {
            set { data = value; }
            get { return data; }
        }
        public int BalanceFactor
            //Porperty for Balancefactor. Will allow to access and change the balance factor
        {
            set { balanceFactor = value; }
            get { return balanceFactor; }
        }
    }
}
