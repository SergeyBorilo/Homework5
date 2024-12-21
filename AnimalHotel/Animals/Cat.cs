namespace AnimalHotel.Animals;

public class Cat : IAnimal, IComparable<Cat>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string[] Color { get; set; }
    public Owner Owner { get; private set; }

    private Cat(string name, int age, string[] color, Owner owner)
    {
        Name = name;
        Age = age;
        Color = color;
        Owner = owner;
    }
    
    public void Meow()
    {
        Console.WriteLine($"{nameof(Cat)} is meowing");
    }
    
    public override void Eat()
    {
        Console.WriteLine($"{nameof(Cat)} is eating");
    }

    public override void Sleep()
    {
        Console.WriteLine($"{nameof(Cat)} is sleeping");
    }
    
    public static Cat CreateCat(string name, int age, string[] color, Owner owner)
    {
        return new Cat(name, age, color, owner);
    }

    public int CompareTo(Cat? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}