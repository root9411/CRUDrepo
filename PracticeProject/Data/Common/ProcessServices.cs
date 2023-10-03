using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static PracticeProject.Data.Common.CommonModels.ResponseModel;

namespace PracticeProject.Data.Common
{
    public class ProcessServices
    {
        private IDBConnectorRepository _repository = null;
        public ProcessServices() 
        {
            this._repository = new DBConnectorRepository();        
        }

        public string successMessage = "success";
        public string errorMessage = "failed";


        public async Task<ResponseData<List<T>>> List_of_ResponseData<T>(Dictionary<string,object> param, string procedureName) where T : new()
        {
            var response = new ResponseData<List<T>>();

            try
            {
                var data = await _repository.GetDataSetFromStoredProcedure<T>(param, procedureName);

                response.data = data;
                if(data.Count() > 0)
                {
                    response.Status = "1";
                    response.Message = successMessage;
                }
                else
                {
                    response.Status = "0";
                    response.Message = errorMessage;
                }

            }
            catch(Exception ex)
            {

            }

            return response;
        }


        public async Task<ResponseData<T>> Get_ResponseData<T>(Dictionary<string,object> param, string procedureName)where T : new()
        {
            var response = new ResponseData<T>();

            try
            {
                var data = await _repository.GetSingleData<T>(param, procedureName);

                response.data = data;
                if(data != null)
                {
                    response.Status = "1";
                    response.Message = successMessage;
                }
                else
                {
                    response.Status = "0";
                    response.Message = errorMessage;
                }
            }
            catch(Exception ex) 
            {
            
            }

            return response;
        }


    }
}