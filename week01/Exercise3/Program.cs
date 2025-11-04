using System;

class Program
{
    static void Main()
    {
        Random randomGenerator = new Random();
        string otra = "yes";
        
        while (otra == "yes")
        {
            int number = randomGenerator.Next(1, 101);
            int guess = 0;
            int intentos = 0;

            Console.WriteLine("\nWelcome to the Number Guessing Game!\n");
            Console.WriteLine("\nGuess the number between 1 and 100!! Can you guess it?\n");

            while (true)
            {
                Console.Write("\nEnter your guess: 7");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                intentos++;

                if (guess < number)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You've guessed the number {number} in {intentos} attempts.");
                    break;
                }
            }
            Console.Write("Do you want to play again? (yes/no): ");
            otra = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Thank you for playing!");
    }
}
