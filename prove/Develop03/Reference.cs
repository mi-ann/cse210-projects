// Represents the scripture reference
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0;
    }

    // Constructor for a range of verses
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayString()
    {
         // Check if _endVerse is zero, indicating a single verse
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}"; // Display single verse
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}"; // Display range of verses
        }
    }
}