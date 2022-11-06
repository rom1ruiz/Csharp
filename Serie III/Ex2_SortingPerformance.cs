using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    public struct SortData
    {
        /// <summary>
        /// Moyenne pour le tri par insertion
        /// </summary>
        public long InsertionMean { get; set; }
        /// <summary>
        /// Écart-type pour le tri par insertion
        /// </summary>
        public long InsertionStd { get; set; }
        /// <summary>
        /// Moyenne pour le tri rapide
        /// </summary>
        public long QuickMean { get; set; }
        /// <summary>
        /// Écart-type pour le tri rapide
        /// </summary>
        public long QuickStd { get; set; }
    }

    public static class SortingPerformance
    {
        public static void DisplayPerformances(List<int> sizes, int count)
        {
            //TODO
        }

        public static List<SortData> PerformancesTest(List<int> sizes, int count)
        {
            List<SortData> sortDatas = new List<SortData>();
            for (int i = 0; i < sizes.Count; i++)
            {

                //srtDatas = new List<SortData> { PerformanceTest(sizes[i], count)};
                sortDatas.Add(PerformanceTest(sizes[i], count));
            }
            return sortDatas;
        }

        public static SortData PerformanceTest(int size, int count)
        {
            double sommeQuick = 0;
            double sommeInsert = 0;
            double sommeSqrtQuick = 0;
            double sommeSqrtInsert = 0;
            SortData result = new SortData();
            for (int i = 0; i < count; i++)
            {
                List<int[]> list = ArraysGenerator(size);
                sommeQuick += UseQuickSort(list[0]);
                sommeInsert += UseInsertionSort(list[1]);
            }
            result.QuickMean = (int)sommeQuick / count;
            result.InsertionMean = (int)sommeInsert / count;
            sommeSqrtQuick = Math.Pow(sommeQuick - result.QuickMean, 2);
            result.QuickStd = (int)sommeSqrtQuick / count;
            sommeSqrtInsert = Math.Pow(sommeInsert - result.InsertionMean, 2);
            result.QuickStd = (int)sommeSqrtInsert / count;

            return result;
        }

        private static List<int[]> ArraysGenerator(int size)
        {
            int[] array1 = new int[size];
            int[] array2 = new int[size];
            Random rd = new Random();
            List<int[]> arrays = new List<int[]>();
            for (int i = 0; i < size; i++)
            {
                int value = rd.Next(-1000, 1001);
                array1[i] = value;
                array2[i] = value;
            }
            arrays = new List<int[]>
            {
                 array1,
                 array2
            };

            return arrays;
        }

        public static long UseInsertionSort(int[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            InsertionSort(array);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long UseQuickSort(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort(array, left, right);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int tmp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tmp;
                    }
                }
            };
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }
            int tmp = array[i];
            array[i] = array[right];
            array[right] = tmp;
            return i;
        }
    }
}
