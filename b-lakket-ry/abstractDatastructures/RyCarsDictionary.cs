using b_lakket_ry.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.abstractDatastructures
{
    /// <summary>
    /// Implementering der benytter Dictionary
    /// </summary>
    public class RyCarsDictionary : IRyCars
    {
        private Dictionary<int,Car> _cars;

        public RyCarsDictionary()
        {
            _cars= new Dictionary<int,Car>();
            foreach (var b in MockDataFactory.GetCars) 
            {
                _cars.Add(b.Id,b);
            }
        }




        /*
         * Implementerer interface
         */
        public Car FindCarById(int id)
        {
            if (!_cars.ContainsKey(id))
            {
                throw new KeyNotFoundException();
            }
            return _cars[id];
        }

        public Car FindCarByRegNo(string regNummer)
        {
            foreach (var car in _cars.Values)  // obs use values
            {
                if (car.RegistreringsNr == regNummer)
                {
                    return car;
                }
            }

            throw new KeyNotFoundException();
        }

        public Car FindNewestCar()
        {
            if (_cars.Count == 0)
            {
                throw new ArgumentException("no cars in collection");
            }
            return _cars.Last().Value;
        }

        public ICollection<Car> FindRedCars()
        {
            ICollection<Car> rødeBiler = new List<Car>();
            foreach (Car car in _cars.Values)    // obs use values
            {
                if (car.Farve.ToLower() == "rød")
                {
                    rødeBiler.Add(car);
                }
            }

            return rødeBiler;
        }

        public Car FindOldestCar()
        {
            if (_cars.Count == 0)
            {
                throw new ArgumentException("no cars in collection");
            }

            return _cars.First().Value;
        }

        public ICollection<Car> GetAllCars()
        {
            return new List<Car>(_cars.Values);  // obs use values
        }

        public void Add(Car car)
        {
            _cars.Add(car.Id,car); 
        }
    }
}
