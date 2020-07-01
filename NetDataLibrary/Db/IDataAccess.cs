using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDataLibrary.Db
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<int> SaveData<T>(string storedprocedure, T parameter, string connectionStringName);
    }
}