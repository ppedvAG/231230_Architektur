using Autofac;
using ppedv.CarRent7000.Data.EfCore;
using ppedv.CarRent7000.Logic.Core;
using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.Model.DomainModel;
using System.Reflection;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Hello, World!");

//Dependency Injection per Code
//IRepository repo = new ppedv.CarRent7000.Data.EfCore.CarRentRepository();

//DI per Reflection
//var path = @"C:\Users\rulan\source\repos\ppedvAG\231230_Architektur\ppedv.CarRent7000\ppedv.CarRent7000.Data.EfCore\bin\Debug\net6.0\ppedv.CarRent7000.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = (IRepository)Activator.CreateInstance(typeMitRepo);

//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<CarRentRepository>().AsImplementedInterfaces();
var container = builder.Build();

var repo = container.Resolve<IRepository>();  

var rentService = new RentService(repo);

foreach (var car in repo.GetAll<Car>())
{
    Console.WriteLine($"{car.Manufacturer} {car.Model}");
    if (rentService.IsCarAvailable(car, DateTime.Now, DateTime.Now.AddDays(3)))
        Console.WriteLine("JO");
    else
        Console.WriteLine("NÖ");
}

