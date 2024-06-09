using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DogLib.Tests
{
    [TestClass()]
    public class DogRepositoryTests
    {
        private DogsRepository _dogRepository = new DogsRepository();

        [TestMethod()]
        public void GetAllTest()
        {
            List<Dog> dogs = _dogRepository.GetAll().ToList();
            Assert.AreEqual(3, dogs.Count);
            Assert.AreEqual("Fido", dogs[0].Name);

            var dogsWithF = dogs.Where(d => d.Name.StartsWith("F"));
            Assert.AreEqual(3, dogsWithF.Count());

            var dogsWithAgeOver3 = dogs.Where(d => d.Age > 3);
            Assert.AreEqual(2, dogsWithAgeOver3.Count());

        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Dog? dog = _dogRepository.GetById(2);
            Assert.IsNotNull(dog);
            Assert.AreEqual("Fjumse", dog.Name);

        }

        [TestMethod()]
        public void AddTest()
        {
            _dogRepository.Add(new Dog { Name = "Futte", Age = 7 });
            List<Dog> dogs = _dogRepository.GetAll().ToList();
            Assert.AreEqual(4, dogs.Count);
            Assert.AreEqual("Futte", dogs[3].Name);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _dogRepository.Delete(2);
            List<Dog> dogs = _dogRepository.GetAll().ToList();
            Assert.AreEqual(2, dogs.Count);
            Assert.IsNull(_dogRepository.GetById(2));
        }
    }
}