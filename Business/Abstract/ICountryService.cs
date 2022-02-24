using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IDataResult<Country> GetById(int countryId);
        IDataResult<List<Country>> GetList();
        IDataResult<List<Country>> GetListByCity(int cityId);
        IResult Add(Country country);
        IResult Delete(Country country);
        IResult Update(Country country);
    }
}
