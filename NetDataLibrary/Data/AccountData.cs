using NetDataLibrary.Db;
using NetDataLibrary.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetDataLibrary.Data
{
    public class AccountData : IAccountData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public AccountData(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public Task<List<UserInstitutions>> GetUserInstitutions(string userGuid)
        {
            return _dataAccess.LoadData<UserInstitutions, dynamic>("ACC_GetUserInstitutions",
                new
                {
                    UserGUID = userGuid
                },
                _connectionStringData.SqlConnectionName);



        }

        public Task<List<UserRoles>> GetUserRoles(string userguid, int instituteId)
        {
            return _dataAccess.LoadData<UserRoles, dynamic>("ACC_GetUserRoles",
                new
                {
                    UserGUID = userguid,
                    InstituteId = instituteId
                },
                _connectionStringData.SqlConnectionName
                );
        }
    }
}
