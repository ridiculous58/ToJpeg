using DataAccess.Concrete.EntityFramework.Contexs;
using DataAccess.Interfaces;
using Entities.Concrete;
using Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPhotoDal : EfEntityRepositoryBase<Photo,ToJpegContext>,IPhotoDal
    {
    }
}
