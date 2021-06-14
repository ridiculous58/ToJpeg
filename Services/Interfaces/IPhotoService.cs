using Entities.Concrete;
using Infrastructure.Utilities.Results;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPhotoService
    {
        Task<Result> AddAsync(PhotoModel model);
        Task<DataResult<IList<Photo>>> GetAllAsync();

    }
}
