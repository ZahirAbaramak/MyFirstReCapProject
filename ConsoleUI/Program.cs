
using Business.Concrete;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;

CarManager carManager = new CarManager(new EfCarDal());
foreach (var  car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}

