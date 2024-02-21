using System;

// Base class representing an Animal
abstract class Animal
{
    public abstract void MakeSound();
}

// Derived class representing a Dog
class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

// Derived class representing a Cat
class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}

// Derived class representing a Bird
class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bird chirps");
    }
}

// Class representing a Zoo
class Zoo
{
    private Animal[] animals;

    // Constructor
    public Zoo(int capacity)
    {
        animals = new Animal[capacity];
    }

    // Method to add an animal to the zoo
    public void AddAnimal(Animal animal, int index)
    {
        if (index >= 0 && index < animals.Length)
        {
            animals[index] = animal;
        }
        else
        {
            Console.WriteLine("Invalid index. Animal not added to the zoo.");
        }
    }

    // Method to make all animals in the zoo make sound
    public void MakeAllSounds()
    {
        Console.WriteLine("Animals in the zoo are making sounds:");
        foreach (Animal animal in animals)
        {
            if (animal != null)
            {
                animal.MakeSound();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a zoo with a capacity of 3
        Zoo zoo = new Zoo(3);

        // Adding animals to the zoo
        zoo.AddAnimal(new Dog(), 0);
        zoo.AddAnimal(new Cat(), 1);
        zoo.AddAnimal(new Bird(), 2);

        // Making all animals in the zoo make sound
        zoo.MakeAllSounds();
    }
}