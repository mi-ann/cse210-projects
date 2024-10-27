public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) 
    {
    }

    // An eternal goal does not change its completion status, so we leave this empty.
    public override void RecordEvent(ref int score)
    {
        score += _points;   // Update the score directly
        Console.WriteLine($"Goal completed! You earned {_points} points.");
    }

    // Eternal goals are never complete, so this always returns false.
    public override bool IsComplete()
    {
        return false; // Eternal goals cannot be completed.
    }

    // This method provides a string representation of the goal.
    public override string GetStringRepresentation()
    {
        return $"EternalGoal: {_shortName}, {_descirption}, {_points}";
    }
}
