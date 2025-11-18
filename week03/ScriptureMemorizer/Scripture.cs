using System;
using System.Collections.Generic;

public class Scripture
{
    // This stores the reference (book, chapter, verses).
    private Reference _reference;

    // This list stores every Word object in the scripture text.
    private List<Word> _words;

    // This constructor takes the reference and the text.
    // It splits the text into words and creates Word objects for each one.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into individual words and convert each one into a Word object.
        string[] splitWords = text.Split(" ");
        foreach (string word in splitWords)
        {
            _words.Add(new Word(word));
        }
    }

    // This hides a certain number of random words.
    // It will ONLY hide words that are not already hidden.
    // This is one of the stretch requirements.
    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();

        // Create a list of words that are not hidden yet.
        List<Word> availableWords = _words.FindAll(w => !w.IsHidden());

        // The loop only hides as many words as are available.
        int limit = Math.Min(numberToHide, availableWords.Count);

        for (int i = 0; i < limit; i++)
        {
            // Pick a random word from the ones still visible.
            int index = rand.Next(availableWords.Count);

            // Hide the chosen word.
            availableWords[index].Hide();

            // Remove it so we don't hide it again in this round.
            availableWords.RemoveAt(index);
        }
    }

    // This returns the scripture reference and the words (hidden or not).
    public string GetDisplayText()
    {
        // First show the reference
        string result = _reference.GetDisplayText() + "\n\n";

        // Then show every word separated by spaces.
        foreach (Word w in _words)
        {
            result += w.GetDisplayText() + " ";
        }

        return result.TrimEnd();
    }

    // This checks if every word is hidden.
    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false; // At least one word is still showing
            }
        }

        return true; // All words hidden
    }
}
