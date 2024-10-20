using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        Random random = new Random();

        // Create a copy of the prompts to avoid modifying the original list
        List<string> availablePrompts = new List<string>(prompts);
        List<string> availableQuestions = new List<string>(questions);

        while(availablePrompts.Count > 0)
        {
                // Get a random index from the available prompts
            int index = random.Next(availablePrompts.Count);
            string prompt = availablePrompts[index];

            // Display the prompt to the user
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine(prompt);
            // Ask the user to press Enter to continue
            // Ask the user to press Enter to continue or Space to quit
            Console.WriteLine("Press Enter when you are ready to continue or Space to quit...");
            while (true) 
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    break; // Continue to the next step
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("You chose to quit. Exiting the activity.");
                    return; // Exit the Run method
                }
                
                // You can add more key checks if needed
            }
            // Provide a pause before moving on to questions
            ShowCountDown(3); // Give user a moment to prepare

            DateTime currentReflectTime = DateTime.Now;
            DateTime endReflectTime = currentReflectTime.AddSeconds(_duration);
            while (DateTime.Now < endReflectTime)
            {
                if (availableQuestions.Count == 0)
                {
                    // Refill availableQuestions if empty
                    availableQuestions = new List<string>(questions);
                    Console.WriteLine("All questions have been used. Refill the questions.");
                }

                // Get a random question
                int questionIndex = random.Next(availableQuestions.Count);
                string question = availableQuestions[questionIndex];
                Console.WriteLine(question);
                // Create a cancellation token for the reflection time
                var cts = new CancellationTokenSource();
                var task = Task.Run(() => ShowSpinner(10), cts.Token);
                
                // Wait for user input to quit
                while (!task.IsCompleted)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Spacebar)
                        {
                            Console.WriteLine("You chose to quit. Exiting the activity.");
                            return; // Exit the Run method
                        }
                    }
                    Thread.Sleep(100); // Small delay to prevent tight looping
                }
                // Remove the used question from the list
                availableQuestions.RemoveAt(questionIndex);
            }

            DisplayEndingMessage();

            // Remove the used prompt from the list
            availablePrompts.RemoveAt(index);
        }
    }
}
