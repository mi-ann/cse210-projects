/* To Exceed requirements I added a scripture library with multiple scripture. 
I also added a play again function and restart function. 
I put some part of the code into a playgame function */
using System;


class Program
{
    private static bool endGame = false; // Changed to a boolean for clarity

    static void Main(string[] args)
    {
         // Initialize the scripture library
        
        while (!endGame) // Continue until endGame is true
        {
            PlayGame();
        }
    }
    static void PlayGame()
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
        var scripture = scriptureLibrary.GetRandomScripture(); // Get a random scripture
        DisplayScripture(scripture);
        HandleUserResponse(scripture);
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear(); // Clear the console for better readability
        Console.WriteLine(scripture.GetDisplayText()); // Display both the reference and text
        Console.WriteLine();
    }

    static void HandleUserResponse(Scripture scripture)
    {
        Console.Write("Press Enter to continue or type 'quit' to finish: ");
        string userResponse = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userResponse))
        {
            HandleWords(scripture); // Hide words in the scripture
        }
        else if (userResponse.Equals("quit", StringComparison.OrdinalIgnoreCase))
        {
            endGame = true; // Set endGame to true to exit the loop
        }
        else
        {
            Console.WriteLine("Invalid Response. Please try again.");
        }
    }

    // Mockup method to represent fetching ascripture

    static void HandleWords(Scripture scripture)
    {
        int numberToHide = 3; // Fixed number of words to hide
        // Check if all words are hidden
        if (scripture.AllWordsHidden())
        {
            
            Console.WriteLine("All words have been hidden!");
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine();

            if (playAgainResponse.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                endGame = false; // Reset endGame to allow playing again
            }
            else
            {
                endGame = true; // Set endGame to true to exit the loop
            }
        }
        else
        {
            scripture.HideRandomWords(numberToHide); // Hide the specified number of words
            DisplayScripture(scripture);
            HandleUserResponse(scripture);
        }
    }

    static void RestartGame()
    {
        Console.Write("Do you want to play again? (yes/no): ");
        string playAgainResponse = Console.ReadLine();

        if (playAgainResponse.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            Console.Clear();
            // Reset any necessary state (if needed)
            PlayGame(); // Start a new game
        }
        else
        {
            endGame = true; // Set endGame to true to exit the loop
        }
    }
}
