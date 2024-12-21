namespace AnimalHotel.Animals;

public class Dog : IAnimal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string[] Color { get; set; }

    public Owner Owner { get; private set; }

    private Dog(string name, int age, string[] color, Owner owner)
    {
        Name = name;
        Age = age;
        Color = color;
        Owner = owner;
    }

    public void Bark()
    {
        Console.WriteLine($"{nameof(Dog)} is barking");
    }


    public override void Eat()
    {
        Console.WriteLine($"{nameof(Dog)} is eating");
    }

    public override void Sleep()
    {
        Console.WriteLine($"{nameof(Dog)} is sleeping");
    }

    public static Dog CreateDog(string name, int age, string[] color, Owner owner)
    {
        return new Dog(name, age, color, owner);
    }
    
}

