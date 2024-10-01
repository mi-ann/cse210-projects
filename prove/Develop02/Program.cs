/* To exceed reuirements I added a login and register feature. This way a user can login with their password to their journal.
 For this i created two additional classes and a users.txt file that saves all registered users*/
 
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        UserManager userManager = new UserManager();
        
        while (true)
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Quit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Register new user
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                
                if (userManager.Register(username, password))
                {
                    Console.WriteLine("Registration successful!");
                }
                else
                {
                    Console.WriteLine("Username already taken. Try again.");
                    continue; // Skip to the next iteration
                }
            }
            else if (choice == "2")
            {
                // User login
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                User user = userManager.Authenticate(username, password);
                if (user != null)
                {
                    Console.WriteLine("Login successful!");
                    StartJournal(userManager); // Proceed to journal functionalities
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                    continue; // Skip to the next iteration
                }
            }
            else if (choice == "3")
            {
                break; // Exit the program
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static void StartJournal(UserManager userManager)
    {
        string homepage = "yes";
        Journal journal = new Journal(); // Create the Journal instance
        
        while (homepage == "yes")
        {
            DisplayMenu();
            string response = GetUserResponse();

            if (response == "1")
            {
                WriteNewEntry(journal);
            }
            else if (response == "2")
            {
                journal.DisplayAll(); // Display all entries
            }
            else if (response == "3")
            {
                Console.Write("Enter filename to load: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile); // Load entries from a file
            }
            else if (response == "4")
            {
                Console.Write("Enter filename to save: ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile); // Save entries to a file
            }
            else if (response == "5")
            {
                homepage = "no"; // Exit the loop
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Journal Program!");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display all entries");
        Console.WriteLine("3. Load entries from a file");
        Console.WriteLine("4. Save entries to a file");
        Console.WriteLine("5. Quit");
    }

    static string GetUserResponse()
    {
        Console.Write("What would you like to do? ");
        return Console.ReadLine();
    }

    static void WriteNewEntry(Journal journal) // Corrected parameter type
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        // Create a new entry
        Entry entry = new Entry()
        {
            _promtText = prompt,
            _entryText = response,
            _date = date
        };

        journal.AddEntry(entry); // Add the entry to the journal
        Console.WriteLine("Entry saved successfully!\n");
    }
}
