using System;

namespace _04_OOP;

// Public class
public class Animal
{
    // Public - accessible from anywhere
    public string Name = "Dog";

    // Private - only inside this class
    private int Age = 5;

    // Protected - accessible inside this class and derived classes
    protected string Color = "Brown";

    // Internal - accessible anywhere in the same project
    internal string Breed = "Labrador";

    // Method to show private member
    public void ShowAge()
    {
        Console.WriteLine("Age: " + Age);
    }
}

// Child class
public class Dog : Animal
{
    public void ShowProtected()
    {
        // Can access protected member
        Console.WriteLine("Color: " + Color);
    }

    public void ShowInternal()
    {
        // Can access internal member
        Console.WriteLine("Breed: " + Breed);
    }
}

internal class Program
{
    public static class AccessModifierDemo
    {
        public static void Run()
        {
            Animal animal = new Animal();

            Console.WriteLine("Name: " + animal.Name);
            Console.WriteLine("Breed: " + animal.Breed);

            animal.ShowAge();

            Dog dog = new Dog();
            dog.ShowProtected();
            dog.ShowInternal();
        }
    }
}