namespace AnimalHotel.Animals;

public abstract class IAnimal
{

    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }

    public abstract void Eat();
    public abstract void Sleep();
}