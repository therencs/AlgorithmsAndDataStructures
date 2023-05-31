Console.WriteLine($"LAB 1\n");
bool valid = false;

int n = 0;

while (n <= 0)
{
    Console.WriteLine($"Enter the length for your array:\n");
    n = Int32.Parse(Console.ReadLine());

}

string[] userArray = new string[n];

for (int i = 0; i < userArray.Length; i++)
{
    Console.WriteLine("Enter a word for string " + (i + 1) + ".");
    string wordInput = Console.ReadLine();

    if (!wordInput.Contains(" ") && wordInput.Length > 0) // If the input from the user doesnt contain a space (empty string) and it contains at least a letter, add it to the array.
    {
        // When the user searches for an uppercase character in an array of lowercase characters, 
        // C# won't count each instance of that uppercase character.
        userArray[i] = wordInput;

        Console.WriteLine($"String {i + 1} is {userArray[i]}\n");

    }
    else
    {
        Console.WriteLine("Your word isnt valid! Words need at least one letter and no spaces!");
        i--; // I saw Zack use this trick to undo the iteration and thought I could apply it to my code here. 
    }

};

char userChar = '_';

while (!valid)
{
    Console.WriteLine($"Enter the character you want the count of.");
    userChar = Console.ReadKey().KeyChar;

    if (!Char.IsLetter(userChar))
    {
        Console.WriteLine($"\nYour character isnt valid! Try to use alphabetical letters\n");
    }
    else
    {

        valid = true;
    }
}

Console.WriteLine($"\n\nYou chose {userChar} \n");

// I overheard my peers talking about how foreach was not only a thing in JS, but is also a thing 
// in C#. Because of that I did some research on it on w3schools, tried to relearn it and implemented it into my code. 

int letterCount = 0;
int totalCount = 0;

for (int i = 0; i < userArray.Length; i++)
{
    // The for loop will only affect the highlighted string in the array at a time, starting from the 
    // first string, at index 0. What the foreach is doing here is iterating through each letter/character
    // in the current string. 

    // In the foreach, if a character is equivalent to the character the user gave as an input, 
    // the count variable I declared above goes up by 1. 

    foreach (char letter in userArray[i])
    {
        totalCount++;

        if (letter == userChar)
        {
            letterCount++;

        }
    }
}

Console.WriteLine("The letter " + userChar + " was found in your array " + letterCount + " times.");

if (letterCount > (totalCount / 4))
{
    Console.WriteLine("25% of the letters in the array is that of your chosen letter. ");

}
else
{
    Console.WriteLine("Your letter is not included in 25% of the array.");
}

// I think int would be the best numeric datatype to store the total count of letters
// because storing numbers with decimal digits wouldnt be neccesary.

// We're only dealing with whole numbers because count only goes up by 1 after every identified letter.

// You can't use BigInteger because it is immutable.
// You cannot assign values to an instance of BigInteger after it is created.

// However, numeric types like float, int or double are mutable, and can be changed after they are 
// created.
