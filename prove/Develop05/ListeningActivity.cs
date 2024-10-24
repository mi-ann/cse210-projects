using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private bool isActive;

    public ListingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {   
        Random random = new Random();
        List<string> availablePrompts = new List<string>(prompts);
        // Get a random index from the available prompts
        int index = random.Next(availablePrompts.Count);
        string prompt = availablePrompts[index];

        // Display the prompt to the user
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
        ShowCountDown(4); // Give user time to think
        CancellationTokenSource cts = new CancellationTokenSource();
        List<string> responses = new List<string>();
        isActive = true;
        Console.WriteLine("Start listing! (Type 'done' when finished):");


        // Start the timer in a separate task
        Task.Run(() => StartTimer(cts));

        while (isActive == true)
        {   
            if (Console.KeyAvailable) // Check if a key is pressed
            {
                string response = Console.ReadLine();
                if (response.ToLower() == "done")
                {  
                    isActive = false;
                    break;
                }

                responses.Add(response);
            }

            if (cts.Token.IsCancellationRequested)
            {
                Console.WriteLine("\nTime is up!"); // Notify the user that time is up
                isActive = false;
                break;
            }

            
        }
        Console.WriteLine($"You listed {responses.Count} items.");
        DisplayEndingMessage();

        
        
    }

    private void StartTimer(CancellationTokenSource cts)
    {
        for (int i = _duration; i > 0; i--)
        {
            Thread.Sleep(1000); // Sleep for 1 second
        }

        // Signal cancellation when time is up
        cts.Cancel();
        isActive = false;

    }
}
