using System;
using System.Collections.Generic;
using System.Linq;
using CarRESTServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRESTServices.Managers
{
    public class CarManager
    {
        private static int nextID = 1;
        private static List<Car> data = new List<Car>()
        {
            new Car() {Id = nextID++, Model = "Toyota Avensis", Price = 500000, LicensePlate = "BK75590"},
            new Car() {Id = nextID++, Model = "Toyota Yaris", Price = 300000, LicensePlate = "BK75591" },
            new Car() {Id = nextID++, Model = "Toyota Corolla", Price = 400000, LicensePlate = "BK75592"},
            new Car() {Id = nextID++, Model = "Toyota Camry", Price = 600000, LicensePlate = "BK75593"}

        };


        public List<Car> GetAll(string? modelFilter, int? priceFilter, string? licensePlateFilter)
        {
            List<Car> result = new List<Car>(data);
            if (!string.IsNullOrWhiteSpace(modelFilter))
            {
                result = result.FindAll(filterCar =>
                    filterCar.Model.Contains(modelFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (priceFilter != null)
            {
                result = result.FindAll(filterCar => filterCar.Price <= priceFilter);
            }

            if (!string.IsNullOrWhiteSpace(licensePlateFilter))
            {
                result = result.FindAll(filterCar =>
                    filterCar.LicensePlate.Contains(licensePlateFilter, StringComparison.OrdinalIgnoreCase));
            }


            return result;

        }

        public Car GetByID(int ID)
        {
            return data.Find(car => car.Id == ID);
        }

        public Car AddCar(Car newCar)
        {
            newCar.Id = nextID++;
            data.Add(newCar);
            return newCar;
        }

        public Car Delete(int id)
        {
            Car car = data.Find(car => car.Id == id);
            if (car == null) return null;
            data.Remove(car);
            return car;
        }


    }
}

