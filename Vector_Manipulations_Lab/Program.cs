using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector_Manipulations_Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            Vector<int> vector = new Vector<int>();

            Console.WriteLine("Створив пустий вектор: "+vector);

            AddRandValuesToVector(vector, 20, -10, 15);
            
            Console.WriteLine("Добавлено випадковi значення: \n" + vector);
            Console.WriteLine("Розмiр: "+vector.Size());
            Console.WriteLine("--------------------------------");

            int indBeg = -1, indEnd = -1;

            GetLongestOddIndexes(vector, out indBeg, out indEnd);

            Console.WriteLine("Найдовша послiдовнiсть непарних чисел. Початок: " + indBeg + "  Кiнець:" + indEnd);

            vector.RemoveRange(indBeg, indEnd);

            Console.WriteLine("Видалено послiдовнiсть: \n" + vector);
            Console.WriteLine("Розмiр: " + vector.Size());
            Console.WriteLine("--------------------------------");

            DublicateOddValues(vector);

            Console.WriteLine("Подвоєно непарнi: \n" + vector);
            Console.WriteLine("Розмiр: " + vector.Size());
            Console.WriteLine("--------------------------------");

            var newVector = RearrangeOddAndEven(vector);

            Console.WriteLine("Новий вектор: \n" + newVector);
        }

        static Vector<int> RearrangeOddAndEven(Vector<int> vector)
        {
            Vector<int> newVector = new Vector<int>();

            for(int i=0;i< vector.Size(); i++)
            {
                if(vector.Get(i) % 2 != 0)
                {
                    newVector.Add(vector.Get(i));
                }
            }
            for (int i = 0; i < vector.Size(); i++)
            {
                if (vector.Get(i) % 2 == 0)
                {
                    newVector.Add(vector.Get(i));
                }
            }

            return newVector;
        }

        static void DublicateOddValues(Vector<int> vector)
        {
            for(int i = 0; i < vector.Size(); i++)
            {
                if (vector.Get(i) % 2 != 0)
                {
                    vector.Add(vector.Get(i), i);
                    i++;
                }
            }
        }

        static void GetLongestOddIndexes(Vector<int> vector, out int indexBeg, out int indexEnd)
        {
            indexBeg = -1;

            int currLenght = 0;
            int maxLenght = 0;
            int currLenghtBeg = 0;

            for (int i = 0; i < vector.Size(); i++){
                if (vector.Get(i) % 2 == 0) // EVEN
                {
                    if (currLenght > maxLenght){
                        indexBeg = currLenghtBeg;
                        maxLenght = currLenght;
                    }
                    currLenght = 0;
                }                           // ODD
                else{
                    if (currLenght == 0)
                    {
                        currLenghtBeg = i;
                    }
                    currLenght++;
                }
            }
            if (currLenght > maxLenght)
            {
                indexBeg = currLenghtBeg;
                maxLenght = currLenght;
            }

            indexEnd = indexBeg + maxLenght-1;


        }

        static void AddRandValuesToVector(Vector<int> vector, int amount, int min, int max)
        {
            Random random = new Random();
            
            for(int i = 0; i < amount; i++)
            {
                vector.Add(random.Next(min, max + 1));
            }
        }

    }
}
