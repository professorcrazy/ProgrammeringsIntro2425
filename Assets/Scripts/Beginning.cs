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
        print(message);

        //Liste med karakterer
        students.Add(new int[] {0, 2,-3, 4, 7, 10, 7, 4, 10 }); //her er en simpel måde at tilføje et array til en liste
        int[] bob = { 12, 2, -3, 10, 7, 7, 7, 4, 10}; //alternativt kan du lave dit int array først og derefter tilfæje det til din liste. 
        students.Add(bob);
        //Hvis vi skal tilføje flere elementer til vores liste kan vi bruge et loop og her bruger vi den funktion vi lavede som generer karakterlister.
        for(int i = 0; i < 10; i++)
        {
            students.Add(RandomGrades());
        }
        //printer alle vores elevers karakter. 
        foreach (int[] student in students)
        {
            print(student);
        }
        //https://github.com/professorcrazy/ProgrammeringsIntro2425
        //Print hver elevs gennemsnit. 

        //print karakterliste og gennemsnit i samme linje. 

        // Lav et histogram
        // - for hver elev
        // - for hvert fag (index)
        // - for alle elever og fag


        //Array
        print("Print et array forlæns");
        for (int i = 0; i < array.Length; i++)
        {
            print(array[i]);
        }

        print("Print et array baglæns");
        for (int i = array.Length-1; i >= 0 ; i--)
        {
            print(array[i]);
        }

        print("Grade average: " + Average(array));
    }

    //Funktions overloading (vi har taget og lavet en særregl for print funktionen så den kan printe et array)
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
    //Her har vi gjort det samme men for en liste
    void print(List<int> array)
    {
        string toPrint = "";
        for (int i = 0; i < array.Count; i++)
        {
            if (i == array.Count - 1)
            {
                toPrint += array[i];
                break;
            }
            toPrint += array[i] + ", ";
        }
        print(toPrint);
    }
//Generer tilfældige karaktere for eleverne. 
    int[] RandomGrades()
    {
        int[] gradeOptions = { -3, 0, 2, 4, 7, 10, 12 };
        int[] tempGrades = new int[9];
        for (int i = 0; i < tempGrades.Length; i++)
        {
            tempGrades[i] = gradeOptions[Random.Range(0, gradeOptions.Length - 1)];//Vi bruger Unitys random funktion
        }
        return tempGrades;
    }
    //En funktion der beregner gennemsnittet af et int array og returnerer (sender et resultat ud) af typen float.
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
    //Det samme som funktionen over bare for et float array
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
    //Beregner og returnerer gennemsnittet for en liste af ints
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
    //Det samme som ovenover bare for en liste af floats
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
