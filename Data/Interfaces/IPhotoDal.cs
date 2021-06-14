using Entities.Concrete;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IPhotoDal : IEntityRepository<Photo>
    {
    }
}
