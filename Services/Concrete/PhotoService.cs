using DataAccess.Interfaces;
using Entities.Concrete;
using Infrastructure.Helper;
using Infrastructure.Utilities.Results;
using Services.Constants;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class PhotoService : IPhotoService
    {
        IPhotoDal _photoDal;
        public PhotoService(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }
        public async Task<Result> AddAsync(PhotoModel model)
        {
            var photo = new Photo
            {
                Name = model.Name,
                Jpeg = JpegHelper.JpegCompress(model.Photo, ParseCompressionLevel(model.CompressionLevel))
            };
            await _photoDal.AddAsync(photo);
            return new SuccessResult(Messages.AddedPhoto);
        }
        private CompressionLevel ParseCompressionLevel(string compressionLevel)
        {
            if (compressionLevel.Equals("optimal",StringComparison.OrdinalIgnoreCase))
            {
                return CompressionLevel.Optimal;
            }
            else if (compressionLevel.Equals("fastest",StringComparison.OrdinalIgnoreCase))
            {
                return CompressionLevel.Fastest;
            }
            else
            {
                return CompressionLevel.NoCompression;
            }
        }
        public async Task<DataResult<IList<Photo>>> GetAllAsync()
        {
            var data = await _photoDal.GetListAsync();
            data = data.Select(x => 
                new Photo 
                {
                    Id= x.Id,
                    Name = x.Name,Jpeg= JpegHelper.JpegDeCompress(x.Jpeg)
                }
            ).ToList();
            return new SuccessDataResult<IList<Photo>>(data,Messages.SuccessfulList);
        }
    }
}
