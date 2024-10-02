/*  Create a class to hold fraction.
    The class should be in its own file.*/
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
public class Fraction
{
    /*  The class should have two attributes for the top and bottom numbers.
        Make sure the attributes are private. */
    private int _top;
    private int _bottom;
    /*  Create the following constructors:
        Constructor that has no parameters that initializes the number to 1/1.*/
    public Fraction()
    {
        _top = 1; 
        _bottom = 1;
    }
    /*    Constructor that has one parameter for the top and that initializes the denominator to 1. 
        So that if you pass in the number 5, the fraction would be initialized to 5/1.*/
    public Fraction(int WholeNumber)
    {
        _top = WholeNumber; 
        _bottom = 1;
    }
    /*    Constructor that has two parameters, one for the top and one for the bottom.
        In your Program.cs file, verify that you can create fractions using all three of these constructors. For example,
        create an instance for 1/1 (using the first constructor), for 6/1 (using the second constructor),
        for 6/7 (using the third constructor). */
    public Fraction(int top, int bottom)
    {
        _top = top; 
        _bottom = bottom;
    }

    /* Create getters and setters for both the top and the bottom values.
    In your Program.cs file, verify that you can call all of these methods and get the correct values, 
    using setters to change the values and then getters to retrieve these new values and then display them to the console.
     */

     public int GetTop()
     {
        return _top;
     }

    public void SetTop(int top)
     {
        _top = top;
     }

     public int GetBottom()
     {
        return _bottom;
     }

     public void SetBottom(int bottom)
     {
        _bottom = bottom;
     }
     
    /* Create a method called GetFractionString that returns the fraction in the form 3/4.
    Create a method called GetDecimalValue that returns a double that is the result of dividing the top number by the bottom number,
    such as 0.75.
    Verify that you can call each constructor and that you can retrieve and display the different representations 
    for a few different fractions. For example, you could try:
    1
    5
    3/4
    1/3 */

    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }
    
     public double GetDecimalValue()
    {
        return (double) _top/ (double) _bottom;
    }
     

}


