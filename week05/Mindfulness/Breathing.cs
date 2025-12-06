using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing.\nFocus on your breath.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int cycles = _duration / 8;

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            TimerCountdown(4);

            Console.WriteLine("Now breathe out...");
            TimerCountdown(4);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
