// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Text;

Console.WriteLine("LAB 4 - Lists");
static int GetHighestValueInList(List<int> intList) // Time complexity: O(n^2)
{
    int greatest = intList[0];

    for (int i = 0; i < intList.Count; i++)
    {
        for(int j = i+1; j < intList.Count; j++)
        {
            if (intList[j] > greatest) {
                greatest = intList[j];
            }
        }
    }
    return greatest;
}

static int GetHighestValueIndex(List<int> intList) // Time complexity: O(n^2)
{
    int greatest = intList[0];
    int index = 0;
    for (int i = 0; i < intList.Count; i++)
    {
        for (int j = i + 1; j < intList.Count; j++)
        {
            if (intList[j] > greatest)
            {
                greatest = intList[j];
                index = j;
            }
        }
    }
    return index;
}

static List<int> MaxNumbersInLists(List<List<int>> listGroup) // Time complexity: O(n^3)
{
    List<int> maxNumberList = new List<int>();

    foreach(List<int> x in listGroup)
    {
        maxNumberList.Add(GetHighestValueInList(x));
    }

    return maxNumberList;
}

static string HighestGrade(List<List<int>> gradeLists) // Time complexity: O3(n^2)
{
    List<int> HighestGradePerClass = new List<int>();

    HighestGradePerClass.AddRange(MaxNumbersInLists(gradeLists));

    string highestGradeMsg = (
        $"The highest grade is {GetHighestValueInList(HighestGradePerClass)}. " +
        $"This grade was found in class(es) {GetHighestValueIndex(HighestGradePerClass)}."
        );

    return highestGradeMsg;
}

static List<int> OrderByLooping (List<int> intList) // Time complexity: O(n^2)
{
    int[] intArray = intList.ToArray();
    int placeholder;
    List<int> listFromArray = new List<int>();

    for (int a = 0; a < intArray.Length; a++) // Mostly taken from my 3rd Lab. I would appreciate it if I could see the proper way to solve this. 
    {
        for (int l = a+1; l < intArray.Length; l++)
        {
            if (intArray[a] > intArray[l])
            {
                placeholder = intArray[a];
                intArray[a] = intArray[l];
                intArray[l] = placeholder;
            }
        }
        
    }

    foreach(int y in intArray)
    {
        listFromArray.Add(y);
    }

    return listFromArray;
}

Console.WriteLine("PROBLEM 1");

List<int> exampleList = new List<int>()
{
    1, 4, 6, 7, 9
};

List<int> exampleList2 = new List<int>()
{
    6, 3, 12, 3, 9
};

if (exampleList.Count > 0) 
{
    Console.WriteLine($"Highest Number: {GetHighestValueInList(exampleList)} \n");
}

Console.WriteLine("PROBLEM 2");

List<List<int>> nestedList1 = new List<List<int>>
{
    new List<int> { 1, 5, 3 },
    new List<int> { 9, 7, 3, -2 },
    new List<int> { 2, 1, 2 }
};

int count = 0;

if (nestedList1.Count > 0)
{
    foreach (int y in MaxNumbersInLists(nestedList1)) // Time complexity: O(n^2)
    {
        count++;
        Console.WriteLine($"List {count} has a maximum of {y}.");
    }
}

Console.WriteLine("\nPROBLEM 3");

List<List<int>> courseGrades = new List<List<int>>
{
    new List<int> {85, 92, 67, 94, 94 },
    new List<int> {50, 60, 57, 95},
    new List<int> {95}
};

if (courseGrades[0].Count > 0)
{
    Console.WriteLine($"{HighestGrade(courseGrades)}"); // I had plans of programming multiple indexes like in the example but I ran out of time. 
}


Console.WriteLine("\nPROBLEM 4");

Console.Write("{");

if (exampleList2.Count > 0)
{
    foreach (int i in OrderByLooping(exampleList2)) 
    {
        Console.Write("{0}, ", i);
    }

}

Console.Write("}");

Console.WriteLine("");


