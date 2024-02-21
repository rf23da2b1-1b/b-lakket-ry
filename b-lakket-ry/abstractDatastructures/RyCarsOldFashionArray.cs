using b_lakket_ry.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.abstractDatastructures
{
    public class RyCarsOldFashionArray : IRyCars
    {
        private Car[] _cars;
        private int _nextCar = 0;

        public RyCarsOldFashionArray()
        {
            _cars = new Car[20];
            foreach (Car c in MockDataFactory.GetCars)
            {
                _cars[_nextCar++] = c;
            }
        }





        /*
         * Implementerer interface
         */
        public Car FindCarById(int id)
        {
            for (int i = 0; i < _nextCar; i++)
            {
                if (_cars[i].Id == id)
                {
                    return _cars[i];
                }
            }

            throw new KeyNotFoundException();
        }

        public Car FindCarByRegNo(string regNummer)
        {
            for (int i = 0; i < _nextCar; i++)
            {
                if (_cars[i].RegistreringsNr == regNummer)
                {
                    return _cars[i];
                }
            }

            throw new KeyNotFoundException();
        }

        public Car FindNewestCar()
        {
            if (_cars.Length == 0)
            {
                throw new ArgumentException("no cars in collection");
            }
            return _cars[_nextCar-1];

        }

        public ICollection<Car> FindRedCars()
        {
            ICollection<Car> redCars = new List<Car>();
            for (int i = 0; i < _nextCar; i++)
            {
                if (_cars[i].Farve.ToLower() == "rød")
                {
                    redCars.Add(_cars[i]);
                }
            }

            return redCars;
        }

        public Car FindOldestCar()
        {
            if (_nextCar == 0)
            {
                throw new ArgumentException("no cars in collection");
            }
            return _cars[0];
        }

        public ICollection<Car> GetAllCars()
        {
            return new List<Car>(_cars);
        }

        public void Add(Car car)
        {
            try
            {
                FindCarById(car.Id);
                throw new ArgumentException("Bil findes i forvejen");
            }
            catch (KeyNotFoundException knfe)
            {
                // findes ikke => altså indsættes
                _cars[_nextCar++] = car;
            }
        }
    }
}
