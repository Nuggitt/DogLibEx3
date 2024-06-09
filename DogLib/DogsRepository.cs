using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogLib
{
    public class DogsRepository
    {
        private int _nextId = 4;

        private List<Dog> _dogs = new List<Dog>()
        {
            new Dog { Id = 1, Name = "Fido", Age = 5 },
            new Dog { Id = 2, Name = "Fjumse", Age = 2 },
            new Dog { Id = 3, Name = "Fisen", Age = 4 }

        };

        public IEnumerable<Dog> GetAll()
        {
            return new List<Dog>(_dogs);
        }

        public Dog? GetById(int id)
        {
            return _dogs.FirstOrDefault(d => d.Id == id);
        }

        public Dog Add(Dog dog)
        {
            dog.Id = _nextId++;
            _dogs.Add(dog);
            return dog;
        }

        public Dog? Delete(int id)
        {
            Dog? dog = GetById(id);
            if (dog != null)
            {
                _dogs.Remove(dog);
            }
            return dog;
        }


    }
}
