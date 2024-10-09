public class Video
{
    public string _title;
    public string _author;
    public double _length;

    public List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, double length)
    {
        _title = title;
        _author = author;
        _length = length;
    }  

    public void Display()
    {
        Console.WriteLine($"Title: {_title}, Author: {_author}, Length: {_length} seconds");
    }

    public void addComment(string name, string text)
        {
            var comment = new Comment(name, text);
            _comments.Add(comment);
        }

    // Method to get the number of comments
    public int commentAmount()
    {
        return _comments.Count;
    }

    // Optional: Method to display all comments
    public void displayComments()
    {
        foreach (var comment in _comments)
        {
            Console.WriteLine($" {comment._name}: {comment._text}");
        }
    }
}