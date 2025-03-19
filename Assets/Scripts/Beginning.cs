using System.Collections.Generic;
using UnityEngine;

public class Beginning : MonoBehaviour
{
    string message = "Hello World!";

    public int[] array = { -3, 12, 4, 7, 0, 10, 12, 4, 7, 2 };
    
    public List<int> myList = new List<int>() { 0, 1, 2};

    List<int[]> students = new List<int[]>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        students.Add(new int[] {0, 2,-3, 4, 7, 10, 7, 4, 10 });
        int[] bob = { 12, 2, -3, 10, 7, 7, 7, 4, 10};
        students.Add(bob);

        for(int i = 0; i < 10; i++)
        {
            students.Add(RandomGrades());
        }
        foreach (int[] student in students)
        {
            print(student);
        }




        //List
        print(myList[0]);
        for (int i = 0; i < myList.Count; i++)
        {
            print(myList[i]);
        }

        //Array
        print(message);
        for (int i = 0; i < array.Length; i++)
        {
            print(array[i]);
        }


        for (int i = array.Length-1; i >= 0 ; i--)
        {
            print(array[i]);
        }

        print("Grade average: " + Average(array));
    }

    void print(int[] array)
    {
        string toPrint = "";
        for(int i = 0; i < array.Length; i++)
        {
            if(i == array.Length - 1)
            {
                toPrint += array[i];
                break;
            }
            toPrint += array[i] + ", "; 
        }
        print(toPrint);
    }

    int[] RandomGrades()
    {
        int[] gradeOptions = { -3, 0, 2, 4, 7, 10, 12 };
        int[] tempGrades = new int[9];
        for (int i = 0; i < tempGrades.Length; i++)
        {
            tempGrades[i] = gradeOptions[Random.Range(0, gradeOptions.Length - 1)];
        }
        return tempGrades;
    }

    float Average(int[] grades)
    {
        if (grades.Length == 0)
        {
            return 0f;
        }
        float sum = 0;
        for (int i = 0; i < grades.Length; i++)
        {
            sum += grades[i];
        }
        return sum / grades.Length;
    }
    float Average(float[] grades)
    {
        if (grades.Length == 0)
        {
            return 0f;
        }
        float sum = 0;
        for (int i = 0; i < grades.Length; i++)
        {
            sum += grades[i];
        }
        return sum / grades.Length;
    }

    float Average(List<int> grades)
    {
        if(grades.Count == 0)
        {
            return 0f;
        }
        float sum = 0f;
        for(int i = 0; i < grades.Count; i++)
        {
            sum += grades[i];
        }
        return sum / grades.Count;
    }
    float Average(List<float> grades)
    {
        if (grades.Count == 0)
        {
            return 0f;
        }
        float sum = 0f;
        for (int i = 0; i < grades.Count; i++)
        {
            sum += grades[i];
        }
        return sum / grades.Count;
    }
}
