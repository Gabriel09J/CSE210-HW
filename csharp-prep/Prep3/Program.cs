using System;

class Program
{
    static void Main()
    {
        // Step 1: Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = Convert.ToInt32(Console.ReadLine());

        // Step 2: Loop until the user guesses the magic number
        while (true)
        {
            // Ask the user for a guess
            Console.Write("What is your guess? ");
            int userGuess = Convert.ToInt32(Console.ReadLine());

            // Check if the guess is correct
            if (userGuess == magicNumber)
            {
                Console.WriteLine("You guessed it!");
                break; // Exit the loop if the guess is correct
            }
            else if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        }
    }
}
