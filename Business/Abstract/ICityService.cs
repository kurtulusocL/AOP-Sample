using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<City> GetById(int cityId);
        IDataResult<List<City>> GetList();
        IDataResult<List<City>> GetListByCity(int countryId);
        IResult Add(City city);
        IResult Delete(City city);
        IResult Update(City city);
    }
}
