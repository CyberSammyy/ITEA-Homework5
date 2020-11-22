using System;

namespace ITEA_Homework5
{
    class Program
    {
        static void Show(int[] array)
        {
            Console.WriteLine("Showing array:");
            foreach(var a in array)
            {
                Console.Write(a + "\t");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 100));
        }
        static int[] ArrayFiller()
        {
            Console.WriteLine("Enter size of an array:");
            int size = 0;
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Try again.");
            }
            int[] array = new int[size];
            var rand = new Random();
            for(int i = 0; i < size; i++)
            {
                array[i] = rand.Next(0, 100);
            }
            Console.WriteLine(new string('-', 100));
            return array;
        }

        static int[] QuickSort(int[] array, int first, int last)
        {
            int p = array[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (array[i] < p && i <= last) ++i;
                while (array[j] > p && j >= first) --j;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) QuickSort(array, first, j);
            if (i < last) QuickSort(array, i, last);
            return array;
        }
        static int[] BubbleSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        static int[] ShakerSort(int[] array, int count)
        {
            int left = 0, right = count - 1;
            int flag = 1; 
            while ((left < right) && flag > 0)
            {
                flag = 0;
                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {             
                        int t = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = t;
                        flag = 1;     
                    }
                }
                right--; 
                for (int i = right; i > left; i--)  
                {
                    if (array[i - 1] > array[i]) 
                    {          
                        int t = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = t;
                        flag = 1;
                    }
                }
                left++;
            }
            return array;
        }
        static int[] ShellSort(int[] array)
        {
            int step = array.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < array.Length; i++)
                {
                    int value = array[i];
                    for (j = i - step; (j >= 0) && (array[j] > value); j -= step)
                        array[j + step] = array[j];
                    array[j + step] = value;
                }
                step /= 2;
            }
            return array;
        }
        static void Main(string[] args)
        {
            int[] array = ArrayFiller();
            Show(array);
            Console.WriteLine("Sorted array (BubbleSort):");
            Show(BubbleSort(array));
            array = ArrayFiller();
            Show(array);
            Console.WriteLine("Sorted array (QuickSort):");
            Show(QuickSort(array, 0, array.Length - 1));
            array = ArrayFiller();
            Show(array);
            Console.WriteLine("Sorted array (ShakerSort):");
            Show(ShakerSort(array, array.Length));
            array = ArrayFiller();
            Show(array);
            Console.WriteLine("Sorted array (ShellSort):");
            Show(ShellSort(array));
        }
    }
}
