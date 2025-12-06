using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you helped someone in need.",
        "Think of a moment where you overcame something difficult.",
        "Recall a time you showed kindness."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this moment meaningful?",
        "How did this experience help you grow?",
        "What did you learn about yourself?"
    };

    public ReflectionActivity()
        : base("Reflection", "This activity guides you to reflect on meaningful moments in your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("Think about this...");
        PauseAnimation();

        int interval = _duration / _questions.Count;

        foreach (var question in _questions)
        {
            Console.WriteLine("\n" + question);
            TimerCountdown(interval);
        }

        DisplayEndingMessage();
    }
}
