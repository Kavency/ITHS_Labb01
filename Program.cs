﻿while (true)
{
    List<string> listOfColoredNumbers = new();
    long totalSum = 0;
    int startInnerLoopAt = 0;

    PrintHeader();
    Console.WriteLine("Enter a string or press enter for a default string.");
    Console.CursorVisible = true;
    string userInput = GetUserInput("Enter a string: ");
    PrintDivider(userInput.Length);

    //
    // Iterate through the string to find numbers starting and ending
    // with the same digit.
    //
    for (int i = 0; i < userInput.Length; i++)
    {
        char charToCompareWith = userInput[i];
        string numbersToCheck = string.Empty;

        for (int j = startInnerLoopAt; j < userInput.Length; j++)
        {
            if (char.IsDigit(userInput[j]))
            {
                numbersToCheck += userInput[j];

                if (charToCompareWith == userInput[j] && numbersToCheck.Length > 1)
                {
                    listOfColoredNumbers.Add(numbersToCheck);
                    break;
                }
            }
            else
                break;
        }
        startInnerLoopAt++;
    }

    //
    // Display the result to the user
    //
    if (listOfColoredNumbers.Count > 0)
    {
        foreach (string item in listOfColoredNumbers)
        {
            totalSum += long.Parse(item);

            string[] splitUserInputStrings = userInput.Split(item);

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(splitUserInputStrings[0]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(item);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(splitUserInputStrings[1]);
            Console.WriteLine();
            Thread.Sleep(110);
        }
    }
    else
    {
        Console.Write("No duplicate numbers found in string: ");
        Console.WriteLine(userInput);
    }

    PrintDivider(userInput.Length);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"Total amount = {totalSum}");
    PrintDivider(userInput.Length);
    Console.WriteLine();
    
    Console.WriteLine("Press any key to run again, press Esc to exit.");
    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
    keyPressed.ToString();

    if (keyPressed.Key == ConsoleKey.Escape)
        break;
}


//
// Methods
//
static string GetUserInput(string prompt)
{
    Console.Write(prompt);
    string input = Console.ReadLine();

    if (input == string.Empty)
        return "29535123p48723487597645723645";

    return input;
}

static void PrintHeader()
{
    Console.Clear();
    Console.WriteLine("********* Labb 01 *********");
    Console.WriteLine("* .NET24 - Magnus Hellman *");
    Console.WriteLine("***************************");
    Console.WriteLine();
}

static void PrintDivider(int lengthOfDivider = 10)
{
    Console.ForegroundColor = ConsoleColor.Gray;

    for(int i = 0; i < lengthOfDivider; i++)
    {
        Console.Write('-');
    }

    Console.WriteLine();
}
