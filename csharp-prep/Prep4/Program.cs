using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        string stop = "no";
        while (stop == "no")
        {
            Console.Write("Enter numbers: ");
            string answer = Console.ReadLine();
            int add_number = int.Parse(answer);
            if (add_number != 0)
                {
                numbers.Add(add_number);
                }
            else {
                int sum = 0;
                int largest_number = 0;
                int smallest_positive_number = 0;
                foreach (int number in numbers )
                    {
                        sum += number;
                        
                        if (largest_number < number)
                            {largest_number = number;}
                        
                        
                        if (smallest_positive_number == 0)
                            {
                                smallest_positive_number = number;
                            }
                        else
                        {
                            if(number < smallest_positive_number && number > 0)
                                {
                                    smallest_positive_number = number;
                                }
                        }
        
                    }
                 Console.WriteLine($"The sum is: {sum}");
                int number_amount= numbers.Count; 
                if (number_amount > 0)
                    {
                    double average = (double)sum / number_amount;
                    Console.WriteLine($"The average is: {average}");
                    }
                else
                    {
                    Console.WriteLine("No numbers were entered.");
                    }
                Console.WriteLine($"The largest number is: {largest_number}");
                Console.WriteLine($"The smallest positive number is: {smallest_positive_number}");
                numbers.Sort(); 
                Console.WriteLine("The sorted list is:");
                foreach (int number in numbers)
                {
                    Console.WriteLine(number);
                    
                }
                stop = "yes"; 
                }
               
            
        
        }
        
    }
}