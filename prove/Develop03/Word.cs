public class Word
{
    // Represents a single word in the scripture
    private string Text; // The text of the word
    private bool IsHidden; // Indicates if the word is hidden

    public Word(string text)
    {
        Text = text;
        IsHidden = false; // Initialize IsHidden to false
    }

    public void Hide()
    {
        IsHidden = true; // Set IsHidden to true
    }

    public void Show()
    {
        IsHidden = false; // Set IsHidden to false
    }

    // Method to check if the word is hidden
    public bool IsWordHidden() // Changed method name
    {
        return IsHidden; // Return the status of IsHidden
    }

    // Method to get the display text of the word
    public string GetDisplayText()
    {
        return IsHidden ? "_____" : Text; // Return "_____" if hidden, else the word
    }
}
