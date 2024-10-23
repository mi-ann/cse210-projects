using System;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square("pink", 4);
        Console.WriteLine(square1.GetColor());
        Console.WriteLine(square1.GetArea());

        Rectangle rectangle1 = new Rectangle("purple", 4,5);
        Console.WriteLine(rectangle1.GetColor());
        Console.WriteLine(rectangle1.GetArea());

        Circle circle1 = new Circle("blue", 4);
        Console.WriteLine(circle1.GetColor());
        Console.WriteLine(circle1.GetArea());

        List<Shape> _shapes = new List<Shape>();
        _shapes.Add(square1);
        _shapes.Add(rectangle1);
        _shapes.Add(circle1);

        foreach (Shape shape in _shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine(color);
            Console.WriteLine(area);
        }
    }
}