using b_lakket_ry.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.abstractDatastructures
{
    /// <summary>
    /// Implementering der benytter Stack
    /// </summary>
    public class RyCarsStack : IRyCars
    {
        private Stack<Car> _cars;

        public RyCarsStack()
        {
            _cars = new Stack<Car>(MockDataFactory.GetCars);
        }




        /*
         * Implementerer interface
         */
        public Car FindCarById(int id)
        {
            /*
             * Not really meaning of a stack to look inside the stack
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
             * Not really meaning of a stack to look inside the stack
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
            return _cars.Peek();  // look at the top
        }

        public ICollection<Car> FindRedCars()
        {
            /*
             * Not really meaning of a stack to look inside the stack
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
             * Not really meaning of a stack to look at the buttom of the stack
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
                _cars.Push(car);
            }
        }
    }
}
