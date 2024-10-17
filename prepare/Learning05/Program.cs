using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.getSummary());
        Console.WriteLine(" ");

        
        MathAssignment mathAssignment1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment1.getSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());
        Console.WriteLine(" ");

        WritingAssignment writingAssignment1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment1.getSummary());
        Console.WriteLine(writingAssignment1.GetWritingInformation());
    }
}