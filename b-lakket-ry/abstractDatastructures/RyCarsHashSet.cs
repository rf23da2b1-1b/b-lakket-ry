using b_lakket_ry.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.abstractDatastructures
{
    /// <summary>
    /// Implementering der benytter HashSet
    /// </summary>
    public class RyCarsHashSet : IRyCars
    {
        private HashSet<Car> _cars;

        public RyCarsHashSet()
        {
            _cars = new HashSet<Car>(MockDataFactory.GetCars);
        }




        /*
         * Implementerer interface
         */
        public Car FindCarById(int id)
        {
            foreach (var car in _cars)
            {
                if (car.Id == id)
                {
                    return car;
                }
            }
            throw new KeyNotFoundException();
        }

        public Car FindCarByRegNo(string regNummer)
        {
            foreach (var car in _cars)
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
            return _cars.Last();
        }

        public ICollection<Car> FindRedCars()
        {
            ICollection<Car> redCars = new List<Car>();
            foreach (Car car in _cars)
            {
                if (car.Farve.ToLower() == "rød")
                {
                    redCars.Add(car);
                }
            }

            return redCars;
        }

        public Car FindOldestCar()
        {
            if (_cars.Count == 0)
            {
                throw new ArgumentException("no cars in collection");
            }

            return _cars.First();
        }

        public ICollection<Car> GetAllCars()
        {
            return new List<Car>(_cars);
        }

        public void Add(Car car)
        {
            _cars.Add(car); // hashset ensures no dublecates
        }

    }
}
