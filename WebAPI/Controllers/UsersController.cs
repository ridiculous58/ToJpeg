using Infrastructure.Entities.Concrete;
using Infrastructure.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getbymail")]
        public async Task<DataResult<User>> GetByMail(string mail)
        {
            return await _userService.GetByMailForControllerAsync(mail);
        }
    }
}
