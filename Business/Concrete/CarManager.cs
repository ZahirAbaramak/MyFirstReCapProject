using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;   
        }

        public IResult Add(Car car)
        {

            if(car.Description.Length>2)
            {
                _carDal.Add(car);
              return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarNameInvalid);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedCar);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>();
            }


           return new SuccessDataResult<List<Car>>();
        }

        public IDataResult<Car> GetById(int id)
        {
           return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==id));
        }

        public IDataResult< List<CarDetailsDto>> GetCarDetails(CarDetailsDto carDetails)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.Details());
        }

        public IDataResult< List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c=>c.BrandId == id));
        }

        public IDataResult< List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c=>c.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
