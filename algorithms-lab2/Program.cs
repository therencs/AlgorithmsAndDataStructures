// See https://aka.ms/new-console-template for more information

using System;
using System.Text;

// A PROGRAM THAT PRODUCES AN ARRAY OF ALL THE CHARACTERS THAT APPEAR MORE THAN ONCE

string word = "Programmatic Python";

char[] charArray = word
    .ToLower()
    .ToCharArray();

Console.WriteLine(charArray);

StringBuilder charStorage = new StringBuilder("", 26);

for (int i = 0; i < charArray.Length; i++)
{
    for (int x = (i + 1); x < charArray.Length - 1; x++)
    {
        if (charArray[x] == charArray[i]
            && !(charStorage.ToString().Contains(charArray[i]))
            && !(charArray[x].ToString().Contains(" "))
            )
        {
            charStorage.Append(new char[] { charArray[x] });
        }
    }
}

Console.WriteLine($"All the characters that appear more than once: {charStorage}");

// A PROGRAM THAT RETURNS AN ARRAY OF STRINGS THAT ARE UNIQUE WORDS FOUND IN AN ARGUMENT.

string examplestring = ("To Be Or Not To Be");

int count = 0;
int hinderLetter = 0;
StringBuilder wordBuild = new StringBuilder("");

List<string> allWords = new List<string>();

for (int i = 0; i < examplestring.Length; i++) // This loop is for seperating the words and bringing them into an array 
{

    if (examplestring[i].ToString().Contains(" ") || i == examplestring.Length - 1)
    {

        if (examplestring[i].ToString().Contains(" "))
        {
            hinderLetter = 1; // If the current index is a string, hinderLetter is set to one. The hinderLetter var being set to one means the space letter will be skipped when a word is being built. See below.

        }
        else if (i == examplestring.Length - 1)
        {
            hinderLetter = 0; // If it's the last letter of the last possible word, dont skip the current index (This is because the current index isnt a space in this case)
        }

        for (int j = i - count; j <= (i - hinderLetter); j++) // j starts at iteration minus the amount of letters it found before the space, j iterates until it reaches one away from current index because the current index is space
        {
            wordBuild.Append(new char[] { examplestring[j] });
        }

        string stringWord = wordBuild.ToString();

        Console.WriteLine($"Only unique words: {stringWord}");

        allWords.Add(stringWord);
        wordBuild.Length = 0;

        count = 0;
    }
    else
    {
        count++;
    }

}

string[] allWordString = allWords.ToArray();

StringBuilder uniqueWords = new StringBuilder("");

for (int i = 0; i < allWordString.Length; i++)
{
    bool isDuplicate = false;
    for (int z = 0; z < i; z++)
    {
        if (allWordString[i] == allWordString[z])
        {
            isDuplicate = true;

            break; // Breaks the child for loop and runs the program back from the top of the parent for loop. 
        }
    }

    if (isDuplicate == false)
    {
        uniqueWords.Append($"{allWordString[i]}, "); // The unique word gets patched onto the existing string. 
    }
}

// I found the solution to the 2nd half of the question from this stackoverflow page: https://stackoverflow.com/questions/9673/how-do-i-remove-duplicates-from-a-c-sharp-array
// The forum user applied this method to a number array that sets empty numbers to 0. I restructured it to suit StringBuilder and string arrays.   
// If the current word in the nested for loop is the same as the word in the parent for loop, it sets isDuplicate to true which skips the string appending statement.
// If the current word is NOT found to be a matching word in the array (indicated by isDuplicate == false), it gets appended to uniqueWords. 

Console.WriteLine(uniqueWords.ToString());

// PROGRAM THAT REVERSES A PROVIDED STRING

string examplestringTwo = "Quick, Talk Backwards!";

StringBuilder reverseMe = new StringBuilder("");

for (int i = examplestringTwo.Length - 1; i > -1; i--)
{
    reverseMe.Append(examplestringTwo[i]);
}

Console.WriteLine($"Original Word: {examplestringTwo}");
Console.WriteLine($"Reversed: {reverseMe}");

// PROGRAM THAT FINDS THE LARGEST UNBROKEN WORD IN A STRING AND PRINTS IT 

// I did hardcode a copy of question 2 with little changes because I don't know if we are supposed to be using functions/methods just yet. 

string examplestringThree = "Tiptoe through the beaming tulips";

wordBuild.Length = 0;
count = 0;
hinderLetter = 0;

string longestWord = "";

for (int i = 0; i < examplestringThree.Length; i++)
{

    if (examplestringThree[i].ToString().Contains(" ") || i == examplestringThree.Length - 1)
    {

        if (examplestringThree[i].ToString().Contains(" "))
        {
            hinderLetter = 1;

        }
        else if (i == examplestringThree.Length - 1)
        {
            hinderLetter = 0;
        }

        for (int j = i - count; j <= (i - hinderLetter); j++)
        {
            wordBuild.Append(new char[] { examplestringThree[j] });
        }

        if (wordBuild.Length >= longestWord.Length)
        {
            longestWord = wordBuild.ToString();
        }

        wordBuild.Length = 0;

        count = 0;
    }
    else
    {
        count++;
    }


}

Console.WriteLine($"The longest word found was: {longestWord}");


// Q: What is StringBuilder? 

// A: StringBuilder is an object containing a arrangement of characters that can be shortened or expanded with its built in methods like replace or append.


// Q: What are the advantages of using StringBuilder? 

// A: The biggest advantage of StringBuilder over strings is that its mutable.
// When you change a string, you are not changing its value, but rather its reference. The original string value is still engrained in memory.
// This does not apply to StringBuilder, as you are modifying the string in a pre-allocated buffer.
// What this means is that you are changing the string in a predetermined region of memory where objects are created.

// The second advantage of StringBuilder is it can execute faster during changes compared to a string being "changed", due in part to the reason above.
