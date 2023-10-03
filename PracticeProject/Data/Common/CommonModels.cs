using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeProject.Data.Common
{
    public class CommonModels
    {

        public class BaseStatus
        {
            public string Status { get; set;}
            public string Message { get; set;} 
        }

        public class ResponseModel
        {
            public class ResponseData<T> : BaseStatus
            {
                public T data;
            }
        }
    }
}