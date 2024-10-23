using System;
using System.Collections.Generic;
using System.Threading;

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

        List<string> responses = new List<string>();
        Console.WriteLine("Start listing! (Type 'done' when finished):");
        CancellationTokenSource cts = new CancellationTokenSource();
        DateTime endListenTime = DateTime.Now.AddSeconds(_duration);

        // Start a task to manage the timing
        Task.Run(() =>
        {
            Thread.Sleep(_duration * 1000); // Wait for the duration
            cts.Cancel(); // Cancel the input
        });

        while (true)
        {
            // Check if time is up
            if (DateTime.Now >= endListenTime)
            {
                Console.WriteLine("Time is up!");
                break;
            }

            // Check if cancellation has been requested
            if (cts.Token.IsCancellationRequested)
            {
                Console.WriteLine("Time is up!");
                break;
            }

            string response = Console.ReadLine();
            if (response.ToLower() == "done")
                break;

            responses.Add(response);
        }

        Console.WriteLine($"You listed {responses.Count} items.");
        DisplayEndingMessage();
        
    }
}
