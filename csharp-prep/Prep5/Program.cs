using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        string user_name = PromptUserName();
        int favorite_number = PromptUserNumber();
        int number_squared = SquareNumber(favorite_number);
        DisplayResult(user_name, number_squared);
        
    }

     /* DisplayWelcome - Displays the message, "Welcome to the Program!" */
    static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        
    /* PromptUserName - Asks for and returns the user's name (as a string) */
    static string PromptUserName()
        {
            Console.Write("User Name: ");
            string user_name = Console.ReadLine();
            return user_name;
        }

    /*  PromptUserNumber - Asks for and returns the user's favorite number (as an integer) */
    static int PromptUserNumber()
        {
            Console.Write("favorite number: ");
            int favorite_number = int.Parse(Console.ReadLine());
            return favorite_number;
        }

    /* SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer) */
    static int SquareNumber(int favorite_number)
        {
            int number_squared = favorite_number * favorite_number;
            return number_squared;
        }

    /* DisplayResult - Accepts the user's name and the squared number and displays them.  */
    static void DisplayResult(string user_name, int number_squared)
        {
            Console.WriteLine($"{user_name}, the square of your number is {number_squared}");
        }
}