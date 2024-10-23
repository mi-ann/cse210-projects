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
             // Check if we are still within the allowed time
            if (DateTime.Now >= endBreathTime)
                break;

            Console.WriteLine("Breathe in...");
            var tokenSource = new CancellationTokenSource();
            var task = Task.Run(() => ShowCountDown(breathTime), tokenSource.Token);

            // Allow time to breathe in before checking again
            while (!task.IsCompleted)
            {
                if (DateTime.Now >= endBreathTime)
                {
                    tokenSource.Cancel();
                    Console.Write("\b \b"); // Cancel the countdown if the time is up
                    break;
                }
                Thread.Sleep(100); // Small delay to prevent tight looping
            }

            // Breathe out phase
            Console.WriteLine("Breathe out...");
            tokenSource = new CancellationTokenSource();
            task = Task.Run(() => ShowCountDown(breathTime), tokenSource.Token);

            // Allow time to breathe out before checking again
            while (!task.IsCompleted)
            {
                if (DateTime.Now >= endBreathTime)
                {
                    tokenSource.Cancel();
                    Console.Write("\b \b"); // Cancel the countdown if the time is up
                    break;
                }
                Thread.Sleep(100); // Small delay to prevent tight looping
            }

            Console.WriteLine(" ");
        }

        // Final message after the activity ends
        DisplayEndingMessage();
         // Optionally show a spinner or pause before ending
    }
}
