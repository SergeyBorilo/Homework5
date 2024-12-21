using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class KyivHotel : IEnumerable<IAnimal>
{
    private int _count = 0;
    private int _capacity = 4;
    private IAnimal[] _animals = new IAnimal[4];
    
    public void FeedAnimals()
    {
        foreach (var animal in _animals.Where(a => a != null))
        {
            animal.Eat();
        }
    }
    
    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals.Where(a => a != null))
        {
            animal.Sleep();
        }
    }
    
    public void AddAnimal(IAnimal animal)
    {
        if (_count == _capacity)
        {
            _capacity *= 2;
            Array.Resize(ref _animals, _capacity);
        }
        
        _animals[_count++] = animal;
    }
    
    public void PrintAnimals()
    {
        foreach (var animal in _animals.Where(a => a != null))
        {
            Console.WriteLine(animal.Name);
        }
    }
    
    public IEnumerable<IAnimal> GetAnimalsByOwnerName(string ownerName)
    {
        return _animals.Where(a => a != null && a is IAnimal animal && ((dynamic)animal).Owner.Name == ownerName);
    }

    public IEnumerable<IAnimal> SortAnimalsByAge()
    {
        return _animals.Where(a => a != null).OrderBy(a => a.Age);
    }
    
    public IAnimal this[int index]
    {
        get => _animals[index];
        set => _animals[index] = value;
    }
    
    public IEnumerator<IAnimal> GetEnumerator()
    {
        for(var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}