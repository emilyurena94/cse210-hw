using System;
using System.Threading;

class Program
{
    static void Main()
    {
        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Started!");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Choose an activity (just the number) : ");
            string choice = Console.ReadLine();

            if (choice == "4")
            {
                Console.WriteLine("Exiting...");
                exit = true;
                continue;
            }

            // Preguntar duración solo si no eligió salir
            int duration = 0;
            while (true)
            {
                Console.Write("Enter duration in seconds: ");
                if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
                    break;
                Console.WriteLine("Please enter a valid positive number.");
            }

            switch (choice)
            {
                case "1":
                    breathing.Run(duration);
                    break;
                case "2":
                    reflection.Run(duration);
                    break;
                case "3":
                    listing.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
