using System;

class Program
{
    static void Main(string[] args)
    {
        string letter_grade = "";
        Console.Write("What's your grade percentage? ");
        string grade_percentage = Console.ReadLine();
        int grade_percentage_number = int.Parse(grade_percentage);
        int last_digit = grade_percentage_number % 10;

        
        if (grade_percentage_number >= 90){
            letter_grade = "A";
        }
        else if (grade_percentage_number >= 80)
        {
            letter_grade = "B";
        }
        else if (grade_percentage_number >= 70)
        {
            letter_grade = "C";
        }
        else if (grade_percentage_number >= 60)
        {
            letter_grade = "D";
        }
        else if (grade_percentage_number < 60 &&  grade_percentage_number >=  0)
        {
            letter_grade = "F";
        }
        else
        {
        Console.WriteLine("Invalid input.");
        }

        if (letter_grade == "F")
        {Console.WriteLine($"Your letter grade is {letter_grade}.");}
        else if (last_digit >= 7 && letter_grade != "A")
        {Console.WriteLine($"Your letter grade is {letter_grade}+.");}
        else if (last_digit < 3)
        {Console.WriteLine($"Your letter grade is {letter_grade}-.");}
        else
        {Console.WriteLine($"Your letter grade is {letter_grade}.");}


        if (grade_percentage_number >= 70){
            Console.WriteLine("You've passed the class. Congratulations.");
        }
        else{ Console.WriteLine("You didn't pass the class. Better luck next time!");}
    }
}