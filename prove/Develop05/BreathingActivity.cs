using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        int breathTime = 10; // Time for each breathing in or out
        DateTime currentBreathTime = DateTime.Now;
        DateTime endBreathTime = currentBreathTime.AddSeconds(_duration);
        while (DateTime.Now < endBreathTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(breathTime);

            Console.WriteLine("Breathe out...");
            ShowCountDown(breathTime);
            Console.WriteLine(" ");
        }

        // Final message after the activity ends
        DisplayEndingMessage();
         // Optionally show a spinner or pause before ending
    }
}
