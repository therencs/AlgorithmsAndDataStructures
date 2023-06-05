// See https://aka.ms/new-console-template for more information

using System.Text; // This is for Q3


Console.WriteLine("LAB 3 - Complexity");


static void printRecurring(int[] numberList) // I declared this method as static because there's nothing to return. 
{
    List<int> storage = new List<int>();

    List<int> repeating = new List<int>();

    foreach (int n in numberList) // This operation should have the time complexity of O(n)
    {
        if (!storage.Contains(n))
        {
            storage.Add(n);
        }
        else
        {
            repeating.Add(n);

            Console.Write("{0}, ", n);
        }
    }

    // For finding out how to print onto a single line like shown below, I used this example: https://www.techiedelight.com/print-an-array-csharp/
    // I am using Console.Write instead of Console.WriteLine here because Console.Write only prints on a single line
    // The {0} specifies the position for where the argument (in this case, z) will show up in the string or line, 

    // Basically with each iteration, the line will be append the index of the repeating list followed by a comma till it ends.

    // This foreach loop will only run if there is something in the repeating list collection.

}

static void sortAndMerge(int[][] twoArrays)
{
    int[] combinedArray = new int[twoArrays[0].Length + twoArrays[1].Length];

    // PROBLEM 2

    int x = 0;

    for (int a = 0; a < twoArrays.Length; a++) // It isn't possible to have O(n) time complexity for this problem because the only you can access the nested arrays to sort or merge them into an array is by iterating through the outermost arrays first.  
    {
        for (int j = 0; j < twoArrays[a].Length; j++)
        {
            combinedArray[x] = twoArrays[a][j];
            //Console.Write("{0}, ", combinedArray[x]); Debugging the merge
            x++;
        }
    }

    int placeholder;
    Console.WriteLine("");

    // I spent 2 hours trying to make a sorting and merging method in just one operation but to no avail, so I ended up splitting the method into to parts and using this reference for the sorting part: https://www.c-sharpcorner.com/blogs/sort-array-in-c-sharp-without-using-inbuilt-function
    // That being said, the merging algorithm I made is completely from scratch.

    for (int n = 0; n < combinedArray.Length; n++)
    {
        for (int y = n + 1; y < combinedArray.Length; y++) // The reason why the assigned value of this iterator is a number after the parent iterator is because we have to compare the array with itself. The index of the array on both iterators being the same wouldn't work because we can't compare values inside the array
        {
            if (combinedArray[n] > combinedArray[y])
            {
                placeholder = combinedArray[n];
                combinedArray[n] = combinedArray[y];
                combinedArray[y] = placeholder;

            }

        }
        Console.Write("{0}, ", combinedArray[n]);
    }
    // As an estimate, the time complexity of this could at the very least be O(n^2)
}

static void reverseDigits(int integer)
{
    char[] integerSplit = integer
        .ToString()
        .ToCharArray();

    StringBuilder numberBuild = new StringBuilder("");

    for (int c = integerSplit.Length - 1; c >= 0; c--) // The time complexity of my solution is O(n)
    {
        numberBuild.Append(new char[] { integerSplit[c] });
    };

    Console.Write($"{numberBuild}\n");


}

// PROBLEM 1

Console.Write($"\n\nPROBLEM 1 \n\n");

List<int> numbers = new List<int>()
    {
        1,
        2,
        3,
        4,
        7,
        9,
        2,
        4,
    };

printRecurring(numbers.ToArray());

// PROBLEM 2

Console.Write($"\n\nPROBLEM 2\n");

int[][] integerArrays = new int[][]
{
    new int[] {1, 2, 3, 4, 5 },
    new int[] {2, 5, 7, 9, 13 },
};

sortAndMerge(integerArrays);

// PROBLEM 3

Console.WriteLine($"\n\nPROBLEM 3\n");

int givenInteger = 3415;

reverseDigits(givenInteger);

