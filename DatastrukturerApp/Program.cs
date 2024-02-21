// See https://aka.ms/new-console-template for more information

using b_lakket_ry.abstractDatastructures;
using b_lakket_ry.model;

IRyCars carCatalog = new RyCarsOldFashionArray();


Console.WriteLine("Alle Biler");
ICollection<Car> cars = carCatalog.GetAllCars();
foreach (Car car in cars)
{
    Console.WriteLine(car);
}

Console.Write("Add bil: ");
try
{
    Car car1 = new Car("Lilla","AB34567",231300);
    Console.WriteLine(car1);
    carCatalog.Add(car1);
    Console.WriteLine("prøver igen");
    carCatalog.Add(car1);
}catch(ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}

Console.WriteLine("Alle røde biler");
ICollection<Car> redCars = carCatalog.FindRedCars();
foreach(Car car in redCars)
{
    Console.WriteLine(car);
}

Console.WriteLine("bil med id = 2 hhv 1234");
try
{
    Car foundCar = carCatalog.FindCarById(2);
    Console.WriteLine(foundCar);
    foundCar = carCatalog.FindCarById(1234);
}catch(KeyNotFoundException knfe)
{
    Console.WriteLine(knfe.Message);
}

Console.WriteLine("bil med reg nummer = AB34567 hhv aaaabbbb");
try
{
    Car foundCar = carCatalog.FindCarByRegNo("AB34567");
    Console.WriteLine(foundCar);
    foundCar = carCatalog.FindCarByRegNo("aaaabbbb");
}
catch (KeyNotFoundException knfe)
{
    Console.WriteLine(knfe.Message);
}


Console.WriteLine("bil ældst");
try
{
    Car foundCar = carCatalog.FindOldestCar();
    Console.WriteLine(foundCar);
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}

Console.WriteLine("bil nyeste");
try
{
    Car foundCar = carCatalog.FindNewestCar();
    Console.WriteLine(foundCar);
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}




