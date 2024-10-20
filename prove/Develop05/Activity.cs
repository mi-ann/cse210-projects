using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected List<string> _animationStrings;

    
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _animationStrings = new List<string>
        {
            "|",
            "/",
            "-",
            "\\",
            "|",
            "/",
            "-",
            "\\"
        };
    }

    public void DisplayStartingMessage()
    { 
        Console.WriteLine($"Welcome to the {_name} activity");
        Console.WriteLine(" ");
        Console.WriteLine(_description);
        Console.WriteLine(" ");
    }

    public void SetDuration()
    {
        Console.Write("Please enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void PrepareToBegin()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        Console.WriteLine(" ");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"Great job! You completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--) // Include 0 in the countdown
        {
            // Convert the current number to a string
            string number = i.ToString();
            
            // Print the current number
            Console.Write(number); 
            Thread.Sleep(1000); // Wait for 1 second
            
            // Determine how many backspaces to perform
            int length = number.Length;

            // Use backspace to overwrite the printed number
            for (int j = 0; j < length; j++)
            {
                Console.Write("\b \b"); // Backspace and overwrite with space
            }
        }
    }


    public void ShowSpinner(int seconds)
    {   
        DateTime currentTime = DateTime.Now;
        DateTime spinTime = currentTime.AddSeconds(seconds);
        int i = 0;
        while(DateTime.Now < spinTime)
        {
            string s = _animationStrings[i];
            Console.Write(s); 
            Thread.Sleep(1000); // Wait for 1 second
            Console.Write("\b \b"); // Backspace and overwrite with space
            i++;
            if( i>= _animationStrings.Count)
            {
                i = 0;
            }
        }
    }
}
