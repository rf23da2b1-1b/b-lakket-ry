using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using b_lakket_ry.model;

namespace b_lakket_ry.abstractDatastructures
{
    public class MockDataFactory
    {
        private static readonly IList<Car> _cars = new Collection<Car>()
        {
            new Car("rød", "AB12345", 345000),
            new Car("Grå", "AB54321", 245000),
            new Car("sort", "CD12345", 210000),
            new Car("lysegrå", "CD54321", 625300),
            new Car("sort", "KL12345", 280000),
            new Car("lysegrå", "KL54321", 750300),
            new Car("sort", "MN12345", 320000),
            new Car("lysegrå", "MN54321", 370300),
            new Car("rød", "EF12345", 217000),
            new Car("Grå", "EF54321", 270000),
            new Car("sort", "GH12345", 210000),
            new Car("lysegrå", "GH54321", 625300),
            new Car("rød", "IJ12345", 198000),
            new Car("Grå", "IJ54321", 240000),
            new Car("rød", "OP12345", 180000),
            new Car("Grå", "OP54321", 260000),
            new Car("sort", "QR12345", 285000)
        };
        
        public static ICollection<Car> GetCars { get { return new Collection<Car>(_cars);} }

    }
}
