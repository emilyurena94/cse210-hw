using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration = 0;

    public Activity(string name, string description)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
        _description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!\n");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");

        // Validación de entrada
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }

        Console.Clear();
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done! You completed the {_name} Activity.");
        Console.WriteLine($"Duration: {_duration} seconds.");
        Console.WriteLine("Returning to menu...");
        PauseAnimation();
    }

    public void PauseAnimation()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write("...");
            Thread.Sleep(600);
        }
        Console.WriteLine();
    }

    public void TimerCountdown(int seconds)
    {
        while (seconds > 0)
        {
            Console.Write(seconds);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            seconds--;
        }
    }
}
