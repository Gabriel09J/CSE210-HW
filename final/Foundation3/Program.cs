using System;

// Base class representing a Vehicle
class Vehicle
{
    protected string brand;
    protected string model;
    protected int year;

    // Constructor
    public Vehicle(string brand, string model, int year)
    {
        this.brand = brand;
        this.model = model;
        this.year = year;
    }

    // Method to display vehicle information
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Brand: " + brand);
        Console.WriteLine("Model: " + model);
        Console.WriteLine("Year: " + year);
    }
}

// Derived class representing a Car
class Car : Vehicle
{
    private int numberOfDoors;

    // Constructor
    public Car(string brand, string model, int year, int numberOfDoors) : base(brand, model, year)
    {
        this.numberOfDoors = numberOfDoors;
    }

    // Method to display car information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Number of Doors: " + numberOfDoors);
    }

    // Method to honk the car horn
    public void HonkHorn()
    {
        Console.WriteLine("Honk! Honk!");
    }
}

// Derived class representing a Truck
class Truck : Vehicle
{
    private double payloadCapacity;

    // Constructor
    public Truck(string brand, string model, int year, double payloadCapacity) : base(brand, model, year)
    {
        this.payloadCapacity = payloadCapacity;
    }

    // Method to display truck information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Payload Capacity: " + payloadCapacity + " tons");
    }

    // Method to load cargo into the truck
    public void LoadCargo(double weight)
    {
        Console.WriteLine("Loading " + weight + " tons of cargo into the truck.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating objects of Car and Truck
        Car car = new Car("Toyota", "Corolla", 2022, 4);
        Truck truck = new Truck("Ford", "F-150", 2020, 2.5);

        // Displaying vehicle information
        Console.WriteLine("Car Information:");
        car.DisplayInfo();
        car.HonkHorn(); // Honking the car horn
        Console.WriteLine("\nTruck Information:");
        truck.DisplayInfo();
        truck.LoadCargo(1.5); // Loading cargo into the truck
    }
}