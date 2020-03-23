using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector_Manipulations_Lab
{
    class Vector<T>
    {
        private T[] array;
        private int nextIndex;

        public Vector() {
            array = new T[1];
            nextIndex = 0;
        }

        public Vector(int size)
        {
            array = new T[size];
            nextIndex = 0;
        }

        private void UpsizeArray(int num)
        {
            T[] tempArray = new T[array.Length + num];

            for(int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            array = tempArray;
        }

        public T Get(int index)
        {
            if (index < nextIndex)
            {
                return array[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(T value)
        {
            if (value != null)
            {
                if (nextIndex >= array.Length) { UpsizeArray(5); }

                array[nextIndex] = value;
                nextIndex++;
            }
        }

        public void Add(T value,int index)
        {
            if (value != null && index < nextIndex)
            {
                if (nextIndex >= array.Length) { UpsizeArray(5); }

                for(int i = nextIndex - 1; i >= index; i--)
                {
                    array[i + 1] = array[i];
                }
                array[index] = value;
                nextIndex++;
            }
        }


        public void Remove(int index)
        {
            if (index < nextIndex)
            {
                for(int i = index; i < nextIndex-1; i++)
                {
                    array[i] = array[i + 1];
                }
                nextIndex--;
            }
        }

        public void RemoveRange(int index1, int index2)
        {
            if (index2 < nextIndex) {

                int tempIndex = index1;

                for (int i = index2+1; i < nextIndex; i++)
                {
                    array[tempIndex] = array[i];
                    tempIndex++;
                }

                nextIndex = tempIndex;
            }
        }

        public int Size()
        {
            return nextIndex;
        }

        public override string ToString()
        {
            string s = "";

            s += "Vector: (";
            for (int i = 0; i < nextIndex; i++)
            {
                s += array[i].ToString();

                if (i != nextIndex - 1)
                {
                    s += " ,";
                }
            }
            s += " )";
            return s;
        }
    }
}
