using DataAccess.Concrete.EntityFramework.Contexs;
using DataAccess.Interfaces;
using Infrastructure.DataAccess.EntityFramework;
using Infrastructure.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ToJpegContext>, IUserDal
    {
        public async Task<List<OperationClaim>> GetClaimsAsync(User user)
        {
            using (var context = new ToJpegContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return await Task.FromResult(result.ToList());
            }
        }
    }
}
