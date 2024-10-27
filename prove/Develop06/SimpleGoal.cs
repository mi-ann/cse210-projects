public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points) 
    {
        _isComplete = false; // Initialize as incomplete
    }
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete; // Set completion status
    }

    public override void RecordEvent(ref int score)
    {
        if (!_isComplete)
        {
            _isComplete = true; // Mark as complete
            score += _points;   // Update the score directly
            Console.WriteLine($"Goal completed! You earned {_points} points.");
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete; // Return completion status
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal: {_shortName}, {_descirption}, {_points}, {_isComplete}";
    }
}