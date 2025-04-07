using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Beginning : MonoBehaviour
{
    string message = "Hello World!";

    public int[] array = { -3, 12, 4, 7, 0, 10, 12, 4, 7, 2 };
    
    public List<int> myList = new List<int>() { 0, 1, 2};

    List<int[]> students = new List<int[]>();

    [SerializeField] Transform histPrefab;

    [SerializeField] GameObject canvasBarPrefab;
    [SerializeField] GameObject canvasValuePrefab;
    [SerializeField] GameObject canvasPanelPrefab;
    [SerializeField] Transform canvasRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(message);

        //Liste med karakterer
        students.Add(new int[] {0, 2,-3, 4, 7, 10, 7, 4, 10 }); //her er en simpel m�de at tilf�je et array til en liste
        int[] bob = { 12, 2, -3, 10, 7, 7, 7, 4, 10}; //alternativt kan du lave dit int array f�rst og derefter tilf�je det til din liste. 
        students.Add(bob);
        //Hvis vi skal tilf�je flere elementer til vores liste kan vi bruge et loop og her bruger vi den funktion vi lavede som generer karakterlister.
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
        print("Print student averages");
        for (int i = 0; i < students.Count; i++)
        {
            print(Average(students[i]));
        }

        //print karakterliste og gennemsnit i samme linje.
        print("Grades and average");
        for (int i = 0; i < students.Count; i++)
        {
            print(StringifyArray(students[i]) + " # " + Average(students[i])); 
        }

        // Lav et histogram
        // - for hver elev
        HistVisualizer(HistArray(students[0]), new Vector3(3, 0, 0));
        // - for hvert fag (index)
        List<int> dansk = new List<int>();
        for (int i = 0; i < students.Count; i++)
        {
            dansk.Add(students[i][0]);
        }
        HistVisualizer(HistArray(dansk), new Vector3(3, 3, 0), 1, Average(dansk));
        // - for alle elever og fag
        List<int> allClassesAndStudents = new List<int>();
        for (int i = 0; i < students.Count; i++)
        {
            for (int j = 0; j < students[i].Length; j++)
            {
                allClassesAndStudents.Add(students[i][j]);
            }
        }
        HistVisualizer(HistArray(allClassesAndStudents), new Vector3(3,7,0), 1/12f);

        HistVisualizerCanvas(HistArray(students[0]), new Vector3(30, 30, 0), 1);
        HistVisualizerCanvas(HistArray(dansk), new Vector3(210, 30, 0), 1);
        HistVisualizerCanvas(HistArray(allClassesAndStudents), new Vector3(390, 30, 0), 0.75f);
        ////Array
        //print("Print et array forl�ns");
        //for (int i = 0; i < array.Length; i++)
        //{
        //    print(array[i]);
        //}

        //print("Print et array bagl�ns");
        //for (int i = array.Length-1; i >= 0 ; i--)
        //{
        //    print(array[i]);
        //}

        //print("Grade average: " + Average(array));
    }

    int[] HistArray(int[] array)
    {
        int[] histValues = new int[7];
        for (int i = 0; i < array.Length; i++)
        {
            switch (array[i])
            {
                case -3:
                    histValues[0]++;
                    break;
                case 0:
                    histValues[1]++;
                    break;
                case 2:
                    histValues[2]++;
                    break;
                case 4:
                    histValues[3]++;
                    break;
                case 7:
                    histValues[4]++;
                    break;
                case 10:
                    histValues[5]++;
                    break;
                case 12:
                    histValues[6]++;
                    break;
                default:
                    break;
            }
        }
        return histValues;
    }

    int[] HistArray(List<int> list)
    {
        int[] histValues = new int[7];
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i])
            {
                case -3:
                    histValues[0]++;
                    break;
                case 0:
                    histValues[1]++;
                    break;
                case 2:
                    histValues[2]++;
                    break;
                case 4:
                    histValues[3]++;
                    break;
                case 7:
                    histValues[4]++;
                    break;
                case 10:
                    histValues[5]++;
                    break;
                case 12:
                    histValues[6]++;
                    break;
                default:
                    break;
            }
        }
        return histValues;
    }
    void HistVisualizer(int[] array, Vector3 startPos) {
        for (int i = 0; i < array.Length; i++)
        {
            Transform g = Instantiate(histPrefab, startPos + ((Vector3.right * i) + (Vector3.up * array[i]/2f)), Quaternion.identity).transform;
            g.transform.localScale = new Vector3(g.localScale.x, array[i], 1);
        }
    }
    void HistVisualizer(int[] array, Vector3 startPos, float yScaler)
    {
        for (int i = 0; i < array.Length; i++)
        {
            float yVal = array[i] * yScaler;
            Transform g = Instantiate(histPrefab, startPos + ((Vector3.right * i) + (Vector3.up * (yVal / 2f))), Quaternion.identity).transform;
            g.transform.localScale = new Vector3(g.localScale.x, yVal, 1);
        }
    }

    void HistVisualizer(int[] array, Vector3 startPos, float yScaler, float average)
    {
        for (int i = 0; i < array.Length; i++)
        {
            float yVal = array[i] * yScaler;
            Transform g = Instantiate(histPrefab, startPos + ((Vector3.right * i) + (Vector3.up * (yVal / 2f))), Quaternion.identity).transform;
            g.transform.localScale = new Vector3(g.localScale.x, yVal, 1);
        }
        float yValAvg = average * yScaler;
        Transform avgT = Instantiate(histPrefab, startPos + ((Vector3.right * ((array.Length/2f)-0.5f)) + (Vector3.up * (yValAvg / 2f))), Quaternion.identity).transform;
        avgT.transform.localScale = new Vector3(array.Length, 0.1f, 1);
    }

    int FindHighest(int[] array)
    {
        if (array.Length == 0)
        {
            return 0;
        }
        int curHighest = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (curHighest < array[i])
            {
                curHighest = array[i];
            }
        }
        return curHighest;
    }

    void HistVisualizerCanvas(int[] array, Vector3 startPos, float scale)
    {
        Transform tempGraphPanel = Instantiate(canvasPanelPrefab, canvasRef).transform;
        tempGraphPanel.transform.position = startPos;
        int highestValue = FindHighest(array);
        RectTransform rtYaxis = tempGraphPanel.Find("Y_Axis").GetComponent<RectTransform>();
        rtYaxis.sizeDelta = new Vector2(5, 20 * highestValue + 20);
        rtYaxis.localPosition = new Vector3(2.5f, highestValue * 10 + 10, 0);

        for (int i = 0; i < highestValue + 1; i++)
        {
            Transform g = Instantiate(canvasValuePrefab, tempGraphPanel).transform;
            g.localPosition = new Vector3(0, i * 20, 0);
            //g.GetComponent<RectTransform>().rect.Set(i * 15, array[i] * 10, 5, array[i] * 20);
            foreach (TMP_Text t in g.GetComponentsInChildren<TMP_Text>())
            {
                t.text = (i + 1).ToString();
            }
        }
        for (int i = 0; i < array.Length; i++)
        {
            Transform g = Instantiate(canvasBarPrefab, tempGraphPanel).transform; //GetComponent<RectTransform>();
            //g.rect.Set(i*25+5, array[i]*10, 5, array[i]*20);
            g.localPosition = new Vector3(i * 20 + 20, array[i] * 10, 0);
            
            g.GetComponent<RectTransform>().sizeDelta = new Vector2(5, array[i] * 20);
            //g.localScale = new Vector3(5, array[i] * 20, 0);
        }
        tempGraphPanel.localScale *= scale;

    }
    //Funktions overloading (vi har taget og lavet en s�rregl for print funktionen s� den kan printe et array)
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

    string StringifyArray(int[] array)
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
        return (toPrint);
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
//Generer tilf�ldige karaktere for eleverne. 
    int[] RandomGrades()
    {
        int[] gradeOptions = { -3, 0, 2, 4, 7, 10, 12 };
        int[] tempGrades = new int[9];
        for (int i = 0; i < tempGrades.Length; i++)
        {
            tempGrades[i] = gradeOptions[Random.Range(0, gradeOptions.Length)];//Vi bruger Unitys random funktion
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
