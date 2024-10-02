

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        // Get the list of visible words (not hidden)
        var visibleWords = _words.Where(w => !w.IsWordHidden()).ToList();

        // Determine how many words to hide (limited by visible words count)
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        // Shuffle the visible words to select randomly
        var shuffledWords = visibleWords.OrderBy(w => Guid.NewGuid()).ToList();

        for (int i = 0; i < wordsToHide; i++)
        {
            shuffledWords[i].Hide(); // Hide the selected word
        }
    }


    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsWordHidden());
    }

    public string GetDisplayText()
    {
        // Combine the reference and the display text of the words
        return $"{_reference.GetDisplayString()}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }
}
