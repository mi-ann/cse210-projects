/*I exceeded requirements by making sure that my prompts only are selected once per activity. 
For my reflection activty I added a feature to continue the program as long as there are unused prompts and a quit option 
while running the reflection activity even during the reflection period of questions.*/
using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
           DisplayMenu();
           HandleUserResponse();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflecting Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
        Console.Write("Select a choice from the menu: ");
    }
    static void HandleUserResponse()
    {
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            BreathingActivity activity = new BreathingActivity("Breathing", "This activity will help you focus on your breath.");
            HandleActivity((BreathingActivity) activity);
        }
        else if (choice == "2")
        {
            ReflectingActivity activity = new ReflectingActivity("Reflecting", "This activity will help you reflect on your experiences."); 
            HandleActivity((ReflectingActivity) activity);
        }
        else if (choice == "3")
        {
            ListingActivity activity = new ListingActivity("Listing", "This activity will help you list positive aspects of your life.");
            HandleActivity((ListingActivity) activity);
        }
        else if (choice == "4")
        {
            return; // Exit the program
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            return; // Prompt the user again
        }  
    }

    static void HandleActivity(BreathingActivity activity)
    {
        activity.DisplayStartingMessage();
        activity.SetDuration();
        activity.PrepareToBegin();
        activity.Run();
    }

    static void HandleActivity(ReflectingActivity activity)
    {
        activity.DisplayStartingMessage();
        activity.SetDuration();
        activity.PrepareToBegin();
        activity.Run();
    }

    static void HandleActivity(ListingActivity activity)
    {
        activity.DisplayStartingMessage();
        activity.SetDuration();
        activity.PrepareToBegin();
        activity.Run();
    }


}

