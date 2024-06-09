using System;
using System.Collections.Generic;

public class SortingAlgorithms
{
    public static void SelectionSort(List<string> arr)
    {
        for (int i = 0; i < arr.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Count; j++)
            {
                if (string.Compare(arr[j], arr[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                string temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }

    public static void BubbleSort(List<string> arr)
    {
        for (int i = 0; i < arr.Count - 1; i++)
        {
            for (int j = 0; j < arr.Count - 1 - i; j++)
            {
                if (string.Compare(arr[j], arr[j + 1]) > 0)
                {
                    string temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static void InsertionSort(List<string> arr)
    {
        for (int i = 1; i < arr.Count; i++)
        {
            string current = arr[i];
            int j = i - 1;
            while (j >= 0 && string.Compare(arr[j], current) > 0)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = current;
        }
    }

    public static void QuickSort(List<string> arr)
    {
        QuickSort(arr, 0, arr.Count - 1);
    }

    private static void QuickSort(List<string> arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);
            QuickSort(arr, left, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }

    private static int Partition(List<string> arr, int left, int right)
    {
        string pivot = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (string.Compare(arr[j], pivot) < 0)
            {
                i++;
                string temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        string temp2 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp2;
        return i + 1;
    }
}
