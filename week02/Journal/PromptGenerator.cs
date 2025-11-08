using System;
using System.Collections.Generic;

// ===================== PROMPT GENERATOR =====================
// This class has a list of fun questions to help you write something new.
public class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What did I learn today?",
        "What am I grateful for today?",
        "How did I overcome a challenge today?",
        "What made you smile today?",
        "What challenge did you face today and how did you handle it?",
        "Who did you spend time with today?",
        "What is something you learned today?",
        "How did you take care of yourself today?",
        "What is one goal you want to achieve this week?",
        "What are you grateful for right now?",
        "What song or movie matched your mood today?",
        "If you could redo one thing from today, what would it be?",
        "What made you proud of yourself today?"
    };

    //  Random helps us pick a different question every time.
    private Random random = new Random();

    //  This chooses and gives one random prompt to the user.
    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}