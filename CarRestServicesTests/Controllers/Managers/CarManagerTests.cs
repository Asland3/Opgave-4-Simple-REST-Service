using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRESTServices.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRESTServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRESTServices.Managers.Tests
{
    [TestClass()]
    public class CarManagerTests
    {

        private CarManager _carManager;


        /*public CarManagerTests(CarManager carManager)
        {
            _carManager = carManager;
        }*/

        [TestInitialize]
        public void SetUp()
        {
            _carManager = new CarManager();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsNotNull(_carManager.GetAll(null, null, null));

            List<Car> cars = _carManager.GetAll(null, null, null);
            foreach (var car in cars)
            {
                /*Assert.IsTrue(_carManager = car);*/
            }

        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_carManager.GetByID(1));
            Assert.IsNull(_carManager.GetByID(0));

            Assert.AreEqual("Toyota Avensis", _carManager.GetByID(1).Model);
            Assert.AreEqual(500000, _carManager.GetByID(1).Price);
            Assert.AreEqual("BK75590", _carManager.GetByID(1).LicensePlate);
            
        }

        [TestMethod()]
        public void AddCarTest()
        {
            var car = new Car()
            {
                Model = "Test", 
                Price = 100,
                LicensePlate = "test2"
            };

            /*var createdResponse = _carManager.Post(car) as CreatedAtActionResult;*/
        }

        [TestMethod()]
        public void DeleteTest()
        {
            throw new NotImplementedException();
        }
    }
}