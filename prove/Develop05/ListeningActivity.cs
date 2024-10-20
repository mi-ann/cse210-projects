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

        DateTime currentListenTime = DateTime.Now;
        DateTime endListenTime = currentListenTime.AddSeconds(_duration);
        while (DateTime.Now < endListenTime)
        {
            string response = Console.ReadLine();
            if (response.ToLower() == "done")
                break;
            responses.Add(response);
            currentListenTime = DateTime.Now;
        }

        Console.WriteLine($"You listed {responses.Count} items.");
        DisplayEndingMessage();
        
    }
}
