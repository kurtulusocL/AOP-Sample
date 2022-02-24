using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.CityId).NotEmpty().NotNull();
        }
    }
}
