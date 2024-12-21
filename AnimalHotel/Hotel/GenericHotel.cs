using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class GenericHotel<T> : IEnumerable<T> where T : IAnimal
{
    private int _count = 0;
    private int _capacity = 4;
    private T[] _animals = new T[4];

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

    public void AddAnimal(T animal)
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

    public IEnumerable<T> GetAnimalsByOwnerName(string ownerName)
    {
        return _animals.Where(a => a != null && a is IAnimal animal && ((dynamic)animal).Owner.Name == ownerName);
    }

    public IEnumerable<T> SortAnimalsByAge()
    {
        return _animals.Where(a => a != null).OrderBy(a => a.Age);
    }

    public T this[int index]
    {
        get => _animals[index];
        set => _animals[index] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}