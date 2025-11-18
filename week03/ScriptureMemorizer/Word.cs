using System;

public class Word
{
    // This stores the actual word from the scripture.
    private string _text;

    // This keeps track of whether the word is hidden or not.
    private bool _isHidden;

    // The constructor saves the word text and starts it as not hidden.
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // This method hides the word by changing the boolean.
    public void Hide()
    {
        _isHidden = true;
    }

    // This returns true or false depending on if the word is hidden.
    public bool IsHidden()
    {
        return _isHidden;
    }

    // This method returns either the real word (if shown)
    // or underscores with the same number of letters (if hidden).
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Creates a string of underscores the same length as the word
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
