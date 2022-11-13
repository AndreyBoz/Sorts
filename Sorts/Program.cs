using System;
using System.Diagnostics;
namespace Sorts;
class Program {
    static List<int> list = new List<int>();
    
    static public void Main() { 
        
        Stopwatch sw = new Stopwatch();
        for(int i =0; i <= 5; i++)
        {
            list = Enumerable.Range(0, 10000*i).Select(s => new Random(s).Next(0, 100)).ToList();
            int[] arr = new int[list.Count];
            arr = list.ToArray();
            sw.Start();
            SortBubble(arr);
            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
        }
        
    }
    private static void Swap(int[] array, int i, int j) {
        int tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
    public static int[] SortInsert(int[] array) {
        if(array.Length==1) return array;
        for (int i = 1; i < array.Length; i++) {
            for (int j = i; j > 0 && array[j - 1] > array[j]; j--)
                Swap(array, j-1, j);
        }
        return array;
    }
    public static int[] SortBubble(int[] array) {
        if (array.Length == 1) return array;
        bool flag = true;
        while (flag) {
            flag = false;
            for (int j = 0; j < array.Length-1; j++) { 
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                    flag = true;
                }
            }
        }
        return array;
    }
    public static int[] SortSelection(int[] array) {
        if (array.Length == 1) return array;
        int minIndex;
        for (int i = 0; i < array.Length-1; i++) {
            minIndex = i;
            for (int j = i; j < array.Length; j++) {
                if(array[minIndex] > array[j])
                    minIndex = j;
            }
            Swap(array,i,minIndex);
        }
        return array;
    }
    static private void Merge(int[] array, int lowIndex, int middleIndex, int highIndex) {

        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (array[left] < array[right])
            {
                tempArray[index] = array[left];
                left++;
            }
            else
            {
                tempArray[index] = array[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            array[lowIndex + i] = tempArray[i];
        }
    }
    static private int[] SortMerge(int[] array, int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            SortMerge(array, lowIndex, middleIndex);
            SortMerge(array, middleIndex + 1, highIndex);
            Merge(array, lowIndex, middleIndex, highIndex);
        }

        return array;
    }

    static public int[] SortMerge(int[] array)
    {
        if (array.Length == 1) return array;
        return SortMerge(array, 0, array.Length - 1);
    }
    static int[] SortShell(int[] array)
    {
        if (array.Length == 1) return array;
        var middle = array.Length / 2;
        while (middle >= 1)
        {
            for (var i = middle; i < array.Length; i++)
            {
                var j = i;
                while ((j >= middle) && (array[j - middle] > array[j]))
                {
                    Swap(array, j, j - middle);
                    j = j - middle;
                }
            }

            middle = middle / 2;
        }
        return array;
    }
    static int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                Swap(array, pivot, i);
            }
        }

        pivot++;
        Swap(array, pivot,maxIndex);
        return pivot;
    }
    static int[] SortQuick(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = Partition(array, minIndex, maxIndex);
        SortQuick(array, minIndex, pivotIndex - 1);
        SortQuick(array, pivotIndex + 1, maxIndex);

        return array;
    }

    static int[] SortQuick(int[] array)
    {
        if (array.Length == 1) return array;
        return SortQuick(array, 0, array.Length - 1);
    }

}