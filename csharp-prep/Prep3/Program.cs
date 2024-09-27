using System;

class Program
{
    static void Main(string[] args)
    {
        string response; 
        
        do
        {
            /* Console.Write("What is the magic number? ");
            string answer = Console.ReadLine();
            int magic_number = int.Parse(answer); */

            Random randomGenerator = new Random();
            int magic_number = randomGenerator.Next(1, 101);
            int guess_count = 0;
            string correct = "no";
            while (correct == "no")
            {
                Console.Write("What is your guess? ");
                guess_count++;
                string answer_2 = Console.ReadLine();
                int guess = int.Parse(answer_2);
                
                if (guess < magic_number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magic_number) 
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    correct = "yes";
                }
               Console.WriteLine($"You've guessed {guess_count} times");
            }

            Console.Write("Do you want to continue? ");
            response = Console.ReadLine();
        } while (response == "yes");
    }
}
