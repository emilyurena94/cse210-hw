using System;
using System.Collections.Generic;
using System.IO;

// ===================== JOURNAL CLASS =====================
// This class holds all the entries together, like a notebook full of pages.
public class Journal
{
    // This is a list that keeps all the entries in memory.
    private List<Entry> entries = new List<Entry>();

    //  This adds a new entry to the list
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
