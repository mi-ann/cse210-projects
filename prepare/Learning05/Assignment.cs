public class Assignment
{
    protected string _studentName;
    protected string _topic;
    
    public Assignment(string studentName , string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string getSummary()
    {
        return $"student: {_studentName}, topic: {_topic}";
    }
}