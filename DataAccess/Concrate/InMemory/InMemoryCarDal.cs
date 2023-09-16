using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                 new Car{ Id = 1,ColorId = 1,BrandId=1,DailyPrice=100000,ModelYear=2021,Description="Hızlı"},
                 new Car{ Id = 2,ColorId = 2,BrandId=1,DailyPrice=200000,ModelYear=2022,Description="Rahat"},
                 new Car{ Id = 3,ColorId = 2,BrandId=2,DailyPrice=400000,ModelYear=2020,Description="Jip"},
                 new Car{ Id = 4,ColorId = 3,BrandId=2,DailyPrice=400000,ModelYear=2023,Description="Teknolik"},
                 new Car{ Id = 5,ColorId = 3,BrandId=3,DailyPrice=200000,ModelYear=1972,Description="Klasik"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);
           _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.Id==id).ToList();
        }

        public void Update(Car car)
        {
           Car carToUpdate = _cars.SingleOrDefault(c=> c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
