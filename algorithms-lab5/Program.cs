// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;

bool exit = false;

int optionGlobal = 0;

Console.WriteLine("LAB 5 - Stacks, Queues");

// Very proud of this one, it may be the first one where I figured it out using pen and paper and problem solving and without using the internet for anything aside from help with syntax.
// Would prefer to be graded on this one. 

static int chooseOption()
{
    Console.WriteLine("Choose an option: \n");

    Console.WriteLine($"1. Add a song to your playlist\n");
    Console.WriteLine($"2. Play the next song in your playlist\n");
    Console.WriteLine($"3. Skip the next song\n");
    Console.WriteLine($"4. Rewind one song \n");
    Console.WriteLine($"5. Exit \n");

    int option = 0;

    while(!(option > 0 && option < 6))
    {
        string input = Console.ReadLine();

        bool ableToConvert = int.TryParse(input, out option);

        if (ableToConvert == false || (!(option > 0 && option < 6)))
        {
            Console.WriteLine("Option doesn't exist! Try choosing a number between 1 - 5\n");
        }

    }

    Console.WriteLine($"> {option}");

    return option; 
}

static int InitQueue()
{
   
    char inputChar = ' ';

    while (!(inputChar == 'Y' || inputChar == 'y'))
    {
        Console.WriteLine($"Add a song to your playlist? ( Y for Yes )\n");
        inputChar = Console.ReadKey().KeyChar;


        if ((!(inputChar == 'Y' || inputChar == 'y')))
        {
            Console.WriteLine("You have to agree to add songs to the queue first.\n");
        }

    }

    Console.WriteLine("");
    return 1;
}

Stack prevSongs = new Stack();

Queue nextSongs = new Queue();

Queue nowPlaying = new Queue();

void doAction(int option)
{
    if (option == 1)
    {

            string input = "";

            Console.WriteLine("");
            Console.Write("Enter a song: ");

            while (input == "")
            {
                input = Console.ReadLine();

                if (input == "")
                {
                    Console.WriteLine("Song title cannot be empty!");
                }
            }

            Console.WriteLine("");
            nextSongs.Enqueue(input);
           

    }
    else if (option == 2)
    {
        if (nextSongs.Count > 0)
        {

            if(nowPlaying.Count > 0)
            {
                prevSongs.Push(nowPlaying.Peek());
            }

            nowPlaying.Clear();
            nowPlaying.Enqueue(nextSongs.Peek());
            nextSongs.Dequeue();
            
        } else
        {
            Console.WriteLine("No more songs left in queue! (You should add more)");
        }

    }
    else if (option == 3)
    {
        if (nextSongs.Count > 1 && nowPlaying.Count > 0)
        {
            prevSongs.Push(nextSongs.Peek());
            nextSongs.Dequeue();
        } else
        {
            Console.WriteLine("Unable to skip! Try playing a song back first or adding more to the queue.");
        }
    }
    else if (option == 4)
    {
        if (prevSongs.Count > 0)
        {

            if (nowPlaying.Count > 0)
            {
                nextSongs.Enqueue(nowPlaying.Peek());
            }

            nowPlaying.Clear();
            nowPlaying.Enqueue(prevSongs.Pop());

        }
        else
        {
            Console.WriteLine("No more songs left to rewind to!");
        }

    } else if (option == 5)
    {
        Console.WriteLine("Exiting...");
        exit = true;
    }

    if (exit == false)
    {

        if (nowPlaying.Count > 0)
        {
            Console.WriteLine("Now Playing - " + nowPlaying.ToArray()[0]);
        }

        if (nextSongs.Count > 0)
        {
            Console.WriteLine("Next song - " + nextSongs.ToArray()[0]);
        }
           

    }


}

optionGlobal = InitQueue();

doAction(optionGlobal);

while (exit == false) { 
    optionGlobal = chooseOption();

    doAction(optionGlobal);
}
