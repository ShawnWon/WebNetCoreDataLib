using System.Collections.Generic;
using System.Threading.Tasks;
using NetDataLibrary.Models.Account;

namespace NetDataLibrary.Data
{
    public interface IAccountData
    {
        Task<List<UserInstitutions>> GetUserInstitutions(string userGuid);
        Task<List<UserRoles>> GetUserRoles(string userguid, int instituteId);
    }
}