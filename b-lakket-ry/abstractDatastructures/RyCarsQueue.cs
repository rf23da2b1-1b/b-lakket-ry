using b_lakket_ry.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.abstractDatastructures
{
    /// <summary>
    /// Implementering der benytter Queue
    /// </summary>
    public class RyCarsQueue : IRyCars
    {
        private Queue<Car> _cars;

        public RyCarsQueue()
        {
            _cars = new Queue<Car>(MockDataFactory.GetCars);
        }




        /*
         * Implementerer interface
         */
        public Car FindCarById(int id)
        {
            /*
             * Not really meaning of a queue to look inside the stack
             */
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
            /*
             * Not really meaning of a queue to look inside the stack
             */
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
            /*
             * Not really meaning of a queue to look inside the stack
             */
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

            /*
             * Not really meaning of a queue to look at the beginíng of the queue
             */
            return _cars.First();
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
                _cars.Enqueue(car);
            }
        }
    }
}
