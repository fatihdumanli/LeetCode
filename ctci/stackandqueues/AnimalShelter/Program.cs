using System;
using System.Collections.Generic;

namespace AnimalShelterNs
{
    public class Animal
    {
        public string Name;
        public int Order;

        public Animal(string name)
        {
            this.Name = name;
        }
    }

    public class Dog : Animal 
    {
        public Dog(string name) : base(name)
        {
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) {}
    }
    
    
    public class AnimalShelter
    {
        private LinkedList<Cat> _cats = new LinkedList<Cat>();
        private LinkedList<Dog> _dogs = new LinkedList<Dog>();
        private int order = 0;
        
        public Animal DequeueAny()
        {
            if (_dogs.Count == 0 && _cats.Count == 0)
                throw new InvalidOperationException($"There's no animal");

            if (_dogs.Count == 0)
                return DequeueCat();

            if (_cats.Count == 0)
                return DequeueDog();

            if (_dogs.First.Value.Order < _cats.First.Value.Order)
                return DequeueDog();

            return DequeueCat();
        }
        
        public Dog DequeueDog()
        {
            if (_dogs.Count == 0)
                throw new InvalidOperationException($"There's no dog!");

            var oldestDog = _dogs.First;
            _dogs.RemoveFirst();
            return oldestDog.Value;
        }

        public Cat DequeueCat()
        {
            if (_cats.Count == 0)
                throw new InvalidOperationException($"There's no cat!");

            var oldestCat = _cats.First;
            _cats.RemoveFirst();
            return oldestCat.Value;
        }
        
        
        
        public void Enqueue(Animal animal)
        {
            animal.Order = ++order;
            if (animal is Dog dog)
                _dogs.AddLast(dog);
            else if (animal is Cat cat)
                _cats.AddLast(cat);
        }
        

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var animalShelter = new AnimalShelter();
            animalShelter.Enqueue(new Dog("dog1"));
            animalShelter.Enqueue(new Dog("dog2"));
            animalShelter.Enqueue(new Dog("dog3"));
            animalShelter.Enqueue(new Dog("dog4"));

            var oldestDog = animalShelter.DequeueDog();
            oldestDog = animalShelter.DequeueDog();
            oldestDog = animalShelter.DequeueDog();
            oldestDog = animalShelter.DequeueDog();
            oldestDog = animalShelter.DequeueDog();
        }
    }
}
