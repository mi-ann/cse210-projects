public abstract class Goal
{
    protected string _shortName;
    protected int _points;
    protected string _descirption;

    protected Goal(string name, string descirption, int points)
    {
        _shortName = name;
        _points = points;
        _descirption = descirption;
    }

    public abstract void RecordEvent(ref int score);
    public abstract bool IsComplete();

    // Base implementation that can be overridden
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]"; // Use the IsComplete method
        return $"{status} {_shortName} ({_descirption}) ";
    }

    public abstract string GetStringRepresentation();
    public string GetGoalName(){
        return _shortName;
    }
}
