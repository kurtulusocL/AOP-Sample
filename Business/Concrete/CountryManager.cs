using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        [SecuredOperation("Product.List,Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IResult Add(Country country)
        {
            IResult result = BusinessRules.Run(CheckIfCountryNameExists(country.Name)/*, CheckIfCounryIsEnabled()*/);

            if (result != null)
            {
                return result;
            }
            _countryDal.Add(country);
            return new SuccessResult(Messages.CountryAdded);
        }

        [SecuredOperation("Product.List,Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult(Messages.CountryDeleted);
        }

        public IDataResult<Country> GetById(int countryId)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(p => p.Id == countryId));
        }

        public IDataResult<List<Country>> GetList()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetList().ToList());
        }

        [SecuredOperation("Product.List,Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(Messages.CountryUpdated);
        }

        private IResult CheckIfCountryNameExists(string countryName)
        {
            var result = _countryDal.GetList(p => p.Name == countryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CountryNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
