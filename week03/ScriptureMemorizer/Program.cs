using System;

class Program
{
    static void Main(string[] args)
    {
        // In this program I am creating a scripture memorizer.
        // The scripture starts normal, and every time I press ENTER
        // the program hides a few random words until everything is hidden.

        // Here I create a Reference object. I used a scripture with two verses,
        // so I am using the constructor that accepts a verse range.
        Reference reference = new Reference("Alma", 5, 12, 13);

        // This is the scripture text that will be memorized.
        string text = "And according to his faith  there was a might change wrought in his heart. Behold i say unto you that this is all true. And behold, he preached the word unto your fathers, and a might change we also wrought in their hearts, and they humbled themselves and put their trust in the truth and living God. And behold, they they were faithful until the end; Therefore they were saved.";

        // Here I create the Scripture object using the reference and the text.
        Scripture scripture = new Scripture(reference, text);

        // This loop keeps running until the user types "quit"
        // or until all the words are hidden.
        while (true)
        {
            Console.Clear(); // Clears the console every time before showing the scripture
            Console.WriteLine(scripture.GetDisplayText()); // Shows the scripture on the screen

            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            // If the user types quit, the program ends
            if (input.ToLower() == "quit")
                break;

            // This hides three random words that are not hidden yet.
            // This part is one of the stretch requirements.
            scripture.HideRandomWords(3);

            // If everything is already hidden, the program ends here.
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program finished.");
                break;
            }
        }
    }
}
