using Entities.Concrete;
using Infrastructure.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _imageService;
        public PhotosController(IPhotoService imageService)
        {
            _imageService = imageService;
        }
        [HttpGet("getall")]
        public async Task<DataResult<IList<Photo>>> GetAllAsync()
        {
            var result = await _imageService.GetAllAsync();
            return result;
        } 
        [HttpPost("add")]
        public async Task<Result> AddPhotoAsync(PhotoModel model)
        {
            return await _imageService.AddAsync(model);
        }
    }
}
