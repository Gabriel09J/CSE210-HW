using System;

// Abstract class representing a Shape
abstract class Shape
{
    // Abstract method to calculate area
    public abstract double CalculateArea();
}

// Concrete subclass representing a Circle
class Circle : Shape
{
    private double radius;

    // Constructor
    public Circle(double radius)
    {
        this.radius = radius;
    }

    // Override abstract method to calculate area
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

// Concrete subclass representing a Square
class Square : Shape
{
    private double sideLength;

    // Constructor
    public Square(double sideLength)
    {
        this.sideLength = sideLength;
    }

    // Override abstract method to calculate area
    public override double CalculateArea()
    {
        return sideLength * sideLength;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating objects of Circle and Square
        Circle circle = new Circle(5);
        Square square = new Square(4);

        // Displaying area of Circle
        Console.WriteLine("Area of Circle: " + circle.CalculateArea());

        // Displaying area of Square
        Console.WriteLine("Area of Square: " + square.CalculateArea());
    }
}