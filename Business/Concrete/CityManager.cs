using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult(Messages.CityDeleted);
        }

        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.CityDeleted);
        }

        public IDataResult<City> GetById(int cityId)
        {
            return new SuccessDataResult<City>(_cityDal.Get(p => p.Id == cityId));
        }

        public IDataResult<List<City>> GetList()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetList().ToList());
        }
        
        public IDataResult<List<City>> GetListByCity(int countryId)
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetList(p => p.CountryId == countryId).ToList());
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(Messages.CityUpdated);
        }
    }
}
