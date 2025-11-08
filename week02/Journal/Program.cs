using System;

// Hello there!! This is our Journal Program!
// This program lets you write journal entries using random prompts.
// You can save them, load them, and even search for words inside your journal.

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
            Console.WriteLine("\nWelcome to your Journal! What would you like to do?");
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
                // Write a new entry
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
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    // Load from a file
                    Console.Write("Enter filename to load: ");
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
