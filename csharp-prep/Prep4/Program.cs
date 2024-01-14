using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to store numbers
        List<int> numbers = new List<int>();

        // Ask the user for a series of numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            // Stop when the user enters 0
            if (userInput == 0)
                break;

            // Append the number to the list
            numbers.Add(userInput);
        }

        // Core Requirement 1: Compute the sum of the numbers
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Core Requirement 2: Compute the average of the numbers
        double average = (double)sum / numbers.Count;

        // Core Requirement 3: Find the maximum number in the list
        int maxNumber = numbers.Count > 0 ? numbers[0] : 0;
        foreach (int num in numbers)
        {
            if (num > maxNumber)
                maxNumber = num;
        }

        // Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");
    }
}
