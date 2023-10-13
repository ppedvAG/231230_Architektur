using ppedv.CarRent7000.Logic.Core;
using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.Model.DomainModel;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Hello, World!");

IRepository repo = new ppedv.CarRent7000.Data.EfCore.CarRentRepository();
var rentService = new RentService(repo);

foreach (var car in repo.GetAll<Car>())
{
    Console.WriteLine($"{car.Manufacturer} {car.Model}");
    if (rentService.IsCarAvailable(car, DateTime.Now, DateTime.Now.AddDays(3)))
        Console.WriteLine("JO");
    else
        Console.WriteLine("NÖ");
}

