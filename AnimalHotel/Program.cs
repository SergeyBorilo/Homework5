// create abstract factory to create animals

using AnimalHotel;
using AnimalHotel.Animals;
using AnimalHotel.Hotel;


internal class Program
{
    public static void Main(string[] args)
    {
        var animalNames = new string[] { "Dog", "Cat", "Parrot", "Horse" };
        var ownerNames = new string[] { "John", "Jane", "Jack", "Jill" };
        var ownerPhoneNumbers = new string[] { "1234567890", "0987654321", "6789054321", "1234509876" };
        var colorNames = new string[] { "Brown", "Black", "White", "Gray" };


        var random = new Random();
        var cats = new GenericHotel<Cat>();
        var genericHotel = new GenericHotel<IAnimal>();
        var kyivHotel = new KyivHotel();
        var romashkaHotel = new RomashkaHotel();
        
        
        for (int i = 0; i < 10; i++)
        {
            var animalName = animalNames[random.Next(animalNames.Length)];
            var ownerName = ownerNames[random.Next(maxValue: ownerNames.Length)];
            var ownerPhoneNumber = ownerPhoneNumbers[random.Next(ownerPhoneNumbers.Length)];
            var animalType = random.Next(2);
            int ownerAge = random.Next(20, 60);
            var colorName = colorNames[random.Next(colorNames.Length)];
    
            var owner = new Owner(ownerName, ownerPhoneNumber,ownerAge);

            IAnimal animal = animalType switch
            {
                0 => Dog.CreateDog(animalName,ownerAge, colorNames, owner),
                1 => Cat.CreateCat(animalName,ownerAge, colorNames, owner),
                _ => throw new ArgumentException("Invalid animal type"),
            };
            
            genericHotel.AddAnimal(animal);
            //genericHotel.AddAnimal(oldSchool);
            kyivHotel.AddAnimal(animal);
            //kyivHotel.AddAnimal(oldSchool);
            romashkaHotel.AddAnimal(animal);
            //romashkaHotel.AddAnimal(oldSchool);
        }
        
        Console.WriteLine("All anymals");
        genericHotel.PrintAnimals();
        
        Console.WriteLine("All anymals");
        romashkaHotel.PrintAnimals();
        
        Console.WriteLine("All anymals");
        kyivHotel.PrintAnimals();
        
        Console.WriteLine("\nAnimals sorted by age:");
        foreach (var animal in genericHotel.SortAnimalsByAge())
        {
            Console.WriteLine($"{animal.Name}, Age: {animal.Age}");
        }
        
        Console.WriteLine("\nAnimals sorted by age:");
        foreach (var animal in kyivHotel.SortAnimalsByAge())
        {
            Console.WriteLine($"{animal.Name}, Age: {animal.Age}");
        }
        
        Console.WriteLine("\nAnimals sorted by age:");
        foreach (var animal in romashkaHotel.SortAnimalsByAge())
        {
            Console.WriteLine($"{(animal as IAnimal).Name}, Age: {(animal as IAnimal).Age}");
        }
        
        Console.WriteLine("\nEnter owner name to filter animals:");
        var ownerFilter = Console.ReadLine();
        var filteredAnimals = genericHotel.GetAnimalsByOwnerName(ownerFilter);
        
        Console.WriteLine($"\nAnimals owned by {ownerFilter}:");
        foreach (var animal in filteredAnimals)
        {
            Console.WriteLine(animal.Name);
        }

        foreach (var animal in genericHotel)
        {
            Console.WriteLine(animal.Name);
            animal.Eat();
        }

        foreach (var animal in kyivHotel)
        {
            Console.WriteLine(animal.Name);
            animal.Sleep();
        }

        foreach (var animal in romashkaHotel)
        {
            Console.WriteLine((animal as IAnimal).Name);
        }


// TODO: get all animals with name 'Parrot' from genericHotel
        var genericHotelParrots = genericHotel.Where(x => x.Name == "Parrot");

// TODO: get all animals with name 'Parrot' from kyivHotel
        var kyivHotelParrots = kyivHotel.Where(x => x.Name == "Parrot");

// TODO: get all animals with name 'Parrot' from romashkaHotel
        var romashkaHotelParrots = romashkaHotel.OfType<Cat>();
    }
    
}

// TODO: extend animals entity to have a property 'Age' and sort animals by age