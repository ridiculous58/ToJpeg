
using Infrastructure.Entities.Concrete;
using Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<List<OperationClaim>> GetClaimsAsync(User user);
        Task AddAsync(User user);
        Task<User> GetByMailAsync(string email);


        Task<DataResult<User>> GetByMailForControllerAsync(string mail);

    }
}
