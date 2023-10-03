using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Data
{
    internal interface IDBConnectorRepository
    {

        Task<T> GetSingleData<T>(Dictionary<string, object> param, string StoredProcedure);
        Task<List<T>> GetDataSetFromStoredProcedure<T>(Dictionary<string,object> param, string StoredProcedure);

    }
}
