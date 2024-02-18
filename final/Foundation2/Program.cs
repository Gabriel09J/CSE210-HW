using System;

// Class representing an Employee with encapsulated fields
class Employee
{
    // Private fields
    private string name;
    private int age;
    private double salary;

    // Properties to encapsulate fields
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set 
        { 
            if (value >= 18 && value <= 100)
            {
                age = value; 
            }
            else
            {
                Console.WriteLine("Invalid age. Age should be between 18 and 100.");
            }
        }
    }

    public double Salary
    {
        get { return salary; }
        set 
        { 
            if (value >= 0)
            {
                salary = value; 
            }
            else
            {
                Console.WriteLine("Invalid salary. Salary should be non-negative.");
            }
        }
    }

    // Method to display employee information
    public void DisplayInfo()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Salary: $" + Salary);
    }

    // Method to increase employee age
    public void IncreaseAge()
    {
        Age++;
    }

    // Method to increase employee salary
    public void IncreaseSalary(double amount)
    {
        if (amount >= 0)
        {
            Salary += amount;
            Console.WriteLine("Salary increased by $" + amount);
        }
        else
        {
            Console.WriteLine("Invalid amount. Salary increase amount should be non-negative.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating an object of Employee
        Employee emp = new Employee();

        // Setting employee information using properties
        emp.Name = "John Doe";
        emp.Age = 30;
        emp.Salary = 50000.0;

        // Displaying employee information
        emp.DisplayInfo();

        // Increasing employee age and salary
        emp.IncreaseAge();
        emp.IncreaseSalary(2000.0);

        // Displaying updated employee information
        emp.DisplayInfo();
    }
}