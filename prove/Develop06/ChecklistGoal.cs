public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0; // Initialize amount completed to 0
        _target = target; 
        _bonus = bonus; 
    }
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted; // Initialize amount completed to 0
        _target = target; 
        _bonus = bonus; 
    }

    public override void RecordEvent(ref int score)
    {
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            _points += _bonus; // Award the bonus
        }
        score += _points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Override to provide specific details for ChecklistGoal
    public override string GetDetailsString()
    {
        return $"[{(_amountCompleted >= _target ? "X" : " ")}] {_shortName} ({_descirption}) -- Currently completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal: {_shortName}, {_descirption}, {_points}, {_bonus}, {_target}, {_amountCompleted} ";
    }
}
