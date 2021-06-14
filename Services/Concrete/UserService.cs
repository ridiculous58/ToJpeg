using DataAccess.Interfaces;
using Infrastructure.Aspects.Autofac.Caching;
using Infrastructure.Entities.Concrete;
using Infrastructure.Utilities.Results;
using Services.Constants;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }       
        public async Task AddAsync(User user)
        {
            await _userDal.AddAsync(user);
        }

        public async Task<DataResult<User>> GetByMailForControllerAsync(string mail)
        {
            var data =  await GetByMailAsync(mail);
            return new SuccessDataResult<User>(data, Messages.Successful);
        }

        public async Task<User> GetByMailAsync(string email)
        {
            return  await _userDal.GetAsync(x => x.Email == email);
        }

        public async Task<List<OperationClaim>> GetClaimsAsync(User user)
        {
            return await _userDal.GetClaimsAsync(user);
        }
    }
}
