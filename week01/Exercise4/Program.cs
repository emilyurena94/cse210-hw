using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int num = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        
        while (num != 0)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine()!;
            num = int.Parse(input);

            if (num != 0) 
            {
                numbers.Add(num);
            }
        }

        // Calculate values
        int sum = numbers.Sum();
        double average = numbers.Average();
        int largest = numbers.Max();
        int smallestPositive = numbers.Where(n => n > 0).Min();

        // Sort the list
        numbers.Sort();

        // Display results
        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is:");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
