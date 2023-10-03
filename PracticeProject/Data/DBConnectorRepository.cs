using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PracticeProject.Data
{
    public class DBConnectorRepository : IDBConnectorRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["EmpData"].ConnectionString;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public async Task<T> GetSingleData<T>(Dictionary<string, object> param, string storeProcedure)
        {

            using (IDbConnection con = Connection)
            {
                if(con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicparameters = new DynamicParameters();

                foreach(string paramName in param.Keys)
                {
                    object paramValue = param[paramName];
                    dynamicparameters.Add(paramName, paramValue);
                }

                var result = (await con.QueryAsync<T>(storeProcedure,dynamicparameters, commandType : CommandType.StoredProcedure)).FirstOrDefault();

                return result;

            }
        }


        public async Task<List<T>> GetDataSetFromStoredProcedure<T>(Dictionary<string,object> param, string storeProcedure)
        {
            using (IDbConnection con = Connection)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters dynamicparamert = new DynamicParameters();

                foreach(string paramName in param.Keys)
                {
                    object paramValue = param[paramName];
                    dynamicparamert.Add(paramName, paramValue);
                }

                var result = (await con.QueryAsync<T>(storeProcedure,dynamicparamert,commandType: CommandType.StoredProcedure)).ToList();
            
                return result;
            }
        }


    }
}