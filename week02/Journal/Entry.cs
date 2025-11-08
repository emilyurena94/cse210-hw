using System;

// ===================== ENTRY CLASS =====================
// This class is like a box that keeps one journal entry inside it.
public class Entry
{
    //  These are the 3 parts of an entry:
    public string Date { get; set; } // When the entry was written
    public string Prompt { get; set; }  // The question or topic to write about
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