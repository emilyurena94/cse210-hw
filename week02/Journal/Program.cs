using System;
using System.Collections.Generic;
using System.IO;

// Hello there!! This is our Journal Program!
// This program lets you write journal entries using random prompts.
// You can save them, load them, and even search for words inside your journal.

// ===================== ENTRY CLASS =====================
// This class is like a box that keeps one journal entry inside it.
public class Entry
{
    //  These are the 3 parts of an entry:
    public string Date { get; set; }     // When the entry was written
    public string Prompt { get; set; }   // The question or topic to write about
    public string Response { get; set; } // What the user wrote (their answer)

    //  This is called a constructor.
    // It runs when we create a new entry, and it gives values to the three parts above.
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    //  This shows the entry nicely on the screen.
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine("------------------------------------");
    }

    //  This changes the entry into one line of text, so it can be saved in a file.
    public string ToFileString()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    //  This takes a line from a file and turns it back into an Entry again.
    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|'); // Split the line wherever it finds a "|"
        return new Entry(parts[0], parts[1], parts[2]);
    }
}

// ===================== JOURNAL  =====================
// This class holds all the entries together , like a notebook full of pages.
public class Journal
{
    // This is a list that keeps all the entries in memory.
    private List<Entry> entries = new List<Entry>();

    //  This adds a new entry to the list.
    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    //  This shows every entry the user has written.
    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
        }
        else
        {
            foreach (var entry in entries)
            {
                entry.Display(); // Show each one
            }
        }
    }

    //  This saves all entries to a text file on your computer.
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToFileString()); // Write each entry in a line
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    //  This loads entries from a text file, so you can see old writings again.
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return; // Stop if the file doesn’t exist
        }

        entries.Clear(); // Clean current entries before loading new ones
        string[] lines = File.ReadAllLines(filename); // Read every line in the file
        foreach (string line in lines)
        {
            entries.Add(Entry.FromFileString(line)); // Turn each line into an entry
        }
        Console.WriteLine($"Journal loaded from {filename}");
    }

    // NEW FEATURE: SEARCH
    // This helps find entries that contain a specific word.
    // we added this option, because we thought it would be useful for the user, if they want to find something specific in their journal.
    public void SearchEntries(string keyword)
    {
        bool found = false;
        foreach (var entry in entries)
        {
            // The ToLower() makes the search ignore uppercase/lowercase differences.
            if (entry.Response.ToLower().Contains(keyword.ToLower()) ||
                entry.Prompt.ToLower().Contains(keyword.ToLower()))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine($"No entries found containing \"{keyword}\".");
        }
    }
}

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

// ===================== MAIN PROGRAM =====================
// This is the "brain" of the whole app. It makes everything work together.
class Program
{
    static void Main(string[] args)
    {
        //  We make a new journal and a new prompt generator to use.
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool exit = false; // This keeps the program running until the user wants to quit.

        //  Main menu loop: runs until 'exit' becomes true.
        while (!exit)
        {
            //  Show the menu to the user
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("\nWelcome to your Journal! What would you like to do? tipe the number of your choice:");
            Console.WriteLine("1) Write a new entry");
            Console.WriteLine("2) Display journal entries");
            Console.WriteLine("3) Save journal to file");
            Console.WriteLine("4) Load journal from file");
            Console.WriteLine("5) Search entries"); // New option for searching that we added
            Console.WriteLine("6) Exit");
            Console.Write("Choose an option (1–6): ");

            //  Get the user’s choice
            string choice = Console.ReadLine();

            //  Use a switch to decide what to do depending on the number they chose.
            switch (choice)
            {
                case "1":
                    // 🖊️ Write a new entry
                    string prompt = promptGen.GetRandomPrompt(); // Get a random question
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine(); // Read what the user types
                    string date = DateTime.Now.ToShortDateString(); // Get today’s date

                    //  Make a new entry and add it to the journal
                    journal.AddEntry(new Entry(date, prompt, response));
                    Console.WriteLine("Entry added!");
                    break;

                case "2":
                    //  Show all entries
                    journal.DisplayEntries();
                    break;

                case "3":
                    //  Save to a file
                    Console.Write("Enter filename to save (example: journal.txt): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    // Load from a file
                    Console.Write("Enter filename to load (example: journal.txt): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    //  Search entries
                    Console.Write("Enter a word to search for: ");
                    string keyword = Console.ReadLine();
                    journal.SearchEntries(keyword);
                    break;

                case "6":
                    //  Exit program
                    exit = true;
                    Console.WriteLine("Goodbye! Thanks for writing today!");
                    break;

                default:
                    //  If user types something wrong
                    Console.WriteLine("That’s not a valid option. Try again!");
                    break;
            }
        }
    }
}
