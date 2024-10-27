public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _pointsToNextLevel;
    private int _diamonds;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1; // Start at level 1
        _pointsToNextLevel = 500; // Points needed to level up
        _diamonds = 0;

    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine(" ");
            Console.WriteLine("Menu options: ");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

    }

    public void DisplayPlayerInfo()
    {
        int pointsToNextLevel = _level * _pointsToNextLevel; // Assuming _pointsToNextLevel is defined
        int pointsNeeded = pointsToNextLevel - _score;

        Console.WriteLine($"You have {_score} points");
        Console.WriteLine($"Current Level: {_level}");
        Console.WriteLine($"Diamonds: {_diamonds}");
        Console.WriteLine($"pointsbar: {_score}/{pointsToNextLevel}");
        Console.WriteLine($"Points needed for next level: {pointsNeeded} out of {pointsToNextLevel}");
    }


    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        int index = 1; // Start index at 1 for user-friendly display
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetGoalName()}");
            index++; // Increment index for each goal
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();

        string name = "";
        string description = "";
        int points = 0;

        switch (goalType)
        {
            case "1":
                HandleGoalInfo(ref name, ref description, ref points);
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                HandleGoalInfo(ref name, ref description, ref points);
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                HandleGoalInfo(ref name, ref description, ref points);
                Console.WriteLine("Enter target number of completions:");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points for completion:");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

    }
    public void RecordEvent()
    {

        ListGoalNames();
        Console.WriteLine("Type in the goal number.");
        Console.Write("Which goal did you accomplish? ");

        int index = int.Parse(Console.ReadLine());
        if (index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");

            return;
        }

        Goal selectedGoal = _goals[index - 1];
        selectedGoal.RecordEvent(ref _score); // Pass the score by reference
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (_score >= _level * _pointsToNextLevel)
        {
            _level++;
            _score -= _pointsToNextLevel;
            Console.WriteLine($"Congratulations! You've leveled up to level {_level}!");
            AwardDiamonds();
        }
    }

    private void AwardDiamonds()
    {
        int diamondsGained = 10; // Set the number of diamonds to award
        _diamonds += diamondsGained; // Increase diamond count
        Console.WriteLine($"You've received {diamondsGained} diamonds as a reward!"); // Inform the player
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            string[] firstLine = reader.ReadLine().Split(',');
            _score = int.Parse(firstLine[0].Trim());
            _level = int.Parse(firstLine[1].Trim());
            _diamonds = int.Parse(firstLine[2].Trim());
            _goals.Clear();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                if (parts.Length < 2) continue; // Skip invalid lines

                string goalType = parts[0].Trim();
                string goalData = parts[1].Trim();
                string[] goalInfo = goalData.Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        if (goalInfo.Length == 4)
                        {
                            string name = goalInfo[0].Trim();
                            string description = goalInfo[1].Trim();
                            int points = int.Parse(goalInfo[2].Trim());
                            bool isComplete = bool.Parse(goalInfo[3].Trim());
                            SimpleGoal simpleGoal = new SimpleGoal(name, description, points, isComplete);
                            _goals.Add(simpleGoal);
                        }
                        break;
                    case "EternalGoal":
                        if (goalInfo.Length == 3)
                        {
                            string name = goalInfo[0].Trim();
                            string description = goalInfo[1].Trim();
                            int points = int.Parse(goalInfo[2].Trim());
                            _goals.Add(new EternalGoal(name, description, points));
                        }
                        break;
                    case "ChecklistGoal":
                        if (goalInfo.Length == 6)
                        {
                            string name = goalInfo[0].Trim();
                            string description = goalInfo[1].Trim();
                            int points = int.Parse(goalInfo[2].Trim());
                            int bonus = int.Parse(goalInfo[3].Trim());
                            int target = int.Parse(goalInfo[4].Trim());
                            int amountCompleted = int.Parse(goalInfo[5].Trim());
                            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                            _goals.Add(checklistGoal);
                        }
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type: {goalType}");
                        break;
                }
            }
        }
        Console.WriteLine("Goals loaded.");
        Console.WriteLine($"Score: {_score}, Level: {_level}, Diamonds: {_diamonds}");
    }


    public void HandleGoalInfo(ref string name, ref string description, ref int points)
    {
        Console.WriteLine("Enter goal name:");
        name = Console.ReadLine();
        Console.WriteLine("Enter goal description:");
        description = Console.ReadLine();
        Console.WriteLine("Enter points for the goal:");
        points = int.Parse(Console.ReadLine());
    }
}
