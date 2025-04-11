using UnityEngine;

public class Sorting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        int[] arrayA = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        int[] arrayB = { 9, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        int[] arrayC = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] sorted = new int[10];
        /*
        print("ArrayA: not sorted ", arrayA);
        print("ArrayB: not sorted ",arrayB);
        print("ArrayC: not sorted ", arrayC);
        */
        print("Reversed Array Swaps: B: " + BubbleSort(arrayA).ToString() + " | S: " + SelectionSort(arrayA).ToString() + " | I: " + InsertionSort(arrayA).ToString());
        print("One off Array Swaps: B: " + BubbleSort(arrayB).ToString() + " | S: " + SelectionSort(arrayB).ToString() + " | I: " + InsertionSort(arrayB).ToString());
        print("Sorted Array Swaps: B: " + BubbleSort(arrayC).ToString() + " | S: " + SelectionSort(arrayC).ToString() + " | I: " + InsertionSort(arrayC).ToString());

        print("42! = " + Factorial(42).ToString());
    }



    //Bubble Sort
    int BubbleSort(int[] array)
    {
        int[] sortedArray = array;
        int swapCount = 0;
        for (int i = 0; i < sortedArray.Length; i++)
        {
            bool swaps = false;
            for (int j = 0; j < sortedArray.Length - 1 - i; j++)
            {
                if (sortedArray[j] > sortedArray[j + 1])
                {
                    int tempValue = sortedArray[j];
                    sortedArray[j] = sortedArray[j + 1];
                    sortedArray[j + 1] = tempValue;
                    swaps = true;
                }
                swapCount++;
            }
            if (swaps == false)
            {
                break;
            }
        }
        //print(sortedArray);
        //print("Bubble Sort, Swaps: " + swapCount);
        return swapCount;
    }

    //Selection Sort
    int SelectionSort(int[] array)
    {
        int[] sortedArray = array;
        int arrayLength = array.Length;
        int swaps = 0;

        for (int i = 0; i < arrayLength - 1; i++)
        {
            int smallestVal = i;
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (sortedArray[j] < sortedArray[smallestVal])
                {
                    smallestVal = j;
                }
                swaps++;
            }
            int tempVar = sortedArray[smallestVal];
            sortedArray[smallestVal] = sortedArray[i];
            sortedArray[i] = tempVar;
        }
        //print(sortedArray);
        //print("Selection Sort, Swaps: " + swaps + ", Time: " + (timer - Time.timeAsDouble).ToString());
        return swaps;
    }

    //Insertion Sort
    int InsertionSort(int[] array)
    {
        int length = array.Length;
        int[] sortedArray = array;
        int swaps = 0;

        for (int i = 1; i < length; i++)
        {
            var key = sortedArray[i];
            var flag = 0;
            for (int j = i - 1; j >= 0 && flag != 1;)
            {
                if (key < sortedArray[j])
                {
                    sortedArray[j + 1] = sortedArray[j];
                    j--;
                    sortedArray[j + 1] = key;
                }
                else
                {
                    flag = 1;
                }
                swaps++;
            }
        }
        //print(sortedArray);
        //print("Insertion Sort, Swaps: " + swaps + ", Time: " + (timer-Time.timeAsDouble).ToString());
        return swaps;
    }

    //----- Recursive functions -----\\
    double Factorial(double num)
    {
        double n = num;
        if (n < 2)
        {
            return 1;
        }
        else {
            return n * Factorial(n - 1);
        }
    }


    //----- Printing functions -----\\
    void print(string s, int[] array)
    {
        string toPrint = s;
        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length - 1)
            {
                toPrint += array[i];
                break;
            }
            toPrint += array[i] + ", ";
        }
        print(toPrint);
    }
    void print(int[] array)
    {
        string toPrint = "";
        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length - 1)
            {
                toPrint += array[i];
                break;
            }
            toPrint += array[i] + ", ";
        }
        print(toPrint);
    }
}
