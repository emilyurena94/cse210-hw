using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List the people you appreciate.",
        "List things that make you smile.",
        "List things you are grateful for today."
    };

    public ListingActivity()
        : base("Listing", "In this activity, you will list as many items as you can related to a prompt.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine(prompt);
        Console.WriteLine("You can start in:");
        TimerCountdown(5);

        List<string> items = new List<string>();
        int endTime = Environment.TickCount + (_duration * 1000);

        while (Environment.TickCount < endTime)
        {
            Console.Write("→ ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
            items.Add(Console.ReadLine());
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
        DisplayEndingMessage();
    }
}
