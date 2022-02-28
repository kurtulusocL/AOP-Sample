using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class City : IEntity
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public int CountryId { get; set; }
    }
}
