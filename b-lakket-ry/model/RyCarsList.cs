using b_lakket_ry.abstractDatastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.model
{
    /// <summary>
    /// Implementering der benytter List
    /// </summary>
    public class RyCarsList : IRyCars
    {
        private List<Car> _cars;

        public RyCarsList()
        {
            _cars = new List<Car>(MockDataFactory.GetCars);
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
            return _cars.Last();   // or
            //return _cars[_cars.Count - 1];

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
            return _cars.First();     // or
            //return _cars[0];
        }

        public ICollection<Car> GetAllCars()
        {
            return new List<Car>(_cars);
        }

        public void Add(Car bil)
        {
            try
            {
                FindCarById(bil.Id);
                throw new ArgumentException("Bil findes i forvejen");
            }
            catch(KeyNotFoundException knfe)
            {
                // findes ikke => altså indsættes
                _cars.Add(bil);
            }
        }
    }
}
