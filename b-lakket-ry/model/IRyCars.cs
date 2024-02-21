using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.model
{
    public interface IRyCars
    {
        public ICollection<Car> GetAllCars();
        public void Add(Car car);
        public ICollection<Car> FindRedCars();
        public Car FindCarById(int id);
        public Car FindCarByRegNo(string regNummer);
        public Car FindOldestCar();
        public Car FindNewestCar();
    }
}
